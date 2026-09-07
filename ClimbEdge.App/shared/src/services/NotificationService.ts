import type { GetNotificationDTO, MarkNotificationsReadDTO, UpdateNotificationPreferenceDTO, GetNotificationPreferenceDTO } from '../types/NotificationDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface NotificationService {
  getNotifications: (userId: number, unreadOnly?: boolean, page?: number, pageSize?: number) => Promise<ApiResponse<GetNotificationDTO[]>>;
  markRead: (data: MarkNotificationsReadDTO) => Promise<ApiResponse<void>>;
  getPreferences: (userId: number) => Promise<ApiResponse<GetNotificationPreferenceDTO[]>>;
  updatePreference: (data: UpdateNotificationPreferenceDTO) => Promise<ApiResponse<void>>;
}

export function createNotificationService(config: ServiceConfig): NotificationService {
  const base = `${config.baseUrl}/api/notification`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getNotifications = async (userId: number, unreadOnly?: boolean, page?: number, pageSize?: number): Promise<ApiResponse<GetNotificationDTO[]>> => {
    try {
      const params = new URLSearchParams({ userId: String(userId) });
      if (unreadOnly != null) params.set('unreadOnly', String(unreadOnly));
      if (page != null) params.set('page', String(page));
      if (pageSize != null) params.set('pageSize', String(pageSize));
      const res = await fetch(`${base}?${params}`, opts('GET'));
      return handleResponse<GetNotificationDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const markRead = async (data: MarkNotificationsReadDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/read?userId=${data.userId}`, opts('PUT', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPreferences = async (userId: number): Promise<ApiResponse<GetNotificationPreferenceDTO[]>> => {
    try {
      const res = await fetch(`${base}/preferences?userId=${userId}`, opts('GET'));
      return handleResponse<GetNotificationPreferenceDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const updatePreference = async (data: UpdateNotificationPreferenceDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/preferences`, opts('PUT', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getNotifications, markRead, getPreferences, updatePreference };
}
