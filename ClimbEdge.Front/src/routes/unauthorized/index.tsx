import { component$ } from "@builder.io/qwik";
import { Link } from "@builder.io/qwik-city";
import { useTheme } from "~/stores/theme";

export default component$(() => {
    const themeStore = useTheme();

    return (
        <div class={`min-h-screen flex items-center justify-center ${
            themeStore.theme.value === 'dark' 
                ? 'bg-gray-900 text-white' 
                : 'bg-gray-50 text-gray-900'
        }`}>
            <div class="max-w-md w-full space-y-8 text-center">
                {/* Icono de acceso denegado */}
                <div class="mx-auto flex items-center justify-center h-24 w-24 rounded-full bg-red-100 dark:bg-red-900/20">
                    <svg 
                        class="h-12 w-12 text-red-600 dark:text-red-400" 
                        fill="none" 
                        stroke="currentColor" 
                        viewBox="0 0 24 24"
                    >
                        <path 
                            stroke-linecap="round" 
                            stroke-linejoin="round" 
                            stroke-width="2" 
                            d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L4.082 16.5c-.77.833.192 2.5 1.732 2.5z"
                        />
                    </svg>
                </div>

                {/* Título */}
                <div class="space-y-4">
                    <h1 class="text-4xl font-bold text-red-600 dark:text-red-400">
                        403
                    </h1>
                    <h2 class={`text-2xl font-semibold ${
                        themeStore.theme.value === 'dark' 
                            ? 'text-gray-200' 
                            : 'text-gray-800'
                    }`}>
                        Acceso Denegado
                    </h2>
                    <p class={`text-lg ${
                        themeStore.theme.value === 'dark' 
                            ? 'text-gray-400' 
                            : 'text-gray-600'
                    }`}>
                        No tienes los permisos necesarios para acceder a esta página.
                    </p>
                </div>

                {/* Información adicional */}
                <div class={`p-4 rounded-lg ${
                    themeStore.theme.value === 'dark' 
                        ? 'bg-gray-800 border border-gray-700' 
                        : 'bg-white border border-gray-200'
                } shadow-md`}>
                    <h3 class={`text-lg font-medium mb-2 ${
                        themeStore.theme.value === 'dark' 
                            ? 'text-gray-200' 
                            : 'text-gray-800'
                    }`}>
                        ¿Qué puedes hacer?
                    </h3>
                    <ul class={`text-sm space-y-2 ${
                        themeStore.theme.value === 'dark' 
                            ? 'text-gray-400' 
                            : 'text-gray-600'
                    }`}>
                        <li>• Contacta a tu administrador para solicitar acceso</li>
                        <li>• Verifica que estás usando la cuenta correcta</li>
                        <li>• Regresa a la página principal</li>
                    </ul>
                </div>

                {/* Botones de acción */}
                <div class="space-y-4">
                    <Link 
                        href="/dashboard" 
                        class={`inline-flex items-center px-6 py-3 border border-transparent text-base font-medium rounded-md transition-all duration-200 ${
                            themeStore.theme.value === 'dark'
                                ? 'text-white bg-blue-600 hover:bg-blue-700 focus:ring-blue-500'
                                : 'text-white bg-blue-600 hover:bg-blue-700 focus:ring-blue-500'
                        } focus:outline-none focus:ring-2 focus:ring-offset-2 shadow-lg hover:shadow-xl transform hover:-translate-y-0.5`}
                    >
                        <svg 
                            class="w-5 h-5 mr-2" 
                            fill="none" 
                            stroke="currentColor" 
                            viewBox="0 0 24 24"
                        >
                            <path 
                                stroke-linecap="round" 
                                stroke-linejoin="round" 
                                stroke-width="2" 
                                d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                            />
                        </svg>
                        Ir al Dashboard
                    </Link>

                    <div class="text-center">
                        <Link 
                            href="/" 
                            class={`text-sm font-medium transition-colors duration-200 ${
                                themeStore.theme.value === 'dark'
                                    ? 'text-blue-400 hover:text-blue-300'
                                    : 'text-blue-600 hover:text-blue-500'
                            }`}
                        >
                            ← Volver al inicio
                        </Link>
                    </div>
                </div>

                {/* Footer informativo */}
                <div class={`text-xs mt-8 p-3 rounded-lg ${
                    themeStore.theme.value === 'dark' 
                        ? 'bg-gray-800/50 text-gray-500' 
                        : 'bg-gray-100 text-gray-500'
                }`}>
                    <p>
                        Si crees que esto es un error, contacta al soporte técnico.
                    </p>
                    <p class="mt-1">
                        Código de error: 403 - INSUFFICIENT_PERMISSIONS
                    </p>
                </div>
            </div>
        </div>
    );
});
