import { component$, useSignal, $ } from '@builder.io/qwik';
import { useNavigate, useLocation } from '@builder.io/qwik-city';
import { authService, type ResetPasswordRequestDTO } from '~/services/auth.service';

export default component$(() => {
  const location = useLocation();
  const navigate = useNavigate();
  
  // Extraer email y token de los query parameters
  const urlParams = new URLSearchParams(location.url.search);
  const emailParam = urlParams.get('email') || '';
  const tokenParam = urlParams.get('token') || '';
  
  const formData = useSignal<ResetPasswordRequestDTO>({
    email: emailParam,
    token: tokenParam,
    newPassword: '',
    confirmPassword: '',
  });
  
  const error = useSignal<string>('');
  const success = useSignal<string>('');
  const isLoading = useSignal<boolean>(false);

  const validateForm = $(() => {
    const { email, token, newPassword, confirmPassword } = formData.value;
    
    if (!email || !token || !newPassword || !confirmPassword) {
      return 'Todos los campos son obligatorios';
    }
    
    if (newPassword !== confirmPassword) {
      return 'Las contraseñas no coinciden';
    }
    
    if (newPassword.length < 6) {
      return 'La contraseña debe tener al menos 6 caracteres';
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
      const response = await authService.resetPassword(formData.value);
      
      if (response.success) {
        success.value = 'Contraseña restablecida exitosamente. Redirigiendo al login...';
        
        // Redirigir después de un breve delay
        setTimeout(() => {
          navigate('/login');
        }, 2000);
      } else {
        error.value = response.error || 'Error al restablecer la contraseña';
      }
    } catch (err: any) {
      error.value = 'Error de conexión' + (err.message || '');
    } finally {
      isLoading.value = false;
    }
  });

  const handleInputChange = $((field: keyof ResetPasswordRequestDTO, value: string) => {
    formData.value = {
      ...formData.value,
      [field]: value,
    };
  });

  // Si no hay email o token en la URL, mostrar mensaje de error
  if (!emailParam || !tokenParam) {
    return (
      <div class="min-h-screen bg-slate-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
        <div class="max-w-md w-full space-y-8">
          <div class="text-center">
            <h2 class="mt-6 text-3xl font-extrabold text-gray-900">
              Enlace Inválido
            </h2>
            <p class="mt-2 text-sm text-gray-600">
              El enlace para restablecer la contraseña es inválido o ha expirado.
            </p>
            <div class="mt-4">
              <a 
                href="/forgot-password" 
                class="font-medium text-blue-600 hover:text-blue-500"
              >
                Solicitar nuevo enlace
              </a>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div class="min-h-screen bg-slate-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Restablecer Contraseña
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            Ingresa tu nueva contraseña
          </p>
        </div>

        <form class="mt-8 space-y-6" onSubmit$={handleSubmit}>
          <div class="space-y-4">
            <div>
              <label for="email" class="block text-sm font-medium text-gray-700">
                Email
              </label>
              <input
                id="email"
                name="email"
                type="email"
                disabled
                class="mt-1 appearance-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-500 bg-gray-100 rounded-md sm:text-sm"
                value={formData.value.email}
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
                  Restableciendo...
                </div>
              ) : (
                'Restablecer Contraseña'
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
