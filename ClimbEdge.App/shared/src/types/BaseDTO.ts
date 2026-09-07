export interface Metadata {
  // Define aquí la estructura de Metadata si la conoces
  [key: string]: any;
}

export abstract class BaseDTO {
  id!: number;
  uid!: string; // Guid → string en TS
  slug: string = "";
  metaData?: Metadata;
  createdAt!: Date;
  updatedAt?: Date;
  deletedAt?: Date;
  restoredAt?: Date;
  lockedAt?: Date;

  isDeleted: boolean = false;
  isRestored: boolean = false;
  isLocked: boolean = false;

  daysSinceCreated: number = 0;
  daysSinceUpdated: number = 0;
  daysSinceDeleted: number = 0;
  daysSinceRestored: number = 0;
  daysSinceLocked: number = 0;

  isRecentlyCreated: boolean = false;
  isRecentlyUpdated: boolean = false;
  isRecentlyDeleted: boolean = false;
  isRecentlyRestored: boolean = false;
  isRecentlyLocked: boolean = false;
}
