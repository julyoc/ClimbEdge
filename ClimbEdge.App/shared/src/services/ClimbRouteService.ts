import type { CreateClimbRouteDTO, UpdateClimbRouteDTO, GetClimbRouteDTO, GetDifficultyScaleDTO, ClimbRouteFilters } from '../types/ClimbRouteDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface ClimbRouteService {
  getAll: (filters?: ClimbRouteFilters) => Promise<ApiResponse<GetClimbRouteDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetClimbRouteDTO>>;
  create: (data: CreateClimbRouteDTO) => Promise<ApiResponse<GetClimbRouteDTO>>;
  update: (uid: string, data: UpdateClimbRouteDTO) => Promise<ApiResponse<GetClimbRouteDTO>>;
  remove: (uid: string) => Promise<ApiResponse<void>>;
  getDifficultyScales: (difficultyScaleNameId?: number) => Promise<ApiResponse<GetDifficultyScaleDTO[]>>;
}

export function createClimbRouteService(config: ServiceConfig): ClimbRouteService {
  const base = `${config.baseUrl}/api/climbRoute`;
  const opts = (method: string, auth: boolean, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, auth, config.token, body);

  const getAll = async (filters?: ClimbRouteFilters): Promise<ApiResponse<GetClimbRouteDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.climbZoneId != null) params.set('climbZoneId', String(filters.climbZoneId));
      if (filters?.difficultyScaleNameId != null) params.set('difficultyScaleNameId', String(filters.difficultyScaleNameId));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}${qs}`, opts('GET', true));
      return handleResponse<GetClimbRouteDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetClimbRouteDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET', true));
      return handleResponse<GetClimbRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateClimbRouteDTO): Promise<ApiResponse<GetClimbRouteDTO>> => {
    try {
      const res = await fetch(base, opts('POST', true, data));
      return handleResponse<GetClimbRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateClimbRouteDTO): Promise<ApiResponse<GetClimbRouteDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', true, data));
      return handleResponse<GetClimbRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const remove = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('DELETE', true));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getDifficultyScales = async (difficultyScaleNameId?: number): Promise<ApiResponse<GetDifficultyScaleDTO[]>> => {
    try {
      const qs = difficultyScaleNameId != null ? `?difficultyScaleNameId=${difficultyScaleNameId}` : '';
      const res = await fetch(`${base}/difficulty-scales${qs}`, opts('GET', true));
      return handleResponse<GetDifficultyScaleDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, remove, getDifficultyScales };
}
