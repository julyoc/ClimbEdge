import { type RequestHandler } from '@builder.io/qwik-city';

/**
 * Redirige a usuarios ya autenticados a la página principal.
 * Aplica a todas las rutas dentro del grupo (auth): login, register, forgot-password, reset-password.
 */
export const onRequest: RequestHandler = ({ cookie, redirect }) => {
  const token = cookie.get('access_token')?.value;
  if (token) {
    throw redirect(302, '/');
  }
};
