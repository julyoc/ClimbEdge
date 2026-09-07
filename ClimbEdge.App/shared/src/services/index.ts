export interface ApiResponse<T> {
  data?: T;
  error?: string;
  success: boolean;
}

export type { ServiceConfig } from './_base';
export { createAuthService } from './AuthService';
export type { AuthService } from './AuthService';
export { createBoardService } from './BoardService';
export type { BoardService } from './BoardService';
export { createClimbRouteService } from './ClimbRouteService';
export type { ClimbRouteService } from './ClimbRouteService';
export { createClimbZoneService } from './ClimbZoneService';
export type { ClimbZoneService } from './ClimbZoneService';
export { createMountainService } from './MountainService';
export type { MountainService } from './MountainService';
export { createExpeditionService } from './ExpeditionService';
export type { ExpeditionService } from './ExpeditionService';
export { createTrainingService } from './TrainingService';
export type { TrainingService } from './TrainingService';
export { createUserSessionService } from './UserSessionService';
export type { UserSessionService } from './UserSessionService';
export { createOrganizationService } from './OrganizationService';
export type { OrganizationService } from './OrganizationService';
export { createCommentService } from './CommentService';
export type { CommentService } from './CommentService';
export { createNotificationService } from './NotificationService';
export type { NotificationService } from './NotificationService';
export { createUserProfileService } from './UserProfileService';
export type { UserProfileService } from './UserProfileService';
export { createPaymentService } from './PaymentService';
export type { PaymentService } from './PaymentService';
