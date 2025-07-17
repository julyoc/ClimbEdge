import { createContextId, useContext, useSignal, useTask$ } from "@builder.io/qwik";
import { isBrowser } from "@builder.io/qwik/build";
import type { Signal } from "@builder.io/qwik";

export type Theme = "light" | "dark" | "system";

export interface ThemeStore {
  theme: Signal<Theme>;
  isDark: Signal<boolean>;
}

export const ThemeContext = createContextId<ThemeStore>("theme");

export const useTheme = () => useContext(ThemeContext);

export const useThemeStore = () => {
  const theme = useSignal<Theme>("system");
  const isDark = useSignal<boolean>(false);

  // Initialize theme on client side
  useTask$(() => {
    if (isBrowser) {
      const savedTheme = localStorage.getItem("theme") as Theme | null;
      const systemDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
      
      if (savedTheme && ["light", "dark"].includes(savedTheme)) {
        theme.value = savedTheme;
        isDark.value = savedTheme === "dark";
        document.documentElement.classList.toggle("dark", savedTheme === "dark");
      } else {
        theme.value = "system";
        isDark.value = systemDark;
        document.documentElement.classList.toggle("dark", systemDark);
      }

      // Listen for system theme changes
      const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");
      const handleSystemThemeChange = (e: MediaQueryListEvent) => {
        if (theme.value === "system") {
          isDark.value = e.matches;
          document.documentElement.classList.toggle("dark", e.matches);
        }
      };

      mediaQuery.addEventListener("change", handleSystemThemeChange);
      
      return () => {
        mediaQuery.removeEventListener("change", handleSystemThemeChange);
      };
    }
  });

  return {
    theme,
    isDark,
  };
};
