import { BaseDTO } from './BaseDTO';

export enum ClimbTickType {
  Attempt = 0,
  Redpoint = 1,
  Flash = 2,
  Onsight = 3,
  TopRope = 4,
}

export enum MountaineerTickType {
  Attempt = 0,
  Summit = 1,
  Descent = 2,
}

export interface StartSessionDTO {
  userId: number;
  boardId?: number | null;
  climbZoneId?: number | null;
  mountainRouteId?: number | null;
  notes?: string;
}

export class GetSessionDTO extends BaseDTO {
  userId!: number;
  boardId?: number | null;
  climbZoneId?: number | null;
  mountainRouteId?: number | null;
  startedAt!: string;
  endedAt?: string | null;
  notes?: string;
  isActive!: boolean;
}

export interface RecordProgressDTO {
  userSessionId: number;
  climbRouteId?: number | null;
  boardProblemId?: number | null;
  boardAngleId?: number | null;
  footRuleId?: number | null;
  mountainRouteId?: number | null;
  climbTickType?: ClimbTickType | null;
  mountaineerTickType?: MountaineerTickType | null;
  isCompleted: boolean;
  duration?: number | null;
  tryAt?: string | null;
  maxElevationReached?: number | null;
  weatherConditions?: string | null;
}

export class GetProgressDTO extends BaseDTO {
  userSessionId!: number;
  climbRouteId?: number | null;
  boardProblemId?: number | null;
  boardAngleId?: number | null;
  footRuleId?: number | null;
  mountainRouteId?: number | null;
  climbTickType?: ClimbTickType | null;
  mountaineerTickType?: MountaineerTickType | null;
  isCompleted!: boolean;
  duration?: number | null;
  tryAt?: string | null;
  maxElevationReached?: number | null;
  weatherConditions?: string | null;
}

export class GetBoardSessionSummaryDTO extends BaseDTO {
  boardId!: number;
  userId!: number;
  totalSessions!: number;
  totalProblemsCompleted!: number;
  totalAttempts!: number;
  attemptNumber?: number | null;
  sentOnAttempt?: number | null;
}

export interface SessionFilters {
  userId?: number;
  activeOnly?: boolean;
  page?: number;
  pageSize?: number;
}
