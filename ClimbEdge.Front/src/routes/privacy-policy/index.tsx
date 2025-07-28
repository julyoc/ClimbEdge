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
            Privacy Policy
          </h1>
          <p class="text-lg text-gray-600 dark:text-gray-300">
            Last updated: {new Date().toLocaleDateString()}
          </p>
        </div>

        {/* Navigation */}
        <div class="mb-8">
          <Link href="/" class="text-blue-600 dark:text-blue-400 hover:underline">
            ← Back to Home
          </Link>
        </div>

        {/* Content */}
        <div class="prose dark:prose-invert max-w-none">
          {/* Introduction */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Introduction
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              ClimbEdge ("we," "our," or "us") is committed to protecting your privacy. This Privacy Policy explains how we collect, use, disclose, and safeguard your information when you use our climbing tracking application and related services.
            </p>
            <p class="text-gray-600 dark:text-gray-300">
              By using ClimbEdge, you agree to the collection and use of information in accordance with this policy.
            </p>
          </section>

          {/* Information We Collect */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Information We Collect
            </h2>
            
            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Personal Information
            </h3>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 mb-4 space-y-1">
              <li>Email address and name for account creation</li>
              <li>Profile information (climbing experience, preferences)</li>
              <li>Climbing route logs and performance data</li>
              <li>Photos and media uploaded by you</li>
            </ul>

            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Usage Information
            </h3>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 mb-4 space-y-1">
              <li>App usage patterns and feature interactions</li>
              <li>Device information and browser type</li>
              <li>IP address and general location data</li>
              <li>Session duration and frequency of use</li>
            </ul>
          </section>

          {/* How We Use Information */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              How We Use Your Information
            </h2>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-2">
              <li>To provide and maintain our climbing tracking services</li>
              <li>To personalize your experience and improve our app</li>
              <li>To communicate with you about updates and support</li>
              <li>To analyze usage patterns and optimize performance</li>
              <li>To ensure security and prevent fraud</li>
              <li>To comply with legal obligations</li>
            </ul>
          </section>

          {/* Information Sharing */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Information Sharing and Disclosure
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              We do not sell, trade, or rent your personal information to third parties. We may share information only in the following circumstances:
            </p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-2">
              <li><strong>With your consent:</strong> When you explicitly agree to share information</li>
              <li><strong>Service providers:</strong> With trusted partners who help us operate our services</li>
              <li><strong>Legal requirements:</strong> When required by law or to protect our rights</li>
              <li><strong>Safety:</strong> To prevent harm to users or the public</li>
            </ul>
          </section>

          {/* Data Security */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Data Security
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              We implement appropriate technical and organizational measures to protect your personal information against unauthorized access, alteration, disclosure, or destruction.
            </p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-1">
              <li>Encryption of data in transit and at rest</li>
              <li>Regular security assessments and updates</li>
              <li>Access controls and authentication measures</li>
              <li>Secure data storage and backup procedures</li>
            </ul>
          </section>

          {/* Your Rights */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Your Rights and Choices
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              You have the following rights regarding your personal information:
            </p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-2">
              <li><strong>Access:</strong> Request copies of your personal data</li>
              <li><strong>Correction:</strong> Request correction of inaccurate information</li>
              <li><strong>Deletion:</strong> Request deletion of your personal data</li>
              <li><strong>Portability:</strong> Request transfer of your data</li>
              <li><strong>Opt-out:</strong> Unsubscribe from marketing communications</li>
            </ul>
          </section>

          {/* Cookies */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Cookies and Tracking Technologies
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              We use cookies and similar tracking technologies to enhance your experience, analyze usage, and provide personalized content. You can control cookie settings through your browser preferences.
            </p>
          </section>

          {/* Children's Privacy */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Children's Privacy
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              ClimbEdge is not intended for use by children under 13 years of age. We do not knowingly collect personal information from children under 13. If you become aware that a child has provided us with personal information, please contact us immediately.
            </p>
          </section>

          {/* Changes */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Changes to This Privacy Policy
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              We may update this Privacy Policy from time to time. We will notify you of any changes by posting the new Privacy Policy on this page and updating the "Last updated" date. We encourage you to review this Privacy Policy periodically.
            </p>
          </section>

          {/* Contact */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Contact Us
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              If you have any questions about this Privacy Policy or our data practices, please contact us:
            </p>
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-4">
              <p class="text-gray-600 dark:text-gray-300">
                Email: <a href="mailto:privacy@climbedge.com" class="text-blue-600 dark:text-blue-400 hover:underline">privacy@climbedge.com</a>
              </p>
              <p class="text-gray-600 dark:text-gray-300">
                Or visit our <Link href="/contact-us" class="text-blue-600 dark:text-blue-400 hover:underline">Contact Us</Link> page
              </p>
            </div>
          </section>
        </div>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: "Privacy Policy - ClimbEdge",
  meta: [
    {
      name: "description",
      content: "Learn how ClimbEdge collects, uses, and protects your personal information in our comprehensive privacy policy.",
    },
  ],
};
