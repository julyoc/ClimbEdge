import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createMountainService } from 'climbedge-shared/services/MountainService';
import { createExpeditionService } from 'climbedge-shared/services/ExpeditionService';
import type { GetMountainDTO } from 'climbedge-shared/types/MountainDTO';
import type { GetExpeditionDTO } from 'climbedge-shared/types/ExpeditionDTO';
import { ExpeditionStatus } from 'climbedge-shared/types/ExpeditionDTO';
import { MountainType } from 'climbedge-shared/types/MountainDTO';

type Tab = 'mountains' | 'expeditions';

const MOUNTAIN_TYPE_LABELS: Record<number, string> = {
  [MountainType.Mountain]: 'Montaña',
  [MountainType.Volcano]: 'Volcán',
  [MountainType.Peak]: 'Pico',
  [MountainType.Ridge]: 'Cresta',
  [MountainType.Other]: 'Otro',
};

const EXPEDITION_STATUS_LABELS: Record<number, string> = {
  [ExpeditionStatus.Draft]: 'Borrador',
  [ExpeditionStatus.Active]: 'Activa',
  [ExpeditionStatus.InProgress]: 'En progreso',
  [ExpeditionStatus.Completed]: 'Completada',
  [ExpeditionStatus.Cancelled]: 'Cancelada',
};

const EXPEDITION_STATUS_COLORS: Record<number, string> = {
  [ExpeditionStatus.Draft]: 'bg-yellow-100 dark:bg-yellow-900/30 text-yellow-700 dark:text-yellow-300',
  [ExpeditionStatus.Active]: 'bg-emerald-100 dark:bg-emerald-900/30 text-emerald-700 dark:text-emerald-300',
  [ExpeditionStatus.InProgress]: 'bg-blue-100 dark:bg-blue-900/30 text-blue-700 dark:text-blue-300',
  [ExpeditionStatus.Completed]: 'bg-gray-100 dark:bg-gray-800 text-gray-600 dark:text-gray-400',
  [ExpeditionStatus.Cancelled]: 'bg-red-100 dark:bg-red-900/30 text-red-700 dark:text-red-300',
};

