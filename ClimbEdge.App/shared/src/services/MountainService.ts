import type { CreateMountainDTO, UpdateMountainDTO, GetMountainDTO, CreateMountainRouteDTO, UpdateMountainRouteDTO, GetMountainRouteDTO, CreateRouteTrackDTO, GetRouteTrackDTO, CreateRouteWaypointDTO, GetRouteWaypointDTO, CreateWeatherConditionDTO, GetWeatherConditionDTO } from '../types/MountainDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface MountainService {
  getAll: () => Promise<ApiResponse<GetMountainDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetMountainDTO>>;
  create: (data: CreateMountainDTO) => Promise<ApiResponse<GetMountainDTO>>;
  update: (uid: string, data: UpdateMountainDTO) => Promise<ApiResponse<GetMountainDTO>>;
  delete: (uid: string) => Promise<ApiResponse<void>>;
  getRoutes: (mountainId: number) => Promise<ApiResponse<GetMountainRouteDTO[]>>;
  getRouteByUid: (uid: string) => Promise<ApiResponse<GetMountainRouteDTO>>;
  createRoute: (data: CreateMountainRouteDTO) => Promise<ApiResponse<GetMountainRouteDTO>>;
  updateRoute: (uid: string, data: UpdateMountainRouteDTO) => Promise<ApiResponse<GetMountainRouteDTO>>;
  deleteRoute: (uid: string) => Promise<ApiResponse<void>>;
  getRouteTracks: (mountainRouteId: number) => Promise<ApiResponse<GetRouteTrackDTO[]>>;
  createRouteTrack: (data: CreateRouteTrackDTO) => Promise<ApiResponse<GetRouteTrackDTO>>;
  getRouteWaypoints: (mountainRouteId: number) => Promise<ApiResponse<GetRouteWaypointDTO[]>>;
  createRouteWaypoint: (data: CreateRouteWaypointDTO) => Promise<ApiResponse<GetRouteWaypointDTO>>;
  getWeatherConditions: (mountainId: number, from?: string, to?: string) => Promise<ApiResponse<GetWeatherConditionDTO[]>>;
  createWeatherCondition: (data: CreateWeatherConditionDTO) => Promise<ApiResponse<GetWeatherConditionDTO>>;
}

export function createMountainService(config: ServiceConfig): MountainService {
  const base = `${config.baseUrl}/api/mountain`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getAll = async (): Promise<ApiResponse<GetMountainDTO[]>> => {
    try {
      const res = await fetch(base, opts('GET'));
      return handleResponse<GetMountainDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetMountainDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET'));
      return handleResponse<GetMountainDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateMountainDTO): Promise<ApiResponse<GetMountainDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetMountainDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateMountainDTO): Promise<ApiResponse<GetMountainDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', data));
      return handleResponse<GetMountainDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getRoutes = async (mountainId: number): Promise<ApiResponse<GetMountainRouteDTO[]>> => {
    try {
      const res = await fetch(`${base}/${mountainId}/routes`, opts('GET'));
      return handleResponse<GetMountainRouteDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getRouteByUid = async (uid: string): Promise<ApiResponse<GetMountainRouteDTO>> => {
    try {
      const res = await fetch(`${base}/route/${uid}`, opts('GET'));
      return handleResponse<GetMountainRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createRoute = async (data: CreateMountainRouteDTO): Promise<ApiResponse<GetMountainRouteDTO>> => {
    try {
      const res = await fetch(`${base}/route`, opts('POST', data));
      return handleResponse<GetMountainRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const updateRoute = async (uid: string, data: UpdateMountainRouteDTO): Promise<ApiResponse<GetMountainRouteDTO>> => {
    try {
      const res = await fetch(`${base}/route/${uid}`, opts('PUT', data));
      return handleResponse<GetMountainRouteDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const deleteMountain = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const deleteRoute = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/route/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getRouteTracks = async (mountainRouteId: number): Promise<ApiResponse<GetRouteTrackDTO[]>> => {
    try {
      const res = await fetch(`${base}/route/${mountainRouteId}/tracks`, opts('GET'));
      return handleResponse<GetRouteTrackDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createRouteTrack = async (data: CreateRouteTrackDTO): Promise<ApiResponse<GetRouteTrackDTO>> => {
    try {
      const res = await fetch(`${base}/route/track`, opts('POST', data));
      return handleResponse<GetRouteTrackDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getRouteWaypoints = async (mountainRouteId: number): Promise<ApiResponse<GetRouteWaypointDTO[]>> => {
    try {
      const res = await fetch(`${base}/route/${mountainRouteId}/waypoints`, opts('GET'));
      return handleResponse<GetRouteWaypointDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createRouteWaypoint = async (data: CreateRouteWaypointDTO): Promise<ApiResponse<GetRouteWaypointDTO>> => {
    try {
      const res = await fetch(`${base}/route/waypoint`, opts('POST', data));
      return handleResponse<GetRouteWaypointDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getWeatherConditions = async (mountainId: number, from?: string, to?: string): Promise<ApiResponse<GetWeatherConditionDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (from) params.set('from', from);
      if (to) params.set('to', to);
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}/${mountainId}/weather${qs}`, opts('GET'));
      return handleResponse<GetWeatherConditionDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createWeatherCondition = async (data: CreateWeatherConditionDTO): Promise<ApiResponse<GetWeatherConditionDTO>> => {
    try {
      const res = await fetch(`${base}/weather`, opts('POST', data));
      return handleResponse<GetWeatherConditionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, delete: deleteMountain, getRoutes, getRouteByUid, createRoute, updateRoute, deleteRoute, getRouteTracks, createRouteTrack, getRouteWaypoints, createRouteWaypoint, getWeatherConditions, createWeatherCondition };
}
