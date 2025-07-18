import { component$, useSignal, $ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';
import { authService, type ChangePasswordRequestDTO } from '~/services/auth.service';

export default component$(() => {
    const { isAuthenticated } = useAuth();

    const formData = useSignal<ChangePasswordRequestDTO>({
        currentPassword: '',
        newPassword: '',
        confirmPassword: '',
    });

    const error = useSignal<string>('');
    const success = useSignal<string>('');
    const isLoading = useSignal<boolean>(false);

    const validateForm = $(() => {
        const { currentPassword, newPassword, confirmPassword } = formData.value;

        if (!currentPassword || !newPassword || !confirmPassword) {
            return 'Todos los campos son obligatorios';
        }

        if (newPassword !== confirmPassword) {
            return 'Las contraseñas nuevas no coinciden';
        }

        if (newPassword.length < 6) {
            return 'La nueva contraseña debe tener al menos 6 caracteres';
        }

        if (currentPassword === newPassword) {
            return 'La nueva contraseña debe ser diferente a la actual';
        }

        return null;
    });

    const handleSubmit = $(async (e: SubmitEvent) => {
        e.preventDefault();

        const validationError = await validateForm();
        if (validationError) {
            error.value = validationError;
            return;
        }

        isLoading.value = true;
        error.value = '';
        success.value = '';

        try {
            const response = await authService.changePassword(formData.value);

            if (response.success) {
                success.value = 'Contraseña cambiada exitosamente';
                // Limpiar el formulario
                formData.value = {
                    currentPassword: '',
                    newPassword: '',
                    confirmPassword: '',
                };
            } else {
                error.value = response.error || 'Error al cambiar la contraseña';
            }
        } catch (err: any) {
            error.value = 'Error de conexión' + (err.message || '');
        } finally {
            isLoading.value = false;
        }
    });

    const handleInputChange = $((field: keyof ChangePasswordRequestDTO, value: string) => {
        formData.value = {
            ...formData.value,
            [field]: value,
        };
    });

    // Redirigir si no está autenticado
    if (!isAuthenticated.value) {
        return (
            <div class="min-h-screen bg-slate-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
                <div class="max-w-md w-full space-y-8">
                    <div class="text-center">
                        <h2 class="mt-6 text-3xl font-extrabold text-gray-900">
                            Acceso Requerido
                        </h2>
                        <p class="mt-2 text-sm text-gray-600">
                            Debes iniciar sesión para cambiar tu contraseña
                        </p>
                        <div class="mt-4">
                            <a
                                href="/login"
                                class="font-medium text-blue-600 hover:text-blue-500"
                            >
                                Iniciar Sesión
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    return (
        <div class="min-h-screen bg-slate-50 py-12 px-4 sm:px-6 lg:px-8">
            <div class="max-w-md mx-auto">
                <div>
                    <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
                        Cambiar Contraseña
                    </h2>
                    <p class="mt-2 text-center text-sm text-gray-600">
                        Ingresa tu contraseña actual y la nueva contraseña
                    </p>
                </div>

                <form class="mt-8 space-y-6" onSubmit$={handleSubmit}>
                    <div class="space-y-4">
                        <div>
                            <label for="currentPassword" class="block text-sm font-medium text-gray-700">
                                Contraseña Actual
                            </label>
                            <input
                                id="currentPassword"
                                name="currentPassword"
                                type="password"
                                autoComplete="current-password"
                                required
                                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                placeholder="Contraseña actual"
                                value={formData.value.currentPassword}
                                onInput$={(e) => handleInputChange('currentPassword', (e.target as HTMLInputElement).value)}
                            />
                        </div>

                        <div>
                            <label for="newPassword" class="block text-sm font-medium text-gray-700">
                                Nueva Contraseña
                            </label>
                            <input
                                id="newPassword"
                                name="newPassword"
                                type="password"
                                autoComplete="new-password"
                                required
                                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                placeholder="Nueva contraseña"
                                value={formData.value.newPassword}
                                onInput$={(e) => handleInputChange('newPassword', (e.target as HTMLInputElement).value)}
                            />
                        </div>

                        <div>
                            <label for="confirmPassword" class="block text-sm font-medium text-gray-700">
                                Confirmar Nueva Contraseña
                            </label>
                            <input
                                id="confirmPassword"
                                name="confirmPassword"
                                type="password"
                                autoComplete="new-password"
                                required
                                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                placeholder="Confirmar nueva contraseña"
                                value={formData.value.confirmPassword}
                                onInput$={(e) => handleInputChange('confirmPassword', (e.target as HTMLInputElement).value)}
                            />
                        </div>
                    </div>

                    {error.value && (
                        <div class="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">
                            {error.value}
                        </div>
                    )}

                    {success.value && (
                        <div class="bg-green-100 border border-green-400 text-green-700 px-4 py-3 rounded">
                            {success.value}
                        </div>
                    )}

                    <div>
                        <button
                            type="submit"
                            disabled={isLoading.value}
                            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 disabled:opacity-50 disabled:cursor-not-allowed"
                        >
                            {isLoading.value ? (
                                <div class="flex items-center">
                                    <div class="animate-spin rounded-full h-4 w-4 border-b-2 border-white mr-2"></div>
                                    Cambiando...
                                </div>
                            ) : (
                                'Cambiar Contraseña'
                            )}
                        </button>
                    </div>

                    <div class="text-center">
                        <a href="/" class="font-medium text-blue-600 hover:text-blue-500">
                            Volver al inicio
                        </a>
                    </div>
                </form>
            </div>
        </div>
    );
});
