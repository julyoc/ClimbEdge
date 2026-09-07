import type { CreateExpeditionDTO, UpdateExpeditionDTO, GetExpeditionDTO, AddExpeditionParticipantDTO, GetExpeditionParticipantDTO, AddExpeditionEquipmentDTO, GetExpeditionEquipmentDTO, ExpeditionFilters, CreateSafetyPlanDTO, UpdateSafetyPlanDTO, GetSafetyPlanDTO, CreateItineraryDayTrackDTO, GetItineraryDayTrackDTO, CreateItineraryDayWaypointDTO, GetItineraryDayWaypointDTO, CreateEquipmentCatalogDTO, GetEquipmentCatalogDTO, GetDebriefDTO } from '../types/ExpeditionDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface ExpeditionService {
  getAll: (filters?: ExpeditionFilters) => Promise<ApiResponse<GetExpeditionDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetExpeditionDTO>>;
  create: (data: CreateExpeditionDTO) => Promise<ApiResponse<GetExpeditionDTO>>;
  update: (uid: string, data: UpdateExpeditionDTO) => Promise<ApiResponse<GetExpeditionDTO>>;
  delete: (uid: string) => Promise<ApiResponse<void>>;
  activate: (expeditionUid: string) => Promise<ApiResponse<void>>;
  close: (expeditionUid: string, closingNotes?: string) => Promise<ApiResponse<void>>;
  getPerformance: (uid: string) => Promise<ApiResponse<unknown>>;
  getDebrief: (expeditionId: number) => Promise<ApiResponse<GetDebriefDTO>>;
  getSafetyPlan: (expeditionId: number) => Promise<ApiResponse<GetSafetyPlanDTO>>;
  createSafetyPlan: (data: CreateSafetyPlanDTO) => Promise<ApiResponse<GetSafetyPlanDTO>>;
  updateSafetyPlan: (expeditionId: number, data: UpdateSafetyPlanDTO) => Promise<ApiResponse<GetSafetyPlanDTO>>;
  getParticipants: (expeditionId: number) => Promise<ApiResponse<GetExpeditionParticipantDTO[]>>;
  addParticipant: (data: AddExpeditionParticipantDTO) => Promise<ApiResponse<void>>;
  getEquipment: (expeditionId: number) => Promise<ApiResponse<GetExpeditionEquipmentDTO[]>>;
  addEquipment: (data: AddExpeditionEquipmentDTO) => Promise<ApiResponse<void>>;
  removeEquipment: (equipmentId: number) => Promise<ApiResponse<void>>;
  getBudget: (expeditionId: number) => Promise<ApiResponse<unknown>>;
  createBudgetItem: (data: unknown) => Promise<ApiResponse<void>>;
  getItinerary: (expeditionId: number) => Promise<ApiResponse<unknown>>;
  createItineraryDay: (data: unknown) => Promise<ApiResponse<void>>;
  getItineraryDayTracks: (itineraryDayId: number) => Promise<ApiResponse<GetItineraryDayTrackDTO[]>>;
  createItineraryDayTrack: (data: CreateItineraryDayTrackDTO) => Promise<ApiResponse<GetItineraryDayTrackDTO>>;
  getItineraryDayWaypoints: (itineraryDayId: number) => Promise<ApiResponse<GetItineraryDayWaypointDTO[]>>;
  createItineraryDayWaypoint: (data: CreateItineraryDayWaypointDTO) => Promise<ApiResponse<GetItineraryDayWaypointDTO>>;
  getEquipmentCatalog: (categoryId?: number) => Promise<ApiResponse<GetEquipmentCatalogDTO[]>>;
  createEquipmentCatalogItem: (data: CreateEquipmentCatalogDTO) => Promise<ApiResponse<GetEquipmentCatalogDTO>>;
}

