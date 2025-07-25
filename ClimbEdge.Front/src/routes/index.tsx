import { component$, useContextProvider } from "@builder.io/qwik";
import type { DocumentHead } from "@builder.io/qwik-city";
import { Link } from "@builder.io/qwik-city";
import { ChangeThemeButton } from "~/components/change-theme-button";
import { ThemeContext, useThemeStore } from "~/stores/theme";
import { useAuth } from "~/contexts/auth.context";

export default component$(() => {
  const themeStore = useThemeStore();
  const { isAuthenticated } = useAuth();

  useContextProvider(ThemeContext, themeStore);

  // Si está autenticado, mostrar mensaje de bienvenida
  if (isAuthenticated.value) {
    return (
      <div class="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-50 dark:from-gray-900 dark:to-blue-900 transition-colors duration-300">
        <div class="container mx-auto px-4 py-16">
          <div class="text-center max-w-2xl mx-auto">
            <h1 class="text-4xl font-bold text-gray-900 dark:text-white mb-6">
              Welcome back to ClimbEdge!
            </h1>
            <p class="text-lg text-gray-600 dark:text-gray-300 mb-8">
              You're already logged in. Ready to explore your climbing routes?
            </p>
            <div class="space-x-4">
              <Link 
                href="/profile" 
                class="inline-flex items-center px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-lg transition-colors duration-200"
              >
                Go to Profile
              </Link>
              <Link 
                href="/settings" 
                class="inline-flex items-center px-6 py-3 bg-gray-200 hover:bg-gray-300 dark:bg-gray-700 dark:hover:bg-gray-600 text-gray-900 dark:text-white font-medium rounded-lg transition-colors duration-200"
              >
                Settings
              </Link>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div class="min-h-screen bg-white dark:bg-gray-900 transition-colors duration-300">
      {/* Navigation */}
      <nav class="bg-white/80 dark:bg-gray-900/80 backdrop-blur-md border-b border-gray-200 dark:border-gray-700 sticky top-0 z-50">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div class="flex justify-between items-center h-16">
            {/* Logo */}
            <div class="flex items-center space-x-3">
              <div class="w-8 h-8 bg-blue-600 rounded-lg flex items-center justify-center">
                <svg viewBox="0 0 24 24" class="w-5 h-5 text-white" fill="currentColor">
                  <path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z"/>
                </svg>
              </div>
              <span class="text-xl font-bold text-gray-900 dark:text-white">ClimbEdge</span>
            </div>

            {/* Navigation Items */}
            <div class="flex items-center space-x-6">
              <ChangeThemeButton />
              <div class="hidden md:flex items-center space-x-4">
                <Link 
                  href="/login" 
                  class="text-gray-600 dark:text-gray-300 hover:text-blue-600 dark:hover:text-blue-400 transition-colors duration-200"
                >
                  Sign In
                </Link>
                <Link 
                  href="/register" 
                  class="px-4 py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-lg transition-colors duration-200"
                >
                  Get Started
                </Link>
              </div>
            </div>
          </div>
        </div>
      </nav>

      {/* Hero Section */}
      <section class="relative overflow-hidden">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-24">
          <div class="text-center">
            {/* Badge */}
            <div class="inline-flex items-center px-3 py-1 mb-6 text-sm font-medium text-blue-700 dark:text-blue-300 bg-blue-100 dark:bg-blue-900/30 border border-blue-200 dark:border-blue-800 rounded-full">
              <span class="w-2 h-2 bg-blue-500 rounded-full mr-2"></span>
              New: Advanced Route Analytics
            </div>

            {/* Headline */}
            <h1 class="text-4xl sm:text-5xl lg:text-6xl font-bold text-gray-900 dark:text-white mb-6">
              Discover Your Next{" "}
              <span class="text-transparent bg-clip-text bg-gradient-to-r from-blue-600 to-purple-600">
                Climbing Adventure
              </span>
            </h1>

            {/* Subtitle */}
            <p class="text-lg sm:text-xl text-gray-600 dark:text-gray-300 mb-8 max-w-3xl mx-auto">
              Track routes, connect with climbers worldwide, and push your limits with the most comprehensive climbing platform for enthusiasts.
            </p>

            {/* CTA Buttons */}
            <div class="flex flex-col sm:flex-row gap-4 justify-center mb-16">
              <Link 
                href="/register" 
                class="px-8 py-4 bg-blue-600 hover:bg-blue-700 text-white font-semibold rounded-lg transition-all duration-200 hover:scale-105 shadow-lg hover:shadow-xl"
              >
                Start Climbing Free
              </Link>
              <Link 
                href="/login" 
                class="px-8 py-4 bg-gray-100 hover:bg-gray-200 dark:bg-gray-800 dark:hover:bg-gray-700 text-gray-900 dark:text-white font-semibold rounded-lg transition-all duration-200 hover:scale-105 shadow-lg hover:shadow-xl"
              >
                Sign In
              </Link>
            </div>

            {/* Stats */}
            <div class="grid grid-cols-1 md:grid-cols-3 gap-8 max-w-2xl mx-auto">
              <div class="text-center">
                <div class="text-3xl font-bold text-blue-600 dark:text-blue-400 mb-2">10K+</div>
                <div class="text-gray-600 dark:text-gray-400">Active Climbers</div>
              </div>
              <div class="text-center">
                <div class="text-3xl font-bold text-purple-600 dark:text-purple-400 mb-2">50K+</div>
                <div class="text-gray-600 dark:text-gray-400">Routes Tracked</div>
              </div>
              <div class="text-center">
                <div class="text-3xl font-bold text-indigo-600 dark:text-indigo-400 mb-2">1M+</div>
                <div class="text-gray-600 dark:text-gray-400">Climbs Logged</div>
              </div>
            </div>
          </div>
        </div>

        {/* Background Elements */}
        <div class="absolute top-0 left-0 w-full h-full overflow-hidden pointer-events-none">
          <div class="absolute top-20 right-20 w-32 h-32 bg-blue-500/10 rounded-full blur-2xl"></div>
          <div class="absolute bottom-20 left-20 w-40 h-40 bg-purple-500/10 rounded-full blur-2xl"></div>
        </div>
      </section>

      {/* Features Section */}
      <section class="py-24 bg-gray-50 dark:bg-gray-800/50">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div class="text-center mb-16">
            <h2 class="text-3xl font-bold text-gray-900 dark:text-white mb-4">
              Everything You Need to Climb
            </h2>
            <p class="text-lg text-gray-600 dark:text-gray-300 max-w-2xl mx-auto">
              From route planning to community connection, ClimbEdge has all the tools you need.
            </p>
          </div>

          <div class="grid md:grid-cols-3 gap-8">
            {/* Feature 1 */}
            <div class="bg-white dark:bg-gray-800 p-8 rounded-xl shadow-sm hover:shadow-lg transition-shadow duration-200 border border-gray-200 dark:border-gray-700">
              <div class="w-12 h-12 bg-blue-100 dark:bg-blue-900/50 rounded-lg flex items-center justify-center mb-6">
                <svg class="w-6 h-6 text-blue-600 dark:text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"/>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Route Tracking
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Log your climbs, track progress, and analyze your performance with detailed statistics and insights.
              </p>
            </div>

            {/* Feature 2 */}
            <div class="bg-white dark:bg-gray-800 p-8 rounded-xl shadow-sm hover:shadow-lg transition-shadow duration-200 border border-gray-200 dark:border-gray-700">
              <div class="w-12 h-12 bg-green-100 dark:bg-green-900/50 rounded-lg flex items-center justify-center mb-6">
                <svg class="w-6 h-6 text-green-600 dark:text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z"/>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Global Community
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Connect with fellow climbers, share routes, and discover new climbing spots with our worldwide community.
              </p>
            </div>

            {/* Feature 3 */}
            <div class="bg-white dark:bg-gray-800 p-8 rounded-xl shadow-sm hover:shadow-lg transition-shadow duration-200 border border-gray-200 dark:border-gray-700">
              <div class="w-12 h-12 bg-purple-100 dark:bg-purple-900/50 rounded-lg flex items-center justify-center mb-6">
                <svg class="w-6 h-6 text-purple-600 dark:text-purple-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"/>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Safety Tools
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Access safety guidelines, weather updates, and route conditions for safer and more informed climbing.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section class="py-24">
        <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <div class="bg-gradient-to-r from-blue-600 to-purple-600 rounded-2xl p-12 text-white">
            <h2 class="text-3xl font-bold mb-4">
              Ready to Start Your Journey?
            </h2>
            <p class="text-blue-100 text-lg mb-8 max-w-2xl mx-auto">
              Join thousands of climbers who trust ClimbEdge to track their adventures and discover new routes.
            </p>
            <Link 
              href="/register" 
              class="inline-flex items-center px-8 py-4 bg-white text-blue-600 font-semibold rounded-lg hover:bg-gray-50 transition-colors duration-200"
            >
              Get Started Free
            </Link>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer class="bg-gray-50 dark:bg-gray-800 border-t border-gray-200 dark:border-gray-700">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
          <div class="grid md:grid-cols-4 gap-8">
            <div class="md:col-span-2">
              <div class="flex items-center space-x-3 mb-4">
                <div class="w-8 h-8 bg-blue-600 rounded-lg flex items-center justify-center">
                  <svg viewBox="0 0 24 24" class="w-5 h-5 text-white" fill="currentColor">
                    <path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z"/>
                  </svg>
                </div>
                <span class="text-xl font-bold text-gray-900 dark:text-white">ClimbEdge</span>
              </div>
              <p class="text-gray-600 dark:text-gray-300 max-w-md">
                The ultimate platform for climbing enthusiasts to track, share, and discover routes worldwide.
              </p>
            </div>
            
            <div>
              <h3 class="font-semibold text-gray-900 dark:text-white mb-4">Platform</h3>
              <ul class="space-y-2">
                <li><Link href="/login" class="text-gray-600 dark:text-gray-300 hover:text-blue-600 dark:hover:text-blue-400 transition-colors">Sign In</Link></li>
                <li><Link href="/register" class="text-gray-600 dark:text-gray-300 hover:text-blue-600 dark:hover:text-blue-400 transition-colors">Get Started</Link></li>
                <li><Link href="/forgot-password" class="text-gray-600 dark:text-gray-300 hover:text-blue-600 dark:hover:text-blue-400 transition-colors">Forgot Password</Link></li>
              </ul>
            </div>
            
            <div>
              <h3 class="font-semibold text-gray-900 dark:text-white mb-4">Support</h3>
              <ul class="space-y-2">
                <li class="text-gray-600 dark:text-gray-300">Help Center</li>
                <li class="text-gray-600 dark:text-gray-300">Contact Us</li>
                <li class="text-gray-600 dark:text-gray-300">Privacy Policy</li>
                <li class="text-gray-600 dark:text-gray-300">Terms of Service</li>
              </ul>
            </div>
          </div>
          
          <div class="border-t border-gray-200 dark:border-gray-700 mt-8 pt-8 text-center">
            <p class="text-gray-600 dark:text-gray-300">
              © 2025 ClimbEdge. All rights reserved.
            </p>
          </div>
        </div>
      </footer>
    </div>
  );
});

export const head: DocumentHead = {
  title: "ClimbEdge - Your Ultimate Climbing Companion",
  meta: [
    {
      name: "description",
      content: "Track routes, connect with climbers, and discover your next adventure with ClimbEdge - the comprehensive climbing platform for enthusiasts.",
    },
    {
      name: "keywords",
      content: "climbing, routes, bouldering, rock climbing, climbing community, route tracking",
    },
    {
      name: "viewport",
      content: "width=device-width, initial-scale=1.0",
    },
    {
      property: "og:title",
      content: "ClimbEdge - Your Ultimate Climbing Companion",
    },
    {
      property: "og:description",
      content: "Track routes, connect with climbers, and discover your next adventure with ClimbEdge.",
    },
    {
      property: "og:type",
      content: "website",
    },
  ],
};
