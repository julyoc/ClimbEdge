import type { CreateTrainingPlanDTO, UpdateTrainingPlanDTO, GetTrainingPlanDTO, CreateTrainingPeriodDTO, GetTrainingPeriodDTO, CreateTrainingWeekDTO, CompleteTrainingWeekDTO, GetTrainingWeekDTO, CreateTrainingSessionDTO, CompleteTrainingSessionDTO, GetTrainingSessionDTO, LogTrainingProgressDTO, TrainingPlanFilters } from '../types/TrainingDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface TrainingService {
  // Plans
  getPlans: (filters?: TrainingPlanFilters) => Promise<ApiResponse<GetTrainingPlanDTO[]>>;
  getPlanByUid: (uid: string) => Promise<ApiResponse<GetTrainingPlanDTO>>;
  createPlan: (data: CreateTrainingPlanDTO) => Promise<ApiResponse<GetTrainingPlanDTO>>;
  updatePlan: (uid: string, data: UpdateTrainingPlanDTO) => Promise<ApiResponse<GetTrainingPlanDTO>>;
  deletePlan: (uid: string) => Promise<ApiResponse<void>>;
  getPlanProgress: (planId: number) => Promise<ApiResponse<unknown>>;
  logProgress: (data: LogTrainingProgressDTO) => Promise<ApiResponse<void>>;
  // Periods
  getPeriods: (planId: number) => Promise<ApiResponse<GetTrainingPeriodDTO[]>>;
  createPeriod: (data: CreateTrainingPeriodDTO) => Promise<ApiResponse<GetTrainingPeriodDTO>>;
  // Weeks
  getWeeks: (periodId: number) => Promise<ApiResponse<GetTrainingWeekDTO[]>>;
  createWeek: (data: CreateTrainingWeekDTO) => Promise<ApiResponse<GetTrainingWeekDTO>>;
  completeWeek: (data: CompleteTrainingWeekDTO) => Promise<ApiResponse<void>>;
  getWeekVolume: (weekId: number) => Promise<ApiResponse<unknown>>;
  // Sessions
  getWeekSessions: (weekId: number) => Promise<ApiResponse<GetTrainingSessionDTO[]>>;
  createSession: (data: CreateTrainingSessionDTO) => Promise<ApiResponse<GetTrainingSessionDTO>>;
  completeSession: (data: CompleteTrainingSessionDTO) => Promise<ApiResponse<void>>;
}

export function createTrainingService(config: ServiceConfig): TrainingService {
  const base = `${config.baseUrl}/api/training`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getPlans = async (filters?: TrainingPlanFilters): Promise<ApiResponse<GetTrainingPlanDTO[]>> => {
    try {
      const params = new URLSearchParams();
      if (filters?.userId != null) params.set('userId', String(filters.userId));
      if (filters?.activeOnly != null) params.set('activeOnly', String(filters.activeOnly));
      if (filters?.page != null) params.set('page', String(filters.page));
      if (filters?.pageSize != null) params.set('pageSize', String(filters.pageSize));
      const qs = params.toString() ? `?${params}` : '';
      const res = await fetch(`${base}/plans${qs}`, opts('GET'));
      return handleResponse<GetTrainingPlanDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPlanByUid = async (uid: string): Promise<ApiResponse<GetTrainingPlanDTO>> => {
    try {
      const res = await fetch(`${base}/plans/${uid}`, opts('GET'));
      return handleResponse<GetTrainingPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createPlan = async (data: CreateTrainingPlanDTO): Promise<ApiResponse<GetTrainingPlanDTO>> => {
    try {
      const res = await fetch(`${base}/plans`, opts('POST', data));
      return handleResponse<GetTrainingPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const updatePlan = async (uid: string, data: UpdateTrainingPlanDTO): Promise<ApiResponse<GetTrainingPlanDTO>> => {
    try {
      const res = await fetch(`${base}/plans/${uid}`, opts('PUT', data));
      return handleResponse<GetTrainingPlanDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const deletePlan = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/plans/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPlanProgress = async (planId: number): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/plans/${planId}/progress`, opts('GET'));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const logProgress = async (data: LogTrainingProgressDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/progress`, opts('POST', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPeriods = async (planId: number): Promise<ApiResponse<GetTrainingPeriodDTO[]>> => {
    try {
      const res = await fetch(`${base}/plans/${planId}/periods`, opts('GET'));
      return handleResponse<GetTrainingPeriodDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createPeriod = async (data: CreateTrainingPeriodDTO): Promise<ApiResponse<GetTrainingPeriodDTO>> => {
    try {
      const res = await fetch(`${base}/periods`, opts('POST', data));
      return handleResponse<GetTrainingPeriodDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getWeeks = async (periodId: number): Promise<ApiResponse<GetTrainingWeekDTO[]>> => {
    try {
      const res = await fetch(`${base}/periods/${periodId}/weeks`, opts('GET'));
      return handleResponse<GetTrainingWeekDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createWeek = async (data: CreateTrainingWeekDTO): Promise<ApiResponse<GetTrainingWeekDTO>> => {
    try {
      const res = await fetch(`${base}/weeks`, opts('POST', data));
      return handleResponse<GetTrainingWeekDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const completeWeek = async (data: CompleteTrainingWeekDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/weeks/complete`, opts('PUT', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getWeekVolume = async (weekId: number): Promise<ApiResponse<unknown>> => {
    try {
      const res = await fetch(`${base}/weeks/${weekId}/volume`, opts('GET'));
      return handleResponse<unknown>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getWeekSessions = async (weekId: number): Promise<ApiResponse<GetTrainingSessionDTO[]>> => {
    try {
      const res = await fetch(`${base}/weeks/${weekId}/sessions`, opts('GET'));
      return handleResponse<GetTrainingSessionDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createSession = async (data: CreateTrainingSessionDTO): Promise<ApiResponse<GetTrainingSessionDTO>> => {
    try {
      const res = await fetch(`${base}/sessions`, opts('POST', data));
      return handleResponse<GetTrainingSessionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const completeSession = async (data: CompleteTrainingSessionDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/sessions/complete`, opts('PUT', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getPlans, getPlanByUid, createPlan, updatePlan, deletePlan, getPlanProgress, logProgress, getPeriods, createPeriod, getWeeks, createWeek, completeWeek, getWeekVolume, getWeekSessions, createSession, completeSession };
}
