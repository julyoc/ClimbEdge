import { component$ } from '@builder.io/qwik';
import { useNavigate } from '@builder.io/qwik-city';
import { useVisibleTask$ } from '@builder.io/qwik';

export default component$(() => {
    const navigate = useNavigate();

    // eslint-disable-next-line qwik/no-use-visible-task
    useVisibleTask$(() => {
        // Redirigir automáticamente a la sección de perfil
        navigate('/settings/profile');
    });

    return (
        <div class="p-6">
            <div class="flex items-center justify-center h-64">
                <div class="text-center">
                    <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600 mx-auto"></div>
                    <p class="mt-4 text-gray-600">Cargando configuración...</p>
                </div>
            </div>
        </div>
    );
});
