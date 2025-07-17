import { component$ } from "@builder.io/qwik";
import type { DocumentHead } from "@builder.io/qwik-city";
import { ChangeThemeButton } from "~/components/change-theme-button";

export default component$(() => {
  return (
    <div class="min-h-screen bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100 transition-colors duration-200">
      <div class="container mx-auto px-4 py-8">
        {/* Header with theme button */}
        <header class="flex justify-between items-center mb-8">
          <h1 class="text-3xl font-bold text-blue-600 dark:text-blue-400">
            ClimbEdge
          </h1>
          <ChangeThemeButton />
        </header>

        {/* Main content */}
        <main class="space-y-6">
          <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 shadow-lg">
            <h2 class="text-xl font-semibold mb-4">
              Hi 👋
            </h2>
            <p class="text-gray-700 dark:text-gray-300">
              Can't wait to see what you build with qwik!
              <br />
              Happy coding.
            </p>
          </div>

          <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 shadow-lg">
            <h3 class="text-lg font-semibold mb-2">
              Theme Demo
            </h3>
            <p class="text-gray-700 dark:text-gray-300 mb-4">
              Try switching between light, dark, and system themes using the button above!
            </p>
            <div class="flex gap-4">
              <div class="bg-blue-500 text-white px-4 py-2 rounded">
                Primary Color
              </div>
              <div class="bg-green-500 text-white px-4 py-2 rounded">
                Accent Color
              </div>
            </div>
          </div>

          <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 shadow-lg">
            <h3 class="text-lg font-semibold mb-2">
              Features
            </h3>
            <ul class="space-y-2 text-gray-700 dark:text-gray-300">
              <li>✅ Light/Dark/System theme support</li>
              <li>✅ Smooth transitions between themes</li>
              <li>✅ Persistent theme preference</li>
              <li>✅ System theme detection</li>
              <li>✅ Accessible dropdown menu</li>
              <li>✅ FOUC prevention</li>
            </ul>
          </div>
        </main>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: "ClimbEdge - Welcome",
  meta: [
    {
      name: "description",
      content: "ClimbEdge climbing route management platform",
    },
  ],
};
