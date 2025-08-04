export const roles = {
  USER: 'User',
  ADMIN: 'Admin',
  SUPER_ADMIN: 'SuperAdmin',
  MODERATOR: 'Moderator',
  GUEST: 'Guest',
  SUPPORT: 'Support',
  DEVELOPER: 'Developer',
  TESTER: 'Tester',
  MANAGER: 'Manager',
  CLIMB: 'Climb',
  MOUNTAINEER: 'Mountaingeer',
  CONTENT_CREATOR: 'ContentCreator',
  CONTENT_EDITOR: 'ContentEditor',
  CONTENT_VIEWER: 'ContentViewer',
  ANALYTICS_VIEWER: 'AnalyticsViewer',
  SYSTEM_USER: 'SystemUser',
  CLIMB_CLUB: 'ClimbClub',
} as const;

// Tipo para TypeScript que incluye todos los roles
export type Role = typeof roles[keyof typeof roles];

// Helper para verificar si un usuario tiene un rol específico
export const hasRole = (userRoles: string[] | undefined, role: Role): boolean => {
  return userRoles?.includes(role) ?? false;
};

// Helper para verificar si un usuario tiene alguno de los roles especificados
export const hasAnyRole = (userRoles: string[] | undefined, rolesToCheck: Role[]): boolean => {
  return rolesToCheck.some(role => hasRole(userRoles, role));
};

// Helper para verificar si un usuario tiene TODOS los roles especificados
export const hasAllRoles = (userRoles: string[] | undefined, rolesToCheck: Role[]): boolean => {
  return rolesToCheck.every(role => hasRole(userRoles, role));
};

// Grupos de roles comunes para facilitar el uso
export const roleGroups = {
  ADMIN_ROLES: [roles.ADMIN, roles.SUPER_ADMIN, roles.MANAGER] as Role[],
  CONTENT_ROLES: [roles.CONTENT_CREATOR, roles.CONTENT_EDITOR, roles.CONTENT_VIEWER] as Role[],
  CLIMBING_ROLES: [roles.CLIMB, roles.MOUNTAINEER, roles.CLIMB_CLUB] as Role[],
  SYSTEM_ROLES: [roles.DEVELOPER, roles.TESTER, roles.SYSTEM_USER] as Role[],
  SUPPORT_ROLES: [roles.SUPPORT, roles.MODERATOR] as Role[],
} as const;