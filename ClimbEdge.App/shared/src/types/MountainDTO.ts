import { BaseDTO } from './BaseDTO';

export enum MountainType {
  Mountain = 0,
  Volcano = 1,
  Peak = 2,
  Ridge = 3,
  Other = 4,
}

export enum RouteType {
  Normal = 0,
  Technical = 1,
  Alpine = 2,
  Ice = 3,
  Mixed = 4,
}

export enum SeasonType {
  Spring = 0,
  Summer = 1,
  Autumn = 2,
  Winter = 3,
  AllYear = 4,
}

// Mountain
export interface CreateMountainDTO {
  name: string;
  description?: string;
  type: MountainType;
  elevation: number;
  country: string;
  region?: string;
  state?: string;
  firstAscentDate?: string | null;
  firstAscentBy?: string;
  difficultyRating: number;
  imageUrls?: string[];
}

export interface UpdateMountainDTO {
  description?: string;
  region?: string;
  state?: string;
  isActive?: boolean;
  difficultyRating?: number;
  imageUrls?: string[];
}

export class GetMountainDTO extends BaseDTO {
  name!: string;
  description?: string;
  type!: MountainType;
  elevation!: number;
  country!: string;
  region?: string;
  state?: string;
  firstAscentDate?: string | null;
  firstAscentBy?: string;
  isActive!: boolean;
  difficultyRating!: number;
  imageUrls?: string[];
}

// Mountain Route
export interface CreateMountainRouteDTO {
  mountainId: number;
  name: string;
  description?: string;
  type: RouteType;
  difficultyScaleId: number;
  distance: number;
  elevationGain?: number;
  elevationLoss?: number;
  estimatedDuration: number;
  bestSeason: SeasonType;
  requiresPermit: boolean;
  maxParticipants?: number;
  isGuided: boolean;
  dangerLevel: number;
  firstAscentDate?: string | null;
  firstAscentBy?: string;
}

export interface UpdateMountainRouteDTO {
  description?: string;
  distance?: number;
  elevationGain?: number;
  estimatedDuration?: number;
  bestSeason?: SeasonType;
  requiresPermit?: boolean;
  maxParticipants?: number;
  isGuided?: boolean;
  dangerLevel?: number;
}

export class GetMountainRouteDTO extends BaseDTO {
  mountainId!: number;
  name!: string;
  description?: string;
  type!: RouteType;
  difficultyScaleId!: number;
  distance!: number;
  elevationGain?: number;
  elevationLoss?: number;
  estimatedDuration!: number;
  bestSeason!: SeasonType;
  requiresPermit!: boolean;
  maxParticipants?: number;
  isGuided!: boolean;
  dangerLevel!: number;
  firstAscentDate?: string | null;
  firstAscentBy?: string;
}

// Route Track
export interface CreateRouteTrackDTO {
  mountainRouteId: number;
  name: string;
  trackDataWkt: string;
  totalDistance?: number;
  minElevation?: number;
  maxElevation?: number;
  recordedBy?: number;
  recordedAt?: string;
  gpsDevice?: string;
  accuracy?: number;
}

export interface GetRouteTrackDTO extends BaseDTO {
  mountainRouteId: number;
  name: string;
  trackDataWkt?: string;
  totalDistance?: number;
  minElevation?: number;
  maxElevation?: number;
  recordedBy?: number;
  recordedAt?: string;
  gpsDevice?: string;
  accuracy?: number;
}

// Route Waypoint
export interface CreateRouteWaypointDTO {
  mountainRouteId: number;
  name: string;
  description?: string;
  locationWkt: string;
  sequence: number;
  waypointTypeId?: number;
  estimatedTimeFromPrevious?: number;
  notes?: string;
  imageUrl?: string;
}

export interface GetRouteWaypointDTO extends BaseDTO {
  mountainRouteId: number;
  name: string;
  description?: string;
  locationWkt?: string;
  sequence: number;
  waypointTypeId?: number;
  estimatedTimeFromPrevious?: number;
  notes?: string;
  imageUrl?: string;
}

// Weather Condition
export interface CreateWeatherConditionDTO {
  mountainId: number;
  recordedAt: string;
  temperature?: number;
  windSpeed?: number;
  windDirection?: number;
  humidity?: number;
  pressure?: number;
  visibility?: number;
  condition?: string;
  snowDepth?: number;
  dataSource?: string;
  rainFall?: number;
  snowFall?: number;
}

export interface GetWeatherConditionDTO extends BaseDTO {
  mountainId: number;
  recordedAt: string;
  temperature?: number;
  windSpeed?: number;
  windDirection?: number;
  humidity?: number;
  pressure?: number;
  visibility?: number;
  condition?: string;
  snowDepth?: number;
  dataSource?: string;
  rainFall?: number;
  snowFall?: number;
}
