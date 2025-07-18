import { component$, Slot, useContextProvider } from '@builder.io/qwik';
import FooterComponent from '~/components/footer-component';
import HeaderComponent from '~/components/header-component';
import MenuComponent from '~/components/menu-component';
import { MenuContext, useMenuStore } from '~/stores/menu';
import { AuthContext, useAuthStore, useAuth } from '~/contexts/auth.context';
import { useAuthCheck } from '~/hooks/use-auth-check';
import DebugAuth from '~/components/debug-auth';

export default component$(() => {
    const menuStore = useMenuStore();
    const authStore = useAuthStore();

    useContextProvider(MenuContext, menuStore);
    useContextProvider(AuthContext, authStore);

    // Verificar autenticación al cargar
    useAuthCheck();

    // Usar el hook de autenticación para verificar el estado
    const { isAuthenticated } = useAuth();

    return (
        <div class="min-h-screen bg-slate-50">
            <HeaderComponent />
            {isAuthenticated.value && <MenuComponent />}

            {/* Main Content Area */}
            <main class={`
                transition-all duration-300 pt-16 min-h-screen
                ${isAuthenticated.value && menuStore.isCollapsed.value ? 'md:ml-16' : isAuthenticated.value ? 'md:ml-64' : ''}
            `}>
                <Slot /> {/* <== This is where the route will be inserted */}
            </main>

            <FooterComponent />
            {/* Debug Auth Component */}
            { isAuthenticated.value && <DebugAuth />}
        </div>
    );
});