import { component$, useSignal } from '@builder.io/qwik';
import { Form, globalAction$, zod$, z } from '@builder.io/qwik-city';

const privacySchema = z.object({
    isPublic: z.boolean(),
    showEmail: z.boolean(),
    showLocation: z.boolean(),
    showDateOfBirth: z.boolean(),
    showClimbingStats: z.boolean(),
    allowMessages: z.boolean(),
    allowFollowers: z.boolean(),
    showOnlineStatus: z.boolean(),
});

export const useUpdatePrivacy = globalAction$(
    async (data, { fail }) => {
        try {
            console.log('Updating privacy settings:', data);
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            return {
                success: true,
                message: 'Configuración de privacidad actualizada'
            };
        } catch {
            return fail(500, {
                message: 'Error al actualizar la configuración de privacidad'
            });
        }
    },
    zod$(privacySchema)
);

export default component$(() => {
    const updatePrivacy = useUpdatePrivacy();
    
    const privacySettings = useSignal({
        isPublic: true,
        showEmail: false,
        showLocation: true,
        showDateOfBirth: false,
        showClimbingStats: true,
        allowMessages: true,
        allowFollowers: true,
        showOnlineStatus: true,
    });

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Configuración de Privacidad</h2>
                <p class="mt-1 text-gray-600">
                    Controla qué información es visible para otros usuarios
                </p>
            </div>

            <Form action={updatePrivacy} class="space-y-8">
                {/* Visibilidad del Perfil */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Visibilidad del Perfil</h3>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-4 bg-gray-50 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Perfil Público</h4>
                                <p class="text-sm text-gray-600">
                                    Tu perfil será visible para todos los usuarios de ClimbEdge
                                </p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="isPublic"
                                    checked={privacySettings.value.isPublic}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Información Visible */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Información Visible</h3>
                    <p class="text-sm text-gray-600">
                        Selecciona qué información quieres mostrar en tu perfil público
                    </p>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Correo Electrónico</h4>
                                <p class="text-xs text-gray-500">Mostrar tu dirección de email</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showEmail"
                                    checked={privacySettings.value.showEmail}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Ubicación</h4>
                                <p class="text-xs text-gray-500">Mostrar tu ciudad y país</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showLocation"
                                    checked={privacySettings.value.showLocation}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Fecha de Nacimiento</h4>
                                <p class="text-xs text-gray-500">Mostrar tu edad</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showDateOfBirth"
                                    checked={privacySettings.value.showDateOfBirth}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Estadísticas de Escalada</h4>
                                <p class="text-xs text-gray-500">Mostrar nivel de experiencia y rutas completadas</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showClimbingStats"
                                    checked={privacySettings.value.showClimbingStats}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Interacciones Sociales */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Interacciones Sociales</h3>
                    <p class="text-sm text-gray-600">
                        Controla cómo otros usuarios pueden interactuar contigo
                    </p>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Permitir Mensajes</h4>
                                <p class="text-xs text-gray-500">Otros usuarios pueden enviarte mensajes privados</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="allowMessages"
                                    checked={privacySettings.value.allowMessages}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Permitir Seguidores</h4>
                                <p class="text-xs text-gray-500">Otros usuarios pueden seguir tu actividad</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="allowFollowers"
                                    checked={privacySettings.value.allowFollowers}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Estado en Línea</h4>
                                <p class="text-xs text-gray-500">Mostrar cuando estás conectado</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="showOnlineStatus"
                                    checked={privacySettings.value.showOnlineStatus}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Mensajes de Estado */}
                {updatePrivacy.value?.success && (
                    <div class="rounded-md bg-green-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-green-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-green-800">
                                    {updatePrivacy.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {updatePrivacy.value?.failed && (
                    <div class="rounded-md bg-red-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-red-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-red-800">
                                    {updatePrivacy.value.message}
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
                        Cancelar
                    </button>
                    <button
                        type="submit"
                        disabled={updatePrivacy.isRunning}
                        class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {updatePrivacy.isRunning ? 'Guardando...' : 'Guardar Configuración'}
                    </button>
                </div>
            </Form>
        </div>
    );
});
