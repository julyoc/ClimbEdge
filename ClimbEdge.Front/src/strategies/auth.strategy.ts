import type { LoginRequestDTO, RegisterRequestDTO, ApiResponse, AuthResponseDTO, ChangePasswordRequestDTO, ForgotPasswordRequestDTO, ResetPasswordRequestDTO, RefreshTokenRequestDTO, UserInfoDTO } from '~/services/auth.service';
import { authService } from '~/services/auth.service';
import { authServer } from '~/server/auth.server';

export interface AuthStrategyOptions {
  forceServer?: boolean;
  forceClient?: boolean;
  environment?: 'development' | 'production' | 'testing';
}

export const authStrategy = {
  // 🎯 Login unificado
  login: async (data: LoginRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<AuthResponseDTO>> => {
    const shouldUseServer = determineStrategy('login', options);
    
    if (shouldUseServer) {
      console.log('🔧 Using SERVER login strategy');
      return await authServer.login(data);
    } else {
      console.log('🎯 Using CLIENT login strategy');
      return await authService.login(data);
    }
  },

  // 🎯 Register unificado
  register: async (data: RegisterRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<AuthResponseDTO>> => {
    const shouldUseServer = determineStrategy('register', options);
    
    if (shouldUseServer) {
      console.log('🔧 Using SERVER register strategy');
      return await authServer.register(data);
    } else {
      console.log('🎯 Using CLIENT register strategy');
      return await authService.register(data);
    }
  },

  // 🎯 Logout unificado
  logout: async (options?: AuthStrategyOptions): Promise<ApiResponse<void>> => {
    const shouldUseServer = determineStrategy('logout', options);
    
    if (shouldUseServer) {
      return await authServer.logout();
    } else {
      return await authService.logout();
    }
  },

  // 🎯 Get current user unificado
  getCurrentUser: async (options?: AuthStrategyOptions): Promise<ApiResponse<UserInfoDTO>> => {
    const shouldUseServer = determineStrategy('getCurrentUser', options);
    
    if (shouldUseServer) {
      return await authServer.getCurrentUser();
    } else {
      return await authService.getCurrentUser();
    }
  },

  // 🎯 Change password unificado
  changePassword: async (data: ChangePasswordRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<void>> => {
    const shouldUseServer = determineStrategy('changePassword', options);
    
    if (shouldUseServer) {
      return await authServer.changePassword(data);
    } else {
      return await authService.changePassword(data);
    }
  },

  // 🎯 Forgot password unificado
  forgotPassword: async (data: ForgotPasswordRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<void>> => {
    const shouldUseServer = determineStrategy('forgotPassword', options);
    
    if (shouldUseServer) {
      return await authServer.forgotPassword(data);
    } else {
      return await authService.forgotPassword(data);
    }
  },

  // 🎯 Reset password unificado
  resetPassword: async (data: ResetPasswordRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<void>> => {
    const shouldUseServer = determineStrategy('resetPassword', options);
    
    if (shouldUseServer) {
      return await authServer.resetPassword(data);
    } else {
      return await authService.resetPassword(data);
    }
  },

  // 🎯 Refresh token unificado
  refreshToken: async (data: RefreshTokenRequestDTO, options?: AuthStrategyOptions): Promise<ApiResponse<AuthResponseDTO>> => {
    const shouldUseServer = determineStrategy('refreshToken', options);
    
    if (shouldUseServer) {
      return await authServer.refreshToken(data);
    } else {
      return await authService.refreshToken(data);
    }
  },
};

// 🧠 Lógica para determinar qué estrategia usar
function determineStrategy(operation: string, options?: AuthStrategyOptions): boolean {
  // Forzar cliente
  if (options?.forceClient) {
    return false;
  }

  // Forzar servidor
  if (options?.forceServer) {
    return true;
  }

  // Determinar por entorno
  const environment = options?.environment || (import.meta.env.PROD ? 'production' : 'development');
  
  switch (environment) {
    case 'production':
      // En producción, usar servidor para operaciones críticas
      return ['login', 'register', 'changePassword', 'refreshToken'].includes(operation);
      
    case 'testing':
      // En testing, usar cliente para velocidad
      return false;
      
    case 'development':
    default:
      // En desarrollo, usar cliente por defecto, servidor para operaciones sensibles
      return ['changePassword', 'refreshToken'].includes(operation);
  }
}

// 🛠️ Utilidades adicionales
export const authStrategyUtils = {
  // Cambiar estrategia globalmente
  setGlobalStrategy: (useServer: boolean) => {
    (globalThis as any).__AUTH_STRATEGY_USE_SERVER = useServer;
  },

  // Obtener estrategia global
  getGlobalStrategy: (): boolean | undefined => {
    return (globalThis as any).__AUTH_STRATEGY_USE_SERVER;
  },

  // Detectar si estamos en servidor
  isServerContext: (): boolean => {
    return typeof window === 'undefined';
  },

  // Obtener información de la estrategia actual
  getStrategyInfo: () => {
    return {
      environment: import.meta.env.PROD ? 'production' : 'development',
      isServer: typeof window === 'undefined',
      globalStrategy: (globalThis as any).__AUTH_STRATEGY_USE_SERVER,
    };
  },
};