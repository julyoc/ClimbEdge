import { component$, useSignal } from '@builder.io/qwik';
import { Form, globalAction$, zod$, z } from '@builder.io/qwik-city';

const notificationsSchema = z.object({
    emailNotifications: z.boolean(),
    pushNotifications: z.boolean(),
    // Específicas de email
    emailNewFollower: z.boolean(),
    emailNewMessage: z.boolean(),
    emailClimbingInvite: z.boolean(),
    emailRouteComments: z.boolean(),
    emailSystemUpdates: z.boolean(),
    emailMarketing: z.boolean(),
    // Específicas de push
    pushNewFollower: z.boolean(),
    pushNewMessage: z.boolean(),
    pushClimbingInvite: z.boolean(),
    pushRouteComments: z.boolean(),
    pushSystemUpdates: z.boolean(),
    // Configuraciones adicionales
    notificationFrequency: z.enum(['immediate', 'daily', 'weekly']),
    quietHoursEnabled: z.boolean(),
    quietHoursStart: z.string(),
    quietHoursEnd: z.string(),
});

export const useUpdateNotifications = globalAction$(
    async (data, { fail }) => {
        try {
            console.log('Updating notification settings:', data);
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            return {
                success: true,
                message: 'Configuración de notificaciones actualizada'
            };
        } catch {
            return fail(500, {
                message: 'Error al actualizar las notificaciones'
            });
        }
    },
    zod$(notificationsSchema)
);

