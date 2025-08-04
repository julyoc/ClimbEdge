import { component$ } from "@builder.io/qwik";
import { DocumentHead } from "@builder.io/qwik-city";
import { Link } from "@builder.io/qwik-city";

export default component$(() => {
  return (
    <div class="min-h-screen bg-white dark:bg-gray-900 transition-colors duration-300">
      <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        {/* Header */}
        <div class="text-center mb-12">
          <h1 class="text-4xl font-bold text-gray-900 dark:text-white mb-4">
            Help Center
          </h1>
          <p class="text-lg text-gray-600 dark:text-gray-300">
            Find answers to frequently asked questions and get support for ClimbEdge
          </p>
        </div>

        {/* Navigation */}
        <div class="mb-8">
          <Link href="/" class="text-blue-600 dark:text-blue-400 hover:underline">
            ← Back to Home
          </Link>
        </div>

        {/* FAQ Sections */}
        <div class="space-y-8">
          {/* Getting Started */}
          <section class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Getting Started
            </h2>
            <div class="space-y-4">
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  How do I create an account?
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  You can create an account by clicking the "Sign Up" button on the homepage and filling out the registration form with your email and preferred password.
                </p>
              </div>
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  How do I log routes?
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Once logged in, navigate to the "Log Route" section and enter details about your climb including route name, grade, location, and any notes.
                </p>
              </div>
            </div>
          </section>

          {/* Account Management */}
          <section class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Account Management
            </h2>
            <div class="space-y-4">
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  How do I reset my password?
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Click on "Forgot Password" on the login page and enter your email address. You'll receive instructions to reset your password.
                </p>
              </div>
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  How do I update my profile?
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Go to your profile settings and update your personal information, climbing preferences, and privacy settings.
                </p>
              </div>
            </div>
          </section>

          {/* Troubleshooting */}
          <section class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Troubleshooting
            </h2>
            <div class="space-y-4">
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  The app is not loading properly
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Try clearing your browser cache and cookies. If the problem persists, please contact our support team.
                </p>
              </div>
              <div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                  I can't find my logged routes
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Check your profile page under "My Routes" or use the search function to find specific climbs.
                </p>
              </div>
            </div>
          </section>
        </div>

        {/* Contact Support */}
        <div class="mt-12 text-center">
          <p class="text-gray-600 dark:text-gray-300 mb-4">
            Can't find what you're looking for?
          </p>
          <Link 
            href="/contact-us" 
            class="inline-block bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition-colors"
          >
            Contact Support
          </Link>
        </div>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: "Help Center - ClimbEdge",
  meta: [
    {
      name: "description",
      content: "Find answers to frequently asked questions and get support for ClimbEdge climbing tracker.",
    },
  ],
};
