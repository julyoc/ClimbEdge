import type { CreateOrganizationDTO, UpdateOrganizationDTO, GetOrganizationDTO, AddOrganizationMemberDTO, RemoveOrganizationMemberDTO, GetOrganizationMemberDTO, CreateOrganizationEventDTO, UpdateOrganizationEventDTO, GetOrganizationEventDTO, RegisterEventParticipantDTO, GetOrganizationEventParticipantDTO, OrganizationFilters } from '../types/OrganizationDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface OrganizationService {
  getAll: (filters?: OrganizationFilters) => Promise<ApiResponse<GetOrganizationDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetOrganizationDTO>>;
  create: (data: CreateOrganizationDTO) => Promise<ApiResponse<GetOrganizationDTO>>;
  update: (uid: string, data: UpdateOrganizationDTO) => Promise<ApiResponse<GetOrganizationDTO>>;
  getMembers: (orgId: number) => Promise<ApiResponse<GetOrganizationMemberDTO[]>>;
  addMember: (data: AddOrganizationMemberDTO) => Promise<ApiResponse<void>>;
  removeMember: (data: RemoveOrganizationMemberDTO) => Promise<ApiResponse<void>>;
  getEvents: (orgId: number) => Promise<ApiResponse<GetOrganizationEventDTO[]>>;
  createEvent: (data: CreateOrganizationEventDTO) => Promise<ApiResponse<GetOrganizationEventDTO>>;
  updateEvent: (uid: string, data: UpdateOrganizationEventDTO) => Promise<ApiResponse<GetOrganizationEventDTO>>;
  registerEventParticipant: (data: RegisterEventParticipantDTO) => Promise<ApiResponse<GetOrganizationEventParticipantDTO>>;
}

export function createOrganizationService(config: ServiceConfig): OrganizationService {
  const base = `${config.baseUrl}/api/organization`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getAll = async (filters?: OrganizationFilters): Promise<ApiResponse<GetOrganizationDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.publicOnly != null) params.set('publicOnly', String(filters.publicOnly));
      if (filters?.country) params.set('country', filters.country);
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}${qs}`, opts('GET'));
      return handleResponse<GetOrganizationDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetOrganizationDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET'));
      return handleResponse<GetOrganizationDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateOrganizationDTO): Promise<ApiResponse<GetOrganizationDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetOrganizationDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateOrganizationDTO): Promise<ApiResponse<GetOrganizationDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', data));
      return handleResponse<GetOrganizationDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getMembers = async (orgId: number): Promise<ApiResponse<GetOrganizationMemberDTO[]>> => {
    try {
      const res = await fetch(`${base}/${orgId}/members`, opts('GET'));
      return handleResponse<GetOrganizationMemberDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const addMember = async (data: AddOrganizationMemberDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/member`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const removeMember = async (data: RemoveOrganizationMemberDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/member`, opts('DELETE', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getEvents = async (orgId: number): Promise<ApiResponse<GetOrganizationEventDTO[]>> => {
    try {
      const res = await fetch(`${base}/${orgId}/events`, opts('GET'));
      return handleResponse<GetOrganizationEventDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createEvent = async (data: CreateOrganizationEventDTO): Promise<ApiResponse<GetOrganizationEventDTO>> => {
    try {
      const res = await fetch(`${base}/event`, opts('POST', data));
      return handleResponse<GetOrganizationEventDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const updateEvent = async (uid: string, data: UpdateOrganizationEventDTO): Promise<ApiResponse<GetOrganizationEventDTO>> => {
    try {
      const res = await fetch(`${base}/event/${uid}`, opts('PUT', data));
      return handleResponse<GetOrganizationEventDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const registerEventParticipant = async (data: RegisterEventParticipantDTO): Promise<ApiResponse<GetOrganizationEventParticipantDTO>> => {
    try {
      const res = await fetch(`${base}/event/register`, opts('POST', data));
      return handleResponse<GetOrganizationEventParticipantDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, getMembers, addMember, removeMember, getEvents, createEvent, updateEvent, registerEventParticipant };
}
