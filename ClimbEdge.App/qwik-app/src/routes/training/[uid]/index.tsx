import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, useLocation, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createTrainingService } from 'climbedge-shared/services/TrainingService';
import type { GetTrainingPlanDTO, GetTrainingPeriodDTO, GetTrainingWeekDTO, GetTrainingSessionDTO } from 'climbedge-shared/types/TrainingDTO';

export default component$(() => {
  const location = useLocation();
  const uid = location.params['uid'];

  const plan = useSignal<GetTrainingPlanDTO | null>(null);
  const periods = useSignal<GetTrainingPeriodDTO[]>([]);
  const expandedPeriod = useSignal<number | null>(null);
  const weeks = useSignal<Record<number, GetTrainingWeekDTO[]>>({});
  const expandedWeek = useSignal<number | null>(null);
  const weekSessions = useSignal<Record<number, GetTrainingSessionDTO[]>>({});
  const loading = useSignal(true);
  const error = useSignal('');

  // Create period form
  const showPeriodForm = useSignal(false);
  const newPeriodName = useSignal('');
  const newPeriodStart = useSignal('');
  const newPeriodEnd = useSignal('');
  const savingPeriod = useSignal(false);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl || !uid) { loading.value = false; return; }

    const svc = createTrainingService(config);
    const planRes = await svc.getPlanByUid(uid);

    if (!planRes.success || !planRes.data) {
      error.value = planRes.error ?? 'Plan no encontrado';
      loading.value = false;
      return;
    }

    plan.value = planRes.data;
    const periodsRes = await svc.getPeriods(planRes.data.id);
    if (periodsRes.success && periodsRes.data) periods.value = periodsRes.data;
    loading.value = false;
  });

  const loadWeeks = $(async (periodId: number) => {
    if (weeks.value[periodId]) {
      expandedPeriod.value = expandedPeriod.value === periodId ? null : periodId;
      return;
    }
    const config = getServiceConfig();
    const svc = createTrainingService(config);
    const res = await svc.getWeeks(periodId);
    if (res.success && res.data) {
      weeks.value = { ...weeks.value, [periodId]: res.data };
    }
    expandedPeriod.value = expandedPeriod.value === periodId ? null : periodId;
  });

  const loadWeekSessions = $(async (weekId: number) => {
    if (weekSessions.value[weekId]) {
      expandedWeek.value = expandedWeek.value === weekId ? null : weekId;
      return;
    }
    const config = getServiceConfig();
    const svc = createTrainingService(config);
    const res = await svc.getWeekSessions(weekId);
    if (res.success && res.data) {
      weekSessions.value = { ...weekSessions.value, [weekId]: res.data };
    }
    expandedWeek.value = expandedWeek.value === weekId ? null : weekId;
  });

  const createPeriod = $(async () => {
    if (!newPeriodName.value.trim() || !plan.value) return;
    savingPeriod.value = true;
    const config = getServiceConfig();
    const svc = createTrainingService(config);
    const res = await svc.createPeriod({
      trainingPlanId: plan.value.id,
      name: newPeriodName.value.trim(),
      periodType: 0,
      startDate: newPeriodStart.value || new Date().toISOString().split('T')[0],
      endDate: newPeriodEnd.value || new Date().toISOString().split('T')[0],
      weekNumber: 1,
    });
    savingPeriod.value = false;
    if (res.success && res.data) {
      periods.value = [...periods.value, res.data];
      newPeriodName.value = '';
      newPeriodStart.value = '';
      newPeriodEnd.value = '';
      showPeriodForm.value = false;
    }
  });

  if (loading.value) {
    return (
      <div class="p-6 flex justify-center items-center min-h-64">
        <div class="animate-spin rounded-full h-10 w-10 border-b-2 border-emerald-600" />
      </div>
    );
  }

  if (error.value || !plan.value) {
    return (
      <div class="p-6">
        <div class="bg-red-50 dark:bg-red-900/20 text-red-700 dark:text-red-300 rounded-xl p-4">
          {error.value || 'Plan no encontrado'}
        </div>
        <Link href="/training" class="mt-4 inline-block text-sm text-emerald-600 hover:underline">← Volver a Entrenamiento</Link>
      </div>
    );
  }

  return (
    <div class="p-6 max-w-5xl mx-auto">
      {/* Breadcrumb */}
      <nav class="text-sm text-gray-500 dark:text-gray-400 mb-4">
        <Link href="/training" class="hover:text-emerald-600">Entrenamiento</Link>
        <span class="mx-2">›</span>
        <span class="text-gray-900 dark:text-white">{plan.value.name}</span>
      </nav>

      {/* Plan header */}
      <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-6 mb-6">
        <div class="flex items-start justify-between">
          <div>
            <h1 class="text-2xl font-bold text-gray-900 dark:text-white">{plan.value.name}</h1>
            {plan.value.description && (
              <p class="text-gray-500 dark:text-gray-400 text-sm mt-1">{plan.value.description}</p>
            )}
            <div class="flex items-center gap-4 mt-3 text-sm text-gray-500 dark:text-gray-400">
              {plan.value.startDate && (
                <span>Inicio: {new Date(plan.value.startDate).toLocaleDateString('es')}</span>
              )}
              {plan.value.endDate && (
                <span>Fin: {new Date(plan.value.endDate).toLocaleDateString('es')}</span>
              )}
            </div>
          </div>
          <span class="px-3 py-1 text-xs font-medium rounded-full bg-emerald-100 dark:bg-emerald-900/40 text-emerald-700 dark:text-emerald-300">
            Activo
          </span>
        </div>
      </div>

      {/* Periods */}
      <div class="flex items-center justify-between mb-4">
        <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Periodos</h2>
        <button
          onClick$={() => { showPeriodForm.value = !showPeriodForm.value; }}
          class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
        >
          <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
          </svg>
          Nuevo periodo
        </button>
      </div>

      {showPeriodForm.value && (
        <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
          <div class="grid grid-cols-1 sm:grid-cols-3 gap-3">
            <input
              type="text"
              placeholder="Nombre del periodo *"
              value={newPeriodName.value}
              onInput$={(e) => { newPeriodName.value = (e.target as HTMLInputElement).value; }}
              class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
            <input
              type="date"
              value={newPeriodStart.value}
              onInput$={(e) => { newPeriodStart.value = (e.target as HTMLInputElement).value; }}
              class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
            <input
              type="date"
              value={newPeriodEnd.value}
              onInput$={(e) => { newPeriodEnd.value = (e.target as HTMLInputElement).value; }}
              class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
          </div>
          <div class="flex justify-end gap-2 mt-3">
            <button onClick$={() => { showPeriodForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
            <button
              onClick$={createPeriod}
              disabled={savingPeriod.value || !newPeriodName.value.trim()}
              class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
            >
              {savingPeriod.value ? 'Guardando...' : 'Guardar'}
            </button>
          </div>
        </div>
      )}

      {periods.value.length === 0 ? (
        <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
          <p class="text-gray-500 dark:text-gray-400 text-sm">No hay periodos en este plan</p>
        </div>
      ) : (
        <div class="space-y-3">
          {periods.value.map(period => (
            <div key={period.id} class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 overflow-hidden">
              {/* Period header */}
              <button
                onClick$={() => loadWeeks(period.id)}
                class="w-full flex items-center justify-between p-4 hover:bg-gray-50 dark:hover:bg-slate-700/50 transition-colors text-left"
              >
                <div>
                  <span class="font-medium text-gray-900 dark:text-white">{period.name}</span>
                  <span class="ml-3 text-xs text-gray-500 dark:text-gray-400">
                    {period.startDate ? new Date(period.startDate).toLocaleDateString('es') : '—'}
                    {' – '}
                    {period.endDate ? new Date(period.endDate).toLocaleDateString('es') : '—'}
                  </span>
                </div>
                <svg
                  class={`w-4 h-4 text-gray-400 transition-transform ${expandedPeriod.value === period.id ? 'rotate-180' : ''}`}
                  fill="none" stroke="currentColor" viewBox="0 0 24 24"
                >
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                </svg>
              </button>

              {/* Weeks */}
              {expandedPeriod.value === period.id && (
                <div class="border-t border-gray-100 dark:border-slate-700 p-4 space-y-2">
                  {!weeks.value[period.id] ? (
                    <div class="flex justify-center py-4">
                      <div class="animate-spin rounded-full h-5 w-5 border-b-2 border-emerald-600" />
                    </div>
                  ) : weeks.value[period.id].length === 0 ? (
                    <p class="text-xs text-gray-500 dark:text-gray-400 text-center py-3">Sin semanas</p>
                  ) : (
                    weeks.value[period.id].map(week => (
                      <div key={week.id} class="border border-gray-100 dark:border-slate-600 rounded-lg overflow-hidden">
                        <button
                          onClick$={() => loadWeekSessions(week.id)}
                          class="w-full flex items-center justify-between px-4 py-3 hover:bg-gray-50 dark:hover:bg-slate-700/30 transition-colors text-left"
                        >
                          <div class="flex items-center gap-2">
                            <span class={`w-2 h-2 rounded-full ${week.isCompleted ? 'bg-emerald-500' : 'bg-gray-300'}`} />
                            <span class="text-sm font-medium text-gray-800 dark:text-gray-200">
                              Semana {week.weekNumber}
                            </span>
                            {week.isCompleted && (
                              <span class="text-xs px-1.5 py-0.5 bg-emerald-100 dark:bg-emerald-900/30 text-emerald-600 dark:text-emerald-400 rounded-full">
                                Completada
                              </span>
                            )}
                          </div>
                          <svg
                            class={`w-3.5 h-3.5 text-gray-400 transition-transform ${expandedWeek.value === week.id ? 'rotate-180' : ''}`}
                            fill="none" stroke="currentColor" viewBox="0 0 24 24"
                          >
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                          </svg>
                        </button>

                        {expandedWeek.value === week.id && (
                          <div class="border-t border-gray-100 dark:border-slate-700 px-4 py-3">
                            {!weekSessions.value[week.id] ? (
                              <div class="flex justify-center py-3">
                                <div class="animate-spin rounded-full h-4 w-4 border-b-2 border-emerald-600" />
                              </div>
                            ) : weekSessions.value[week.id].length === 0 ? (
                              <p class="text-xs text-gray-500 dark:text-gray-400">Sin sesiones</p>
                            ) : (
                              <div class="space-y-2">
                                {weekSessions.value[week.id].map(session => (
                                  <div key={session.id} class="flex items-center gap-3 text-xs">
                                    <span class={`w-1.5 h-1.5 rounded-full ${session.isCompleted ? 'bg-emerald-500' : 'bg-gray-300'}`} />
                                    <span class="text-gray-700 dark:text-gray-300">{session.date ? new Date(session.date).toLocaleDateString('es') : 'Sesión'}</span>
                                    {session.isCompleted && (
                                      <span class="text-emerald-600 dark:text-emerald-400 ml-auto">✓</span>
                                    )}
                                  </div>
                                ))}
                              </div>
                            )}
                          </div>
                        )}
                      </div>
                    ))
                  )}
                </div>
              )}
            </div>
          ))}
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Plan de Entrenamiento — ClimbEdge',
};
