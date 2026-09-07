import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createTrainingService } from 'climbedge-shared/services/TrainingService';
import { useAuth } from '~/contexts/auth.context';
import type { GetTrainingPlanDTO } from 'climbedge-shared/types/TrainingDTO';

export default component$(() => {
  const { user } = useAuth();
  const plans = useSignal<GetTrainingPlanDTO[]>([]);
  const loading = useSignal(true);
  const showForm = useSignal(false);
  const saving = useSignal(false);
  const formError = useSignal('');

  const newName = useSignal('');
  const newDesc = useSignal('');
  const newStart = useSignal('');
  const newEnd = useSignal('');

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl) { loading.value = false; return; }
    const svc = createTrainingService(config);
    const res = await svc.getPlans({ page: 1, pageSize: 50 });
    if (res.success && res.data) plans.value = res.data;
    loading.value = false;
  });

  const createPlan = $(async () => {
    if (!newName.value.trim()) return;
    saving.value = true;
    formError.value = '';
    const config = getServiceConfig();
    const svc = createTrainingService(config);
    const res = await svc.createPlan({
      userId: user.value?.id ?? 0,
      name: newName.value.trim(),
      description: newDesc.value.trim() || undefined,
      startDate: newStart.value || new Date().toISOString().split('T')[0],
      endDate: newEnd.value || null,
    });
    saving.value = false;
    if (res.success && res.data) {
      plans.value = [res.data, ...plans.value];
      newName.value = '';
      newDesc.value = '';
      newStart.value = '';
      newEnd.value = '';
      showForm.value = false;
    } else {
      formError.value = res.error ?? 'Error al crear el plan';
    }
  });

  const deletePlan = $(async (uid: string) => {
    const config = getServiceConfig();
    const svc = createTrainingService(config);
    const res = await svc.deletePlan(uid);
    if (res.success) {
      plans.value = plans.value.filter(p => p.uid !== uid);
    }
  });

  return (
    <div class="p-6 max-w-6xl mx-auto">
      {/* Header */}
      <div class="flex items-center justify-between mb-6">
        <div>
          <h1 class="text-2xl font-bold text-gray-900 dark:text-white">Entrenamiento</h1>
          <p class="text-gray-500 dark:text-gray-400 text-sm mt-1">Gestiona tus planes de entrenamiento</p>
        </div>
        <button
          onClick$={() => { showForm.value = !showForm.value; }}
          class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 text-white text-sm font-medium rounded-lg transition-colors"
        >
          <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
          </svg>
          Nuevo plan
        </button>
      </div>

      {/* Create form */}
      {showForm.value && (
        <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-5 mb-6">
          <h3 class="text-sm font-semibold text-gray-900 dark:text-white mb-4">Crear plan de entrenamiento</h3>
          <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <input
              type="text"
              placeholder="Nombre del plan *"
              value={newName.value}
              onInput$={(e) => { newName.value = (e.target as HTMLInputElement).value; }}
              class="col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
            <input
              type="text"
              placeholder="Descripción (opcional)"
              value={newDesc.value}
              onInput$={(e) => { newDesc.value = (e.target as HTMLInputElement).value; }}
              class="col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
            <div>
              <label class="block text-xs text-gray-500 dark:text-gray-400 mb-1">Fecha inicio</label>
              <input
                type="date"
                value={newStart.value}
                onInput$={(e) => { newStart.value = (e.target as HTMLInputElement).value; }}
                class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
              />
            </div>
            <div>
              <label class="block text-xs text-gray-500 dark:text-gray-400 mb-1">Fecha fin</label>
              <input
                type="date"
                value={newEnd.value}
                onInput$={(e) => { newEnd.value = (e.target as HTMLInputElement).value; }}
                class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
              />
            </div>
          </div>
          {formError.value && <p class="text-red-500 text-xs mt-2">{formError.value}</p>}
          <div class="flex justify-end gap-3 mt-4">
            <button
              onClick$={() => { showForm.value = false; formError.value = ''; }}
              class="px-4 py-2 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors"
            >
              Cancelar
            </button>
            <button
              onClick$={createPlan}
              disabled={saving.value || !newName.value.trim()}
              class="px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
            >
              {saving.value ? 'Creando...' : 'Crear plan'}
            </button>
          </div>
        </div>
      )}

      {/* Plans list */}
      {loading.value ? (
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {[1, 2, 3].map(i => (
            <div key={i} class="h-48 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
          ))}
        </div>
      ) : plans.value.length === 0 ? (
        <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
          <svg class="w-12 h-12 text-gray-300 dark:text-slate-500 mx-auto mb-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
          </svg>
          <p class="text-gray-500 dark:text-gray-400">No hay planes de entrenamiento</p>
          <button
            onClick$={() => { showForm.value = true; }}
            class="mt-3 text-sm text-emerald-600 hover:underline"
          >
            Crear tu primer plan
          </button>
        </div>
      ) : (
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {plans.value.map(plan => (
            <div key={plan.uid} class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 flex flex-col">
              <div class="flex items-start justify-between mb-3">
                <div class="w-10 h-10 bg-emerald-100 dark:bg-emerald-900/30 rounded-lg flex items-center justify-center flex-shrink-0">
                  <svg class="w-5 h-5 text-emerald-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
                  </svg>
                </div>
                <button
                  onClick$={() => deletePlan(plan.uid)}
                  class="text-gray-400 hover:text-red-500 transition-colors p-1"
                  title="Eliminar plan"
                  aria-label="Eliminar plan"
                >
                  <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                  </svg>
                </button>
              </div>
              <h3 class="font-semibold text-gray-900 dark:text-white">{plan.name}</h3>
              {plan.description && (
                <p class="text-xs text-gray-500 dark:text-gray-400 mt-1 line-clamp-2 flex-1">{plan.description}</p>
              )}
              <div class="mt-3 pt-3 border-t border-gray-100 dark:border-slate-700 flex items-center justify-between">
                <div class="text-xs text-gray-500 dark:text-gray-400">
                  {plan.startDate ? new Date(plan.startDate).toLocaleDateString('es') : '—'}
                  {' – '}
                  {plan.endDate ? new Date(plan.endDate).toLocaleDateString('es') : '—'}
                </div>
                <Link
                  href={`/training/${plan.uid}`}
                  class="text-xs text-emerald-600 hover:underline font-medium"
                >
                  Ver plan →
                </Link>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Entrenamiento — ClimbEdge',
};
