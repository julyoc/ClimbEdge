import { BaseDTO } from './BaseDTO';

// Enums
export enum BoardVisibility {
  Private = 0,
  Organization = 1,
  Public = 2,
}

export enum BoardMemberRole {
  Member = 0,
  Admin = 1,
  Owner = 2,
}

// Create / Update
export interface CreateBoardDTO {
  name: string;
  description?: string;
  visibility: BoardVisibility;
  boardConfigId: number;
  organizationId?: number | null;
}

export interface UpdateBoardDTO {
  name?: string;
  description?: string;
  visibility?: BoardVisibility;
  organizationId?: number | null;
}

export interface AddBoardMemberDTO {
  boardId: number;
  userId: number;
  role: BoardMemberRole;
}

// Read
export class GetBoardDTO extends BaseDTO {
  name!: string;
  description?: string;
  visibility!: BoardVisibility;
  boardConfigId!: number;
  organizationId?: number | null;
}

export class GetBoardMemberDTO extends BaseDTO {
  boardId!: number;
  userId!: number;
  role!: BoardMemberRole;
}

// Filters
export interface BoardFilters {
  organizationId?: number;
  page?: number;
  pageSize?: number;
}

export interface BoardProblemFilters {
  includeArchived?: boolean;
  page?: number;
  pageSize?: number;
}
