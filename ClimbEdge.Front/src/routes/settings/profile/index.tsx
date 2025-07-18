import { component$, useSignal, $ } from '@builder.io/qwik';
import { Form, globalAction$, zod$, z } from '@builder.io/qwik-city';
import { useAuth } from '~/contexts/auth.context';

// Schema de validación
const profileSchema = z.object({
    firstName: z.string().min(1, 'El nombre es requerido').max(100),
    lastName: z.string().min(1, 'El apellido es requerido').max(100),
    dateOfBirth: z.string().optional(),
    bio: z.string().max(1000).optional(),
    website: z.string().url().optional().or(z.literal('')),
    location: z.string().max(200).optional(),
    // Datos específicos de escalada
    climbingExperienceLevel: z.string().optional(),
    preferredClimbingStyle: z.string().optional(),
    emergencyContact: z.string().max(25).optional(),
    emergencyContactName: z.string().max(100).optional(),
});

export const useUpdateProfile = globalAction$(
    async (data, { fail }) => {
        try {
            // TODO: Implementar llamada a la API
            console.log('Updating profile with data:', data);
            
            // Simular delay de API
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            return {
                success: true,
                message: 'Perfil actualizado correctamente'
            };
        } catch {
            return fail(500, {
                message: 'Error al actualizar el perfil'
            });
        }
    },
    zod$(profileSchema)
);

export default component$(() => {
    const { user } = useAuth();
    const updateProfile = useUpdateProfile();
    const profilePictureFile = useSignal<File | null>(null);

    const experienceLevels = [
        { value: '', label: 'Seleccionar nivel' },
        { value: 'beginner', label: 'Principiante' },
        { value: 'intermediate', label: 'Intermedio' },
        { value: 'advanced', label: 'Avanzado' },
        { value: 'expert', label: 'Experto' },
    ];

    const climbingStyles = [
        { value: '', label: 'Seleccionar estilo' },
        { value: 'sport', label: 'Escalada Deportiva' },
        { value: 'trad', label: 'Escalada Tradicional' },
        { value: 'bouldering', label: 'Boulder' },
        { value: 'alpine', label: 'Escalada Alpina' },
        { value: 'ice', label: 'Escalada en Hielo' },
        { value: 'mixed', label: 'Mixto' },
    ];

    const handleProfilePictureChange = $((event: Event) => {
        const target = event.target as HTMLInputElement;
        const file = target.files?.[0];
        if (file) {
            profilePictureFile.value = file;
        }
    });

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Perfil Personal</h2>
                <p class="mt-1 text-gray-600">
                    Actualiza tu información personal y datos de escalada
                </p>
            </div>

            <Form action={updateProfile} class="space-y-8">
                {/* Foto de Perfil */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Foto de Perfil</h3>
                    <div class="flex items-center space-x-4">
                        <div class="w-20 h-20 bg-blue-600 rounded-full flex items-center justify-center">
                            <span class="text-white text-2xl font-medium">
                                {user.value?.firstName?.[0] || user.value?.email?.[0] || 'U'}
                            </span>
                        </div>
                        <div>
                            <input
                                type="file"
                                accept="image/*"
                                onChange$={handleProfilePictureChange}
                                class="hidden"
                                id="profile-picture"
                            />
                            <label
                                for="profile-picture"
                                class="inline-flex items-center px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 cursor-pointer"
                            >
                                Cambiar foto
                            </label>
                            <p class="mt-1 text-xs text-gray-500">
                                PNG, JPG hasta 10MB
                            </p>
                        </div>
                    </div>
                </div>

                {/* Información Personal */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Información Personal</h3>
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="firstName" class="block text-sm font-medium text-gray-700">
                                Nombre *
                            </label>
                            <input
                                type="text"
                                name="firstName"
                                id="firstName"
                                value={user.value?.firstName || ''}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            />
                        </div>

                        <div>
                            <label for="lastName" class="block text-sm font-medium text-gray-700">
                                Apellido *
                            </label>
                            <input
                                type="text"
                                name="lastName"
                                id="lastName"
                                value={user.value?.lastName || ''}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            />
                        </div>

                        <div>
                            <label for="dateOfBirth" class="block text-sm font-medium text-gray-700">
                                Fecha de Nacimiento
                            </label>
                            <input
                                type="date"
                                name="dateOfBirth"
                                id="dateOfBirth"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            />
                        </div>

                        <div>
                            <label for="location" class="block text-sm font-medium text-gray-700">
                                Ubicación
                            </label>
                            <input
                                type="text"
                                name="location"
                                id="location"
                                placeholder="Ciudad, País"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            />
                        </div>

                        <div class="md:col-span-2">
                            <label for="website" class="block text-sm font-medium text-gray-700">
                                Sitio Web
                            </label>
                            <input
                                type="url"
                                name="website"
                                id="website"
                                placeholder="https://tu-sitio-web.com"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            />
                        </div>

                        <div class="md:col-span-2">
                            <label for="bio" class="block text-sm font-medium text-gray-700">
                                Biografía
                            </label>
                            <textarea
                                name="bio"
                                id="bio"
                                rows={4}
                                placeholder="Cuéntanos sobre ti, tu experiencia en escalada y tus objetivos..."
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                maxLength={1000}
                            ></textarea>
                            <p class="mt-1 text-xs text-gray-500">Máximo 1000 caracteres</p>
                        </div>
                    </div>
                </div>

                {/* Información de Escalada */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Información de Escalada</h3>
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="climbingExperienceLevel" class="block text-sm font-medium text-gray-700">
                                Nivel de Experiencia
                            </label>
                            <select
                                name="climbingExperienceLevel"
                                id="climbingExperienceLevel"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                {experienceLevels.map((level) => (
                                    <option key={level.value} value={level.value}>
                                        {level.label}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label for="preferredClimbingStyle" class="block text-sm font-medium text-gray-700">
                                Estilo Preferido
                            </label>
                            <select
                                name="preferredClimbingStyle"
                                id="preferredClimbingStyle"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                {climbingStyles.map((style) => (
                                    <option key={style.value} value={style.value}>
                                        {style.label}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label for="emergencyContactName" class="block text-sm font-medium text-gray-700">
                                Contacto de Emergencia
                            </label>
                            <input
                                type="text"
                                name="emergencyContactName"
                                id="emergencyContactName"
                                placeholder="Nombre del contacto"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            />
                        </div>

                        <div>
                            <label for="emergencyContact" class="block text-sm font-medium text-gray-700">
                                Teléfono de Emergencia
                            </label>
                            <input
                                type="tel"
                                name="emergencyContact"
                                id="emergencyContact"
                                placeholder="+593 99 999 9999"
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            />
                        </div>
                    </div>
                </div>

                {/* Mensajes */}
                {updateProfile.value?.success && (
                    <div class="rounded-md bg-green-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-green-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-green-800">
                                    {updateProfile.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {updateProfile.value?.failed && (
                    <div class="rounded-md bg-red-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-red-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-red-800">
                                    {updateProfile.value.message}
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
                        disabled={updateProfile.isRunning}
                        class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {updateProfile.isRunning ? 'Guardando...' : 'Guardar Cambios'}
                    </button>
                </div>
            </Form>
        </div>
    );
});
