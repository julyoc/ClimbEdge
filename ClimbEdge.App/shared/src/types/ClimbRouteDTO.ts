import { BaseDTO } from './BaseDTO';

export interface CreateClimbRouteDTO {
  name: string;
  description: string;
  difficultyScaleId: number;
  difficultyScaleNameId: number;
  climbTagId?: number | null;
  pitchCount?: number | null;
  firstAscentDate?: string | null;
  climbZoneId?: number | null;
}

export interface UpdateClimbRouteDTO {
  name?: string;
  description?: string;
  difficultyScaleId?: number;
  climbTagId?: number | null;
  pitchCount?: number | null;
  climbZoneId?: number | null;
}

export class GetClimbRouteDTO extends BaseDTO {
  name!: string;
  description!: string;
  difficultyScaleId!: number;
  difficultyScaleNameId!: number;
  climbTagId?: number | null;
  pitchCount?: number | null;
  firstAscentDate?: string | null;
  climbZoneId?: number | null;
}

export class GetDifficultyScaleDTO extends BaseDTO {
  difficultyScaleNameId!: number;
  difficultyScaleName!: string;
  value!: string;
  ircra!: number;
  difficultyGroupId?: number | null;
  description?: string;
}

export interface ClimbRouteFilters {
  climbZoneId?: number;
  difficultyScaleNameId?: number;
  page?: number;
  pageSize?: number;
}
