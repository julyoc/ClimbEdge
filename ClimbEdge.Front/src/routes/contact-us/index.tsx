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
            Contact Us
          </h1>
          <p class="text-lg text-gray-600 dark:text-gray-300">
            Get in touch with our team - we're here to help
          </p>
        </div>

        {/* Navigation */}
        <div class="mb-8">
          <Link href="/" class="text-blue-600 dark:text-blue-400 hover:underline">
            ← Back to Home
          </Link>
        </div>

        <div class="grid md:grid-cols-2 gap-12">
          {/* Contact Form */}
          <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-6">
              Send us a message
            </h2>
            <form class="space-y-4">
              <div>
                <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
                  Name
                </label>
                <input
                  type="text"
                  class="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-white focus:ring-blue-500 focus:border-blue-500"
                  placeholder="Your full name"
                />
              </div>
              <div>
                <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
                  Email
                </label>
                <input
                  type="email"
                  class="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-white focus:ring-blue-500 focus:border-blue-500"
                  placeholder="your.email@example.com"
                />
              </div>
              <div>
                <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
                  Subject
                </label>
                <select class="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-white focus:ring-blue-500 focus:border-blue-500">
                  <option>General Inquiry</option>
                  <option>Technical Support</option>
                  <option>Feature Request</option>
                  <option>Bug Report</option>
                  <option>Account Issues</option>
                </select>
              </div>
              <div>
                <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
                  Message
                </label>
                <textarea
                  rows={5}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-white focus:ring-blue-500 focus:border-blue-500"
                  placeholder="Tell us how we can help you..."
                ></textarea>
              </div>
              <button
                type="submit"
                class="w-full bg-blue-600 text-white py-2 px-4 rounded-md hover:bg-blue-700 transition-colors"
              >
                Send Message
              </button>
            </form>
          </div>

          {/* Contact Information */}
          <div class="space-y-8">
            <div>
              <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-6">
                Other ways to reach us
              </h2>
            </div>

            {/* Email Support */}
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
              <div class="flex items-center mb-3">
                <div class="w-8 h-8 bg-blue-100 dark:bg-blue-900 rounded-full flex items-center justify-center mr-3">
                  <svg class="w-4 h-4 text-blue-600 dark:text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 8l7.89 4.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"></path>
                  </svg>
                </div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white">
                  Email Support
                </h3>
              </div>
              <p class="text-gray-600 dark:text-gray-300 mb-2">
                For general inquiries and support
              </p>
              <a href="mailto:support@climbedge.com" class="text-blue-600 dark:text-blue-400 hover:underline">
                support@climbedge.com
              </a>
            </div>

            {/* Bug Reports */}
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6">
              <div class="flex items-center mb-3">
                <div class="w-8 h-8 bg-red-100 dark:bg-red-900 rounded-full flex items-center justify-center mr-3">
                  <svg class="w-4 h-4 text-red-600 dark:text-red-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L4.082 16.5c-.77.833.192 2.5 1.732 2.5z"></path>
                  </svg>
                </div>
                <h3 class="text-lg font-medium text-gray-900 dark:text-white">
                  Bug Reports
                </h3>
              </div>
              <p class="text-gray-600 dark:text-gray-300 mb-2">
                Found a bug? Let us know
              </p>
              <a href="mailto:bugs@climbedge.com" class="text-blue-600 dark:text-blue-400 hover:underline">
                bugs@climbedge.com
              </a>
            </div>

            {/* Response Time */}
            <div class="bg-blue-50 dark:bg-blue-900/20 rounded-lg p-6">
              <h3 class="text-lg font-medium text-gray-900 dark:text-white mb-2">
                Response Time
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                We typically respond to all inquiries within 24-48 hours during business days.
              </p>
            </div>
          </div>
        </div>

        {/* FAQ Link */}
        <div class="mt-12 text-center">
          <p class="text-gray-600 dark:text-gray-300 mb-4">
            Looking for quick answers?
          </p>
          <Link 
            href="/help-center" 
            class="inline-block text-blue-600 dark:text-blue-400 hover:underline"
          >
            Check out our Help Center →
          </Link>
        </div>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: "Contact Us - ClimbEdge",
  meta: [
    {
      name: "description",
      content: "Get in touch with the ClimbEdge team for support, questions, or feedback.",
    },
  ],
};
