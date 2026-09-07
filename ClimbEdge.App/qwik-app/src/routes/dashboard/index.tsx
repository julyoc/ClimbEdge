import { component$, useSignal, useVisibleTask$ } from '@builder.io/qwik';
import { Link, type DocumentHead } from '@builder.io/qwik-city';
import { useAuth } from '~/contexts/auth.context';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createUserSessionService } from 'climbedge-shared/services/UserSessionService';
import { createTrainingService } from 'climbedge-shared/services/TrainingService';
import { createOrganizationService } from 'climbedge-shared/services/OrganizationService';
import { createNotificationService } from 'climbedge-shared/services/NotificationService';
import type { GetSessionDTO } from 'climbedge-shared/types/SessionDTO';
import type { GetTrainingPlanDTO } from 'climbedge-shared/types/TrainingDTO';
import type { GetNotificationDTO } from 'climbedge-shared/types/NotificationDTO';

export default component$(() => {
  const { user } = useAuth();
  const recentSessions = useSignal<GetSessionDTO[]>([]);
  const activePlans = useSignal<GetTrainingPlanDTO[]>([]);
  const notifications = useSignal<GetNotificationDTO[]>([]);
  const statsLoading = useSignal(true);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl) return;

    try {
      const sessionSvc = createUserSessionService(config);
      const trainingSvc = createTrainingService(config);
      const notifSvc = createNotificationService(config);

      const userId = user.value?.id;
      if (!userId) return;

      const [sessRes, planRes, notifRes] = await Promise.all([
        sessionSvc.getSessions({ page: 1, pageSize: 5 }),
        trainingSvc.getPlans({ activeOnly: true, page: 1, pageSize: 5 }),
        notifSvc.getNotifications(userId, true, 1, 10),
      ]);

      if (sessRes.success && sessRes.data) recentSessions.value = sessRes.data;
      if (planRes.success && planRes.data) activePlans.value = planRes.data;
      if (notifRes.success && notifRes.data) notifications.value = notifRes.data;
    } finally {
      statsLoading.value = false;
    }
  });

  const greeting = () => {
    const hour = new Date().getHours();
    if (hour < 12) return 'Buenos días';
    if (hour < 18) return 'Buenas tardes';
    return 'Buenas noches';
  };

  const quickLinks = [
    { href: '/climbing', label: 'Ir a Escalada', icon: 'M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5zM4 13a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H5a1 1 0 01-1-1v-6zM16 13a1 1 0 011-1h2a1 1 0 011 1v6a1 1 0 01-1 1h-2a1 1 0 01-1-1v-6z', color: 'bg-blue-500' },
    { href: '/training', label: 'Mis Planes', icon: 'M13 10V3L4 14h7v7l9-11h-7z', color: 'bg-emerald-500' },
    { href: '/mountaineering', label: 'Montañismo', icon: 'M5 3l3.057-3 9.943 4-3.057 3L5 3zm2 4l3.057-3 9.943 4-3.057 3L7 7z', color: 'bg-orange-500' },
    { href: '/settings/profile', label: 'Mi Perfil', icon: 'M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z', color: 'bg-purple-500' },
  ];

  return (
    <div class="p-6 max-w-7xl mx-auto">
      {/* Header */}
      <div class="mb-8">
        <h1 class="text-3xl font-bold text-gray-900 dark:text-white">
          {greeting()},{' '}
          <span class="text-emerald-600">
            {user.value?.firstName || user.value?.email || 'Escalador'}
          </span>
        </h1>
        <p class="mt-1 text-gray-500 dark:text-gray-400">
          Aquí tienes un resumen de tu actividad reciente
        </p>
      </div>

      {/* Stats Cards */}
      <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
          <div class="flex items-center justify-between">
            <div>
              <p class="text-sm font-medium text-gray-500 dark:text-gray-400">Sesiones recientes</p>
              <p class="text-3xl font-bold text-gray-900 dark:text-white mt-1">
                {statsLoading.value ? '—' : recentSessions.value.length}
              </p>
            </div>
            <div class="w-12 h-12 bg-blue-100 dark:bg-blue-900/30 rounded-xl flex items-center justify-center">
              <svg class="w-6 h-6 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M14.828 14.828a4 4 0 01-5.656 0M9 10h1.01M15 10h1.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
          <Link href="/climbing" class="text-xs text-blue-600 mt-3 block hover:underline">Ver sesiones →</Link>
        </div>

        <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
          <div class="flex items-center justify-between">
            <div>
              <p class="text-sm font-medium text-gray-500 dark:text-gray-400">Planes activos</p>
              <p class="text-3xl font-bold text-gray-900 dark:text-white mt-1">
                {statsLoading.value ? '—' : activePlans.value.length}
              </p>
            </div>
            <div class="w-12 h-12 bg-emerald-100 dark:bg-emerald-900/30 rounded-xl flex items-center justify-center">
              <svg class="w-6 h-6 text-emerald-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
              </svg>
            </div>
          </div>
          <Link href="/training" class="text-xs text-emerald-600 mt-3 block hover:underline">Ver planes →</Link>
        </div>

        <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
          <div class="flex items-center justify-between">
            <div>
              <p class="text-sm font-medium text-gray-500 dark:text-gray-400">Notificaciones</p>
              <p class="text-3xl font-bold text-gray-900 dark:text-white mt-1">
                {statsLoading.value ? '—' : notifications.value.length}
              </p>
            </div>
            <div class="w-12 h-12 bg-yellow-100 dark:bg-yellow-900/30 rounded-xl flex items-center justify-center">
              <svg class="w-6 h-6 text-yellow-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9" />
              </svg>
            </div>
          </div>
          <span class="text-xs text-yellow-600 mt-3 block">Sin leer</span>
        </div>

        <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
          <div class="flex items-center justify-between">
            <div>
              <p class="text-sm font-medium text-gray-500 dark:text-gray-400">Perfil</p>
              <p class="text-lg font-bold text-gray-900 dark:text-white mt-1 truncate">
                {user.value?.firstName || 'Sin nombre'}
              </p>
            </div>
            <div class="w-12 h-12 bg-purple-100 dark:bg-purple-900/30 rounded-xl flex items-center justify-center">
              <svg class="w-6 h-6 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
              </svg>
            </div>
          </div>
          <Link href="/settings/profile" class="text-xs text-purple-600 mt-3 block hover:underline">Editar perfil →</Link>
        </div>
      </div>

      {/* Main Content Grid */}
      <div class="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Quick Access */}
        <div class="lg:col-span-1">
          <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white mb-4">Acceso rápido</h2>
            <div class="space-y-3">
              {quickLinks.map(link => (
                <Link key={link.href} href={link.href} class="flex items-center gap-3 p-3 rounded-lg hover:bg-gray-50 dark:hover:bg-slate-700 transition-colors">
                  <div class={`w-9 h-9 ${link.color} rounded-lg flex items-center justify-center flex-shrink-0`}>
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d={link.icon} />
                    </svg>
                  </div>
                  <span class="text-sm font-medium text-gray-700 dark:text-gray-300">{link.label}</span>
                  <svg class="w-4 h-4 text-gray-400 ml-auto" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                  </svg>
                </Link>
              ))}
            </div>
          </div>
        </div>

        {/* Recent Sessions */}
        <div class="lg:col-span-2">
          <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
            <div class="flex items-center justify-between mb-4">
              <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Sesiones recientes</h2>
              <Link href="/climbing" class="text-sm text-emerald-600 hover:underline">Ver todas</Link>
            </div>

            {statsLoading.value ? (
              <div class="space-y-3">
                {[1, 2, 3].map(i => (
                  <div key={i} class="h-14 bg-gray-100 dark:bg-slate-700 rounded-lg animate-pulse" />
                ))}
              </div>
            ) : recentSessions.value.length === 0 ? (
              <div class="text-center py-10">
                <svg class="w-12 h-12 text-gray-300 dark:text-slate-600 mx-auto mb-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M14.828 14.828a4 4 0 01-5.656 0M9 10h1.01M15 10h1.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
                <p class="text-gray-500 dark:text-gray-400 text-sm">No hay sesiones recientes</p>
                <Link href="/climbing" class="mt-2 inline-block text-sm text-emerald-600 hover:underline">
                  Iniciar una sesión
                </Link>
              </div>
            ) : (
              <div class="space-y-3">
                {recentSessions.value.map(session => (
                  <div key={session.uid} class="flex items-center gap-4 p-3 rounded-lg border border-gray-100 dark:border-slate-700">
                    <div class={`w-2 h-2 rounded-full flex-shrink-0 ${session.endedAt ? 'bg-gray-400' : 'bg-emerald-500 animate-pulse'}`} />
                    <div class="flex-1 min-w-0">
                      <p class="text-sm font-medium text-gray-900 dark:text-white truncate">
                        Sesión {session.startedAt ? new Date(session.startedAt).toLocaleDateString('es', { day: '2-digit', month: 'short' }) : '—'}
                      </p>
                      <p class="text-xs text-gray-500 dark:text-gray-400">
                        {session.endedAt ? 'Finalizada' : 'En progreso'}
                      </p>
                    </div>
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
      </div>

      {/* Active Plans */}
      {!statsLoading.value && activePlans.value.length > 0 && (
        <div class="mt-6">
          <div class="bg-white dark:bg-slate-800 rounded-xl shadow-sm border border-gray-200 dark:border-slate-700 p-6">
            <div class="flex items-center justify-between mb-4">
              <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Planes de entrenamiento activos</h2>
              <Link href="/training" class="text-sm text-emerald-600 hover:underline">Ver todos</Link>
            </div>
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {activePlans.value.map(plan => (
                <Link key={plan.uid} href={`/training/${plan.uid}`} class="block p-4 rounded-lg border border-gray-200 dark:border-slate-600 hover:border-emerald-400 transition-colors">
                  <p class="font-medium text-gray-900 dark:text-white truncate">{plan.name}</p>
                  <p class="text-xs text-gray-500 dark:text-gray-400 mt-1">
                    {plan.startDate ? new Date(plan.startDate).toLocaleDateString('es') : '—'}
                    {' – '}
                    {plan.endDate ? new Date(plan.endDate).toLocaleDateString('es') : '—'}
                  </p>
                  <span class="mt-2 inline-block px-2 py-0.5 text-xs font-medium bg-emerald-100 dark:bg-emerald-900/40 text-emerald-700 dark:text-emerald-300 rounded-full">
                    Activo
                  </span>
                </Link>
              ))}
            </div>
          </div>
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Dashboard — ClimbEdge',
};
