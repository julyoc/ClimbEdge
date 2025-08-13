import { server$ } from '@builder.io/qwik-city'
import { ApiResponse, AuthResponseDTO, authService, UserInfoDTO } from '~/services/auth.service'

export const authServer = {
  login: server$(async (data): Promise<ApiResponse<AuthResponseDTO>> => {
    return await authService.login(data);
  }),

  register: server$(async (data): Promise<ApiResponse<AuthResponseDTO>> => {
    return await authService.register(data);
  }),

  logout: server$(async (): Promise<ApiResponse<void>> => {
    return await authService.logout();
  }),

  getCurrentUser: server$(async (): Promise<ApiResponse<UserInfoDTO>> => {
    return await authService.getCurrentUser();
  }),

  changePassword: server$(async (data): Promise<ApiResponse<void>> => {
    return await authService.changePassword(data);
  }),

  forgotPassword: server$(async (data): Promise<ApiResponse<void>> => {
    return await authService.forgotPassword(data);
  }),

  resetPassword: server$(async (data): Promise<ApiResponse<void>> => {
    return await authService.resetPassword(data);
  }),

  refreshToken: server$(async (data): Promise<ApiResponse<AuthResponseDTO>> => {
    return await authService.refreshToken(data);
  }),
}