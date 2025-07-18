import { component$, useSignal, $ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';

export default component$(() => {
    const { user } = useAuth();
    const isDeleteModalOpen = useSignal(false);
    const isExportModalOpen = useSignal(false);
    const confirmDeleteText = useSignal('');

    const openDeleteModal = $(() => {
        isDeleteModalOpen.value = true;
    });

    const closeDeleteModal = $(() => {
        isDeleteModalOpen.value = false;
        confirmDeleteText.value = '';
    });

    const openExportModal = $(() => {
        isExportModalOpen.value = true;
    });

    const closeExportModal = $(() => {
        isExportModalOpen.value = false;
    });

    const handleDeleteAccount = $(() => {
        if (confirmDeleteText.value === 'ELIMINAR') {
            // TODO: Implementar eliminación de cuenta
            console.log('Eliminar cuenta');
            closeDeleteModal();
        }
    });

    const handleExportData = $(() => {
        // TODO: Implementar exportación de datos
        console.log('Exportar datos');
        closeExportModal();
    });

    const accountCreationDate = new Date('2024-01-15T10:30:00Z');
    const lastLoginDate = new Date('2025-07-18T14:30:00Z');

    const formatDate = (date: Date) => {
        return date.toLocaleString('es-EC', {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        });
    };

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Gestión de Cuenta</h2>
                <p class="mt-1 text-gray-600">
                    Información de tu cuenta y opciones de gestión
                </p>
            </div>

            <div class="space-y-8">
                {/* Información de la Cuenta */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Información de la Cuenta</h3>
                    
                    <div class="bg-white border border-gray-200 rounded-lg p-6">
                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                            <div>
                                <label class="block text-sm font-medium text-gray-700">
                                    Correo Electrónico
                                </label>
                                <div class="mt-1 flex items-center">
                                    <span class="text-sm text-gray-900">{user.value?.email || 'No disponible'}</span>
                                    {user.value?.emailConfirmed ? (
                                        <span class="ml-2 inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800">
                                            Verificado
                                        </span>
                                    ) : (
                                        <span class="ml-2 inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-yellow-100 text-yellow-800">
                                            Sin verificar
                                        </span>
                                    )}
                                </div>
                            </div>

                            <div>
                                <label class="block text-sm font-medium text-gray-700">
                                    Nombre de Usuario
                                </label>
                                <div class="mt-1">
                                    <span class="text-sm text-gray-900">{user.value?.userName || 'No disponible'}</span>
                                </div>
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
                                        <span class="text-sm text-gray-500">Sin roles asignados</span>
                                    )}
                                </div>
                            </div>

                            <div>
                                <label class="block text-sm font-medium text-gray-700">
                                    ID de Usuario
                                </label>
                                <div class="mt-1">
                                    <span class="text-sm text-gray-500 font-mono">{user.value?.id || 'No disponible'}</span>
                                </div>
                            </div>

                            <div>
                                <label class="block text-sm font-medium text-gray-700">
                                    Cuenta Creada
                                </label>
                                <div class="mt-1">
                                    <span class="text-sm text-gray-900">{formatDate(accountCreationDate)}</span>
                                </div>
                            </div>

                            <div>
                                <label class="block text-sm font-medium text-gray-700">
                                    Último Acceso
                                </label>
                                <div class="mt-1">
                                    <span class="text-sm text-gray-900">{formatDate(lastLoginDate)}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Estadísticas de Uso */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Estadísticas de Uso</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
                        <div class="bg-white border border-gray-200 rounded-lg p-6 text-center">
                            <div class="text-3xl font-bold text-blue-600">125</div>
                            <div class="text-sm text-gray-600">Rutas Completadas</div>
                        </div>
                        <div class="bg-white border border-gray-200 rounded-lg p-6 text-center">
                            <div class="text-3xl font-bold text-green-600">89</div>
                            <div class="text-sm text-gray-600">Días Activo</div>
                        </div>
                        <div class="bg-white border border-gray-200 rounded-lg p-6 text-center">
                            <div class="text-3xl font-bold text-purple-600">42</div>
                            <div class="text-sm text-gray-600">Publicaciones</div>
                        </div>
                    </div>
                </div>

                {/* Gestión de Email */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Gestión de Email</h3>
                    
                    <div class="bg-white border border-gray-200 rounded-lg p-6">
                        {!user.value?.emailConfirmed && (
                            <div class="mb-4 p-4 bg-yellow-50 border border-yellow-200 rounded-lg">
                                <div class="flex">
                                    <svg class="h-5 w-5 text-yellow-400" fill="currentColor" viewBox="0 0 20 20">
                                        <path fill-rule="evenodd" d="M8.257 3.099c.765-1.36 2.722-1.36 3.486 0l5.58 9.92c.75 1.334-.213 2.98-1.742 2.98H4.42c-1.53 0-2.493-1.646-1.743-2.98l5.58-9.92zM11 13a1 1 0 11-2 0 1 1 0 012 0zm-1-8a1 1 0 00-1 1v3a1 1 0 002 0V6a1 1 0 00-1-1z" clip-rule="evenodd" />
                                    </svg>
                                    <div class="ml-3">
                                        <h4 class="text-sm font-medium text-yellow-800">
                                            Email sin verificar
                                        </h4>
                                        <p class="text-sm text-yellow-700 mt-1">
                                            Tu dirección de email no ha sido verificada. Esto puede limitar algunas funciones.
                                        </p>
                                        <div class="mt-3">
                                            <button
                                                type="button"
                                                class="text-sm font-medium text-yellow-800 hover:text-yellow-900"
                                            >
                                                Reenviar Email de Verificación
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )}

                        <div class="space-y-4">
                            <button
                                type="button"
                                class="inline-flex items-center px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                            >
                                Cambiar Dirección de Email
                            </button>
                        </div>
                    </div>
                </div>

                {/* Exportar Datos */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Datos Personales</h3>
                    
                    <div class="bg-white border border-gray-200 rounded-lg p-6">
                        <div class="flex items-start">
                            <div class="flex-shrink-0">
                                <svg class="h-6 w-6 text-blue-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                                </svg>
                            </div>
                            <div class="ml-3 flex-1">
                                <h4 class="text-sm font-medium text-gray-900">
                                    Exportar mis datos
                                </h4>
                                <p class="text-sm text-gray-600 mt-1">
                                    Descarga una copia de todos tus datos almacenados en ClimbEdge. 
                                    Incluye perfil, rutas, estadísticas y configuraciones.
                                </p>
                                <div class="mt-4">
                                    <button
                                        onClick$={openExportModal}
                                        type="button"
                                        class="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-blue-600 bg-blue-100 hover:bg-blue-200"
                                    >
                                        Solicitar Exportación
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Configuración de Conexiones */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Conexiones Externas</h3>
                    
                    <div class="bg-white border border-gray-200 rounded-lg p-6">
                        <div class="space-y-4">
                            <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                                <div class="flex items-center">
                                    <div class="flex-shrink-0">
                                        <svg class="h-6 w-6 text-black" fill="currentColor" viewBox="0 0 24 24">
                                            <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
                                        </svg>
                                    </div>
                                    <div class="ml-3">
                                        <h4 class="text-sm font-medium text-gray-900">GitHub</h4>
                                        <p class="text-xs text-gray-500">Próximamente disponible</p>
                                    </div>
                                </div>
                                <button
                                    disabled
                                    class="text-sm text-gray-400 cursor-not-allowed"
                                >
                                    Conectar
                                </button>
                            </div>

                            <div class="flex items-center justify-between p-3 border border-gray-200 rounded-lg">
                                <div class="flex items-center">
                                    <div class="flex-shrink-0">
                                        <svg class="h-6 w-6 text-blue-600" fill="currentColor" viewBox="0 0 24 24">
                                            <path d="M23.953 4.57a10 10 0 01-2.825.775 4.958 4.958 0 002.163-2.723c-.951.555-2.005.959-3.127 1.184a4.92 4.92 0 00-8.384 4.482C7.69 8.095 4.067 6.13 1.64 3.162a4.822 4.822 0 00-.666 2.475c0 1.71.87 3.213 2.188 4.096a4.904 4.904 0 01-2.228-.616v.06a4.923 4.923 0 003.946 4.827 4.996 4.996 0 01-2.212.085 4.936 4.936 0 004.604 3.417 9.867 9.867 0 01-6.102 2.105c-.39 0-.779-.023-1.17-.067a13.995 13.995 0 007.557 2.209c9.053 0 13.998-7.496 13.998-13.985 0-.21 0-.42-.015-.63A9.935 9.935 0 0024 4.59z"/>
                                        </svg>
                                    </div>
                                    <div class="ml-3">
                                        <h4 class="text-sm font-medium text-gray-900">Twitter</h4>
                                        <p class="text-xs text-gray-500">Próximamente disponible</p>
                                    </div>
                                </div>
                                <button
                                    disabled
                                    class="text-sm text-gray-400 cursor-not-allowed"
                                >
                                    Conectar
                                </button>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Eliminar Cuenta */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900 text-red-600">Zona Peligrosa</h3>
                    
                    <div class="bg-red-50 border border-red-200 rounded-lg p-6">
                        <div class="flex">
                            <div class="flex-shrink-0">
                                <svg class="h-6 w-6 text-red-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L3.232 16.5c-.77.833.192 2.5 1.732 2.5z" />
                                </svg>
                            </div>
                            <div class="ml-3 flex-1">
                                <h4 class="text-sm font-medium text-red-800">
                                    Eliminar mi cuenta
                                </h4>
                                <p class="text-sm text-red-700 mt-1">
                                    Esta acción eliminará permanentemente tu cuenta y todos los datos asociados. 
                                    Esta acción no se puede deshacer.
                                </p>
                                <div class="mt-4">
                                    <button
                                        onClick$={openDeleteModal}
                                        type="button"
                                        class="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-700"
                                    >
                                        Eliminar Cuenta
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Modal de Confirmación de Eliminación */}
            {isDeleteModalOpen.value && (
                <div class="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full z-50">
                    <div class="relative top-20 mx-auto p-5 border w-96 shadow-lg rounded-md bg-white">
                        <div class="mt-3">
                            <div class="flex items-center">
                                <div class="flex-shrink-0">
                                    <svg class="h-6 w-6 text-red-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L3.232 16.5c-.77.833.192 2.5 1.732 2.5z" />
                                    </svg>
                                </div>
                                <div class="ml-3">
                                    <h3 class="text-lg font-medium text-gray-900">
                                        Confirmar eliminación de cuenta
                                    </h3>
                                </div>
                            </div>
                            <div class="mt-4">
                                <p class="text-sm text-gray-600">
                                    Esta acción es irreversible. Todos tus datos, incluyendo perfil, rutas, 
                                    estadísticas y configuraciones serán eliminados permanentemente.
                                </p>
                                <div class="mt-4">
                                    <label class="block text-sm font-medium text-gray-700">
                                        Para confirmar, escribe "ELIMINAR" en el campo:
                                    </label>
                                    <input
                                        type="text"
                                        value={confirmDeleteText.value}
                                        onInput$={(event) => {
                                            confirmDeleteText.value = (event.target as HTMLInputElement).value;
                                        }}
                                        class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-red-500 focus:border-red-500 sm:text-sm"
                                        placeholder="ELIMINAR"
                                    />
                                </div>
                            </div>
                            <div class="flex justify-end space-x-3 mt-6">
                                <button
                                    onClick$={closeDeleteModal}
                                    type="button"
                                    class="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                                >
                                    Cancelar
                                </button>
                                <button
                                    onClick$={handleDeleteAccount}
                                    disabled={confirmDeleteText.value !== 'ELIMINAR'}
                                    type="button"
                                    class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-red-600 hover:bg-red-700 disabled:opacity-50 disabled:cursor-not-allowed"
                                >
                                    Eliminar Cuenta
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {/* Modal de Exportación */}
            {isExportModalOpen.value && (
                <div class="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full z-50">
                    <div class="relative top-20 mx-auto p-5 border w-96 shadow-lg rounded-md bg-white">
                        <div class="mt-3">
                            <div class="flex items-center">
                                <div class="flex-shrink-0">
                                    <svg class="h-6 w-6 text-blue-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                                    </svg>
                                </div>
                                <div class="ml-3">
                                    <h3 class="text-lg font-medium text-gray-900">
                                        Exportar datos
                                    </h3>
                                </div>
                            </div>
                            <div class="mt-4">
                                <p class="text-sm text-gray-600">
                                    Se generará un archivo ZIP con todos tus datos. Te enviaremos un enlace 
                                    de descarga a tu email una vez que esté listo.
                                </p>
                                <div class="mt-4">
                                    <h4 class="text-sm font-medium text-gray-900">Datos incluidos:</h4>
                                    <ul class="mt-2 text-sm text-gray-600 list-disc list-inside">
                                        <li>Información de perfil</li>
                                        <li>Rutas y estadísticas</li>
                                        <li>Configuraciones</li>
                                        <li>Historial de actividad</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="flex justify-end space-x-3 mt-6">
                                <button
                                    onClick$={closeExportModal}
                                    type="button"
                                    class="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50"
                                >
                                    Cancelar
                                </button>
                                <button
                                    onClick$={handleExportData}
                                    type="button"
                                    class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700"
                                >
                                    Exportar Datos
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
});
