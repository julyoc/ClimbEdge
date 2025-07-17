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
                class="inline-flex items-center justify-center rounded-md px-3 py-2 text-sm font-medium transition-colors duration-200 ease-in-out bg-white dark:bg-gray-800 text-gray-900 dark:text-gray-100 border border-gray-300 dark:border-gray-600 hover:bg-gray-50 hover:dark:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 focus:ring-offset-white focus:dark:ring-offset-gray-800"
                title={`Current theme: ${currentTheme.label}`}
            >
                <span class="mr-2 text-base">{currentTheme.icon}</span>
                <span>{currentTheme.label}</span>
                <svg
                    class={`ml-2 h-4 w-4 transition-transform duration-200 ${isDropdownOpen.value ? "rotate-180" : ""
                        }`}
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

            {isDropdownOpen.value && (
                <div class="absolute right-0 z-10 mt-2 w-48 origin-top-right rounded-md shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                    <div class="py-1 bg-white dark:bg-gray-800 border border-gray-200 dark:border-gray-700 rounded-md">
                        {themes.map((theme) => (
                            <button
                                key={theme.value}
                                onClick$={() => selectTheme(theme.value)}
                                class={`flex w-full items-center px-4 py-2 text-sm transition-colors duration-200 text-gray-700 dark:text-gray-200 hover:bg-gray-100 hover:dark:bg-gray-700 ${themeStore.theme.value === theme.value
                                        ? "bg-blue-50 dark:bg-blue-900/20 text-blue-700 dark:text-blue-300"
                                        : ""
                                    }`}
                            >
                                <span class="mr-3 text-base">{theme.icon}</span>
                                <span>{theme.label}</span>
                                {themeStore.theme.value === theme.value && (
                                    <svg
                                        class="ml-auto h-4 w-4 text-blue-600 dark:text-blue-400"
                                        fill="currentColor"
                                        viewBox="0 0 20 20"
                                    >
                                        <path
                                            fill-rule="evenodd"
                                            d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z"
                                            clip-rule="evenodd"
                                        />
                                    </svg>
                                )}
                            </button>
                        ))}
                    </div>
                </div>
            )}
        </div>
    );
});

export default ChangeThemeButton;
