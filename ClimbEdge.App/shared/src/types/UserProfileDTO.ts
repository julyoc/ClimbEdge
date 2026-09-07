import { BaseDTO } from './BaseDTO';

export interface CreateUserProfileDTO {
  userId: string;
  firstName?: string;
  lastName?: string;
  dateOfBirth?: string | null;
  bio?: string;
  profilePictureUrl?: string | null;
  website?: string;
  location?: string;
  country?: string;
  timeZone?: string;
  preferredLanguage?: string;
  isPublic?: boolean;
  emailNotifications?: boolean;
  pushNotifications?: boolean;
}

export interface UpdateUserProfileDTO {
  firstName?: string;
  lastName?: string;
  dateOfBirth?: string | null;
  bio?: string;
  profilePictureUrl?: string | null;
  website?: string;
  location?: string;
  country?: string;
  timeZone?: string;
  preferredLanguage?: string;
  isPublic?: boolean;
  emailNotifications?: boolean;
  pushNotifications?: boolean;
}

export class GetUserProfileDTO extends BaseDTO {
  userId!: number;
  firstName?: string;
  lastName?: string;
  dateOfBirth?: string | null;
  bio?: string;
  profilePictureUrl?: string | null;
  website?: string;
  location?: string;
  country!: string;
  timeZone!: string;
  preferredLanguage!: string;
  isPublic!: boolean;
  emailNotifications!: boolean;
  pushNotifications!: boolean;
  fullName!: string;
  age?: number | null;
  initials?: string;
}
