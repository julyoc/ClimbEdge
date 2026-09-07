import { BaseDTO } from './BaseDTO';

export enum OrganizationType {
  Club = 0,
  Company = 1,
  Federation = 2,
  School = 3,
  Other = 4,
}

export enum MembershipType {
  Basic = 0,
  Standard = 1,
  Premium = 2,
  Honorary = 3,
}

export enum MembershipStatus {
  Active = 0,
  Inactive = 1,
  Suspended = 2,
  Expired = 3,
}

// Organization
export interface CreateOrganizationDTO {
  name: string;
  displayName?: string;
  description?: string;
  type: OrganizationType;
  email?: string;
  phone?: string;
  website?: string;
  address?: string;
  city?: string;
  state?: string;
  country: string;
  postalCode?: string;
  timeZone?: string;
  logoUrl?: string | null;
  foundedDate?: string | null;
}

export interface UpdateOrganizationDTO {
  displayName?: string;
  description?: string;
  email?: string;
  phone?: string;
  website?: string;
  address?: string;
  city?: string;
  state?: string;
  postalCode?: string;
  timeZone?: string;
  logoUrl?: string | null;
  bannerUrl?: string | null;
  isPublic?: boolean;
}

export class GetOrganizationDTO extends BaseDTO {
  name!: string;
  displayName?: string;
  description?: string;
  type!: OrganizationType;
  email?: string;
  phone?: string;
  website?: string;
  city?: string;
  country!: string;
  isVerified!: boolean;
  isPublic!: boolean;
  logoUrl?: string | null;
  bannerUrl?: string | null;
}

// Members
export interface AddOrganizationMemberDTO {
  organizationId: number;
  userId: number;
  membershipType: MembershipType;
}

export interface RemoveOrganizationMemberDTO {
  organizationId: number;
  userId: number;
}

export class GetOrganizationMemberDTO extends BaseDTO {
  organizationId!: number;
  userId!: number;
  membershipType!: MembershipType;
  status!: MembershipStatus;
  role?: string;
  joinedAt!: string;
  expiresAt?: string | null;
}

// Events
export interface CreateOrganizationEventDTO {
  organizationId: number;
  title: string;
  description?: string;
  eventType: string;
  startDate: string;
  endDate: string;
  location?: string;
  facilityId?: number | null;
  maxParticipants?: number;
  registrationDeadline?: string | null;
  cost?: number;
  currency?: string;
  requiresRegistration: boolean;
  isPublic: boolean;
  skillLevelRequired?: string;
  instructor?: string;
  contactEmail?: string;
  contactPhone?: string;
}

export interface UpdateOrganizationEventDTO {
  title?: string;
  description?: string;
  startDate?: string;
  endDate?: string;
  location?: string;
  maxParticipants?: number;
  registrationDeadline?: string | null;
  status?: string;
  isPublic?: boolean;
}

export class GetOrganizationEventDTO extends BaseDTO {
  organizationId!: number;
  title!: string;
  description?: string;
  eventType!: string;
  startDate!: string;
  endDate!: string;
  location?: string;
  maxParticipants?: number;
  currentParticipants!: number;
  cost?: number;
  currency?: string;
  isPublic!: boolean;
  status!: string;
}

export interface RegisterEventParticipantDTO {
  eventId: number;
  userId: number;
  notes?: string;
}

export class GetOrganizationEventParticipantDTO extends BaseDTO {
  eventId!: number;
  userId!: number;
  registrationDate!: string;
  status!: string;
  paymentStatus?: string;
  checkInTime?: string | null;
}

export interface OrganizationFilters {
  publicOnly?: boolean;
  country?: string;
  page?: number;
  pageSize?: number;
}
