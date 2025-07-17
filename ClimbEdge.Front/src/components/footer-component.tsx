import { component$ } from '@builder.io/qwik';
import { Link } from '@builder.io/qwik-city';

export default component$(() => {
    const currentYear = new Date().getFullYear();

    return (
        <footer class="bg-slate-900 border-t border-slate-800">
            <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
                <div class="grid grid-cols-1 md:grid-cols-4 gap-8">
                    {/* Brand Section */}
                    <div class="md:col-span-2">
                        <div class="flex items-center space-x-3 mb-4">
                            <div class="w-8 h-8 bg-gradient-to-br from-emerald-400 to-cyan-500 rounded-lg flex items-center justify-center">
                                <svg class="w-5 h-5 text-white" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M12 2L14.09 8.26L20 9L15 14L16.18 20L12 17.27L7.82 20L9 14L4 9L9.91 8.26L12 2Z" />
                                </svg>
                            </div>
                            <div>
                                <h3 class="text-lg font-bold text-white">ClimbEdge</h3>
                                <p class="text-sm text-slate-400">Smart Climbing Technology</p>
                            </div>
                        </div>
                        <p class="text-slate-400 mb-6 max-w-md">
                            Revolutionary climbing training system that combines hardware sensors
                            with intelligent software to enhance your climbing experience on a digital MoonBoard.
                        </p>
                        <div class="flex items-center space-x-4">
                            <div class="flex items-center space-x-2">
                                <div class="w-2 h-2 bg-emerald-400 rounded-full"></div>
                                <span class="text-sm text-slate-400">216 Smart Holds</span>
                            </div>
                            <div class="flex items-center space-x-2">
                                <div class="w-2 h-2 bg-cyan-400 rounded-full"></div>
                                <span class="text-sm text-slate-400">Real-time Tracking</span>
                            </div>
                        </div>
                    </div>

                    {/* Navigation Links */}
                    <div>
                        <h4 class="text-white font-semibold mb-4">Navigation</h4>
                        <ul class="space-y-2">
                            <li>
                                <Link href="/dashboard" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Dashboard
                                </Link>
                            </li>
                            <li>
                                <Link href="/board" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Board
                                </Link>
                            </li>
                            <li>
                                <Link href="/training" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Training
                                </Link>
                            </li>
                            <li>
                                <Link href="/mountaineering" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Mountaineering
                                </Link>
                            </li>
                        </ul>
                    </div>

                    {/* Support Links */}
                    <div>
                        <h4 class="text-white font-semibold mb-4">Support</h4>
                        <ul class="space-y-2">
                            <li>
                                <Link href="/help" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Help Center
                                </Link>
                            </li>
                            <li>
                                <Link href="/about" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    About
                                </Link>
                            </li>
                            <li>
                                <a href="mailto:support@climbedge.com" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Contact
                                </a>
                            </li>
                            <li>
                                <a href="#" class="text-slate-400 hover:text-emerald-400 transition-colors">
                                    Documentation
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>

                {/* Bottom Section */}
                <div class="border-t border-slate-800 mt-8 pt-8">
                    <div class="flex flex-col md:flex-row justify-between items-center space-y-4 md:space-y-0">
                        <div class="flex items-center space-x-6">
                            <p class="text-slate-400 text-sm">
                                © {currentYear} ClimbEdge. All rights reserved.
                            </p>
                            <div class="hidden md:flex items-center space-x-4">
                                <Link href="/privacy" class="text-slate-500 hover:text-slate-400 text-sm transition-colors">
                                    Privacy
                                </Link>
                                <Link href="/terms" class="text-slate-500 hover:text-slate-400 text-sm transition-colors">
                                    Terms
                                </Link>
                            </div>
                        </div>

                        {/* Technology Stack */}
                        <div class="flex items-center space-x-4 text-slate-500">
                            <div class="flex items-center space-x-2">
                                <svg class="w-4 h-4" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M12 0C5.374 0 0 5.373 0 12 0 17.302 3.438 21.8 8.207 23.387c.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23A11.509 11.509 0 0112 5.803c1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576C20.566 21.797 24 17.3 24 12c0-6.627-5.373-12-12-12z" />
                                </svg>
                                <span class="text-xs">Open Source</span>
                            </div>
                            <div class="flex items-center space-x-2">
                                <svg class="w-4 h-4" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5" />
                                </svg>
                                <span class="text-xs">Made with QwikCity</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
});