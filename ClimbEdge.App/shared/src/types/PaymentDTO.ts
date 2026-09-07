import { BaseDTO } from './BaseDTO';

export enum SubscriptionStatus {
  Active = 0,
  Cancelled = 1,
  Expired = 2,
  PastDue = 3,
}

export interface CreateSubscriptionDTO {
  userId: number;
  planId: number;
  autoRenew: boolean;
}

export interface CancelSubscriptionDTO {
  subscriptionUid: string;
  cancellationReason?: string;
}

export class GetSubscriptionDTO extends BaseDTO {
  userId!: number;
  planId!: number;
  status!: SubscriptionStatus;
  startDate!: string;
  endDate?: string | null;
  nextBillingDate?: string | null;
  autoRenew!: boolean;
  cancelledAt?: string | null;
  cancellationReason?: string;
}

export class GetPlanDTO extends BaseDTO {
  name!: string;
  description?: string;
  price!: number;
  currency!: string;
  billingPeriod!: string;
  isActive!: boolean;
  maxBoards?: number | null;
  maxMembers?: number | null;
  aiGenerationsPerMonth?: number | null;
}

export interface AddPaymentMethodDTO {
  userId: number;
  type: string;
  provider: string;
  token: string;
  lastFourDigits?: string;
  expiryDate?: string | null;
  isDefault: boolean;
}

export class GetPaymentMethodDTO extends BaseDTO {
  userId!: number;
  type!: string;
  provider!: string;
  lastFourDigits?: string;
  expiryDate?: string | null;
  isDefault!: boolean;
  isActive!: boolean;
}
