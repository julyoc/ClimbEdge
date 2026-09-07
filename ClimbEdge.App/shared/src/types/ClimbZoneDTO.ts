import { BaseDTO } from './BaseDTO';

export interface CreateClimbZoneDTO {
  name: string;
  description?: string;
  isPublic: boolean;
  isIndoor: boolean;
  imageUrl?: string | null;
  organizationId?: number | null;
}

export interface UpdateClimbZoneDTO {
  name?: string;
  description?: string;
  isPublic?: boolean;
  imageUrl?: string | null;
  organizationId?: number | null;
}

export class GetClimbZoneDTO extends BaseDTO {
  name!: string;
  description?: string;
  isPublic!: boolean;
  isIndoor!: boolean;
  imageUrl?: string | null;
  organizationId?: number | null;
}
