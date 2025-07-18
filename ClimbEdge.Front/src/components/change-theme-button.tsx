import { component$, useSignal, $ } from "@builder.io/qwik";
import { useTheme } from "~/stores/theme";
import type { Theme } from "~/stores/theme";

export const ChangeThemeButton = component$(() => {
    const themeStore = useTheme();
    const isDropdownOpen = useSignal(false);

    const toggleDropdown = $(() => {
        isDropdownOpen.value = !isDropdownOpen.value;
    });

    const selectTheme = $((theme: Theme) => {
        if (typeof window !== "undefined") {
            const html = document.documentElement;

            if (theme === "system") {
                localStorage.removeItem("theme");
                const systemDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
                themeStore.isDark.value = systemDark;
                html.classList.toggle("dark", systemDark);
            } else {
                localStorage.setItem("theme", theme);
                themeStore.isDark.value = theme === "dark";
                html.classList.toggle("dark", theme === "dark");
            }
        }

        themeStore.theme.value = theme;
        isDropdownOpen.value = false;
    });

    const themes = [
        { value: "light" as const, label: "Light", icon: "☀️" },
        { value: "dark" as const, label: "Dark", icon: "🌙" },
        { value: "system" as const, label: "System", icon: "💻" },
    ];

    const currentTheme = themes.find(t => t.value === themeStore.theme.value) || themes[2];

    return (
        <div class="relative inline-block text-left">
            <button
                onClick$={toggleDropdown}
                class="group relative inline-flex items-center justify-center rounded-xl px-4 py-2.5 text-sm font-medium transition-all duration-300 ease-out bg-gradient-to-r from-slate-50 to-slate-100 dark:from-slate-800 dark:to-slate-700 text-slate-700 dark:text-slate-200 border border-slate-200 dark:border-slate-600 hover:border-slate-300 dark:hover:border-slate-500 hover:shadow-lg hover:shadow-slate-200/50 dark:hover:shadow-slate-900/30 hover:scale-105 focus:outline-none focus:ring-2 focus:ring-blue-500/50 focus:ring-offset-2 focus:ring-offset-white dark:focus:ring-offset-slate-800 backdrop-blur-sm"
                title={`Current theme: ${currentTheme.label}`}
            >
                {/* Background glow effect */}
                <div class="absolute inset-0 rounded-xl bg-gradient-to-r from-blue-500/10 to-purple-500/10 opacity-0 group-hover:opacity-100 transition-opacity duration-300"></div>
                
                {/* Content */}
                <span class="relative z-10 mr-2 text-lg transition-transform duration-300 group-hover:scale-110">{currentTheme.icon}</span>
                <span class="relative z-10 font-semibold">{currentTheme.label}</span>
                <svg
                    class={`relative z-10 ml-2 h-4 w-4 transition-all duration-300 group-hover:text-blue-500 ${isDropdownOpen.value ? "rotate-180 text-blue-500" : ""
                        }`}
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    stroke-width="2.5"
                >
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M19 9l-7 7-7-7"
                    />
                </svg>
            </button>

            {isDropdownOpen.value && (
                <>
                    {/* Backdrop overlay */}
                    <div 
                        class="fixed inset-0 z-40" 
                        onClick$={toggleDropdown}
                    ></div>
                    
                    {/* Dropdown menu */}
                    <div class="absolute right-0 z-50 mt-3 w-56 origin-top-right transform transition-all duration-200 ease-out">
                        <div class="rounded-2xl shadow-2xl ring-1 ring-black/5 backdrop-blur-xl bg-white/90 dark:bg-slate-800/90 border border-slate-200/50 dark:border-slate-700/50">
                            <div class="py-2">
                                {themes.map((theme, index) => (
                                    <button
                                        key={theme.value}
                                        onClick$={() => selectTheme(theme.value)}
                                        class={`group flex w-full items-center px-4 py-3 text-sm font-medium transition-all duration-200 hover:scale-[1.02] ${
                                            themeStore.theme.value === theme.value
                                                ? "bg-gradient-to-r from-blue-50 to-indigo-50 dark:from-blue-900/30 dark:to-indigo-900/30 text-blue-700 dark:text-blue-300 border-l-4 border-blue-500"
                                                : "text-slate-700 dark:text-slate-200 hover:bg-slate-50 dark:hover:bg-slate-700/50 border-l-4 border-transparent hover:border-slate-300 dark:hover:border-slate-600"
                                        } ${index === 0 ? "rounded-t-2xl" : ""} ${index === themes.length - 1 ? "rounded-b-2xl" : ""}`}
                                    >
                                        <span class="mr-3 text-lg transition-transform duration-200 group-hover:scale-110">{theme.icon}</span>
                                        <span class="flex-1 text-left font-semibold">{theme.label}</span>
                                        {themeStore.theme.value === theme.value && (
                                            <div class="ml-auto flex items-center">
                                                <div class="h-2 w-2 rounded-full bg-blue-500 animate-pulse mr-2"></div>
                                                <svg
                                                    class="h-5 w-5 text-blue-600 dark:text-blue-400"
                                                    fill="currentColor"
                                                    viewBox="0 0 20 20"
                                                >
                                                    <path
                                                        fill-rule="evenodd"
                                                        d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z"
                                                        clip-rule="evenodd"
                                                    />
                                                </svg>
                                            </div>
                                        )}
                                    </button>
                                ))}
                            </div>
                        </div>
                    </div>
                </>
            )}
        </div>
    );
});

export default ChangeThemeButton;
