import { component$, useSignal, $ } from '@builder.io/qwik';
import { authService, type ForgotPasswordRequestDTO } from '~/services/auth.service';

export default component$(() => {
  const formData = useSignal<ForgotPasswordRequestDTO>({
    email: '',
  });
  
  const error = useSignal<string>('');
  const success = useSignal<string>('');
  const isLoading = useSignal<boolean>(false);

  const handleSubmit = $(async (e: SubmitEvent) => {
    e.preventDefault();
    
    if (!formData.value.email) {
      error.value = 'El email es obligatorio';
      return;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(formData.value.email)) {
      error.value = 'Email inválido';
      return;
    }

    isLoading.value = true;
    error.value = '';
    success.value = '';

    try {
      const response = await authService.forgotPassword(formData.value);
      
      if (response.success) {
        success.value = 'Se ha enviado un email con instrucciones para restablecer tu contraseña';
        formData.value.email = '';
      } else {
        error.value = response.error || 'Error al enviar el email';
      }
    } catch (err) {
      error.value = 'Error de conexión';
    } finally {
      isLoading.value = false;
    }
  });

  const handleInputChange = $((value: string) => {
    formData.value = {
      email: value,
    };
  });

  return (
    <div class="min-h-screen bg-slate-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Recuperar Contraseña
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            Ingresa tu email para recibir instrucciones de recuperación
          </p>
        </div>

        <form class="mt-8 space-y-6" onSubmit$={handleSubmit}>
          <div>
            <label for="email" class="block text-sm font-medium text-gray-700">
              Email
            </label>
            <input
              id="email"
              name="email"
              type="email"
              autoComplete="email"
              required
              class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-md focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
              placeholder="Tu email"
              value={formData.value.email}
              onInput$={(e) => handleInputChange((e.target as HTMLInputElement).value)}
            />
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
                  Enviando...
                </div>
              ) : (
                'Enviar Instrucciones'
              )}
            </button>
          </div>

          <div class="text-center">
            <a href="/login" class="font-medium text-blue-600 hover:text-blue-500">
              Volver al inicio de sesión
            </a>
          </div>
        </form>
      </div>
    </div>
  );
});
