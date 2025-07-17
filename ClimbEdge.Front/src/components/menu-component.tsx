import { component$, $ } from '@builder.io/qwik';
import { Link, useLocation } from '@builder.io/qwik-city';
import { useMenuContext } from '~/stores/menu';

export default component$(() => {
    const location = useLocation();
    const menuStore = useMenuContext();
    const { isCollapsed, isMobileMenuOpen } = menuStore;

    const toggleMobileMenu = $(() => {
        isMobileMenuOpen.value = !isMobileMenuOpen.value;
    });

    const toggleSidebar = $(() => {
        isCollapsed.value = !isCollapsed.value;
    });

    const navigationItems = [
        { href: '/dashboard', label: 'Dashboard', icon: 'M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2H5a2 2 0 00-2-2z' },
        { href: '/board', label: 'Board', icon: 'M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5zM4 13a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H5a1 1 0 01-1-1v-6zM16 13a1 1 0 011-1h2a1 1 0 011 1v6a1 1 0 01-1 1h-2a1 1 0 01-1-1v-6z' },
        { href: '/training', label: 'Training', icon: 'M13 10V3L4 14h7v7l9-11h-7z' },
        { href: '/mountaineering', label: 'Mountaineering', icon: 'M5 3l3.057-3 9.943 4-3.057 3L5 3zm2 4l3.057-3 9.943 4-3.057 3L7 7z' },
        { href: '/about', label: 'About', icon: 'M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z' },
        { href: '/help', label: 'Help', icon: 'M8.228 9c.549-1.165 2.03-2 3.772-2 2.21 0 4 1.343 4 3 0 1.4-1.278 2.575-3.006 2.907-.542.104-.994.54-.994 1.093m0 3h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z' }
    ];

    const quickActions = [
        { action: 'sync', label: 'Sync Routes', icon: 'M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15' },
        { action: 'session', label: 'Start Session', icon: 'M14.828 14.828a4 4 0 01-5.656 0M9 10h1.01M15 10h1.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z' }
    ];

    const isActivePath = (href: string) => {
        return location.url.pathname === href || location.url.pathname.startsWith(href + '/');
    };

    return (
        <>
            {/* Desktop Sidebar */}
            <aside class={`
                hidden md:flex flex-col fixed left-0 top-16 bottom-0 bg-slate-800 border-r border-slate-700 transition-all duration-300 z-40
                ${isCollapsed.value ? 'w-16' : 'w-64'}
            `}>
                {/* Collapse Toggle */}
                <div class="flex items-center justify-end p-3 border-b border-slate-700">
                    <button
                        onClick$={toggleSidebar}
                        class="p-2 text-slate-400 hover:text-white hover:bg-slate-700 rounded-lg transition-colors"
                        title={isCollapsed.value ? "Expand Sidebar" : "Collapse Sidebar"}
                        aria-label={isCollapsed.value ? "Expand Sidebar" : "Collapse Sidebar"}
                    >
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={isCollapsed.value ? "M9 5l7 7-7 7" : "M15 19l-7-7 7-7"} />
                        </svg>
                    </button>
                </div>

                {/* Navigation Items */}
                <nav class="flex-1 px-3 py-4 space-y-2 overflow-y-auto">
                    {navigationItems.map((item) => (
                        <Link
                            key={item.href}
                            href={item.href}
                            class={`
                                group flex items-center px-3 py-3 text-sm font-medium rounded-lg transition-all duration-200
                                ${isActivePath(item.href)
                                    ? 'bg-emerald-600 text-white shadow-lg shadow-emerald-600/25'
                                    : 'text-slate-300 hover:text-white hover:bg-slate-700'
                                }
                            `}
                            title={isCollapsed.value ? item.label : undefined}
                        >
                            <svg class="w-5 h-5 flex-shrink-0" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={item.icon} />
                            </svg>
                            {!isCollapsed.value && (
                                <span class="ml-3 truncate">{item.label}</span>
                            )}
                        </Link>
                    ))}
                </nav>

                {/* Quick Actions Section */}
                <div class="border-t border-slate-700 p-3">
                    {!isCollapsed.value && (
                        <h3 class="text-xs font-semibold text-slate-400 uppercase tracking-wider mb-3">
                            Quick Actions
                        </h3>
                    )}
                    <div class="space-y-2">
                        {quickActions.map((action) => (
                            <button
                                key={action.action}
                                class="w-full flex items-center px-3 py-2 text-sm text-slate-400 hover:text-emerald-400 hover:bg-slate-700 rounded-lg transition-colors"
                                title={action.label}
                                aria-label={action.label}
                            >
                                <svg class="w-4 h-4 flex-shrink-0" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={action.icon} />
                                </svg>
                                {!isCollapsed.value && (
                                    <span class="ml-3 truncate">{action.label}</span>
                                )}
                            </button>
                        ))}
                    </div>
                </div>

                {/* Status Indicator */}
                <div class="border-t border-slate-700 p-3">
                    <div class={`flex items-center ${isCollapsed.value ? 'justify-center' : 'space-x-2'}`}>
                        <div class="w-2 h-2 bg-emerald-400 rounded-full animate-pulse"></div>
                        {!isCollapsed.value && (
                            <span class="text-xs text-slate-400">Board Connected</span>
                        )}
                    </div>
                </div>
            </aside>

            {/* Mobile Navigation */}
            <div class="md:hidden">
                {/* Mobile Header Bar */}
                <div class="fixed top-16 left-0 right-0 bg-slate-800 border-b border-slate-700 z-50">
                    <div class="flex items-center justify-between px-4 py-3">
                        <div class="flex items-center space-x-2">
                            <div class="w-2 h-2 bg-emerald-400 rounded-full animate-pulse"></div>
                            <span class="text-sm text-slate-300">Board Connected</span>
                        </div>
                        <button
                            onClick$={toggleMobileMenu}
                            class="p-2 text-slate-400 hover:text-white hover:bg-slate-700 rounded-lg transition-colors"
                            title="Toggle navigation menu"
                            aria-label="Toggle navigation menu"
                            aria-expanded={isMobileMenuOpen.value}
                        >
                            <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                {isMobileMenuOpen.value ? (
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                                ) : (
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                                )}
                            </svg>
                        </button>
                    </div>
                </div>

                {/* Mobile Menu Overlay */}
                {isMobileMenuOpen.value && (
                    <>
                        <div
                            class="fixed inset-0 bg-black bg-opacity-50 z-40"
                            onClick$={toggleMobileMenu}
                        ></div>
                        <div class="fixed top-28 left-0 right-0 bottom-0 bg-slate-800 z-50 overflow-y-auto">
                            <div class="px-4 py-4 space-y-2">
                                {/* Navigation Items */}
                                {navigationItems.map((item) => (
                                    <Link
                                        key={item.href}
                                        href={item.href}
                                        onClick$={() => isMobileMenuOpen.value = false}
                                        class={`
                                            flex items-center px-4 py-3 rounded-lg text-base font-medium transition-all duration-200
                                            ${isActivePath(item.href)
                                                ? 'bg-emerald-600 text-white'
                                                : 'text-slate-300 hover:text-white hover:bg-slate-700'
                                            }
                                        `}
                                    >
                                        <svg class="w-5 h-5 mr-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={item.icon} />
                                        </svg>
                                        {item.label}
                                    </Link>
                                ))}

                                {/* Quick Actions */}
                                <div class="pt-4 mt-4 border-t border-slate-700">
                                    <h3 class="text-sm font-semibold text-slate-400 mb-3">Quick Actions</h3>
                                    {quickActions.map((action) => (
                                        <button
                                            key={action.action}
                                            onClick$={() => isMobileMenuOpen.value = false}
                                            class="w-full flex items-center px-4 py-3 text-base text-slate-300 hover:text-emerald-400 hover:bg-slate-700 rounded-lg transition-colors"
                                        >
                                            <svg class="w-5 h-5 mr-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={action.icon} />
                                            </svg>
                                            {action.label}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        </div>
                    </>
                )}
            </div>
        </>
    );
});