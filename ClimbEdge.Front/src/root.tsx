import { component$, isDev, useContextProvider } from "@builder.io/qwik";
import { QwikCityProvider, RouterOutlet } from "@builder.io/qwik-city";
import { RouterHead } from "./components/router-head/router-head";
import { ThemeContext, useThemeStore } from "./stores/theme";
import { PWAInstaller } from "./components/pwa-installer/pwa-installer";
import { ServiceWorkerRegistration } from "./components/service-worker/service-worker";

import "./global.css";

export default component$(() => {
  /**
   * The root of a QwikCity site always start with the <QwikCityProvider> component,
   * immediately followed by the document's <head> and <body>.
   *
   * Don't remove the `<head>` and `<body>` elements.
   */

  const themeStore = useThemeStore();
  useContextProvider(ThemeContext, themeStore);

  return (
    <QwikCityProvider>
      <head>
        <meta charset="utf-8" />
        {!isDev && (
          <link
            rel="manifest"
            href={`${import.meta.env.BASE_URL}manifest.json`}
          />
        )}
        <meta name="theme-color" content="#10b981" />
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <meta name="apple-mobile-web-app-status-bar-style" content="default" />
        <meta name="apple-mobile-web-app-title" content="ClimbEdge" />
        <link rel="apple-touch-icon" href="/icon-192.svg" />

        {/* Prevent FOUC by setting theme before page loads */}
        <script
          dangerouslySetInnerHTML={`
            (function() {
              const theme = localStorage.getItem('theme');
              const systemDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
              
              if (theme === 'dark' || (theme !== 'light' && systemDark)) {
                document.documentElement.classList.add('dark');
              }
            })();
          `}
        />

        <RouterHead />
      </head>
      <body lang="en">
        <RouterOutlet />
        {!isDev && <ServiceWorkerRegistration />}
        <PWAInstaller />
      </body>
    </QwikCityProvider>
  );
});
