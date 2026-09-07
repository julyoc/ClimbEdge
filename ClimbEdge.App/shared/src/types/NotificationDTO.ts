import { BaseDTO } from './BaseDTO';

export enum NotificationType {
  Info = 0,
  Success = 1,
  Warning = 2,
  Error = 3,
}

export enum NotificationStatus {
  Unread = 0,
  Read = 1,
  Archived = 2,
}

export class GetNotificationDTO extends BaseDTO {
  userId!: number;
  type!: NotificationType;
  subject?: string;
  message!: string;
  status!: NotificationStatus;
  sentAt?: string | null;
  readAt?: string | null;
}

export interface MarkNotificationsReadDTO {
  userId: number;
  notificationUids?: string[];
  markAll: boolean;
}

export interface UpdateNotificationPreferenceDTO {
  userId: number;
  category: string;
  emailEnabled: boolean;
  pushEnabled: boolean;
  inAppEnabled: boolean;
  smsEnabled: boolean;
}

export class GetNotificationPreferenceDTO extends BaseDTO {
  userId!: number;
  category!: string;
  emailEnabled!: boolean;
  pushEnabled!: boolean;
  inAppEnabled!: boolean;
  smsEnabled!: boolean;
}
