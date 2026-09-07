import type { CreateClimbZoneDTO, UpdateClimbZoneDTO, GetClimbZoneDTO } from '../types/ClimbZoneDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface ClimbZoneService {
  getAll: () => Promise<ApiResponse<GetClimbZoneDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetClimbZoneDTO>>;
  create: (data: CreateClimbZoneDTO) => Promise<ApiResponse<GetClimbZoneDTO>>;
  update: (uid: string, data: UpdateClimbZoneDTO) => Promise<ApiResponse<GetClimbZoneDTO>>;
  remove: (uid: string) => Promise<ApiResponse<void>>;
}

export function createClimbZoneService(config: ServiceConfig): ClimbZoneService {
  const base = `${config.baseUrl}/api/climbZone`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getAll = async (): Promise<ApiResponse<GetClimbZoneDTO[]>> => {
    try {
      const res = await fetch(base, opts('GET'));
      return handleResponse<GetClimbZoneDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetClimbZoneDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET'));
      return handleResponse<GetClimbZoneDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateClimbZoneDTO): Promise<ApiResponse<GetClimbZoneDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetClimbZoneDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateClimbZoneDTO): Promise<ApiResponse<GetClimbZoneDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', data));
      return handleResponse<GetClimbZoneDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const remove = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, remove };
}
