import { component$ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';

export default component$(() => {
    const { user, isAuthenticated } = useAuth();

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
                            Debes iniciar sesión para ver tu perfil
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
            <div class="max-w-2xl mx-auto">
                <div class="bg-white shadow rounded-lg">
                    <div class="px-6 py-4 border-b border-gray-200">
                        <h2 class="text-2xl font-bold text-gray-900">Mi Perfil</h2>
                    </div>

                    <div class="px-6 py-4">
                        <div class="space-y-6">
                            {/* Avatar */}
                            <div class="flex items-center space-x-4">
                                <div class="w-16 h-16 bg-blue-600 rounded-full flex items-center justify-center">
                                    <span class="text-white text-xl font-medium">
                                        {user.value?.firstName?.[0] || user.value?.email?.[0] || 'U'}
                                    </span>
                                </div>
                                <div>
                                    <h3 class="text-lg font-medium text-gray-900">
                                        {user.value?.firstName} {user.value?.lastName}
                                    </h3>
                                    <p class="text-sm text-gray-500">
                                        {user.value?.email}
                                    </p>
                                </div>
                            </div>

                            {/* Información del usuario */}
                            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Nombre
                                    </label>
                                    <p class="mt-1 text-sm text-gray-900">
                                        {user.value?.firstName || 'No especificado'}
                                    </p>
                                </div>

                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Apellido
                                    </label>
                                    <p class="mt-1 text-sm text-gray-900">
                                        {user.value?.lastName || 'No especificado'}
                                    </p>
                                </div>

                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Email
                                    </label>
                                    <p class="mt-1 text-sm text-gray-900">
                                        {user.value?.email}
                                    </p>
                                </div>

                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Nombre de Usuario
                                    </label>
                                    <p class="mt-1 text-sm text-gray-900">
                                        {user.value?.userName || 'No especificado'}
                                    </p>
                                </div>

                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Email Confirmado
                                    </label>
                                    <p class="mt-1 text-sm">
                                        <span class={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${user.value?.emailConfirmed
                                                ? 'bg-green-100 text-green-800'
                                                : 'bg-red-100 text-red-800'
                                            }`}>
                                            {user.value?.emailConfirmed ? 'Confirmado' : 'No confirmado'}
                                        </span>
                                    </p>
                                </div>

                                <div>
                                    <label class="block text-sm font-medium text-gray-700">
                                        Roles
                                    </label>
                                    <div class="mt-1">
                                        {user.value?.roles && user.value.roles.length > 0 ? (
                                            <div class="flex flex-wrap gap-1">
                                                {user.value.roles.map((role, index) => (
                                                    <span
                                                        key={index}
                                                        class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800"
                                                    >
                                                        {role}
                                                    </span>
                                                ))}
                                            </div>
                                        ) : (
                                            <p class="text-sm text-gray-900">Sin roles asignados</p>
                                        )}
                                    </div>
                                </div>
                            </div>

                            {/* Acciones */}
                            <div class="pt-6 border-t border-gray-200">
                                <div class="flex space-x-3">
                                    <a
                                        href="/change-password"
                                        class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
                                    >
                                        Cambiar Contraseña
                                    </a>
                                    <a
                                        href="/"
                                        class="inline-flex justify-center py-2 px-4 border border-gray-300 shadow-sm text-sm font-medium rounded-md text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
                                    >
                                        Volver al Inicio
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
});
