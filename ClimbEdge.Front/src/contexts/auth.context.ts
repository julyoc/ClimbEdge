import { 
  createContextId, 
  useContext, 
  useSignal, 
  $,
  type Signal
} from '@builder.io/qwik';
import type { UserInfoDTO } from '~/services/auth.service';

export interface AuthStore {
  user: Signal<UserInfoDTO | null>;
  isAuthenticated: Signal<boolean>;
  isLoading: Signal<boolean>;
}

export const AuthContext = createContextId<AuthStore>('auth-context');

export const useAuthStore = () => {
  const user = useSignal<UserInfoDTO | null>(null);
  const isAuthenticated = useSignal(false);
  const isLoading = useSignal(false);

  return {
    user,
    isAuthenticated,
    isLoading,
  };
};

export const useAuth = () => {
  const authStore = useContext(AuthContext);
  
  const setUser = $((userData: UserInfoDTO | null) => {
    authStore.user.value = userData;
    authStore.isAuthenticated.value = !!userData;
  });

  const setLoading = $((loading: boolean) => {
    authStore.isLoading.value = loading;
  });

  const clearAuth = $(() => {
    authStore.user.value = null;
    authStore.isAuthenticated.value = false;
    authStore.isLoading.value = false;
  });

  return {
    user: authStore.user,
    isAuthenticated: authStore.isAuthenticated,
    isLoading: authStore.isLoading,
    setUser,
    setLoading,
    clearAuth,
  };
};
