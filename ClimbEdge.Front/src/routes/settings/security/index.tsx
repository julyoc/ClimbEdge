import { component$, useSignal } from '@builder.io/qwik';
import { Link } from '@builder.io/qwik-city';

export default component$(() => {
    const sessions = useSignal([
        {
            id: '1',
            device: 'Chrome en Windows 10',
            location: 'Quito, Ecuador',
            ipAddress: '192.168.1.100',
            lastActive: '2025-07-18T14:30:00Z',
            isCurrent: true,
        },
        {
            id: '2',
            device: 'Mobile App en Android',
            location: 'Quito, Ecuador',
            ipAddress: '192.168.1.101',
            lastActive: '2025-07-17T20:15:00Z',
            isCurrent: false,
        },
        {
            id: '3',
            device: 'Safari en iPhone',
            location: 'Guayaquil, Ecuador',
            ipAddress: '201.230.45.123',
            lastActive: '2025-07-16T09:45:00Z',
            isCurrent: false,
        },
    ]);

    const securityEvents = useSignal([
        {
            id: '1',
            type: 'login',
            description: 'Inicio de sesión exitoso',
            timestamp: '2025-07-18T14:30:00Z',
            device: 'Chrome en Windows 10',
            location: 'Quito, Ecuador',
            status: 'success',
        },
        {
            id: '2',
            type: 'password_change',
            description: 'Contraseña actualizada',
            timestamp: '2025-07-15T16:20:00Z',
            device: 'Chrome en Windows 10',
            location: 'Quito, Ecuador',
            status: 'success',
        },
        {
            id: '3',
            type: 'login_failed',
            description: 'Intento de inicio de sesión fallido',
            timestamp: '2025-07-14T10:30:00Z',
            device: 'Desconocido',
            location: 'Lima, Perú',
            status: 'warning',
        },
    ]);

    const formatDate = (dateString: string) => {
        const date = new Date(dateString);
        return date.toLocaleString('es-EC', {
            year: 'numeric',
            month: 'short',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        });
    };

    const getEventIcon = (type: string) => {
        switch (type) {
            case 'login':
                return 'M11 16l-4-4m0 0l4-4m-4 4h14m-5 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h7a3 3 0 013 3v1';
            case 'password_change':
                return 'M15 7a2 2 0 012 2m4 0a6 6 0 01-7.743 5.743L11 17H9v2H7v2H4a1 1 0 01-1-1v-2.586a1 1 0 01.293-.707l5.964-5.964A6 6 0 1121 9z';
            case 'login_failed':
                return 'M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L3.232 16.5c-.77.833.192 2.5 1.732 2.5z';
            default:
                return 'M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z';
        }
    };

    const getEventColor = (status: string) => {
        switch (status) {
            case 'success':
                return 'text-green-600';
            case 'warning':
                return 'text-yellow-600';
            case 'error':
                return 'text-red-600';
            default:
                return 'text-gray-600';
        }
    };

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Configuración de Seguridad</h2>
                <p class="mt-1 text-gray-600">
                    Gestiona la seguridad de tu cuenta y controla el acceso
                </p>
            </div>

            <div class="space-y-8">
                {/* Cambio de Contraseña */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Contraseña y Autenticación</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div class="bg-white border border-gray-200 rounded-lg p-6">
                            <div class="flex items-center mb-4">
                                <div class="flex-shrink-0">
                                    <svg class="h-8 w-8 text-blue-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 7a2 2 0 012 2m4 0a6 6 0 01-7.743 5.743L11 17H9v2H7v2H4a1 1 0 01-1-1v-2.586a1 1 0 01.293-.707l5.964-5.964A6 6 0 1121 9z" />
                                    </svg>
                                </div>
                                <div class="ml-4">
                                    <h4 class="text-lg font-medium text-gray-900">Cambiar Contraseña</h4>
                                    <p class="text-sm text-gray-600">Actualiza tu contraseña regularmente</p>
                                </div>
                            </div>
                            <Link
                                href="/change-password"
                                class="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-blue-600 hover:bg-blue-700"
                            >
                                Cambiar Contraseña
                            </Link>
                        </div>

                        <div class="bg-white border border-gray-200 rounded-lg p-6">
                            <div class="flex items-center mb-4">
                                <div class="flex-shrink-0">
                                    <svg class="h-8 w-8 text-green-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z" />
                                    </svg>
                                </div>
                                <div class="ml-4">
                                    <h4 class="text-lg font-medium text-gray-900">Autenticación en Dos Pasos</h4>
                                    <p class="text-sm text-gray-600">Próximamente disponible</p>
                                </div>
                            </div>
                            <button
                                disabled
                                class="inline-flex items-center px-4 py-2 border border-gray-300 text-sm font-medium rounded-md text-gray-400 bg-gray-100 cursor-not-allowed"
                            >
                                Próximamente
                            </button>
                        </div>
                    </div>
                </div>

                {/* Sesiones Activas */}
                <div class="space-y-4">
                    <div class="flex items-center justify-between">
                        <h3 class="text-lg font-semibold text-gray-900">Sesiones Activas</h3>
                        <span class="text-sm text-gray-500">
                            {sessions.value.length} {sessions.value.length === 1 ? 'sesión' : 'sesiones'}
                        </span>
                    </div>
                    
                    <div class="bg-white border border-gray-200 rounded-lg overflow-hidden">
                        <ul class="divide-y divide-gray-200">
                            {sessions.value.map((session) => (
                                <li key={session.id} class="p-4">
                                    <div class="flex items-center justify-between">
                                        <div class="flex-1 min-w-0">
                                            <div class="flex items-center">
                                                <div class="flex-shrink-0">
                                                    <svg class="h-6 w-6 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.75 17L9 20l-1 1h8l-1-1-.75-3M3 13h18M5 17h14a2 2 0 002-2V5a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                                    </svg>
                                                </div>
                                                <div class="ml-3 flex-1 min-w-0">
                                                    <div class="flex items-center">
                                                        <p class="text-sm font-medium text-gray-900 truncate">
                                                            {session.device}
                                                        </p>
                                                        {session.isCurrent && (
                                                            <span class="ml-2 inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800">
                                                                Actual
                                                            </span>
                                                        )}
                                                    </div>
                                                    <p class="text-sm text-gray-600">
                                                        {session.location} • {session.ipAddress}
                                                    </p>
                                                    <p class="text-xs text-gray-500">
                                                        Último acceso: {formatDate(session.lastActive)}
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        {!session.isCurrent && (
                                            <div class="flex-shrink-0">
                                                <button
                                                    type="button"
                                                    class="text-sm text-red-600 hover:text-red-800"
                                                >
                                                    Cerrar Sesión
                                                </button>
                                            </div>
                                        )}
                                    </div>
                                </li>
                            ))}
                        </ul>
                    </div>
                </div>

                {/* Historial de Seguridad */}
                <div class="space-y-4">
                    <div class="flex items-center justify-between">
                        <h3 class="text-lg font-semibold text-gray-900">Historial de Seguridad</h3>
                        <button
                            type="button"
                            class="text-sm text-blue-600 hover:text-blue-800"
                        >
                            Ver Todo
                        </button>
                    </div>
                    
                    <div class="bg-white border border-gray-200 rounded-lg overflow-hidden">
                        <ul class="divide-y divide-gray-200">
                            {securityEvents.value.map((event) => (
                                <li key={event.id} class="p-4">
                                    <div class="flex items-start">
                                        <div class="flex-shrink-0">
                                            <svg 
                                                class={`h-6 w-6 ${getEventColor(event.status)}`} 
                                                fill="none" 
                                                viewBox="0 0 24 24" 
                                                stroke="currentColor"
                                            >
                                                <path 
                                                    stroke-linecap="round" 
                                                    stroke-linejoin="round" 
                                                    stroke-width="2" 
                                                    d={getEventIcon(event.type)} 
                                                />
                                            </svg>
                                        </div>
                                        <div class="ml-3 flex-1 min-w-0">
                                            <p class="text-sm font-medium text-gray-900">
                                                {event.description}
                                            </p>
                                            <div class="text-sm text-gray-600">
                                                <p>{event.device} • {event.location}</p>
                                                <p class="text-xs text-gray-500">
                                                    {formatDate(event.timestamp)}
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            ))}
                        </ul>
                    </div>
                </div>

                {/* Configuraciones de Seguridad Adicionales */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Configuraciones Adicionales</h3>
                    
                    <div class="bg-white border border-gray-200 rounded-lg p-6">
                        <div class="space-y-6">
                            <div class="flex items-center justify-between">
                                <div class="flex-1">
                                    <h4 class="text-sm font-medium text-gray-900">
                                        Notificaciones de Inicio de Sesión
                                    </h4>
                                    <p class="text-sm text-gray-600">
                                        Recibir notificaciones cuando se inicie sesión en tu cuenta
                                    </p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        checked={true}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>

                            <div class="flex items-center justify-between">
                                <div class="flex-1">
                                    <h4 class="text-sm font-medium text-gray-900">
                                        Notificaciones de Actividad Sospechosa
                                    </h4>
                                    <p class="text-sm text-gray-600">
                                        Alertas por intentos de acceso desde ubicaciones desconocidas
                                    </p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        checked={true}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>

                            <div class="flex items-center justify-between">
                                <div class="flex-1">
                                    <h4 class="text-sm font-medium text-gray-900">
                                        Cerrar Sesión Automáticamente
                                    </h4>
                                    <p class="text-sm text-gray-600">
                                        Cerrar sesión después de 30 días de inactividad
                                    </p>
                                </div>
                                <label class="relative inline-flex items-center cursor-pointer">
                                    <input
                                        type="checkbox"
                                        checked={false}
                                        class="sr-only peer"
                                    />
                                    <div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-300 rounded-full peer peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Acciones de Emergencia */}
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold text-gray-900">Acciones de Emergencia</h3>
                    
                    <div class="bg-red-50 border border-red-200 rounded-lg p-6">
                        <div class="flex">
                            <div class="flex-shrink-0">
                                <svg class="h-6 w-6 text-red-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L3.232 16.5c-.77.833.192 2.5 1.732 2.5z" />
                                </svg>
                            </div>
                            <div class="ml-3 flex-1">
                                <h4 class="text-sm font-medium text-red-800">
                                    Cerrar Todas las Sesiones
                                </h4>
                                <p class="text-sm text-red-700 mt-1">
                                    Si sospechas que tu cuenta ha sido comprometida, puedes cerrar todas las sesiones activas inmediatamente.
                                </p>
                                <div class="mt-4">
                                    <button
                                        type="button"
                                        class="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-700"
                                    >
                                        Cerrar Todas las Sesiones
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
});
