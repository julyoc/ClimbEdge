import { 
  createContextId, 
  useContext, 
  useSignal, 
  $,
  type Signal
} from '@builder.io/qwik';
import { UserInfoDTO } from 'climbedge-shared/types/AppUserDTO';

export interface AuthStore {
  user: Signal<UserInfoDTO | null>;
  isAuthenticated: Signal<boolean>;
  isLoading: Signal<boolean>;
  isAnonymous: Signal<boolean>; // Nueva señal para usuarios anónimos
}

export const AuthContext = createContextId<AuthStore>('auth-context');

export const useAuthStore = () => {
  const user = useSignal<UserInfoDTO | null>(null);
  const isAuthenticated = useSignal(false);
  const isLoading = useSignal(false);
  const isAnonymous = useSignal(true); // Inicializar como anónimo por defecto

  return {
    user,
    isAuthenticated,
    isLoading,
    isAnonymous,
  };
};

export const useAuth = () => {
  const authStore = useContext(AuthContext);
  
  const setUser = $((userData: UserInfoDTO | null) => {
    authStore.user.value = userData;
    authStore.isAuthenticated.value = !!userData;
    authStore.isAnonymous.value = !userData; // Anónimo si NO hay usuario
  });

  const setLoading = $((loading: boolean) => {
    authStore.isLoading.value = loading;
  });

  const clearAuth = $(() => {
    authStore.user.value = null;
    authStore.isAuthenticated.value = false;
    authStore.isLoading.value = false;
    authStore.isAnonymous.value = true; // Establecer como anónimo
  });

  // Función para obtener roles de manera reactiva
  const getRoles = $(() => {
    if (authStore.isAnonymous.value) {
      return ['Guest'];
    }
    return authStore.user.value?.roles || [];
  });

  return {
    user: authStore.user,
    isAuthenticated: authStore.isAuthenticated,
    isLoading: authStore.isLoading,
    isAnonymous: authStore.isAnonymous,
    setUser,
    setLoading,
    clearAuth,
    getRoles, // Función reactiva para obtener roles
  };
};
