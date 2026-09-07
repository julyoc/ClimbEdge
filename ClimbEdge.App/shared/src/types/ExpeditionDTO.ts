import { BaseDTO } from './BaseDTO';

export enum ExpeditionStatus {
  Draft = 0,
  Active = 1,
  InProgress = 2,
  Completed = 3,
  Cancelled = 4,
}

export enum ParticipantRole {
  Participant = 0,
  Leader = 1,
  Guide = 2,
  Support = 3,
}

export enum ParticipantStatus {
  Invited = 0,
  Confirmed = 1,
  Declined = 2,
  Withdrawn = 3,
}

export enum TrackType {
  Planned = 0,
  Recorded = 1,
}

export interface CreateExpeditionDTO {
  mountainId: number;
  mountainRouteId?: number | null;
  name: string;
  description?: string;
  startDate: string;
  endDate: string;
  plannedDurationDays: number;
  minParticipants: number;
  maxParticipants: number;
  requiredExperienceLevel?: string;
  cost?: number | null;
  currency?: string;
  requiresPermit: boolean;
  insuranceRequired: boolean;
  organizedBy: number;
  organizedByOrganizationId?: number | null;
  isPublic: boolean;
  registrationDeadline?: string | null;
}

export interface UpdateExpeditionDTO {
  name?: string;
  description?: string;
  status?: ExpeditionStatus;
  startDate?: string;
  endDate?: string;
  actualDurationDays?: number;
  cost?: number;
  isPublic?: boolean;
  registrationDeadline?: string | null;
}

export class GetExpeditionDTO extends BaseDTO {
  mountainId!: number;
  mountainRouteId?: number | null;
  name!: string;
  description?: string;
  status!: ExpeditionStatus;
  startDate!: string;
  endDate!: string;
  plannedDurationDays!: number;
  actualDurationDays?: number;
  minParticipants!: number;
  maxParticipants!: number;
  cost?: number | null;
  currency?: string;
  isPublic!: boolean;
  organizedBy!: number;
}

export interface AddExpeditionParticipantDTO {
  expeditionId: number;
  userId: number;
  role: ParticipantRole;
  emergencyContact?: string;
  specialRequirements?: string;
}

export class GetExpeditionParticipantDTO extends BaseDTO {
  expeditionId!: number;
  userId!: number;
  role!: ParticipantRole;
  status!: ParticipantStatus;
  invitedAt!: string;
  joinedAt?: string | null;
  medicalClearance!: boolean;
  emergencyContact?: string;
  specialRequirements?: string;
}

export interface AddExpeditionEquipmentDTO {
  expeditionId: number;
  equipmentId: number;
  quantity: number;
  isMandatory: boolean;
  isProvided: boolean;
  responsibleParticipant?: number | null;
  notes?: string;
}

export class GetExpeditionEquipmentDTO extends BaseDTO {
  expeditionId!: number;
  equipmentId!: number;
  equipmentName!: string;
  quantity!: number;
  isMandatory!: boolean;
  isProvided!: boolean;
  responsibleParticipant?: number | null;
  notes?: string;
}

export interface ExpeditionFilters {
  mountainId?: number;
  publicOnly?: boolean;
  page?: number;
  pageSize?: number;
}

// Safety Plan
export interface CreateSafetyPlanDTO {
  expeditionId: number;
  emergencyContactName?: string;
  emergencyContactPhone?: string;
  emergencyContactRelation?: string;
  localRescueService?: string;
  nearestHospital?: string;
  evacuationPlan?: string;
  communicationPlan?: string;
  riskAssessment?: string;
  contingencyPlans?: string;
  medicalSupplies?: string;
}

export interface UpdateSafetyPlanDTO {
  emergencyContactName?: string;
  emergencyContactPhone?: string;
  emergencyContactRelation?: string;
  localRescueService?: string;
  nearestHospital?: string;
  evacuationPlan?: string;
  communicationPlan?: string;
  riskAssessment?: string;
  contingencyPlans?: string;
  medicalSupplies?: string;
}

export interface GetSafetyPlanDTO {
  uid: string;
  expeditionId: number;
  emergencyContactName?: string;
  emergencyContactPhone?: string;
  emergencyContactRelation?: string;
  localRescueService?: string;
  nearestHospital?: string;
  evacuationPlan?: string;
  communicationPlan?: string;
  riskAssessment?: string;
  contingencyPlans?: string;
  medicalSupplies?: string;
  lastUpdated?: string;
}

// Itinerary Day Track
export interface CreateItineraryDayTrackDTO {
  itineraryDayId: number;
  name: string;
  trackDataWkt: string;
  plannedRouteWkt?: string;
  startAltitude?: number;
  endAltitude?: number;
  totalDistance?: number;
  elevationGain?: number;
  elevationLoss?: number;
  startTime?: string;
  endTime?: string;
  recordedBy?: number;
  gpsDevice?: string;
  weatherDuring?: string;
}

export interface GetItineraryDayTrackDTO {
  uid: string;
  itineraryDayId: number;
  name: string;
  trackDataWkt?: string;
  startAltitude?: number;
  endAltitude?: number;
  totalDistance?: number;
  elevationGain?: number;
  elevationLoss?: number;
  startTime?: string;
  endTime?: string;
  gpsDevice?: string;
  weatherDuring?: string;
}

// Itinerary Day Waypoint
export interface CreateItineraryDayWaypointDTO {
  itineraryDayId: number;
  name: string;
  description?: string;
  locationWkt: string;
  timestamp?: string;
  altitude?: number;
  notes?: string;
  imageUrl?: string;
}

export interface GetItineraryDayWaypointDTO {
  uid: string;
  itineraryDayId: number;
  name: string;
  description?: string;
  locationWkt?: string;
  timestamp?: string;
  altitude?: number;
  notes?: string;
  imageUrl?: string;
}

// Equipment Catalog
export interface CreateEquipmentCatalogDTO {
  name: string;
  description?: string;
  brand?: string;
  model?: string;
  weight?: number;
  categoryId?: number;
  isMandatory?: boolean;
  notes?: string;
  imageUrl?: string;
}

export interface GetEquipmentCatalogDTO {
  uid: string;
  id: number;
  name: string;
  description?: string;
  brand?: string;
  model?: string;
  weight?: number;
  categoryId?: number;
  isMandatory?: boolean;
  notes?: string;
  imageUrl?: string;
}

// Debrief
export interface GetDebriefDTO {
  uid: string;
  expeditionId: number;
  date?: string;
  technicalNotes?: string;
  teamNotes?: string;
  equipmentNotes?: string;
  recommendations?: string;
}
