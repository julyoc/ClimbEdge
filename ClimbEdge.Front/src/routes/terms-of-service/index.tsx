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
            Terms of Service
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
              Agreement to Terms
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              These Terms of Service ("Terms") govern your use of ClimbEdge ("Service") operated by ClimbEdge ("us", "we", or "our"). By accessing or using our Service, you agree to be bound by these Terms.
            </p>
            <p class="text-gray-600 dark:text-gray-300">
              If you disagree with any part of these terms, then you may not access the Service.
            </p>
          </section>

          {/* Use of Service */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Use of Service
            </h2>
            
            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Permitted Use
            </h3>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              ClimbEdge is a climbing tracking application designed to help climbers log routes, track progress, and connect with the climbing community. You may use the Service for personal, non-commercial purposes in accordance with these Terms.
            </p>

            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Prohibited Activities
            </h3>
            <p class="text-gray-600 dark:text-gray-300 mb-2">You agree not to:</p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-1">
              <li>Use the Service for any unlawful purpose or in violation of applicable laws</li>
              <li>Upload, post, or transmit harmful, offensive, or inappropriate content</li>
              <li>Attempt to gain unauthorized access to the Service or other users' accounts</li>
              <li>Interfere with or disrupt the Service or servers</li>
              <li>Use automated tools to access or collect data from the Service</li>
              <li>Impersonate another person or entity</li>
              <li>Share false or misleading climbing information that could endanger others</li>
            </ul>
          </section>

          {/* Accounts */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              User Accounts
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              To use certain features of the Service, you must create an account. You are responsible for:
            </p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-2">
              <li>Maintaining the confidentiality of your account credentials</li>
              <li>All activities that occur under your account</li>
              <li>Providing accurate and up-to-date information</li>
              <li>Notifying us immediately of any unauthorized use of your account</li>
            </ul>
            <p class="text-gray-600 dark:text-gray-300 mt-4">
              We reserve the right to suspend or terminate accounts that violate these Terms.
            </p>
          </section>

          {/* Content */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              User Content
            </h2>
            
            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Your Content
            </h3>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              You retain ownership of content you create and share through the Service, including climbing logs, photos, and comments. By posting content, you grant us a non-exclusive, worldwide, royalty-free license to use, display, and distribute your content in connection with the Service.
            </p>

            <h3 class="text-xl font-medium text-gray-900 dark:text-white mb-3">
              Content Standards
            </h3>
            <p class="text-gray-600 dark:text-gray-300 mb-2">All content must:</p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-1">
              <li>Be accurate and not misleading</li>
              <li>Respect intellectual property rights</li>
              <li>Not contain harmful, offensive, or inappropriate material</li>
              <li>Comply with applicable laws and regulations</li>
            </ul>
          </section>

          {/* Safety Disclaimer */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Safety and Risk Disclaimer
            </h2>
            <div class="bg-yellow-50 dark:bg-yellow-900/20 border border-yellow-200 dark:border-yellow-800 rounded-lg p-4 mb-4">
              <p class="text-yellow-800 dark:text-yellow-200 font-medium">
                ⚠️ Important Safety Notice
              </p>
            </div>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              Climbing is an inherently dangerous activity that can result in serious injury or death. ClimbEdge is a tracking tool only and does not provide safety advice or route conditions. You acknowledge that:
            </p>
            <ul class="list-disc pl-6 text-gray-600 dark:text-gray-300 space-y-2">
              <li>You climb at your own risk and assume full responsibility for your safety</li>
              <li>Route information may be outdated, incomplete, or inaccurate</li>
              <li>Weather, rock conditions, and other factors can change rapidly</li>
              <li>You should always use proper safety equipment and techniques</li>
              <li>You should never rely solely on information from ClimbEdge for safety decisions</li>
            </ul>
          </section>

          {/* Intellectual Property */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Intellectual Property
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              The Service and its original content, features, and functionality are owned by ClimbEdge and are protected by international copyright, trademark, patent, trade secret, and other intellectual property laws.
            </p>
            <p class="text-gray-600 dark:text-gray-300">
              You may not copy, modify, distribute, sell, or lease any part of our Service without our prior written consent.
            </p>
          </section>

          {/* Privacy */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Privacy
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              Your privacy is important to us. Please review our <Link href="/privacy-policy" class="text-blue-600 dark:text-blue-400 hover:underline">Privacy Policy</Link>, which also governs your use of the Service, to understand our practices.
            </p>
          </section>

          {/* Disclaimer */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Disclaimer of Warranties
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              The Service is provided on an "AS IS" and "AS AVAILABLE" basis. We make no warranties, expressed or implied, and hereby disclaim all other warranties including, without limitation, implied warranties of merchantability, fitness for a particular purpose, or non-infringement.
            </p>
            <p class="text-gray-600 dark:text-gray-300">
              We do not warrant that the Service will be uninterrupted, error-free, or completely secure.
            </p>
          </section>

          {/* Limitation of Liability */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Limitation of Liability
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              In no event shall ClimbEdge be liable for any indirect, incidental, special, consequential, or punitive damages, including without limitation, loss of profits, data, use, goodwill, or other intangible losses, resulting from your use of the Service.
            </p>
          </section>

          {/* Termination */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Termination
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              We may terminate or suspend your account and access to the Service immediately, without prior notice, for conduct that we believe violates these Terms or is harmful to other users, us, or third parties.
            </p>
            <p class="text-gray-600 dark:text-gray-300">
              You may terminate your account at any time by contacting us or using the account deletion feature in the app.
            </p>
          </section>

          {/* Changes */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Changes to Terms
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              We reserve the right to modify these Terms at any time. We will notify users of any material changes by posting the new Terms on this page and updating the "Last updated" date. Your continued use of the Service after changes constitutes acceptance of the new Terms.
            </p>
          </section>

          {/* Governing Law */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Governing Law
            </h2>
            <p class="text-gray-600 dark:text-gray-300">
              These Terms shall be governed by and construed in accordance with the laws of [Your Jurisdiction], without regard to its conflict of law provisions.
            </p>
          </section>

          {/* Contact */}
          <section class="mb-8">
            <h2 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">
              Contact Information
            </h2>
            <p class="text-gray-600 dark:text-gray-300 mb-4">
              If you have any questions about these Terms of Service, please contact us:
            </p>
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-4">
              <p class="text-gray-600 dark:text-gray-300">
                Email: <a href="mailto:legal@climbedge.com" class="text-blue-600 dark:text-blue-400 hover:underline">legal@climbedge.com</a>
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
  title: "Terms of Service - ClimbEdge",
  meta: [
    {
      name: "description",
      content: "Read ClimbEdge's Terms of Service to understand the rules and guidelines for using our climbing tracking application.",
    },
  ],
};