export default component$(() => {
  const activeTab = useSignal<Tab>('mountains');

  // Mountains
  const mountains = useSignal<GetMountainDTO[]>([]);
  const mountainsLoading = useSignal(true);
  const showMountainForm = useSignal(false);
  const newMountainName = useSignal('');
  const newMountainCountry = useSignal('');
  const newMountainAltitude = useSignal('');
  const savingMountain = useSignal(false);

  // Expeditions
  const expeditions = useSignal<GetExpeditionDTO[]>([]);
  const expeditionsLoading = useSignal(true);
  const showExpeditionForm = useSignal(false);
  const newExpName = useSignal('');
  const newExpMountainId = useSignal('');
  const newExpStart = useSignal('');
  const newExpEnd = useSignal('');
  const savingExp = useSignal(false);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl) {
      mountainsLoading.value = false;
      expeditionsLoading.value = false;
      return;
    }

    const mountainSvc = createMountainService(config);
    const expSvc = createExpeditionService(config);

    const [mtnRes, expRes] = await Promise.all([
      mountainSvc.getAll(),
      expSvc.getAll({ page: 1, pageSize: 50 }),
    ]);

    if (mtnRes.success && mtnRes.data) mountains.value = mtnRes.data;
    mountainsLoading.value = false;

    if (expRes.success && expRes.data) expeditions.value = expRes.data;
    expeditionsLoading.value = false;
  });

  const createMountain = $(async () => {
    if (!newMountainName.value.trim() || !newMountainCountry.value.trim()) return;
    savingMountain.value = true;
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const res = await svc.create({
      name: newMountainName.value.trim(),
      country: newMountainCountry.value.trim(),
      elevation: newMountainAltitude.value ? parseFloat(newMountainAltitude.value) : 0,
      type: MountainType.Mountain,
      difficultyRating: 1,
    });
    savingMountain.value = false;
    if (res.success && res.data) {
      mountains.value = [res.data, ...mountains.value];
      newMountainName.value = '';
      newMountainCountry.value = '';
      newMountainAltitude.value = '';
      showMountainForm.value = false;
    }
  });

  const createExpedition = $(async () => {
    if (!newExpName.value.trim() || !newExpMountainId.value || !newExpStart.value || !newExpEnd.value) return;
    savingExp.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const start = new Date(newExpStart.value);
    const end = new Date(newExpEnd.value);
    const days = Math.max(1, Math.ceil((end.getTime() - start.getTime()) / 86400000));
    const res = await svc.create({
      name: newExpName.value.trim(),
      mountainId: parseInt(newExpMountainId.value),
      startDate: newExpStart.value,
      endDate: newExpEnd.value,
      plannedDurationDays: days,
      minParticipants: 1,
      maxParticipants: 10,
      requiresPermit: false,
      insuranceRequired: false,
      organizedBy: 0,
      isPublic: true,
    });
    savingExp.value = false;
    if (res.success && res.data) {
      expeditions.value = [res.data, ...expeditions.value];
      newExpName.value = '';
      newExpMountainId.value = '';
      newExpStart.value = '';
      newExpEnd.value = '';
      showExpeditionForm.value = false;
    }
  });

  return (
    <div class="p-6 max-w-7xl mx-auto">
      {/* Header */}
      <div class="flex items-center justify-between mb-6">
        <div>
          <h1 class="text-2xl font-bold text-gray-900 dark:text-white">Montañismo</h1>
          <p class="text-gray-500 dark:text-gray-400 text-sm mt-1">Gestiona montañas y expediciones</p>
        </div>
      </div>

      {/* Tabs */}
      <div class="border-b border-gray-200 dark:border-slate-700 mb-6">
        <nav class="-mb-px flex space-x-8">
          {([
            { id: 'mountains' as Tab, label: 'Montañas' },
            { id: 'expeditions' as Tab, label: 'Expediciones' },
          ]).map(tab => (
            <button
              key={tab.id}
              onClick$={() => { activeTab.value = tab.id; }}
              class={`py-3 px-1 border-b-2 text-sm font-medium transition-colors ${
                activeTab.value === tab.id
                  ? 'border-emerald-500 text-emerald-600 dark:text-emerald-400'
                  : 'border-transparent text-gray-500 dark:text-gray-400 hover:text-gray-700 dark:hover:text-gray-300'
              }`}
            >
              {tab.label}
            </button>
          ))}
        </nav>
      </div>

      {/* MOUNTAINS TAB */}
      {activeTab.value === 'mountains' && (
        <div>
          <div class="flex justify-end mb-4">
            <button
              onClick$={() => { showMountainForm.value = !showMountainForm.value; }}
              class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Agregar montaña
            </button>
          </div>

          {showMountainForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-5 mb-6">
              <h3 class="text-sm font-semibold text-gray-900 dark:text-white mb-4">Agregar montaña</h3>
              <div class="grid grid-cols-1 sm:grid-cols-3 gap-3">
                <input
                  type="text"
                  placeholder="Nombre *"
                  value={newMountainName.value}
                  onInput$={(e) => { newMountainName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="País"
                  value={newMountainCountry.value}
                  onInput$={(e) => { newMountainCountry.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="number"
                  placeholder="Altitud (m)"
                  value={newMountainAltitude.value}
                  onInput$={(e) => { newMountainAltitude.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-3 mt-4">
                <button
                  onClick$={() => { showMountainForm.value = false; }}
                  class="px-4 py-2 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors"
                >Cancelar</button>
                <button
                  onClick$={createMountain}
                  disabled={savingMountain.value || !newMountainName.value.trim()}
                  class="px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
                >
                  {savingMountain.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {mountainsLoading.value ? (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {[1, 2, 3].map(i => (
                <div key={i} class="h-40 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
              ))}
            </div>
          ) : mountains.value.length === 0 ? (
            <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400">No hay montañas registradas</p>
            </div>
          ) : (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {mountains.value.map(mountain => (
                <Link
                  key={mountain.uid}
                  href={`/mountaineering/mountains/${mountain.uid}`}
                  class="block bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 hover:border-emerald-400 hover:shadow-md transition-all"
                >
                  <div class="flex items-start justify-between mb-3">
                    <div class="w-10 h-10 bg-orange-100 dark:bg-orange-900/30 rounded-lg flex items-center justify-center">
                      <svg class="w-5 h-5 text-orange-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 3l3.057-3 9.943 4-3.057 3L5 3zm2 4l3.057-3 9.943 4-3.057 3L7 7z" />
                      </svg>
                    </div>
                    {mountain.type != null && (
                      <span class="text-xs px-2 py-0.5 rounded-full bg-gray-100 dark:bg-slate-700 text-gray-500 dark:text-gray-400">
                        {MOUNTAIN_TYPE_LABELS[mountain.type] ?? 'Montaña'}
                      </span>
                    )}
                  </div>
                  <h3 class="font-semibold text-gray-900 dark:text-white">{mountain.name}</h3>
                  <div class="mt-2 space-y-1">
                    {mountain.country && (
                      <p class="text-xs text-gray-500 dark:text-gray-400">📍 {mountain.country}</p>
                    )}
                    {mountain.elevation != null && (
                      <p class="text-xs text-gray-500 dark:text-gray-400">⬆ {mountain.elevation.toLocaleString()} m</p>
                    )}
                  </div>
                </Link>
              ))}
            </div>
          )}
        </div>
      )}

      {/* EXPEDITIONS TAB */}
      {activeTab.value === 'expeditions' && (
        <div>
          <div class="flex justify-end mb-4">
            <button
              onClick$={() => { showExpeditionForm.value = !showExpeditionForm.value; }}
              class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Nueva expedición
            </button>
          </div>

          {showExpeditionForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-5 mb-6">
              <h3 class="text-sm font-semibold text-gray-900 dark:text-white mb-4">Crear expedición</h3>
              <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                <input
                  type="text"
                  placeholder="Nombre de la expedición *"
                  value={newExpName.value}
                  onInput$={(e) => { newExpName.value = (e.target as HTMLInputElement).value; }}
                  class="col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <select
                  value={newExpMountainId.value}
                  onChange$={(e) => { newExpMountainId.value = (e.target as HTMLSelectElement).value; }}
                  class="col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                >
                  <option value="">Seleccionar montaña (opcional)</option>
                  {mountains.value.map(m => (
                    <option key={m.id} value={String(m.id)}>{`${m.name}${m.country ? ' (' + m.country + ')' : ''}`}</option>
                  ))}
                </select>
                <div>
                  <label class="block text-xs text-gray-500 dark:text-gray-400 mb-1">Fecha inicio</label>
                  <input
                    type="date"
                    value={newExpStart.value}
                    onInput$={(e) => { newExpStart.value = (e.target as HTMLInputElement).value; }}
                    class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                  />
                </div>
                <div>
                  <label class="block text-xs text-gray-500 dark:text-gray-400 mb-1">Fecha fin</label>
                  <input
                    type="date"
                    value={newExpEnd.value}
                    onInput$={(e) => { newExpEnd.value = (e.target as HTMLInputElement).value; }}
                    class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                  />
                </div>
              </div>
              <div class="flex justify-end gap-3 mt-4">
                <button onClick$={() => { showExpeditionForm.value = false; }} class="px-4 py-2 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createExpedition}
                  disabled={savingExp.value || !newExpName.value.trim()}
                  class="px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
                >
                  {savingExp.value ? 'Creando...' : 'Crear expedición'}
                </button>
              </div>
            </div>
          )}

          {expeditionsLoading.value ? (
            <div class="space-y-3">
              {[1, 2, 3].map(i => (
                <div key={i} class="h-20 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
              ))}
            </div>
          ) : expeditions.value.length === 0 ? (
            <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400">No hay expediciones</p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
              {expeditions.value.map(exp => (
                <Link
                  key={exp.uid}
                  href={`/mountaineering/expeditions/${exp.uid}`}
                  class="flex items-center gap-4 p-4 hover:bg-gray-50 dark:hover:bg-slate-700/50 transition-colors"
                >
                  <div class="w-10 h-10 bg-purple-100 dark:bg-purple-900/30 rounded-lg flex items-center justify-center flex-shrink-0">
                    <svg class="w-5 h-5 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 21v-4m0 0V5a2 2 0 012-2h6.5l1 1H21l-3 6 3 6h-8.5l-1-1H5a2 2 0 00-2 2zm9-13.5V9" />
                    </svg>
                  </div>
                  <div class="flex-1 min-w-0">
                    <p class="font-medium text-gray-900 dark:text-white truncate">{exp.name}</p>
                    <p class="text-xs text-gray-500 dark:text-gray-400">
                      {exp.startDate ? new Date(exp.startDate).toLocaleDateString('es') : '—'}
                      {' – '}
                      {exp.endDate ? new Date(exp.endDate).toLocaleDateString('es') : '—'}
                    </p>
                  </div>
                  {exp.status != null && (
                    <span class={`text-xs px-2.5 py-1 rounded-full font-medium flex-shrink-0 ${EXPEDITION_STATUS_COLORS[exp.status] ?? ''}`}>
                      {EXPEDITION_STATUS_LABELS[exp.status] ?? 'Desconocido'}
                    </span>
                  )}
                  <svg class="w-4 h-4 text-gray-400 flex-shrink-0" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                  </svg>
                </Link>
              ))}
            </div>
          )}
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Montañismo — ClimbEdge',
};
