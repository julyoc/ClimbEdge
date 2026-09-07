import type { CreateSubscriptionDTO, CancelSubscriptionDTO, GetSubscriptionDTO, GetPlanDTO, AddPaymentMethodDTO, GetPaymentMethodDTO } from '../types/PaymentDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface PaymentService {
  getPlans: (activeOnly?: boolean) => Promise<ApiResponse<GetPlanDTO[]>>;
  getSubscription: (userId: number) => Promise<ApiResponse<GetSubscriptionDTO>>;
  createSubscription: (data: CreateSubscriptionDTO) => Promise<ApiResponse<GetSubscriptionDTO>>;
  cancelSubscription: (data: CancelSubscriptionDTO) => Promise<ApiResponse<void>>;
  getPaymentMethods: (userId: number) => Promise<ApiResponse<GetPaymentMethodDTO[]>>;
  addPaymentMethod: (data: AddPaymentMethodDTO) => Promise<ApiResponse<GetPaymentMethodDTO>>;
  removePaymentMethod: (uid: string) => Promise<ApiResponse<void>>;
}

export function createPaymentService(config: ServiceConfig): PaymentService {
  const base = `${config.baseUrl}/api/payment`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getPlans = async (activeOnly?: boolean): Promise<ApiResponse<GetPlanDTO[]>> => {
    try {
      const qs = activeOnly != null ? `?activeOnly=${activeOnly}` : '';
      const res = await fetch(`${base}/plans${qs}`, opts('GET'));
      return handleResponse<GetPlanDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getSubscription = async (userId: number): Promise<ApiResponse<GetSubscriptionDTO>> => {
    try {
      const res = await fetch(`${base}/subscription?userId=${userId}`, opts('GET'));
      return handleResponse<GetSubscriptionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const createSubscription = async (data: CreateSubscriptionDTO): Promise<ApiResponse<GetSubscriptionDTO>> => {
    try {
      const res = await fetch(`${base}/subscription`, opts('POST', data));
      return handleResponse<GetSubscriptionDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const cancelSubscription = async (data: CancelSubscriptionDTO): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/subscription/cancel`, opts('PUT', data));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getPaymentMethods = async (userId: number): Promise<ApiResponse<GetPaymentMethodDTO[]>> => {
    try {
      const res = await fetch(`${base}/methods?userId=${userId}`, opts('GET'));
      return handleResponse<GetPaymentMethodDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const addPaymentMethod = async (data: AddPaymentMethodDTO): Promise<ApiResponse<GetPaymentMethodDTO>> => {
    try {
      const res = await fetch(`${base}/methods`, opts('POST', data));
      return handleResponse<GetPaymentMethodDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const removePaymentMethod = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/methods/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getPlans, getSubscription, createSubscription, cancelSubscription, getPaymentMethods, addPaymentMethod, removePaymentMethod };
}