export default component$(() => {
    const updateNotifications = useUpdateNotifications();
    
    const notificationSettings = useSignal({
        emailNotifications: true,
        pushNotifications: true,
        // Email específicas
        emailNewFollower: true,
        emailNewMessage: true,
        emailClimbingInvite: true,
        emailRouteComments: false,
        emailSystemUpdates: true,
        emailMarketing: false,
        // Push específicas
        pushNewFollower: true,
        pushNewMessage: true,
        pushClimbingInvite: true,
        pushRouteComments: true,
        pushSystemUpdates: true,
        // Configuraciones adicionales
        notificationFrequency: 'immediate' as const,
        quietHoursEnabled: false,
        quietHoursStart: '22:00',
        quietHoursEnd: '08:00',
    });

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Configuración de Notificaciones</h2>
                <p class="mt-1 text-gray-600">
                    Controla qué notificaciones quieres recibir y cómo
                </p>
            </div>

            <Form action={updateNotifications} class="space-y-8">
                {/* Configuración General */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Configuración General</h3>
                    
                    <div class="space-y-4">
                        <div class="flex items-center justify-between p-4 bg-blue-50 rounded-lg border-l-4 border-blue-400">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Notificaciones por Email</h4>
                                <p class="text-sm text-gray-600">
                                    Recibir notificaciones en tu correo electrónico
                                </p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailNotifications"
                                    checked={notificationSettings.value.emailNotifications}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-4 bg-green-50 rounded-lg border-l-4 border-green-400">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Notificaciones Push</h4>
                                <p class="text-sm text-gray-600">
                                    Recibir notificaciones en tiempo real en tu dispositivo
                                </p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushNotifications"
                                    checked={notificationSettings.value.pushNotifications}
                                    class="sr-only peer"
                                />
                                <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Notificaciones por Email */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Notificaciones por Email</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Nuevos Seguidores</h4>
                                <p class="text-xs text-gray-500">Cuando alguien comience a seguirte</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailNewFollower"
                                    checked={notificationSettings.value.emailNewFollower}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Mensajes Privados</h4>
                                <p class="text-xs text-gray-500">Cuando recibas un mensaje nuevo</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailNewMessage"
                                    checked={notificationSettings.value.emailNewMessage}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Invitaciones a Escalar</h4>
                                <p class="text-xs text-gray-500">Invitaciones a sesiones de escalada</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailClimbingInvite"
                                    checked={notificationSettings.value.emailClimbingInvite}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Comentarios en Rutas</h4>
                                <p class="text-xs text-gray-500">Comentarios en tus rutas publicadas</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailRouteComments"
                                    checked={notificationSettings.value.emailRouteComments}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Actualizaciones del Sistema</h4>
                                <p class="text-xs text-gray-500">Cambios importantes y mantenimiento</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailSystemUpdates"
                                    checked={notificationSettings.value.emailSystemUpdates}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Marketing</h4>
                                <p class="text-xs text-gray-500">Promociones y novedades de ClimbEdge</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="emailMarketing"
                                    checked={notificationSettings.value.emailMarketing}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Notificaciones Push */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Notificaciones Push</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Nuevos Seguidores</h4>
                                <p class="text-xs text-gray-500">Notificación instantánea</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushNewFollower"
                                    checked={notificationSettings.value.pushNewFollower}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Mensajes Privados</h4>
                                <p class="text-xs text-gray-500">Notificación instantánea</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushNewMessage"
                                    checked={notificationSettings.value.pushNewMessage}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Invitaciones a Escalar</h4>
                                <p class="text-xs text-gray-500">Notificación instantánea</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushClimbingInvite"
                                    checked={notificationSettings.value.pushClimbingInvite}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Comentarios en Rutas</h4>
                                <p class="text-xs text-gray-500">Notificación instantánea</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushRouteComments"
                                    checked={notificationSettings.value.pushRouteComments}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>

                        <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                            <div class="flex-1">
                                <h4 class="text-sm font-medium text-gray-900">Actualizaciones del Sistema</h4>
                                <p class="text-xs text-gray-500">Notificación instantánea</p>
                            </div>
                            <label class="relative inline-flex items-center cursor-pointer">
                                <input
                                    type="checkbox"
                                    name="pushSystemUpdates"
                                    checked={notificationSettings.value.pushSystemUpdates}
                                    class="sr-only peer"
                                />
                                <div class="w-8 h-4 bg-gray-200 peer-focus:outline-none peer-focus:ring-2 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all peer-checked:bg-blue-600"></div>
                            </label>
                        </div>
                    </div>
                </div>

                {/* Configuraciones Adicionales */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Configuraciones Adicionales</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="notificationFrequency" class="block text-sm font-medium text-gray-700">
                                Frecuencia de Notificaciones
                            </label>
                            <select
                                name="notificationFrequency"
                                id="notificationFrequency"
                                value={notificationSettings.value.notificationFrequency}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                <option value="immediate">Inmediata</option>
                                <option value="daily">Resumen Diario</option>
                                <option value="weekly">Resumen Semanal</option>
                            </select>
                        </div>

                        <div class="space-y-4">
                            <div class="flex items-center justify-between">
                                <div>
                                    <h4 class="text-sm font-medium text-gray-900">Horario Silencioso</h4>
                                    <p class="text-xs text-gray-500">No recibir notificaciones push durante estas horas</p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        name="quietHoursEnabled"
                                        checked={notificationSettings.value.quietHoursEnabled}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>

                            {notificationSettings.value.quietHoursEnabled && (
                                <div class="flex space-x-3">
                                    <div class="flex-1">
                                        <label for="quietHoursStart" class="block text-xs font-medium text-gray-700">
                                            Desde
                                        </label>
                                        <input
                                            type="time"
                                            name="quietHoursStart"
                                            id="quietHoursStart"
                                            value={notificationSettings.value.quietHoursStart}
                                            class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                        />
                                    </div>
                                    <div class="flex-1">
                                        <label for="quietHoursEnd" class="block text-xs font-medium text-gray-700">
                                            Hasta
                                        </label>
                                        <input
                                            type="time"
                                            name="quietHoursEnd"
                                            id="quietHoursEnd"
                                            value={notificationSettings.value.quietHoursEnd}
                                            class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                        />
                                    </div>
                                </div>
                            )}
                        </div>
                    </div>
                </div>

                {/* Mensajes de Estado */}
                {updateNotifications.value?.success && (
                    <div class="rounded-md bg-green-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-green-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-green-800">
                                    {updateNotifications.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {updateNotifications.value?.failed && (
                    <div class="rounded-md bg-red-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-red-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-red-800">
                                    {updateNotifications.value.message}
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
                        disabled={updateNotifications.isRunning}
                        class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {updateNotifications.isRunning ? 'Guardando...' : 'Guardar Configuración'}
                    </button>
                </div>
            </Form>
        </div>
    );
});
