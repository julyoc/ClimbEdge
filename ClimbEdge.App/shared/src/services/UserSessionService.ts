import type { StartSessionDTO, GetSessionDTO, RecordProgressDTO, GetProgressDTO, GetBoardSessionSummaryDTO, SessionFilters } from '../types/SessionDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface UserSessionService {
  getSessions: (filters?: SessionFilters) => Promise<ApiResponse<GetSessionDTO[]>>;
  getByUid: (uid: string) => Promise<ApiResponse<GetSessionDTO>>;
  start: (data: StartSessionDTO) => Promise<ApiResponse<GetSessionDTO>>;
  end: (uid: string, notes?: string) => Promise<ApiResponse<void>>;
  recordProgress: (data: RecordProgressDTO) => Promise<ApiResponse<GetProgressDTO>>;
  getProgress: (sessionId: number) => Promise<ApiResponse<GetProgressDTO[]>>;
  getBoardSessionSummary: (boardId: number, userId: number) => Promise<ApiResponse<GetBoardSessionSummaryDTO>>;
}

export function createUserSessionService(config: ServiceConfig): UserSessionService {
  const base = `${config.baseUrl}/api/session`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getSessions = async (filters?: SessionFilters): Promise<ApiResponse<GetSessionDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.userId != null) params.set('userId', String(filters.userId));
      if (filters?.activeOnly != null) params.set('activeOnly', String(filters.activeOnly));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}${qs}`, opts('GET'));
      return handleResponse<GetSessionDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getByUid = async (uid: string): Promise<ApiResponse<GetSessionDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('GET'));
      return handleResponse<GetSessionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const start = async (data: StartSessionDTO): Promise<ApiResponse<GetSessionDTO>> => {
    try {
      const res = await fetch(`${base}/start`, opts('POST', data));
      return handleResponse<GetSessionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const end = async (uid: string, notes?: string): Promise<ApiResponse<void>> => {
    try {
      const qs = notes ? `?notes=${encodeURIComponent(notes)}` : '';
      const res = await fetch(`${base}/${uid}/end${qs}`, opts('PUT'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const recordProgress = async (data: RecordProgressDTO): Promise<ApiResponse<GetProgressDTO>> => {
    try {
      const res = await fetch(`${base}/progress`, opts('POST', data));
      return handleResponse<GetProgressDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getProgress = async (sessionId: number): Promise<ApiResponse<GetProgressDTO[]>> => {
    try {
      const res = await fetch(`${base}/${sessionId}/progress`, opts('GET'));
      return handleResponse<GetProgressDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getBoardSessionSummary = async (boardId: number, userId: number): Promise<ApiResponse<GetBoardSessionSummaryDTO>> => {
    try {
      const res = await fetch(`${config.baseUrl}/api/board/${boardId}/session-summary/${userId}`, opts('GET'));
      return handleResponse<GetBoardSessionSummaryDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getSessions, getByUid, start, end, recordProgress, getProgress, getBoardSessionSummary };
}
