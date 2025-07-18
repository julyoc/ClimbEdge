import { component$, useSignal, $, useOnDocument } from '@builder.io/qwik';
import { useNavigate } from '@builder.io/qwik-city';
import { authService, type LoginRequestDTO } from '~/services/auth.service';
import { useAuth } from '~/contexts/auth.context';

export default component$(() => {
  const navigate = useNavigate();
  const { setUser, setLoading, isLoading } = useAuth();

  const formData = useSignal<LoginRequestDTO>({
    email: '',
    password: '',
  });

  const error = useSignal<string>('');
  const success = useSignal<string>('');

  const handleSubmit = $(async (e: SubmitEvent) => {
    e.preventDefault();
    e.stopPropagation();

    console.log('Form data:', formData.value);
    console.log("iniciando sesión");

    if (!formData.value.email || !formData.value.password) {
      error.value = 'Todos los campos son obligatorios';
      return;
    }

    setLoading(true);
    error.value = '';
    success.value = '';

    try {
      const response = await authService.login(formData.value);

      if (response.success && response.data) {
        setUser(response.data.user);
        success.value = 'Inicio de sesión exitoso';

        // Redirigir después de un breve delay para mostrar el mensaje
        setTimeout(() => {
          navigate('/');
        }, 1000);
      } else {
        error.value = response.error || 'Error en el inicio de sesión';
      }
    } catch (err: any) {
      error.value = 'Error de conexión' + err.message;
      console.error('Error de conexión:', err);
    } finally {
      console.log('Finalizando sesión');
      console.log('isLoading:', isLoading.value);
      setLoading(false);
    }
  });

  const handleInputChange = $((field: keyof LoginRequestDTO, value: string) => {
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
            Iniciar Sesión
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            ¿No tienes una cuenta?{' '}
            <a href="/register" class="font-medium text-blue-600 hover:text-blue-500">
              Regístrate aquí
            </a>
          </p>
        </div>

        <form class="mt-8 space-y-6" preventdefault:submit onSubmit$={handleSubmit}>
          <div class="rounded-md shadow-sm -space-y-px">
            <div>
              <label for="email" class="sr-only">
                Email
              </label>
              <input
                id="email"
                name="email"
                type="email"
                autoComplete="email"
                required
                class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 focus:z-10 sm:text-sm"
                placeholder="Email"
                value={formData.value.email}
                onInput$={(e) => handleInputChange('email', (e.target as HTMLInputElement).value)}
              />
            </div>
            <div>
              <label for="password" class="sr-only">
                Contraseña
              </label>
              <input
                id="password"
                name="password"
                type="password"
                autoComplete="current-password"
                required
                class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 focus:z-10 sm:text-sm"
                placeholder="Contraseña"
                value={formData.value.password}
                onInput$={(e) => handleInputChange('password', (e.target as HTMLInputElement).value)}
              />
            </div>
          </div>

          <div class="flex items-center justify-between">
            <div class="text-sm">
              <a href="/forgot-password" class="font-medium text-blue-600 hover:text-blue-500">
                ¿Olvidaste tu contraseña?
              </a>
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
                  Iniciando sesión...
                </div>
              ) : (
                'Iniciar Sesión'
              )}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
});
