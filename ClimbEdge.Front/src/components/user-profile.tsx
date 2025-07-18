import { component$, useSignal, $ } from '@builder.io/qwik';
import { useNavigate } from '@builder.io/qwik-city';
import { useAuth } from '~/contexts/auth.context';
import { authService } from '~/services/auth.service';

export default component$(() => {
    const navigate = useNavigate();
    const { user, isAuthenticated, clearAuth } = useAuth();
    const isMenuOpen = useSignal(false);

    const handleLogout = $(async () => {
        try {
            await authService.logout();
            clearAuth();
            navigate('/login');
        } catch (error) {
            console.error('Error al cerrar sesión:', error);
            // Limpiar auth localmente aunque falle la API
            clearAuth();
            navigate('/login');
        }
    });

    const toggleMenu = $(() => {
        isMenuOpen.value = !isMenuOpen.value;
    });

    if (!isAuthenticated.value) {
        return (
            <div class="flex items-center space-x-2">
                <a
                    href="/login"
                    class="text-gray-700 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
                >
                    Iniciar Sesión
                </a>
                <a
                    href="/register"
                    class="bg-blue-600 text-white hover:bg-blue-700 px-3 py-2 rounded-md text-sm font-medium"
                >
                    Registrarse
                </a>
            </div>
        );
    }

    return (
        <div class="relative">
            <button
                onClick$={toggleMenu}
                class="flex items-center space-x-2 text-gray-700 hover:text-blue-600 px-3 py-2 rounded-md text-sm font-medium"
            >
                <div class="w-8 h-8 bg-blue-600 rounded-full flex items-center justify-center">
                    <span class="text-white text-xs font-medium">
                        {user.value?.firstName?.[0] || user.value?.email?.[0] || 'U'}
                    </span>
                </div>
                <span class="hidden md:block">
                    {user.value?.firstName || user.value?.email || 'Usuario'}
                </span>
                <svg
                    class="w-4 h-4 ml-1"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                >
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M19 9l-7 7-7-7"
                    />
                </svg>
            </button>

            {isMenuOpen.value && (
                <div class="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg py-1 z-50">
                    <div class="px-4 py-2 text-sm text-gray-700 border-b">
                        <div class="font-medium">
                            {user.value?.firstName} {user.value?.lastName}
                        </div>
                        <div class="text-gray-500 text-xs">
                            {user.value?.email}
                        </div>
                    </div>

                    <a
                        href="/profile"
                        class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100"
                    >
                        Mi Perfil
                    </a>

                    <a
                        href="/change-password"
                        class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100"
                    >
                        Cambiar Contraseña
                    </a>

                    <button
                        onClick$={handleLogout}
                        class="block w-full text-left px-4 py-2 text-sm text-gray-700 hover:bg-gray-100"
                    >
                        Cerrar Sesión
                    </button>
                </div>
            )}
        </div>
    );
});
