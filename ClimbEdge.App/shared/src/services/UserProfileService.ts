import type { CreateUserProfileDTO, UpdateUserProfileDTO, GetUserProfileDTO } from '../types/UserProfileDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface UserProfileService {
  getProfile: (userId: number) => Promise<ApiResponse<GetUserProfileDTO>>;
  create: (data: CreateUserProfileDTO) => Promise<ApiResponse<GetUserProfileDTO>>;
  update: (userId: number, data: UpdateUserProfileDTO) => Promise<ApiResponse<GetUserProfileDTO>>;
}

export function createUserProfileService(config: ServiceConfig): UserProfileService {
  const base = `${config.baseUrl}/api/userProfile`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getProfile = async (userId: number): Promise<ApiResponse<GetUserProfileDTO>> => {
    try {
      const res = await fetch(`${base}/${userId}`, opts('GET'));
      return handleResponse<GetUserProfileDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateUserProfileDTO): Promise<ApiResponse<GetUserProfileDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetUserProfileDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (userId: number, data: UpdateUserProfileDTO): Promise<ApiResponse<GetUserProfileDTO>> => {
    try {
      const res = await fetch(`${base}/${userId}`, opts('PUT', data));
      return handleResponse<GetUserProfileDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getProfile, create, update };
}
