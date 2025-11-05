import { BaseDTO } from "./BaseDTO";

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

export class UserInfoDTO extends BaseDTO {
  email?: string;
  userName?: string;
  firstName?: string;
  lastName?: string;
  emailConfirmed!: boolean;
  roles?: string[];
}

export class AuthResponseDTO {
  token!: string;
  refreshToken!: string;
  user!: UserInfoDTO;
}