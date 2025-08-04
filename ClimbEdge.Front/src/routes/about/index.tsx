import { component$ } from "@builder.io/qwik";
import { DocumentHead } from "@builder.io/qwik-city";
import { Link } from "@builder.io/qwik-city";

export default component$(() => {
  return (
    <div class="min-h-screen bg-white dark:bg-gray-900 transition-colors duration-300">
      <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        {/* Header */}
        <div class="text-center mb-16">
          <h1 class="text-5xl font-bold text-gray-900 dark:text-white mb-6">
            About ClimbEdge
          </h1>
          <p class="text-xl text-gray-600 dark:text-gray-300 max-w-3xl mx-auto">
            Empowering climbers to track their progress, discover new routes, and connect with the global climbing community
          </p>
        </div>

        {/* Navigation */}
        <div class="mb-12">
          <Link href="/" class="text-blue-600 dark:text-blue-400 hover:underline text-lg">
            ← Back to Home
          </Link>
        </div>

        {/* Mission Section */}
        <section class="mb-16">
          <div class="grid md:grid-cols-2 gap-12 items-center">
            <div>
              <h2 class="text-3xl font-bold text-gray-900 dark:text-white mb-6">
                Our Mission
              </h2>
              <p class="text-lg text-gray-600 dark:text-gray-300 mb-4">
                ClimbEdge was born from a passion for climbing and a desire to help fellow climbers reach new heights. We believe every climber deserves tools that inspire progress, build confidence, and foster community.
              </p>
              <p class="text-lg text-gray-600 dark:text-gray-300">
                Whether you're a beginner taking your first steps on indoor walls or a seasoned pro tackling big walls, ClimbEdge is designed to support your climbing journey.
              </p>
            </div>
            <div class="bg-gradient-to-br from-blue-500 to-purple-600 rounded-lg p-8 text-white">
              <div class="text-center">
                <div class="text-4xl mb-4">🧗‍♀️</div>
                <h3 class="text-xl font-semibold mb-2">Track. Progress. Conquer.</h3>
                <p class="text-blue-100">
                  Every route logged is a step towards your next breakthrough
                </p>
              </div>
            </div>
          </div>
        </section>

        {/* Features Section */}
        <section class="mb-16">
          <h2 class="text-3xl font-bold text-gray-900 dark:text-white text-center mb-12">
            What Makes ClimbEdge Special
          </h2>
          <div class="grid md:grid-cols-3 gap-8">
            {/* Feature 1 */}
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 text-center">
              <div class="w-16 h-16 bg-blue-100 dark:bg-blue-900 rounded-full flex items-center justify-center mx-auto mb-4">
                <svg class="w-8 h-8 text-blue-600 dark:text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"></path>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Comprehensive Tracking
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Log routes, track grades, record attempts, and monitor your progression over time with detailed analytics.
              </p>
            </div>

            {/* Feature 2 */}
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 text-center">
              <div class="w-16 h-16 bg-green-100 dark:bg-green-900 rounded-full flex items-center justify-center mx-auto mb-4">
                <svg class="w-8 h-8 text-green-600 dark:text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"></path>
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"></path>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Route Discovery
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Discover new climbing areas, find routes that match your skill level, and explore detailed route information.
              </p>
            </div>

            {/* Feature 3 */}
            <div class="bg-gray-50 dark:bg-gray-800 rounded-lg p-6 text-center">
              <div class="w-16 h-16 bg-purple-100 dark:bg-purple-900 rounded-full flex items-center justify-center mx-auto mb-4">
                <svg class="w-8 h-8 text-purple-600 dark:text-purple-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z"></path>
                </svg>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-3">
                Community Connection
              </h3>
              <p class="text-gray-600 dark:text-gray-300">
                Connect with fellow climbers, share experiences, and get inspired by the global climbing community.
              </p>
            </div>
          </div>
        </section>

        {/* Story Section */}
        <section class="mb-16">
          <div class="bg-gradient-to-r from-gray-50 to-blue-50 dark:from-gray-800 dark:to-blue-900/20 rounded-xl p-8 md:p-12">
            <h2 class="text-3xl font-bold text-gray-900 dark:text-white mb-6 text-center">
              Our Story
            </h2>
            <div class="max-w-4xl mx-auto">
              <p class="text-lg text-gray-600 dark:text-gray-300 mb-6">
                ClimbEdge started as a simple idea: what if climbers had a better way to track their progress and discover new challenges? After countless sessions at the crag and gym, struggling with scattered notes and forgotten route details, our team decided to build the tool we wished we had.
              </p>
              <p class="text-lg text-gray-600 dark:text-gray-300 mb-6">
                We spent months talking to climbers of all levels - from weekend warriors to professional athletes - understanding their needs, frustrations, and dreams. The result is ClimbEdge: a platform designed by climbers, for climbers.
              </p>
              <p class="text-lg text-gray-600 dark:text-gray-300">
                Today, ClimbEdge serves thousands of climbers worldwide, helping them push their limits, celebrate their achievements, and discover their next adventure. We're just getting started.
              </p>
            </div>
          </div>
        </section>

        {/* Values Section */}
        <section class="mb-16">
          <h2 class="text-3xl font-bold text-gray-900 dark:text-white text-center mb-12">
            Our Values
          </h2>
          <div class="grid md:grid-cols-2 gap-8">
            <div class="flex items-start space-x-4">
              <div class="w-12 h-12 bg-blue-100 dark:bg-blue-900 rounded-lg flex items-center justify-center flex-shrink-0">
                <svg class="w-6 h-6 text-blue-600 dark:text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                </svg>
              </div>
              <div>
                <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                  Safety First
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  We prioritize climber safety in everything we do, providing accurate information and promoting responsible climbing practices.
                </p>
              </div>
            </div>

            <div class="flex items-start space-x-4">
              <div class="w-12 h-12 bg-green-100 dark:bg-green-900 rounded-lg flex items-center justify-center flex-shrink-0">
                <svg class="w-6 h-6 text-green-600 dark:text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z"></path>
                </svg>
              </div>
              <div>
                <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                  Continuous Innovation
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  We constantly evolve and improve, listening to our community and embracing new technologies to enhance the climbing experience.
                </p>
              </div>
            </div>

            <div class="flex items-start space-x-4">
              <div class="w-12 h-12 bg-purple-100 dark:bg-purple-900 rounded-lg flex items-center justify-center flex-shrink-0">
                <svg class="w-6 h-6 text-purple-600 dark:text-purple-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>
                </svg>
              </div>
              <div>
                <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                  Community Driven
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  Our platform thrives on community input, collaboration, and the shared passion that unites climbers worldwide.
                </p>
              </div>
            </div>

            <div class="flex items-start space-x-4">
              <div class="w-12 h-12 bg-orange-100 dark:bg-orange-900 rounded-lg flex items-center justify-center flex-shrink-0">
                <svg class="w-6 h-6 text-orange-600 dark:text-orange-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707M16 12a4 4 0 11-8 0 4 4 0 018 0z"></path>
                </svg>
              </div>
              <div>
                <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                  Accessibility
                </h3>
                <p class="text-gray-600 dark:text-gray-300">
                  We believe climbing tools should be accessible to everyone, regardless of experience level, background, or physical ability.
                </p>
              </div>
            </div>
          </div>
        </section>

        {/* Team Section */}
        <section class="mb-16">
          <h2 class="text-3xl font-bold text-gray-900 dark:text-white text-center mb-12">
            Meet the Team
          </h2>
          <div class="grid md:grid-cols-3 gap-8">
            {/* Team Member 1 */}
            <div class="text-center">
              <div class="w-32 h-32 bg-gradient-to-br from-blue-400 to-purple-500 rounded-full mx-auto mb-4 flex items-center justify-center">
                <span class="text-white text-2xl font-bold">JC</span>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                Julio Castro
              </h3>
              <p class="text-blue-600 dark:text-blue-400 mb-2">Founder & Lead Developer</p>
              <p class="text-gray-600 dark:text-gray-300 text-sm">
                Passionate climber and software engineer with 10+ years of experience building user-focused applications.
              </p>
            </div>

            {/* Team Member 2 */}
            <div class="text-center">
              <div class="w-32 h-32 bg-gradient-to-br from-green-400 to-blue-500 rounded-full mx-auto mb-4 flex items-center justify-center">
                <span class="text-white text-2xl font-bold">SJ</span>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                Sarah Johnson
              </h3>
              <p class="text-blue-600 dark:text-blue-400 mb-2">UX Designer</p>
              <p class="text-gray-600 dark:text-gray-300 text-sm">
                Former professional climber turned designer, dedicated to creating intuitive and beautiful user experiences.
              </p>
            </div>

            {/* Team Member 3 */}
            <div class="text-center">
              <div class="w-32 h-32 bg-gradient-to-br from-purple-400 to-pink-500 rounded-full mx-auto mb-4 flex items-center justify-center">
                <span class="text-white text-2xl font-bold">MR</span>
              </div>
              <h3 class="text-xl font-semibold text-gray-900 dark:text-white mb-2">
                Mike Rodriguez
              </h3>
              <p class="text-blue-600 dark:text-blue-400 mb-2">Community Manager</p>
              <p class="text-gray-600 dark:text-gray-300 text-sm">
                Route setter and climbing coach who keeps our community connected and our route database comprehensive.
              </p>
            </div>
          </div>
        </section>

        {/* CTA Section */}
        <section class="text-center">
          <div class="bg-gradient-to-r from-blue-600 to-purple-600 rounded-xl p-8 md:p-12 text-white">
            <h2 class="text-3xl font-bold mb-4">
              Ready to Start Your Climbing Journey?
            </h2>
            <p class="text-xl text-blue-100 mb-8 max-w-2xl mx-auto">
              Join thousands of climbers who trust ClimbEdge to track their progress and discover new adventures.
            </p>
            <div class="flex flex-col sm:flex-row gap-4 justify-center">
              <Link 
                href="/register" 
                class="bg-white text-blue-600 px-8 py-3 rounded-lg font-semibold hover:bg-blue-50 transition-colors"
              >
                Get Started Free
              </Link>
              <Link 
                href="/contact-us" 
                class="border-2 border-white text-white px-8 py-3 rounded-lg font-semibold hover:bg-white hover:text-blue-600 transition-colors"
              >
                Contact Us
              </Link>
            </div>
          </div>
        </section>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: "About Us - ClimbEdge",
  meta: [
    {
      name: "description",
      content: "Learn about ClimbEdge's mission to empower climbers worldwide with comprehensive tracking tools and community features.",
    },
  ],
};
