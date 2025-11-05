import type { AuthResponseDTO, ChangePasswordRequestDTO, ForgotPasswordRequestDTO, LoginRequestDTO, RefreshTokenRequestDTO, RegisterRequestDTO, ResetPasswordRequestDTO, UserInfoDTO } from "../types/AppUserDTO";
import type { ApiResponse } from "./index";

export interface AuthServiceConfig {
    baseUrl: string;
    apiKey: string;
    token?: string;
}

export interface AuthService {
    register: (data: RegisterRequestDTO) => Promise<ApiResponse<AuthResponseDTO>>;
    login: (data: LoginRequestDTO) => Promise<ApiResponse<AuthResponseDTO>>;
    logout: () => Promise<ApiResponse<void>>;
    getCurrentUser: () => Promise<ApiResponse<UserInfoDTO>>;
    changePassword: (data: ChangePasswordRequestDTO) => Promise<ApiResponse<void>>;
    forgotPassword: (data: ForgotPasswordRequestDTO) => Promise<ApiResponse<void>>;
    resetPassword: (data: ResetPasswordRequestDTO) => Promise<ApiResponse<void>>;
    refreshToken: (data: RefreshTokenRequestDTO) => Promise<ApiResponse<AuthResponseDTO>>;
    setAuthToken: (token: string) => void;
}

// Constants
const API_KEY_HEADER_NAME = "X-API-Key";
const IsWebEnvironment = typeof window !== 'undefined';

/**
 * Función para crear una instancia del AuthService
 * @param config Configuración del servicio
 * @returns Nueva instancia de AuthService
 */
export function createAuthService(config: AuthServiceConfig): AuthService {
    const baseUrl = config.baseUrl + '/account';
    const apiKey = config.apiKey;
    let authToken = config.token;

    const getFetchOptions = (method: string, requiresAuth: boolean, body?: any): RequestInit => {
        const options: RequestInit = {
            method,
            headers: getHeaders(requiresAuth),
        };

        if (body) {
            options.body = JSON.stringify(body);
        }

        // Solo incluir credenciales/auth si se requiere autenticación
        if (requiresAuth && IsWebEnvironment) {
            options.credentials = 'include';
        }

        return options;
    };

    const getHeaders = (requiresAuth: boolean = true): HeadersInit => {
        const headers: HeadersInit = {
            'Content-Type': 'application/json',
            [API_KEY_HEADER_NAME]: apiKey,
        };

        // Solo agregar Authorization si se requiere auth y tenemos token
        if (requiresAuth && !IsWebEnvironment && authToken) {
            headers['Authorization'] = `Bearer ${authToken}`;
        }

        return headers;
    };

    // Función para actualizar el token (útil para entornos no-web)
    const setAuthToken = (token: string): void => {
        authToken = token;
    };

    const register = async (data: RegisterRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
        try {
            const response = await fetch(`${baseUrl}/register`, {
                ...getFetchOptions('POST', false, data) // No requiere auth
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
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const login = async (data: LoginRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
        try {
            const response = await fetch(`${baseUrl}/login`, {
                ...getFetchOptions('POST', false, data) // No requiere auth
            });

            if (!response.ok) {
                const errorData = await response.json();
                return {
                    success: false,
                    error: errorData.message || 'Error en el login',
                };
            }

            const result = await response.json();

            // Si estamos en entorno no-web y obtenemos un token, guardarlo
            if (!IsWebEnvironment && result.token) {
                setAuthToken(result.token);
            }

            return {
                success: true,
                data: result,
            };
        } catch (error: any) {
            return {
                success: false,
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const logout = async (): Promise<ApiResponse<void>> => {
        try {
            const response = await fetch(`${baseUrl}/logout`, {
                ...getFetchOptions('POST', true)
            });

            if (!response.ok) {
                return {
                    success: false,
                    error: 'Error al cerrar sesión',
                };
            }

            // Limpiar token en entornos no-web
            if (!IsWebEnvironment) {
                authToken = undefined;
            }

            return {
                success: true,
            };
        } catch (error: any) {
            return {
                success: false,
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const getCurrentUser = async (): Promise<ApiResponse<UserInfoDTO>> => {
        try {
            const response = await fetch(`${baseUrl}/me`, {
                ...getFetchOptions('GET', true)
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
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const changePassword = async (data: ChangePasswordRequestDTO): Promise<ApiResponse<void>> => {
        try {
            const response = await fetch(`${baseUrl}/change-password`, {
                ...getFetchOptions('POST', true, data)
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
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const forgotPassword = async (data: ForgotPasswordRequestDTO): Promise<ApiResponse<void>> => {
        try {
            const response = await fetch(`${baseUrl}/forgot-password`, {
                ...getFetchOptions('POST', false, data) // No requiere auth
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
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const resetPassword = async (data: ResetPasswordRequestDTO): Promise<ApiResponse<void>> => {
        try {
            const response = await fetch(`${baseUrl}/reset-password`, {
                ...getFetchOptions('POST', false, data) // No requiere auth
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
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    const refreshToken = async (data: RefreshTokenRequestDTO): Promise<ApiResponse<AuthResponseDTO>> => {
        try {
            const response = await fetch(`${baseUrl}/refresh-token`, {
                ...getFetchOptions('POST', false, data) // No requiere auth inicial
            });

            if (!response.ok) {
                const errorData = await response.json();
                return {
                    success: false,
                    error: errorData.message || 'Error al renovar token',
                };
            }

            const result = await response.json();

            // Si estamos en entorno no-web y obtenemos un nuevo token, guardarlo
            if (!IsWebEnvironment && result.token) {
                setAuthToken(result.token);
            }

            return {
                success: true,
                data: result,
            };
        } catch (error: any) {
            return {
                success: false,
                error: 'Error de conexión: ' + error.message,
            };
        }
    };

    return {
        register,
        login,
        logout,
        getCurrentUser,
        changePassword,
        forgotPassword,
        resetPassword,
        refreshToken,
        setAuthToken,
    };
}