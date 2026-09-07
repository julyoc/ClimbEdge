import { type RequestHandler } from '@builder.io/qwik-city';

/**
 * Rutas que no requieren autenticación.
 * Soporta strings exactos y prefijos con '*' al final.
 */
const PUBLIC_ROUTES = [
  '/',
  '/login',
  '/register',
  '/forgot-password',
  '/reset-password',
  '/unauthorized',
  '/about',
  '/privacy-policy',
  '/terms-of-service',
  '/help-center',
  '/contact-us',
  '/robots.txt',
  '/sitemap.xml',
];

function isPublicRoute(pathname: string): boolean {
  return PUBLIC_ROUTES.some((route) => pathname === route || pathname.startsWith(route + '/'));
}

export const onRequest: RequestHandler = ({ cookie, redirect, url }) => {
  if (isPublicRoute(url.pathname)) return;

  const token = cookie.get('access_token')?.value;

  if (!token) {
    throw redirect(302, `/login?redirect=${encodeURIComponent(url.pathname)}`);
  }
};
