import type { CreateCommentDTO, UpdateCommentDTO, GetCommentDTO } from '../types/CommentDTO';
import type { ApiResponse } from './index';
import { buildFetchOptions, handleResponse, type ServiceConfig } from './_base';

export interface CommentService {
  getComments: (entityType: string, entityId: number) => Promise<ApiResponse<GetCommentDTO[]>>;
  getReplies: (parentCommentId: number) => Promise<ApiResponse<GetCommentDTO[]>>;
  create: (data: CreateCommentDTO) => Promise<ApiResponse<GetCommentDTO>>;
  update: (uid: string, data: UpdateCommentDTO) => Promise<ApiResponse<GetCommentDTO>>;
  remove: (uid: string) => Promise<ApiResponse<void>>;
}

export function createCommentService(config: ServiceConfig): CommentService {
  const base = `${config.baseUrl}/api/comment`;
  const opts = (method: string, body?: unknown) =>
    buildFetchOptions(method, config.apiKey, true, config.token, body);

  const getComments = async (entityType: string, entityId: number): Promise<ApiResponse<GetCommentDTO[]>> => {
    try {
      const res = await fetch(`${base}?entityType=${encodeURIComponent(entityType)}&entityId=${entityId}`, opts('GET'));
      return handleResponse<GetCommentDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const getReplies = async (parentCommentId: number): Promise<ApiResponse<GetCommentDTO[]>> => {
    try {
      const res = await fetch(`${base}/${parentCommentId}/replies`, opts('GET'));
      return handleResponse<GetCommentDTO[]>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const create = async (data: CreateCommentDTO): Promise<ApiResponse<GetCommentDTO>> => {
    try {
      const res = await fetch(base, opts('POST', data));
      return handleResponse<GetCommentDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const update = async (uid: string, data: UpdateCommentDTO): Promise<ApiResponse<GetCommentDTO>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('PUT', data));
      return handleResponse<GetCommentDTO>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  const remove = async (uid: string): Promise<ApiResponse<void>> => {
    try {
      const res = await fetch(`${base}/${uid}`, opts('DELETE'));
      return handleResponse<void>(res);
    } catch (e: any) {
      return { success: false, error: e.message };
    }
  };

  return { getComments, getReplies, create, update, remove };
}
