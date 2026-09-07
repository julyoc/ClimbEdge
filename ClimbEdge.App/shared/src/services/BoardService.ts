import type { CreateBoardDTO, UpdateBoardDTO, GetBoardDTO, AddBoardMemberDTO, GetBoardMemberDTO, BoardFilters, BoardProblemFilters } from '../types/BoardDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface BoardService {
  getAll: (filters?: BoardFilters) => Promise<ApiResponse<GetBoardDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetBoardDTO>>;
  create: (data: CreateBoardDTO) => Promise<ApiResponse<GetBoardDTO>>;
  update: (uid: string, data: UpdateBoardDTO) => Promise<ApiResponse<GetBoardDTO>>;
  remove: (uid: string) => Promise<ApiResponse<void>>;
  getMembers: (boardId: number) => Promise<ApiResponse<GetBoardMemberDTO[]>>;
  addMember: (data: AddBoardMemberDTO) => Promise<ApiResponse<void>>;
  removeMember: (boardId: number, userId: number) => Promise<ApiResponse<void>>;
  getSessionSummary: (boardId: number, userId: number) => Promise<ApiResponse<unknown>>;
  getProblems: (boardConfigId: number, filters?: BoardProblemFilters) => Promise<ApiResponse<unknown[]>>;
  getProblemByUid: (uid: string) => Promise<ApiResponse<unknown>>;
}

export function createBoardService(config: ServiceConfig): BoardService {
  const base = `${config.baseUrl}/api/board`;
  const opts = (method: string, auth: boolean, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, auth, config.token, body);

  const getAll = async (filters?: BoardFilters): Promise<ApiResponse<GetBoardDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.organizationId != null) params.set('organizationId', String(filters.organizationId));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}${qs}`, opts('GET', true));
      return handleResponse<GetBoardDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetBoardDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET', true));
      return handleResponse<GetBoardDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateBoardDTO): Promise<ApiResponse<GetBoardDTO>> => {
    try {
      const res = await fetch(base, opts('POST', true, data));
      return handleResponse<GetBoardDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateBoardDTO): Promise<ApiResponse<GetBoardDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', true, data));
      return handleResponse<GetBoardDTO>(res);
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

  const getMembers = async (boardId: number): Promise<ApiResponse<GetBoardMemberDTO[]>> => {
    try {
      const res = await fetch(`${base}/${boardId}/members`, opts('GET', true));
      return handleResponse<GetBoardMemberDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const addMember = async (data: AddBoardMemberDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/member`, opts('POST', true, data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const removeMember = async (boardId: number, userId: number): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/member?boardId=${boardId}&userId=${userId}`, opts('DELETE', true));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getSessionSummary = async (boardId: number, userId: number): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/${boardId}/session-summary/${userId}`, opts('GET', true));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getProblems = async (boardConfigId: number, filters?: BoardProblemFilters): Promise<ApiResponse<unknown[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.includeArchived != null) params.set('includeArchived', String(filters.includeArchived));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}/${boardConfigId}/problems${qs}`, opts('GET', true));
      return handleResponse<unknown[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getProblemByUid = async (uid: string): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/problem/${uid}`, opts('GET', true));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getAll, getByUid, create, update, remove, getMembers, addMember, removeMember, getSessionSummary, getProblems, getProblemByUid };
}
