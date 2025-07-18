import { $, useTask$, useVisibleTask$ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';
import { authService } from '~/services/auth.service';

export const useAuthCheck = () => {
  const { setUser, setLoading, clearAuth } = useAuth();

  const checkAuth = $(async () => {
    console.log('🔍 Checking auth...');
    setLoading(true);
    
    try {
      const response = await authService.getCurrentUser();
      console.log('🔍 Auth response:', response);
      
      if (response.success && response.data) {
        console.log('✅ Setting user:', response.data);
        setUser(response.data);
      } else {
        console.log('❌ Auth failed, clearing auth');
        clearAuth();
      }
    } catch (error) {
      console.log('💥 Auth error:', error);
      clearAuth();
    } finally {
      setLoading(false);
    }
  });

  // Verificar autenticación al cargar (servidor)
  useTask$(async () => {
    console.log('🚀 useTask$ running...');
    await checkAuth();
  });

  // También verificar en el cliente
  useVisibleTask$(async () => {
    console.log('👀 useVisibleTask$ running...');
    await checkAuth();
  });

  return {
    checkAuth,
  };
};