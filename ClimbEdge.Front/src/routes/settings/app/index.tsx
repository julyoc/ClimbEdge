import { component$, useSignal } from '@builder.io/qwik';
import { Form, globalAction$, zod$, z } from '@builder.io/qwik-city';

const appSchema = z.object({
    theme: z.enum(['light', 'dark', 'auto']),
    compactMode: z.boolean(),
    showTutorials: z.boolean(),
    autoSave: z.boolean(),
    soundEffects: z.boolean(),
    animations: z.boolean(),
    dataUsage: z.enum(['minimal', 'balanced', 'full']),
    cacheSize: z.enum(['small', 'medium', 'large']),
    offlineMode: z.boolean(),
    debugMode: z.boolean(),
});

export const useUpdateApp = globalAction$(
    async (data, { fail }) => {
        try {
            console.log('Updating app settings:', data);
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            return {
                success: true,
                message: 'Configuración de aplicación actualizada'
            };
        } catch {
            return fail(500, {
                message: 'Error al actualizar la configuración de aplicación'
            });
        }
    },
    zod$(appSchema)
);

export default component$(() => {
    const updateApp = useUpdateApp();
    
    const appSettings = useSignal({
        theme: 'light',
        compactMode: false,
        showTutorials: true,
        autoSave: true,
        soundEffects: false,
        animations: true,
        dataUsage: 'balanced',
        cacheSize: 'medium',
        offlineMode: false,
        debugMode: false,
    });

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Configuración de Aplicación</h2>
                <p class="mt-1 text-gray-600">
                    Personaliza la apariencia y comportamiento de ClimbEdge
                </p>
            </div>

            <Form action={updateApp} class="space-y-8">
                {/* Apariencia */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Apariencia</h3>
                    
                    <div class="space-y-6">
                        <div>
                            <label class="block text-sm font-medium text-gray-700 mb-4">
                                Tema
                            </label>
                            <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
                                <label class="relative flex cursor-pointer rounded-lg border p-4 focus-within:ring-2 focus-within:ring-blue-500">
                                    <input
                                        type="radio"
                                        name="theme"
                                        value="light"
                                        checked={appSettings.value.theme === 'light'}
                                        class="sr-only"
                                    />
                                    <div class="flex-1">
                                        <div class="flex items-center">
                                            <div class="text-sm">
                                                <div class="font-medium text-gray-900">☀️ Claro</div>
                                                <div class="text-gray-500">
                                                    <p class="text-xs">Tema claro tradicional</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="h-5 w-5 text-blue-600 flex-shrink-0">
                                        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
                                            <circle cx="10" cy="10" r="3" class={appSettings.value.theme === 'light' ? 'block' : 'hidden'} />
                                        </svg>
                                    </div>
                                </label>

                                <label class="relative flex cursor-pointer rounded-lg border p-4 focus-within:ring-2 focus-within:ring-blue-500">
                                    <input
                                        type="radio"
                                        name="theme"
                                        value="dark"
                                        checked={appSettings.value.theme === 'dark'}
                                        class="sr-only"
                                    />
                                    <div class="flex-1">
                                        <div class="flex items-center">
                                            <div class="text-sm">
                                                <div class="font-medium text-gray-900">🌙 Oscuro</div>
                                                <div class="text-gray-500">
                                                    <p class="text-xs">Perfecto para la noche</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="h-5 w-5 text-blue-600 flex-shrink-0">
                                        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
                                            <circle cx="10" cy="10" r="3" class={appSettings.value.theme === 'dark' ? 'block' : 'hidden'} />
                                        </svg>
                                    </div>
                                </label>

                                <label class="relative flex cursor-pointer rounded-lg border p-4 focus-within:ring-2 focus-within:ring-blue-500">
                                    <input
                                        type="radio"
                                        name="theme"
                                        value="auto"
                                        checked={appSettings.value.theme === 'auto'}
                                        class="sr-only"
                                    />
                                    <div class="flex-1">
                                        <div class="flex items-center">
                                            <div class="text-sm">
                                                <div class="font-medium text-gray-900">🔄 Automático</div>
                                                <div class="text-gray-500">
                                                    <p class="text-xs">Según tu sistema</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="h-5 w-5 text-blue-600 flex-shrink-0">
                                        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
                                            <circle cx="10" cy="10" r="3" class={appSettings.value.theme === 'auto' ? 'block' : 'hidden'} />
                                        </svg>
                                    </div>
                                </label>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                                <div class="flex-1">
                                    <h4 class="text-sm font-medium text-gray-900">Modo Compacto</h4>
                                    <p class="text-xs text-gray-500">Reduce el espaciado y tamaño de elementos</p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        name="compactMode"
                                        checked={appSettings.value.compactMode}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>

                            <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                                <div class="flex-1">
                                    <h4 class="text-sm font-medium text-gray-900">Animaciones</h4>
                                    <p class="text-xs text-gray-500">Efectos de transición y animaciones suaves</p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        name="animations"
                                        checked={appSettings.value.animations}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Experiencia de Usuario */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Experiencia de Usuario</h3>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Mostrar Tutoriales</h4>
                                <p class="text-xs text-gray-500">Guías y consejos para nuevas funciones</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showTutorials"
                                    checked={appSettings.value.showTutorials}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Guardado Automático</h4>
                                <p class="text-xs text-gray-500">Guarda cambios automáticamente mientras escribes</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="autoSave"
                                    checked={appSettings.value.autoSave}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Efectos de Sonido</h4>
                                <p class="text-xs text-gray-500">Sonidos para interacciones y notificaciones</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="soundEffects"
                                    checked={appSettings.value.soundEffects}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Rendimiento y Datos */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Rendimiento y Datos</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="dataUsage" class="block text-sm font-medium text-gray-700">
                                Uso de Datos
                            </label>
                            <select
                                name="dataUsage"
                                id="dataUsage"
                                value={appSettings.value.dataUsage}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                <option value="minimal">Mínimo - Solo lo esencial</option>
                                <option value="balanced">Balanceado - Calidad y eficiencia</option>
                                <option value="full">Completo - Máxima calidad</option>
                            </select>
                            <p class="mt-1 text-xs text-gray-500">
                                Controla cuántos datos se descargan automáticamente
                            </p>
                        </div>

                        <div>
                            <label for="cacheSize" class="block text-sm font-medium text-gray-700">
                                Tamaño de Caché
                            </label>
                            <select
                                name="cacheSize"
                                id="cacheSize"
                                value={appSettings.value.cacheSize}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                <option value="small">Pequeño - 50 MB</option>
                                <option value="medium">Mediano - 200 MB</option>
                                <option value="large">Grande - 500 MB</option>
                            </select>
                            <p class="mt-1 text-xs text-gray-500">
                                Espacio para almacenar datos temporalmente
                            </p>
                        </div>
                    </div>

                    <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                        <div class="flex-1">
                            <h4 class="text-sm font-medium text-gray-900">Modo Offline</h4>
                            <p class="text-xs text-gray-500">Permite usar funciones básicas sin conexión</p>
                        </div>
                        <label class="relative inline-flex items-center cursor-pointer">
                            <input
                                type="checkbox"
                                name="offlineMode"
                                checked={appSettings.value.offlineMode}
                                class="sr-only peer"
                            />
                            <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                        </label>
                    </div>
                </div>

                {/* Configuraciones Avanzadas */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Configuraciones Avanzadas</h3>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-3 border border-yellow-200 bg-yellow-50 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Modo Debug</h4>
                                <p class="text-xs text-gray-500">
                                    Muestra información técnica adicional. Solo para desarrolladores.
                                </p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="debugMode"
                                    checked={appSettings.value.debugMode}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-yellow-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-yellow-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Información del Sistema */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Información del Sistema</h3>
                    
                    <div class="bg-gray-50 rounded-lg p-4">
                        <div class="grid grid-cols-1 md:grid-cols-2 gap-4 text-sm">
                            <div>
                                <span class="text-gray-600">Versión de la App: </span>
                                <span class="font-mono">v1.0.0</span>
                            </div>
                            <div>
                                <span class="text-gray-600">Última Actualización: </span>
                                <span class="font-mono">2025-07-18</span>
                            </div>
                            <div>
                                <span class="text-gray-600">Navegador: </span>
                                <span class="font-mono">Chrome 126.0</span>
                            </div>
                            <div>
                                <span class="text-gray-600">Sistema: </span>
                                <span class="font-mono">Windows 10</span>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Acciones de Mantenimiento */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Mantenimiento</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <button
                            type="button"
                            class="flex items-center justify-center px-4 py-3 border border-gray-300 rounded-lg text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                        >
                            <svg class="h-5 w-5 mr-2 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                            </svg>
                            Limpiar Caché
                        </button>

                        <button
                            type="button"
                            class="flex items-center justify-center px-4 py-3 border border-gray-300 rounded-lg text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                        >
                            <svg class="h-5 w-5 mr-2 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                            </svg>
                            Exportar Configuración
                        </button>
                    </div>
                </div>

                {/* Mensajes de Estado */}
                {updateApp.value?.success && (
                    <div class="rounded-md bg-green-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-green-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-green-800">
                                    {updateApp.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {updateApp.value?.failed && (
                    <div class="rounded-md bg-red-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-red-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-red-800">
                                    {updateApp.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {/* Botones */}
                <div class="flex justify-end space-x-3 pt-6 border-t border-gray-200">
                    <button
                        type="button"
                        class="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                    >
                        Restablecer
                    </button>
                    <button
                        type="submit"
                        disabled={updateApp.isRunning}
                        class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {updateApp.isRunning ? 'Guardando...' : 'Guardar Configuración'}
                    </button>
                </div>
            </Form>
        </div>
    );
});
