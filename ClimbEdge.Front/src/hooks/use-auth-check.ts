import { $, useTask$ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';
import { authService } from '~/services/auth.service';

export const useAuthCheck = () => {
  const { setUser, setLoading, clearAuth } = useAuth();

  const checkAuth = $(async () => {
    setLoading(true);
    
    try {
      const response = await authService.getCurrentUser();
      
      if (response.success && response.data) {
        setUser(response.data);
      } else {
        clearAuth();
      }
    } catch (error) {
      clearAuth();
    } finally {
      setLoading(false);
    }
  });

  // Verificar autenticación al cargar
  useTask$(async () => {
    await checkAuth();
  });

  return {
    checkAuth,
  };
};
