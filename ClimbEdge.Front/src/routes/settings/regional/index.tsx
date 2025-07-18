import { component$, useSignal } from '@builder.io/qwik';
import { Form, globalAction$, zod$, z } from '@builder.io/qwik-city';

const regionalSchema = z.object({
    country: z.string().min(1, 'El país es requerido'),
    timeZone: z.string().min(1, 'La zona horaria es requerida'),
    preferredLanguage: z.string().min(1, 'El idioma es requerido'),
    currency: z.string().min(1, 'La moneda es requerida'),
    dateFormat: z.string().min(1, 'El formato de fecha es requerido'),
    timeFormat: z.string().min(1, 'El formato de hora es requerido'),
    measurementUnit: z.enum(['metric', 'imperial']),
    firstDayOfWeek: z.enum(['sunday', 'monday']),
});

export const useUpdateRegional = globalAction$(
    async (data, { fail }) => {
        try {
            console.log('Updating regional settings:', data);
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            return {
                success: true,
                message: 'Configuración regional actualizada'
            };
        } catch {
            return fail(500, {
                message: 'Error al actualizar la configuración regional'
            });
        }
    },
    zod$(regionalSchema)
);

export default component$(() => {
    const updateRegional = useUpdateRegional();
    
    const regionalSettings = useSignal({
        country: 'EC',
        timeZone: 'UTC-5',
        preferredLanguage: 'es-LA',
        currency: 'USD',
        dateFormat: 'dd/MM/yyyy',
        timeFormat: '24h',
        measurementUnit: 'metric',
        firstDayOfWeek: 'monday',
    });

    const countries = [
        { code: 'EC', name: 'Ecuador', flag: '🇪🇨' },
        { code: 'CO', name: 'Colombia', flag: '🇨🇴' },
        { code: 'PE', name: 'Perú', flag: '🇵🇪' },
        { code: 'BO', name: 'Bolivia', flag: '🇧🇴' },
        { code: 'CL', name: 'Chile', flag: '🇨🇱' },
        { code: 'AR', name: 'Argentina', flag: '🇦🇷' },
        { code: 'US', name: 'Estados Unidos', flag: '🇺🇸' },
        { code: 'ES', name: 'España', flag: '🇪🇸' },
        { code: 'MX', name: 'México', flag: '🇲🇽' },
    ];

    const timeZones = [
        { value: 'UTC-5', label: 'UTC-5 (Ecuador, Colombia, Perú)' },
        { value: 'UTC-4', label: 'UTC-4 (Bolivia, Chile)' },
        { value: 'UTC-3', label: 'UTC-3 (Argentina, Uruguay)' },
        { value: 'UTC-6', label: 'UTC-6 (México Central)' },
        { value: 'UTC-7', label: 'UTC-7 (México Pacífico)' },
        { value: 'UTC-8', label: 'UTC-8 (Pacífico)' },
        { value: 'UTC+1', label: 'UTC+1 (España)' },
    ];

    const languages = [
        { code: 'es-LA', name: 'Español (Latinoamérica)' },
        { code: 'es-ES', name: 'Español (España)' },
        { code: 'en-US', name: 'English (United States)' },
        { code: 'en-GB', name: 'English (United Kingdom)' },
        { code: 'pt-BR', name: 'Português (Brasil)' },
        { code: 'fr-FR', name: 'Français (France)' },
    ];

    const currencies = [
        { code: 'USD', name: 'Dólar Estadounidense ($)', symbol: '$' },
        { code: 'EUR', name: 'Euro (€)', symbol: '€' },
        { code: 'COP', name: 'Peso Colombiano (COL$)', symbol: 'COL$' },
        { code: 'PEN', name: 'Sol Peruano (S/)', symbol: 'S/' },
        { code: 'CLP', name: 'Peso Chileno (CLP$)', symbol: 'CLP$' },
        { code: 'ARS', name: 'Peso Argentino (ARS$)', symbol: 'ARS$' },
        { code: 'BOB', name: 'Boliviano (Bs)', symbol: 'Bs' },
        { code: 'MXN', name: 'Peso Mexicano (MX$)', symbol: 'MX$' },
    ];

    const dateFormats = [
        { value: 'dd/MM/yyyy', label: '31/12/2024 (DD/MM/AAAA)' },
        { value: 'MM/dd/yyyy', label: '12/31/2024 (MM/DD/AAAA)' },
        { value: 'yyyy-MM-dd', label: '2024-12-31 (AAAA-MM-DD)' },
        { value: 'dd-MM-yyyy', label: '31-12-2024 (DD-MM-AAAA)' },
    ];

    return (
        <div class="p-6">
            <div class="border-b border-gray-200 pb-4 mb-6">
                <h2 class="text-2xl font-bold text-gray-900">Configuración Regional</h2>
                <p class="mt-1 text-gray-600">
                    Ajusta la configuración de ubicación, idioma y formatos
                </p>
            </div>

            <Form action={updateRegional} class="space-y-8">
                {/* Ubicación y Zona Horaria */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Ubicación y Zona Horaria</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="country" class="block text-sm font-medium text-gray-700">
                                País *
                            </label>
                            <select
                                name="country"
                                id="country"
                                value={regionalSettings.value.country}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                {countries.map((country) => (
                                    <option key={country.code} value={country.code}>
                                        {`${country.flag} ${country.name}`}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label for="timeZone" class="block text-sm font-medium text-gray-700">
                                Zona Horaria *
                            </label>
                            <select
                                name="timeZone"
                                id="timeZone"
                                value={regionalSettings.value.timeZone}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                {timeZones.map((tz) => (
                                    <option key={tz.value} value={tz.value}>
                                        {tz.label}
                                    </option>
                                ))}
                            </select>
                        </div>
                    </div>
                </div>

                {/* Idioma y Moneda */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Idioma y Moneda</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="preferredLanguage" class="block text-sm font-medium text-gray-700">
                                Idioma Preferido *
                            </label>
                            <select
                                name="preferredLanguage"
                                id="preferredLanguage"
                                value={regionalSettings.value.preferredLanguage}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                {languages.map((lang) => (
                                    <option key={lang.code} value={lang.code}>
                                        {lang.name}
                                    </option>
                                ))}
                            </select>
                            <p class="mt-1 text-xs text-gray-500">
                                Idioma de la interfaz y notificaciones
                            </p>
                        </div>

                        <div>
                            <label for="currency" class="block text-sm font-medium text-gray-700">
                                Moneda *
                            </label>
                            <select
                                name="currency"
                                id="currency"
                                value={regionalSettings.value.currency}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                {currencies.map((currency) => (
                                    <option key={currency.code} value={currency.code}>
                                        {currency.name}
                                    </option>
                                ))}
                            </select>
                            <p class="mt-1 text-xs text-gray-500">
                                Para precios y transacciones futuras
                            </p>
                        </div>
                    </div>
                </div>

                {/* Formatos de Fecha y Hora */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Formatos de Fecha y Hora</h3>
                    
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                            <label for="dateFormat" class="block text-sm font-medium text-gray-700">
                                Formato de Fecha *
                            </label>
                            <select
                                name="dateFormat"
                                id="dateFormat"
                                value={regionalSettings.value.dateFormat}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                {dateFormats.map((format) => (
                                    <option key={format.value} value={format.value}>
                                        {format.label}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label for="timeFormat" class="block text-sm font-medium text-gray-700">
                                Formato de Hora *
                            </label>
                            <select
                                name="timeFormat"
                                id="timeFormat"
                                value={regionalSettings.value.timeFormat}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                required
                            >
                                <option value="24h">24 horas (14:30)</option>
                                <option value="12h">12 horas (2:30 PM)</option>
                            </select>
                        </div>

                        <div>
                            <label for="firstDayOfWeek" class="block text-sm font-medium text-gray-700">
                                Primer Día de la Semana
                            </label>
                            <select
                                name="firstDayOfWeek"
                                id="firstDayOfWeek"
                                value={regionalSettings.value.firstDayOfWeek}
                                class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                            >
                                <option value="monday">Lunes</option>
                                <option value="sunday">Domingo</option>
                            </select>
                        </div>
                    </div>
                </div>

                {/* Unidades de Medida */}
                <div class="space-y-6">
                    <h3 class="text-lg font-semibold text-gray-900">Unidades de Medida</h3>
                    <p class="text-sm text-gray-600">
                        Configuración para escalada y actividades deportivas
                    </p>
                    
                    <div class="space-y-4">
                        <div>
                            <label class="block text-sm font-medium text-gray-700 mb-3">
                                Sistema de Medición
                            </label>
                            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                                <label class="relative flex cursor-pointer rounded-lg border p-4 focus-within:ring-2 focus-within:ring-blue-500">
                                    <input
                                        type="radio"
                                        name="measurementUnit"
                                        value="metric"
                                        checked={regionalSettings.value.measurementUnit === 'metric'}
                                        class="sr-only"
                                    />
                                    <div class="flex-1">
                                        <div class="flex items-center">
                                            <div class="text-sm">
                                                <div class="font-medium text-gray-900">Sistema Métrico</div>
                                                <div class="text-gray-500">
                                                    <p class="text-xs">Metros, kilómetros, kilogramos</p>
                                                    <p class="text-xs">Altitud en metros, distancia en km</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="h-5 w-5 text-blue-600 flex-shrink-0">
                                        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
                                            <circle cx="10" cy="10" r="3" class={regionalSettings.value.measurementUnit === 'metric' ? 'block' : 'hidden'} />
                                        </svg>
                                    </div>
                                </label>

                                <label class="relative flex cursor-pointer rounded-lg border p-4 focus-within:ring-2 focus-within:ring-blue-500">
                                    <input
                                        type="radio"
                                        name="measurementUnit"
                                        value="imperial"
                                        checked={regionalSettings.value.measurementUnit === 'imperial'}
                                        class="sr-only"
                                    />
                                    <div class="flex-1">
                                        <div class="flex items-center">
                                            <div class="text-sm">
                                                <div class="font-medium text-gray-900">Sistema Imperial</div>
                                                <div class="text-gray-500">
                                                    <p class="text-xs">Pies, millas, libras</p>
                                                    <p class="text-xs">Altitud en pies, distancia en millas</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="h-5 w-5 text-blue-600 flex-shrink-0">
                                        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
                                            <circle cx="10" cy="10" r="3" class={regionalSettings.value.measurementUnit === 'imperial' ? 'block' : 'hidden'} />
                                        </svg>
                                    </div>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Vista Previa */}
                <div class="space-y-4 p-4 bg-gray-50 rounded-lg">
                    <h4 class="text-sm font-medium text-gray-900">Vista Previa de Configuración</h4>
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4 text-sm">
                        <div>
                            <span class="text-gray-600">Fecha: </span>
                            <span class="font-mono">
                                {regionalSettings.value.dateFormat === 'dd/MM/yyyy' ? '18/07/2025' :
                                 regionalSettings.value.dateFormat === 'MM/dd/yyyy' ? '07/18/2025' :
                                 regionalSettings.value.dateFormat === 'yyyy-MM-dd' ? '2025-07-18' :
                                 '18-07-2025'}
                            </span>
                        </div>
                        <div>
                            <span class="text-gray-600">Hora: </span>
                            <span class="font-mono">
                                {regionalSettings.value.timeFormat === '24h' ? '14:30' : '2:30 PM'}
                            </span>
                        </div>
                        <div>
                            <span class="text-gray-600">Moneda: </span>
                            <span class="font-mono">
                                {currencies.find(c => c.code === regionalSettings.value.currency)?.symbol}1,250.00
                            </span>
                        </div>
                        <div>
                            <span class="text-gray-600">Distancia: </span>
                            <span class="font-mono">
                                {regionalSettings.value.measurementUnit === 'metric' ? '1.5 km' : '0.93 miles'}
                            </span>
                        </div>
                    </div>
                </div>

                {/* Mensajes de Estado */}
                {updateRegional.value?.success && (
                    <div class="rounded-md bg-green-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-green-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-green-800">
                                    {updateRegional.value.message}
                                </p>
                            </div>
                        </div>
                    </div>
                )}

                {updateRegional.value?.failed && (
                    <div class="rounded-md bg-red-50 p-4">
                        <div class="flex">
                            <svg class="h-5 w-5 text-red-400" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
                            </svg>
                            <div class="ml-3">
                                <p class="text-sm font-medium text-red-800">
                                    {updateRegional.value.message}
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
                        disabled={updateRegional.isRunning}
                        class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {updateRegional.isRunning ? 'Guardando...' : 'Guardar Configuración'}
                    </button>
                </div>
            </Form>
        </div>
    );
});
