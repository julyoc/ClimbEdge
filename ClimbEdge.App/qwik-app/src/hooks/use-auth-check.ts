import { $, useVisibleTask$ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';
import { createAuthService } from 'climbedge-shared/services/AuthService';

export const useAuthCheck = () => {
  const { setUser, setLoading, clearAuth } = useAuth();

  const checkAuth = $(async () => {
    const baseUrl = import.meta.env.VITE_API_URL;
    if (!baseUrl) {
      console.log('⚠️ VITE_API_URL not set, skipping auth check');
      setLoading(false);
      return;
    }

    const service = createAuthService({
      baseUrl,
      apiKey: import.meta.env.VITE_API_KEY,
    });

    console.log('🔍 Checking auth...');
    setLoading(true);
    
    try {
      const response = await service.getCurrentUser();
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

  // Verificar autenticación solo en el cliente (los tokens/cookies son del navegador)
  useVisibleTask$(async () => {
    console.log('👀 useVisibleTask$ running...');
    await checkAuth();
  });

  return {
    checkAuth,
  };
};