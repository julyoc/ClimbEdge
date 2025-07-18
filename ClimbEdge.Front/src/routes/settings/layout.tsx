import { component$, Slot, useSignal, $ } from '@builder.io/qwik';
import { Link, useLocation } from '@builder.io/qwik-city';

export default component$(() => {
    const location = useLocation();
    const isMobileMenuOpen = useSignal(false);

    const toggleMobileMenu = $(() => {
        isMobileMenuOpen.value = !isMobileMenuOpen.value;
    });

    const settingsNavItems = [
        {
            path: '/settings/profile',
            label: 'Perfil Personal',
            icon: 'M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z'
        },
        {
            path: '/settings/privacy',
            label: 'Privacidad',
            icon: 'M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z'
        },
        {
            path: '/settings/notifications',
            label: 'Notificaciones',
            icon: 'M15 17h5l-5-5v5zM10.67 5H14v2h-3.33l2.08 2.08L11.33 10.5 8 7.17V10H6V5h4.67z'
        },
        {
            path: '/settings/regional',
            label: 'Regional',
            icon: 'M3.055 11H5a2 2 0 012 2v1a2 2 0 002 2 2 2 0 012 2v2.945M8 3.935V5.5A2.5 2.5 0 0010.5 8h.5a2 2 0 012 2 2 2 0 104 0 2 2 0 012-2h1.064M15 20.488V18a2 2 0 012-2h3.064'
        },
        {
            path: '/settings/security',
            label: 'Seguridad',
            icon: 'M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z'
        },
        {
            path: '/settings/app',
            label: 'Aplicación',
            icon: 'M10.325 4.317c.426-1.756 2.924-1.756 3.35 0a1.724 1.724 0 002.573 1.066c1.543-.94 3.31.826 2.37 2.37a1.724 1.724 0 001.065 2.572c1.756.426 1.756 2.924 0 3.35a1.724 1.724 0 00-1.066 2.573c.94 1.543-.826 3.31-2.37 2.37a1.724 1.724 0 00-2.572 1.065c-.426 1.756-2.924 1.756-3.35 0a1.724 1.724 0 00-2.573-1.066c-1.543.94-3.31-.826-2.37-2.37a1.724 1.724 0 00-1.065-2.572c-1.756-.426-1.756-2.924 0-3.35a1.724 1.724 0 001.066-2.573c-.94-1.543.826-3.31 2.37-2.37.996.608 2.296.07 2.572-1.065z'
        },
        {
            path: '/settings/account',
            label: 'Cuenta',
            icon: 'M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z'
        }
    ];

    const isActivePath = (path: string) => {
        return location.url.pathname === path || 
               (location.url.pathname === '/settings/' && path === '/settings/profile');
    };

    return (
        <div class="min-h-screen bg-slate-50">
            <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
                {/* Header */}
                <div class="mb-8">
                    <div class="flex items-center justify-between">
                        <div>
                            <h1 class="text-3xl font-bold text-gray-900">Configuración</h1>
                            <p class="mt-2 text-gray-600">
                                Gestiona tu cuenta y preferencias de ClimbEdge
                            </p>
                        </div>
                        <div class="md:hidden">
                            <button
                                onClick$={toggleMobileMenu}
                                class="p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100"
                            >
                                <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                                </svg>
                            </button>
                        </div>
                    </div>
                </div>

                <div class="flex flex-col md:flex-row gap-8">
                    {/* Navigation Sidebar */}
                    <div class={`md:w-64 flex-shrink-0 ${isMobileMenuOpen.value ? 'block' : 'hidden md:block'}`}>
                        <nav class="bg-white rounded-lg shadow-sm border border-gray-200 p-4">
                            <ul class="space-y-2">
                                {settingsNavItems.map((item) => (
                                    <li key={item.path}>
                                        <Link
                                            href={item.path}
                                            class={`
                                                flex items-center space-x-3 px-3 py-2 rounded-md text-sm font-medium transition-colors
                                                ${isActivePath(item.path) 
                                                    ? 'bg-blue-50 text-blue-700 border-r-2 border-blue-500' 
                                                    : 'text-gray-600 hover:text-gray-900 hover:bg-gray-50'
                                                }
                                            `}
                                        >
                                            <svg 
                                                class="h-5 w-5 flex-shrink-0" 
                                                fill="none" 
                                                viewBox="0 0 24 24" 
                                                stroke="currentColor"
                                            >
                                                <path 
                                                    stroke-linecap="round" 
                                                    stroke-linejoin="round" 
                                                    stroke-width="2" 
                                                    d={item.icon} 
                                                />
                                            </svg>
                                            <span>{item.label}</span>
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        </nav>
                    </div>

                    {/* Main Content */}
                    <div class="flex-1 min-w-0">
                        <div class="bg-white rounded-lg shadow-sm border border-gray-200">
                            <Slot />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
});
