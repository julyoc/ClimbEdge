import { component$, Slot, useVisibleTask$, JSXChildren, createContextId, useContext, useContextProvider, useSignal, $, type Signal } from "@builder.io/qwik";
import { useNavigate, useLocation } from "@builder.io/qwik-city";
import { useAuth } from "~/contexts/auth.context";
import { hasAnyRole, Role } from "~/utils/rolesConst";

interface AuthComponentProps {
    children?: JSXChildren;
}

interface AuthAnonimusProps {
    children?: JSXChildren;
}

interface AuthProps {
    children?: JSXChildren;
}

interface AuthWithRoleProps {
    roles: Role[];
    children?: JSXChildren;
}

// Context para asegurar que los sub-componentes estén dentro de AuthComponent
interface AuthContainerContext {
    isInAuthComponent: boolean;
    hasAuthAnonimus: Signal<boolean>; // Cambiar a Signal
    setHasAuthAnonimus: (value: boolean) => void;
}

const AuthContainerContextId = createContextId<AuthContainerContext>('auth-container');

/**
 * AuthComponent - Componente contenedor OBLIGATORIO para manejar autenticación
 */
export const AuthComponent = component$<AuthComponentProps>(() => {
    const hasAuthAnonimus = useSignal(false);
    const location = useLocation();
    
    // Resetear hasAuthAnonimus cuando cambia la ruta
    useVisibleTask$(({ track }) => {
        track(() => location.url.pathname);
        hasAuthAnonimus.value = false;
        console.log('AuthComponent - Ruta cambiada, reseteando hasAuthAnonimus:', location.url.pathname);
    });
    
    const setHasAuthAnonimus = $((value: boolean) => {
        console.log('AuthComponent - setHasAuthAnonimus:', value);
        hasAuthAnonimus.value = value;
    });
    
    // Proveer el contexto que indica que estamos dentro de AuthComponent
    useContextProvider(AuthContainerContextId, { 
        isInAuthComponent: true,
        hasAuthAnonimus: hasAuthAnonimus,
        setHasAuthAnonimus
    });
    
    return <Slot />;
});

/**
 * AuthAnonimus - Para contenido de usuarios anónimos/no autenticados
 */
export const AuthAnonimus = component$<AuthAnonimusProps>(() => {
    const authContainer = useContext(AuthContainerContextId);
    if (!authContainer?.isInAuthComponent) {
        throw new Error('AuthAnonimus debe estar dentro de un AuthComponent');
    }

    // Registrar que existe un AuthAnonimus INMEDIATAMENTE
    useVisibleTask$(() => {
        console.log('AuthAnonimus - Registrando presencia');
        authContainer.setHasAuthAnonimus(true);
        
        // Cleanup cuando el componente se desmonta
        return () => {
            console.log('AuthAnonimus - Cleanup, removiendo presencia');
            authContainer.setHasAuthAnonimus(false);
        };
    });

    const { isAnonymous } = useAuth();
    
    // Solo renderizar si es anónimo (no autenticado)
    if (isAnonymous.value) {
        return <Slot />;
    }
    
    return null;
});

/**
 * Auth - Para contenido de usuarios autenticados
 */
export const Auth = component$<AuthProps>(() => {
    const authContainer = useContext(AuthContainerContextId);
    if (!authContainer?.isInAuthComponent) {
        throw new Error('Auth debe estar dentro de un AuthComponent');
    }

    const { isAuthenticated, isAnonymous } = useAuth();
    const nav = useNavigate();

    useVisibleTask$(async ({ track }) => {
        track(() => isAuthenticated.value);
        track(() => isAnonymous.value);
        track(() => authContainer.hasAuthAnonimus.value);

        // Delay para permitir que AuthAnonimus se registre si existe
        await new Promise(resolve => setTimeout(resolve, 250));
        
        console.log('Auth - Verificando condiciones:');
        console.log('  - isAuthenticated:', isAuthenticated.value);
        console.log('  - isAnonymous:', isAnonymous.value);
        console.log('  - hasAuthAnonimus:', authContainer.hasAuthAnonimus.value);
        
        // Solo redirigir si NO está autenticado Y NO hay AuthAnonimus presente
        if (!isAuthenticated.value && !authContainer.hasAuthAnonimus.value) {
            console.warn('Auth - Redirigiendo a /login');
            nav('/login');
        } else {
            console.log('Auth - No redirigiendo, condiciones no cumplidas');
        }
    });
    
    // Solo renderizar si está autenticado Y NO es anónimo
    if (isAuthenticated.value && !isAnonymous.value) {
        return <Slot />;
    }
    
    return null;
});

/**
 * AuthWithRole - Para contenido basado en roles específicos
 */
export const AuthWithRole = component$<AuthWithRoleProps>(({ roles }) => {
    const authContainer = useContext(AuthContainerContextId);
    if (!authContainer?.isInAuthComponent) {
        throw new Error('AuthWithRole debe estar dentro de un AuthComponent');
    }

    const { user, isAuthenticated, isAnonymous } = useAuth();
    const nav = useNavigate();

    useVisibleTask$(async ({ track }) => {
        track(() => isAuthenticated.value);
        track(() => isAnonymous.value);
        track(() => user.value);
        track(() => authContainer.hasAuthAnonimus.value);

        // Delay para permitir que AuthAnonimus se registre si existe
        await new Promise(resolve => setTimeout(resolve, 250));
        
        console.log('AuthWithRole - Verificando condiciones:');
        console.log('  - isAuthenticated:', isAuthenticated.value);
        console.log('  - isAnonymous:', isAnonymous.value);
        console.log('  - hasAuthAnonimus:', authContainer.hasAuthAnonimus.value);
        
        // Solo redirigir a login si NO está autenticado Y NO hay AuthAnonimus presente
        if (!isAuthenticated.value && !authContainer.hasAuthAnonimus.value) {
            console.warn('AuthWithRole - Redirigiendo a /login');
            nav('/login');
            return;
        }
        
        // Si está autenticado pero no tiene los roles necesarios
        if (isAuthenticated.value && !isAnonymous.value && user.value) {
            const userRoles = user.value.roles || [];
            const hasRequiredRole = hasAnyRole(userRoles, roles);
            if (!hasRequiredRole) {
                console.warn('AuthWithRole - Redirigiendo a /unauthorized');
                nav('/unauthorized');
            }
        }
    });

    // Verificar si debe renderizar contenido
    if (isAuthenticated.value && !isAnonymous.value && user.value) {
        const userRoles = user.value.roles || [];
        const hasRequiredRole = hasAnyRole(userRoles, roles);
        if (hasRequiredRole) {
            return <Slot />;
        }
    }
    
    return null;
});
