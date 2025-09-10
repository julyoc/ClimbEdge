import { component$, Slot, useContextProvider } from '@builder.io/qwik';
import { useLocation } from '@builder.io/qwik-city';
import FooterComponent from '~/components/footer-component';
import HeaderComponent from '~/components/header-component';
import MenuComponent from '~/components/menu-component';
import { MenuContext, useMenuStore } from '~/stores/menu';
import { AuthContext, useAuthStore, useAuth } from '~/contexts/auth.context';
import { ThemeContext, useThemeStore } from '~/stores/theme';
import { useAuthCheck } from '~/hooks/use-auth-check';
import DebugAuth from '~/components/debug-auth';

export default component$(() => {
    const menuStore = useMenuStore();
    const authStore = useAuthStore();
    const themeStore = useThemeStore();
    const location = useLocation();

    useContextProvider(MenuContext, menuStore);
    useContextProvider(AuthContext, authStore);
    useContextProvider(ThemeContext, themeStore);

    // Verificar autenticación al cargar
    useAuthCheck();

    // Usar el hook de autenticación para verificar el estado
    const { isAuthenticated } = useAuth();

    // Detectar si estamos en la página principal y no autenticado
    const isLandingPage = location.url.pathname === '/' && !isAuthenticated.value;

    // Si es la página principal y no está autenticado, usar layout simplificado
    if (isLandingPage) {
        return (
            <div class="min-h-screen bg-white dark:bg-gray-900 transition-colors duration-300">
                <Slot /> {/* <== This is where the route will be inserted */}
            </div>
        );
    }

    // Layout normal para usuarios autenticados o páginas internas
    return (
        <div class="min-h-screen bg-slate-50 dark:bg-gray-900 transition-colors duration-300">
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