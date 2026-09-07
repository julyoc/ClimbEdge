import { BaseDTO } from './BaseDTO';

export enum ActivityType {
  Running = 0,
  Hiking = 1,
  AlpineClimbing = 2,
  SportClimbing = 3,
  Bouldering = 4,
  Strength = 5,
  Yoga = 6,
  Cycling = 7,
  Swimming = 8,
  Other = 9,
}

export enum TrainingZone {
  Zone1 = 1,
  Zone2 = 2,
  Zone3 = 3,
  Zone4 = 4,
  Zone5 = 5,
}

export enum TrainingPeriodType {
  Preparation = 0,
  Base = 1,
  Build = 2,
  Peak = 3,
  Race = 4,
  Recovery = 5,
  Transition = 6,
}

// Training Plan
export interface CreateTrainingPlanDTO {
  userId: number;
  name: string;
  description?: string;
  notes?: string;
  startDate: string;
  endDate?: string | null;
  longTermGoal?: string[];
  shortTermGoal?: string[];
  baselinePhysiologicalDataId?: number | null;
  createdByUserId?: number | null;
}

export interface UpdateTrainingPlanDTO {
  name?: string;
  description?: string;
  notes?: string;
  endDate?: string | null;
  isActive?: boolean;
  longTermGoal?: string[];
  shortTermGoal?: string[];
}

export class GetTrainingPlanDTO extends BaseDTO {
  userId!: number;
  name!: string;
  description?: string;
  notes?: string;
  startDate!: string;
  endDate?: string | null;
  isActive!: boolean;
  longTermGoal?: string[];
  shortTermGoal?: string[];
}

// Training Period
export interface CreateTrainingPeriodDTO {
  trainingPlanId: number;
  periodType: TrainingPeriodType;
  name: string;
  description?: string;
  startDate: string;
  endDate: string;
  weekNumber: number;
  volumePercentage?: number;
  notes?: string;
}

export class GetTrainingPeriodDTO extends BaseDTO {
  trainingPlanId!: number;
  periodType!: TrainingPeriodType;
  name!: string;
  startDate!: string;
  endDate!: string;
  weekNumber!: number;
  volumePercentage?: number;
  isCompleted!: boolean;
}

// Training Week
export interface CreateTrainingWeekDTO {
  trainingPeriodId: number;
  weekNumber: number;
  startDate: string;
  endDate: string;
  trainingObjective?: string;
  climbingObjective?: string;
  nutritionObjective?: string;
  plannedHours: number;
}

export interface CompleteTrainingWeekDTO {
  trainingWeekUid: string;
  completedHours?: number;
  zone1Hours?: number;
  zone2Hours?: number;
  zone3Hours?: number;
  strengthHours?: number;
  alpineClimbingHours?: number;
  schoolClimbingHours?: number;
  elevationGained?: number;
  weeklyEvaluation?: string;
}

export class GetTrainingWeekDTO extends BaseDTO {
  trainingPeriodId!: number;
  weekNumber!: number;
  startDate!: string;
  endDate!: string;
  trainingObjective?: string;
  climbingObjective?: string;
  plannedHours!: number;
  completedHours?: number;
  isCompleted!: boolean;
  weeklyEvaluation?: string;
}

// Training Session
export interface CreateTrainingSessionDTO {
  trainingWeekId: number;
  date: string;
  activityType: ActivityType;
  plannedDuration: number;
  trainingZone?: TrainingZone | null;
  location?: string;
  notes?: string;
}

export interface CompleteTrainingSessionDTO {
  trainingSessionUid: string;
  actualDuration: number;
  trainingZone?: TrainingZone | null;
  elevationGained?: number;
  weightCarried?: number;
  distance?: number;
  heartRateAvg?: number;
  heartRateMax?: number;
  rating?: number;
  notes?: string;
  userSessionId?: number | null;
}

export class GetTrainingSessionDTO extends BaseDTO {
  trainingWeekId!: number;
  date!: string;
  activityType!: ActivityType;
  plannedDuration!: number;
  actualDuration?: number;
  trainingZone?: TrainingZone | null;
  elevationGained?: number;
  weightCarried?: number;
  distance?: number;
  heartRateAvg?: number;
  heartRateMax?: number;
  rating?: number;
  isCompleted!: boolean;
  notes?: string;
  location?: string;
}

// Progress
export interface LogTrainingProgressDTO {
  userId: number;
  trainingPlanId: number;
  measurementDate: string;
  metricType: string;
  metricName: string;
  value: number;
  unit: string;
  notes?: string;
  measuredBy?: string;
}

export interface TrainingPlanFilters {
  userId?: number;
  activeOnly?: boolean;
  page?: number;
  pageSize?: number;
}