export function createExpeditionService(config: ServiceConfig): ExpeditionService {
  const base = `${config.baseUrl}/api/expedition`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getAll = async (filters?: ExpeditionFilters): Promise<ApiResponse<GetExpeditionDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.mountainId != null) params.set('mountainId', String(filters.mountainId));
      if (filters?.publicOnly != null) params.set('publicOnly', String(filters.publicOnly));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}${qs}`, opts('GET'));
      return handleResponse<GetExpeditionDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetExpeditionDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET'));
      return handleResponse<GetExpeditionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateExpeditionDTO): Promise<ApiResponse<GetExpeditionDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetExpeditionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateExpeditionDTO): Promise<ApiResponse<GetExpeditionDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', data));
      return handleResponse<GetExpeditionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const activate = async (expeditionUid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/activate`, opts('POST', { expeditionUid }));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const close = async (expeditionUid: string, closingNotes?: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/close`, opts('POST', { expeditionUid, closingNotes }));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPerformance = async (uid: string): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/${uid}/performance`, opts('GET'));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getParticipants = async (expeditionId: number): Promise<ApiResponse<GetExpeditionParticipantDTO[]>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/participants`, opts('GET'));
      return handleResponse<GetExpeditionParticipantDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const addParticipant = async (data: AddExpeditionParticipantDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/participant`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getEquipment = async (expeditionId: number): Promise<ApiResponse<GetExpeditionEquipmentDTO[]>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/equipment`, opts('GET'));
      return handleResponse<GetExpeditionEquipmentDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const addEquipment = async (data: AddExpeditionEquipmentDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/equipment`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const removeEquipment = async (equipmentId: number): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/equipment/${equipmentId}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getBudget = async (expeditionId: number): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/budget`, opts('GET'));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createBudgetItem = async (data: unknown): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/budget`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getItinerary = async (expeditionId: number): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/itinerary`, opts('GET'));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createItineraryDay = async (data: unknown): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/itinerary/day`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const deleteExpedition = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getDebrief = async (expeditionId: number): Promise<ApiResponse<GetDebriefDTO>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/debrief`, opts('GET'));
      return handleResponse<GetDebriefDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getSafetyPlan = async (expeditionId: number): Promise<ApiResponse<GetSafetyPlanDTO>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/safety-plan`, opts('GET'));
      return handleResponse<GetSafetyPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createSafetyPlan = async (data: CreateSafetyPlanDTO): Promise<ApiResponse<GetSafetyPlanDTO>> => {
    try {
      const res = await fetch(`${base}/safety-plan`, opts('POST', data));
      return handleResponse<GetSafetyPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const updateSafetyPlan = async (expeditionId: number, data: UpdateSafetyPlanDTO): Promise<ApiResponse<GetSafetyPlanDTO>> => {
    try {
      const res = await fetch(`${base}/${expeditionId}/safety-plan`, opts('PUT', data));
      return handleResponse<GetSafetyPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getItineraryDayTracks = async (itineraryDayId: number): Promise<ApiResponse<GetItineraryDayTrackDTO[]>> => {
    try {
      const res = await fetch(`${base}/itinerary/day/${itineraryDayId}/tracks`, opts('GET'));
      return handleResponse<GetItineraryDayTrackDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createItineraryDayTrack = async (data: CreateItineraryDayTrackDTO): Promise<ApiResponse<GetItineraryDayTrackDTO>> => {
    try {
      const res = await fetch(`${base}/itinerary/day/track`, opts('POST', data));
      return handleResponse<GetItineraryDayTrackDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getItineraryDayWaypoints = async (itineraryDayId: number): Promise<ApiResponse<GetItineraryDayWaypointDTO[]>> => {
    try {
      const res = await fetch(`${base}/itinerary/day/${itineraryDayId}/waypoints`, opts('GET'));
      return handleResponse<GetItineraryDayWaypointDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createItineraryDayWaypoint = async (data: CreateItineraryDayWaypointDTO): Promise<ApiResponse<GetItineraryDayWaypointDTO>> => {
    try {
      const res = await fetch(`${base}/itinerary/day/waypoint`, opts('POST', data));
      return handleResponse<GetItineraryDayWaypointDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getEquipmentCatalog = async (categoryId?: number): Promise<ApiResponse<GetEquipmentCatalogDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (categoryId != null) params.set('categoryId', String(categoryId));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}/equipment/catalog${qs}`, opts('GET'));
      return handleResponse<GetEquipmentCatalogDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createEquipmentCatalogItem = async (data: CreateEquipmentCatalogDTO): Promise<ApiResponse<GetEquipmentCatalogDTO>> => {
    try {
      const res = await fetch(`${base}/equipment/catalog`, opts('POST', data));
      return handleResponse<GetEquipmentCatalogDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, delete: deleteExpedition, activate, close, getPerformance, getDebrief, getSafetyPlan, createSafetyPlan, updateSafetyPlan, getParticipants, addParticipant, getEquipment, addEquipment, removeEquipment, getBudget, createBudgetItem, getItinerary, createItineraryDay, getItineraryDayTracks, createItineraryDayTrack, getItineraryDayWaypoints, createItineraryDayWaypoint, getEquipmentCatalog, createEquipmentCatalogItem };
}
