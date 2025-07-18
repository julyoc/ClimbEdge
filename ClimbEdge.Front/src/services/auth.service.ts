import { $ } from '@builder.io/qwik';

// Tipos basados en los DTOs del backend
export interface RegisterRequestDTO {
  email: string;
  password: string;
  confirmPassword: string;
  firstName?: string;
  lastName?: string;
}

export interface LoginRequestDTO {
  email: string;
  password: string;
}

export interface ChangePasswordRequestDTO {
  currentPassword: string;
  newPassword: string;
  confirmPassword: string;
}

export interface ForgotPasswordRequestDTO {
  email: string;
}

export interface ResetPasswordRequestDTO {
  email: string;
  token: string;
  newPassword: string;
  confirmPassword: string;
}

export interface RefreshTokenRequestDTO {
  token: string;
  refreshToken: string;
}

export interface UserInfoDTO {
  id: string;
  email?: string;
  userName?: string;
  firstName?: string;
  lastName?: string;
  emailConfirmed: boolean;
  roles?: string[];
}

export interface AuthResponseDTO {
  token: string;
  refreshToken: string;
  user: UserInfoDTO;
}

export interface ApiResponse<T> {
  data?: T;
  error?: string;
  success: boolean;
}

const API_BASE_URL = '/api/account';

export const authService = {
  register: $(async (data: RegisterRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/register`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        credentials: 'include', // Para incluir cookies
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Error en el registro',
        };
      }

      const result = await response.json();
      return {
        success: true,
        data: result,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  login: $(async (data: LoginRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        credentials: 'include', // Para incluir cookies
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Credenciales inválidas',
        };
      }

      const result = await response.json();
      return {
        success: true,
        data: result,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  logout: $(async (): Promise<ApiResponse<void>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/logout`, {
        method: 'POST',
        credentials: 'include',
      });

      if (!response.ok) {
        return {
          success: false,
          error: 'Error al cerrar sesión',
        };
      }

      return {
        success: true,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  getCurrentUser: $(async (): Promise<ApiResponse<UserInfoDTO>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/me`, {
        method: 'GET',
        credentials: 'include',
      });

      if (!response.ok) {
        return {
          success: false,
          error: 'No autenticado',
        };
      }

      const result = await response.json();
      return {
        success: true,
        data: result,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  changePassword: $(async (data: ChangePasswordRequestDTO): Promise<ApiResponse<void>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/change-password`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        credentials: 'include',
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Error al cambiar contraseña',
        };
      }

      return {
        success: true,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  forgotPassword: $(async (data: ForgotPasswordRequestDTO): Promise<ApiResponse<void>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/forgot-password`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Error al enviar email',
        };
      }

      return {
        success: true,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  resetPassword: $(async (data: ResetPasswordRequestDTO): Promise<ApiResponse<void>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/reset-password`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Error al restablecer contraseña',
        };
      }

      return {
        success: true,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión' + error.message,
      };
    }
  }),

  refreshToken: $(async (data: RefreshTokenRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/refresh-token`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        credentials: 'include',
      });

      if (!response.ok) {
        const errorData = await response.json();
        return {
          success: false,
          error: errorData.message || 'Error al renovar token',
        };
      }

      const result = await response.json();
      return {
        success: true,
        data: result,
      };
    } catch (error: any) {
      return {
        success: false,
        error: 'Error de conexión'+ error.message,
      };
    }
  }),
};
