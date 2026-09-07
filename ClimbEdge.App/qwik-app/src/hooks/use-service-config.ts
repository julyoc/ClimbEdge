export interface ServiceConfig {
  baseUrl: string;
  apiKey: string;
}

export const getServiceConfig = (): ServiceConfig => ({
  baseUrl: import.meta.env.VITE_API_URL ?? '',
  apiKey: import.meta.env.VITE_API_KEY ?? '',
});
