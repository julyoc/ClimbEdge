import type { ApiResponse } from './index';

export const API_KEY_HEADER_NAME = 'X-API-Key';
export const IS_WEB = typeof window !== 'undefined';

export interface ServiceConfig {
  baseUrl: string;
  apiKey: string;
  token?: string;
}

export function buildFetchOptions(
  method: string,
  apiKey: string,
  requiresAuth: boolean,
  token?: string,
  body?: unknown
): RequestInit {
  const headers: Record<string, string> = {
    'Content-Type': 'application/json',
    [API_KEY_HEADER_NAME]: apiKey,
  };

  if (requiresAuth && !IS_WEB && token) {
    headers['Authorization'] = `Bearer ${token}`;
  }

  const opts: RequestInit = { method, headers };

  if (body !== undefined) {
    opts.body = JSON.stringify(body);
  }

  if (requiresAuth && IS_WEB) {
    opts.credentials = 'include';
  }

  return opts;
}

export async function handleResponse<T>(response: Response): Promise<ApiResponse<T>> {
  if (!response.ok) {
    try {
      const err = await response.json();
      return { success: false, error: err.message || err.title || `Error ${response.status}` };
    } catch {
      return { success: false, error: `Error ${response.status}` };
    }
  }

  // 204 No Content
  if (response.status === 204) {
    return { success: true };
  }

  try {
    const data: T = await response.json();
    return { success: true, data };
  } catch {
    return { success: true };
  }
}
