import { component$, useSignal, $ } from '@builder.io/qwik';
import { useNavigate } from '@builder.io/qwik-city';
import { authService, type RegisterRequestDTO } from '~/services/auth.service';
import { useAuth } from '~/contexts/auth.context';

export default component$(() => {
  const navigate = useNavigate();
  const { setUser, setLoading, isLoading } = useAuth();

  const formData = useSignal<RegisterRequestDTO>({
    email: '',
    password: '',
    confirmPassword: '',
    firstName: '',
    lastName: '',
  });

  const error = useSignal<string>('');
  const success = useSignal<string>('');

  const validateForm = $(() => {
    const { email, password, confirmPassword, firstName, lastName } = formData.value;

    if (!email || !password || !confirmPassword) {
      return 'Todos los campos obligatorios deben ser completados';
    }

    if (password !== confirmPassword) {
      return 'Las contraseñas no coinciden';
    }

    if (password.length < 6) {
      return 'La contraseña debe tener al menos 6 caracteres';
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      return 'Email inválido';
    }

    return null;
  });

  const handleSubmit = $(async (e: SubmitEvent) => {
    e.preventDefault();
    e.stopPropagation();

    const validationError = await validateForm();
    if (validationError) {
      error.value = validationError;
      return;
    }

    setLoading(true);
    error.value = '';
    success.value = '';

    try {
      const response = await authService.register(formData.value);

      if (response.success && response.data) {
        setUser(response.data.user);
        success.value = 'Registro exitoso. Redirigiendo...';

        // Redirigir después de un breve delay para mostrar el mensaje
        setTimeout(() => {
          navigate('/');
        }, 1000);
      } else {
        error.value = response.error || 'Error en el registro';
      }
    } catch (err) {
      error.value = 'Error de conexión';
    } finally {
      setLoading(false);
    }
  });

  const handleInputChange = $((field: keyof RegisterRequestDTO, value: string) => {
    formData.value = {
      ...formData.value,
      [field]: value,
    };
  });

  return (
    <div class="min-h-screen bg-slate-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Crear Cuenta
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            ¿Ya tienes una cuenta?{' '}
            <a href="/login" class="font-medium text-blue-600 hover:text-blue-500">
              Inicia sesión aquí
            </a>
          </p>
        </div>

        <form class="mt-8 space-y-6" preventdefault:submit onSubmit$={handleSubmit}>
          <div class="space-y-4">
            <div class="grid grid-cols-2 gap-4">
              <div>
                <label for="firstName" class="block text-sm font-medium text-gray-700">
                  Nombre
                </label>
                <input
                  id="firstName"
                  name="firstName"
                  type="text"
                  autoComplete="given-name"
                  class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                  placeholder="Nombre"
                  value={formData.value.firstName}
                  onInput$={(e) => handleInputChange('firstName', (e.target as HTMLInputElement).value)}
                />
              </div>
              <div>
                <label for="lastName" class="block text-sm font-medium text-gray-700">
                  Apellido
                </label>
                <input
                  id="lastName"
                  name="lastName"
                  type="text"
                  autoComplete="family-name"
                  class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                  placeholder="Apellido"
                  value={formData.value.lastName}
                  onInput$={(e) => handleInputChange('lastName', (e.target as HTMLInputElement).value)}
                />
              </div>
            </div>

            <div>
              <label for="email" class="block text-sm font-medium text-gray-700">
                Email *
              </label>
              <input
                id="email"
                name="email"
                type="email"
                autoComplete="email"
                required
                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                placeholder="Email"
                value={formData.value.email}
                onInput$={(e) => handleInputChange('email', (e.target as HTMLInputElement).value)}
              />
            </div>

            <div>
              <label for="password" class="block text-sm font-medium text-gray-700">
                Contraseña *
              </label>
              <input
                id="password"
                name="password"
                type="password"
                autoComplete="new-password"
                required
                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                placeholder="Contraseña"
                value={formData.value.password}
                onInput$={(e) => handleInputChange('password', (e.target as HTMLInputElement).value)}
              />
            </div>

            <div>
              <label for="confirmPassword" class="block text-sm font-medium text-gray-700">
                Confirmar Contraseña *
              </label>
              <input
                id="confirmPassword"
                name="confirmPassword"
                type="password"
                autoComplete="new-password"
                required
                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                placeholder="Confirmar Contraseña"
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
                  Creando cuenta...
                </div>
              ) : (
                'Crear Cuenta'
              )}
            </button>
          </div>

          <div class="text-xs text-gray-500 text-center">
            * Campos obligatorios
          </div>
        </form>
      </div>
    </div>
  );
});
