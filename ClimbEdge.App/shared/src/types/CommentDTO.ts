import { BaseDTO } from './BaseDTO';

export interface CreateCommentDTO {
  authorId: number;
  entityType: string;
  entityId: number;
  parentCommentId?: number | null;
  content: string;
}

export interface UpdateCommentDTO {
  content: string;
}

export class GetCommentDTO extends BaseDTO {
  authorId!: number;
  entityType!: string;
  entityId!: number;
  parentCommentId?: number | null;
  content!: string;
  isEdited!: boolean;
  editedAt?: string | null;
  isPinned!: boolean;
}
