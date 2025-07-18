import { component$, useSignal, $, useTask$ } from '@builder.io/qwik';
import { Link, useLocation } from '@builder.io/qwik-city';
import { useAuth } from '~/contexts/auth.context';
import { authService } from '~/services/auth.service';

export default component$(() => {
    const { user, isAuthenticated, clearAuth } = useAuth();
    const isUserMenuOpen = useSignal(false);
    const isNotificationOpen = useSignal(false);
    const notificationCount = useSignal(3); // Simulated notification count
    const isSyncing = useSignal(false);
    const loc = useLocation();

    const toggleUserMenu = $(() => {
        isUserMenuOpen.value = !isUserMenuOpen.value;
        if (isUserMenuOpen.value) {
            isNotificationOpen.value = false;
        }
    });

    const toggleNotifications = $(() => {
        isNotificationOpen.value = !isNotificationOpen.value;
        if (isNotificationOpen.value) {
            isUserMenuOpen.value = false;
        }
    });

    const handleSync = $(async () => {
        if (isSyncing.value) return; // Evitar múltiples clicks

        isSyncing.value = true;
        console.log('Syncing routes with board...');

        try {
            // Simular una llamada a API para sincronizar
            await new Promise(resolve => setTimeout(resolve, 2000));

            console.log('Sync completed successfully');

            // Simular que hay nuevas notificaciones después del sync
            notificationCount.value = notificationCount.value + 1;

        } catch (error) {
            console.error('Error during sync:', error);
        } finally {
            isSyncing.value = false;
        }
    });

    const closeMenus = $(() => {
        setTimeout(() => {
            isUserMenuOpen.value = false;
            isNotificationOpen.value = false;
        }, 0);
    });
    useTask$(async ({ track }) => {
        track(() => loc.url.pathname);
        await closeMenus();
    });

    const handleMarkAllAsRead = $(() => {
        // Marcar todas las notificaciones como leídas
        notificationCount.value = 0;
        closeMenus();
        console.log('All notifications marked as read');
    });

    const handleNotificationClick = $((notificationId: string) => {
        // Manejar clic en notificación individual
        console.log('Notification clicked:', notificationId);
        // Aquí podrías implementar navegación o acciones específicas
        // Por ejemplo: navigate('/route/crimson-edge') para la primera notificación
    });

    const handleLogout = $(async () => {
        try {
            await authService.logout();
            clearAuth();
            closeMenus();
            // Redirigir al login podría manejarse aquí si es necesario
        } catch (error) {
            console.error('Error al cerrar sesión:', error);
            // Limpiar auth localmente aunque falle la API
            clearAuth();
            closeMenus();
        }
    });

    return (
        <header class="fixed top-0 left-0 right-0 bg-gradient-to-r from-slate-900 via-slate-800 to-slate-900 shadow-xl border-b border-slate-700 z-50">
            <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                <div class="flex justify-between items-center h-16">
                    {/* Logo and Brand */}
                    <div class="flex items-center space-x-3">
                        <Link href="/" class="flex items-center space-x-3 hover:opacity-80 transition-opacity">
                            <div class="w-10 h-10 bg-gradient-to-br from-emerald-400 to-cyan-500 rounded-lg flex items-center justify-center shadow-lg">
                                <svg class="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M12 2L14.09 8.26L20 9L15 14L16.18 20L12 17.27L7.82 20L9 14L4 9L9.91 8.26L12 2Z" />
                                </svg>
                            </div>
                            <div class="flex flex-col">
                                <h1 class="text-xl font-bold text-white">ClimbEdge</h1>
                                <span class="text-xs text-slate-400 -mt-1">Smart Climbing</span>
                            </div>
                        </Link>
                    </div>

                    {/* Status Indicator */}
                    <div class="hidden md:flex items-center space-x-4">
                        <div class="flex items-center space-x-2 bg-slate-800 rounded-full px-3 py-1">
                            <div class="w-2 h-2 bg-emerald-400 rounded-full animate-pulse"></div>
                            <span class="text-sm text-slate-300">Board Connected</span>
                        </div>

                        {/* User Menu */}
                        <div class="flex items-center space-x-3 relative">
                            {/* Sync/Download Button */}
                            <button
                                onClick$={handleSync}
                                disabled={isSyncing.value}
                                class={`p-2 hover:text-white hover:bg-slate-700 rounded-lg transition-colors ${isSyncing.value ? 'text-emerald-400 animate-spin' : 'text-slate-400'
                                    }`}
                                title={isSyncing.value ? "Syncing..." : "Sync Routes"}
                                aria-label="Sync routes with board"
                            >
                                <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4" />
                                </svg>
                            </button>

                            {/* Notifications Button */}
                            <div class="relative">
                                <button
                                    onClick$={toggleNotifications}
                                    class={`p-2 hover:text-white hover:bg-slate-700 rounded-lg transition-colors relative ${isNotificationOpen.value ? 'text-emerald-400 bg-slate-700' : 'text-slate-400'
                                        }`}
                                    title="Notifications"
                                    aria-label="View notifications"
                                >
                                    <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 17h5l-5 5-5-5h5v-12" />
                                    </svg>
                                    {notificationCount.value > 0 && (
                                        <span class="absolute -top-1 -right-1 bg-red-500 text-white text-xs rounded-full w-5 h-5 flex items-center justify-center animate-pulse">
                                            {notificationCount.value}
                                        </span>
                                    )}
                                </button>

                                {/* Notifications Dropdown */}
                                {isNotificationOpen.value && (
                                    <div class="absolute right-0 mt-2 w-80 bg-slate-800 rounded-lg shadow-xl border border-slate-700 z-50">
                                        <div class="p-4 border-b border-slate-700">
                                            <h3 class="text-white font-semibold">Notifications</h3>
                                        </div>
                                        <div class="max-h-64 overflow-y-auto">
                                            <div
                                                class="p-3 hover:bg-slate-700 border-b border-slate-700 cursor-pointer transition-colors"
                                                onClick$={() => handleNotificationClick('route-upload-1')}
                                            >
                                                <div class="flex items-center space-x-3">
                                                    <div class="w-2 h-2 bg-emerald-400 rounded-full"></div>
                                                    <div class="flex-1">
                                                        <p class="text-sm text-white">New route uploaded</p>
                                                        <p class="text-xs text-slate-400">V8 "Crimson Edge" added to board</p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div
                                                class="p-3 hover:bg-slate-700 border-b border-slate-700 cursor-pointer transition-colors"
                                                onClick$={() => handleNotificationClick('training-session-1')}
                                            >
                                                <div class="flex items-center space-x-3">
                                                    <div class="w-2 h-2 bg-cyan-400 rounded-full"></div>
                                                    <div class="flex-1">
                                                        <p class="text-sm text-white">Training session completed</p>
                                                        <p class="text-xs text-slate-400">45 minutes, 12 problems solved</p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div
                                                class="p-3 hover:bg-slate-700 cursor-pointer transition-colors"
                                                onClick$={() => handleNotificationClick('system-update-1')}
                                            >
                                                <div class="flex items-center space-x-3">
                                                    <div class="w-2 h-2 bg-yellow-400 rounded-full"></div>
                                                    <div class="flex-1">
                                                        <p class="text-sm text-white">System update available</p>
                                                        <p class="text-xs text-slate-400">Version 2.1.0 with new features</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="p-3 border-t border-slate-700">
                                            <button
                                                onClick$={handleMarkAllAsRead}
                                                class="w-full text-sm text-emerald-400 hover:text-emerald-300 transition-colors"
                                            >
                                                Mark all as read
                                            </button>
                                        </div>
                                    </div>
                                )}
                            </div>

                            {/* User Profile Button */}
                            <div class="relative">
                                <button
                                    onClick$={toggleUserMenu}
                                    class={`p-2 hover:text-white hover:bg-slate-700 rounded-lg transition-colors ${isUserMenuOpen.value ? 'text-emerald-400 bg-slate-700' : 'text-slate-400'
                                        }`}
                                    title="User Profile"
                                    aria-label="Open user menu"
                                >
                                    <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                                    </svg>
                                </button>

                                {/* User Menu Dropdown */}
                                {isUserMenuOpen.value && (
                                    <div class="absolute right-0 mt-2 w-64 bg-slate-800 rounded-lg shadow-xl border border-slate-700 z-50">
                                        {/* User Info */}
                                        <div class="p-4 border-b border-slate-700">
                                            {isAuthenticated.value ? (
                                                <div class="flex items-center space-x-3">
                                                    <div class="w-10 h-10 bg-gradient-to-br from-emerald-400 to-cyan-500 rounded-full flex items-center justify-center">
                                                        <span class="text-sm font-bold text-white">
                                                            {user.value?.firstName?.[0] || user.value?.email?.[0] || 'U'}
                                                        </span>
                                                    </div>
                                                    <div>
                                                        <p class="text-white font-medium">
                                                            {user.value?.firstName} {user.value?.lastName || 'Climber'}
                                                        </p>
                                                        <p class="text-sm text-slate-400">
                                                            {user.value?.email}
                                                        </p>
                                                    </div>
                                                </div>
                                            ) : (
                                                <div class="flex items-center space-x-3">
                                                    <div class="w-10 h-10 bg-slate-600 rounded-full flex items-center justify-center">
                                                        <span class="text-sm font-bold text-white">?</span>
                                                    </div>
                                                    <div>
                                                        <p class="text-white font-medium">Usuario Invitado</p>
                                                        <p class="text-sm text-slate-400">No autenticado</p>
                                                    </div>
                                                </div>
                                            )}
                                        </div>

                                        {/* Menu Items */}
                                        <div class="py-2">
                                            {isAuthenticated.value ? (
                                                <>
                                                    <Link
                                                        href="/profile"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                                                        </svg>
                                                        Mi Perfil
                                                    </Link>
                                                    <Link
                                                        href="/change-password"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 7a3 3 0 013 3v1.5a3 3 0 11-6 0V10a3 3 0 013-3z" />
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 20a3 3 0 01-3-3v-1.5a3 3 0 11-6 0V16a3 3 0 013-3z" />
                                                        </svg>
                                                        Cambiar Contraseña
                                                    </Link>
                                                    <Link
                                                        href="/stats"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                                                        </svg>
                                                        Estadísticas
                                                    </Link>
                                                    <Link
                                                        href="/settings"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10.325 4.317c.426-1.756 2.924-1.756 3.35 0a1.724 1.724 0 002.573 1.066c1.543-.94 3.31.826 2.37 2.37a1.724 1.724 0 001.065 2.572c1.756.426 1.756 2.924 0 3.35a1.724 1.724 0 00-1.066 2.573c.94 1.543-.826 3.31-2.37 2.37a1.724 1.724 0 00-2.572 1.065c-.426 1.756-2.924 1.756-3.35 0a1.724 1.724 0 00-2.573-1.066c-1.543.94-3.31-.826-2.37-2.37a1.724 1.724 0 00-1.065-2.572c-1.756-.426-1.756-2.924 0-3.35a1.724 1.724 0 001.066-2.573c-.94-1.543.826-3.31 2.37-2.37.996.608 2.296.07 2.572-1.065z" />
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                                        </svg>
                                                        Configuración
                                                    </Link>
                                                </>
                                            ) : (
                                                <>
                                                    <Link
                                                        href="/login"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 16l-4-4m0 0l4-4m-4 4h14m-5 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h7a3 3 0 013 3v1" />
                                                        </svg>
                                                        Iniciar Sesión
                                                    </Link>
                                                    <Link
                                                        href="/register"
                                                        class="flex items-center px-4 py-2 text-sm text-slate-300 hover:text-white hover:bg-slate-700"
                                                    >
                                                        <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z" />
                                                        </svg>
                                                        Registrarse
                                                    </Link>
                                                </>
                                            )}
                                        </div>

                                        {/* Logout */}
                                        {isAuthenticated.value && (
                                            <div class="border-t border-slate-700 py-2">
                                                <button
                                                    onClick$={handleLogout}
                                                    class="flex items-center w-full px-4 py-2 text-sm text-red-400 hover:text-red-300 hover:bg-slate-700"
                                                >
                                                    <svg class="w-4 h-4 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1" />
                                                    </svg>
                                                    Cerrar Sesión
                                                </button>
                                            </div>
                                        )}
                                    </div>
                                )}
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Overlay to close menus when clicking outside */}
            {(isUserMenuOpen.value || isNotificationOpen.value) && (
                <div
                    class="fixed inset-0 z-40"
                    onClick$={closeMenus}
                ></div>
            )}
        </header>
    );
});