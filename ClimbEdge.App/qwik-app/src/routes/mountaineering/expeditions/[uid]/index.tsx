import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, useLocation, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createExpeditionService } from 'climbedge-shared/services/ExpeditionService';
import type {
  GetExpeditionDTO,
  GetExpeditionParticipantDTO,
  GetExpeditionEquipmentDTO,
  GetSafetyPlanDTO,
  GetDebriefDTO,
  GetItineraryDayTrackDTO,
  GetItineraryDayWaypointDTO,
} from 'climbedge-shared/types/ExpeditionDTO';
import { ExpeditionStatus } from 'climbedge-shared/types/ExpeditionDTO';

const STATUS_LABELS: Record<number, string> = {
  [ExpeditionStatus.Draft]: 'Borrador',
  [ExpeditionStatus.Active]: 'Activa',
  [ExpeditionStatus.InProgress]: 'En progreso',
  [ExpeditionStatus.Completed]: 'Completada',
  [ExpeditionStatus.Cancelled]: 'Cancelada',
};

const STATUS_COLORS: Record<number, string> = {
  [ExpeditionStatus.Draft]: 'bg-yellow-100 dark:bg-yellow-900/30 text-yellow-700 dark:text-yellow-300',
  [ExpeditionStatus.Active]: 'bg-emerald-100 dark:bg-emerald-900/30 text-emerald-700 dark:text-emerald-300',
  [ExpeditionStatus.InProgress]: 'bg-blue-100 dark:bg-blue-900/30 text-blue-700 dark:text-blue-300',
  [ExpeditionStatus.Completed]: 'bg-gray-100 dark:bg-gray-800 text-gray-600 dark:text-gray-400',
  [ExpeditionStatus.Cancelled]: 'bg-red-100 dark:bg-red-900/30 text-red-700 dark:text-red-300',
};

type DetailTab = 'overview' | 'participants' | 'equipment' | 'budget' | 'itinerary' | 'safety' | 'tracks' | 'debrief';

export default component$(() => {
  const location = useLocation();
  const uid = location.params['uid'];

  const expedition = useSignal<GetExpeditionDTO | null>(null);
  const participants = useSignal<GetExpeditionParticipantDTO[]>([]);
  const equipment = useSignal<GetExpeditionEquipmentDTO[]>([]);
  const budget = useSignal<unknown>(null);
  const itinerary = useSignal<unknown>(null);
  const loading = useSignal(true);
  const error = useSignal('');
  const activeTab = useSignal<DetailTab>('overview');
  const tabLoaded = useSignal<Set<DetailTab>>(new Set(['overview']));
  const activating = useSignal(false);
  const closing = useSignal(false);

  // Safety plan
  const safetyPlan = useSignal<GetSafetyPlanDTO | null>(null);
  const showSafetyForm = useSignal(false);
  const spEmergencyName = useSignal('');
  const spEmergencyPhone = useSignal('');
  const spLocalRescue = useSignal('');
  const spEvacuationPlan = useSignal('');
  const savingSafety = useSignal(false);

  // Debrief
  const debrief = useSignal<GetDebriefDTO | null>(null);

  // Day tracks
  const selectedDayId = useSignal<number | null>(null);
  const dayTracks = useSignal<GetItineraryDayTrackDTO[]>([]);
  const dayWaypoints = useSignal<GetItineraryDayWaypointDTO[]>([]);
  const tracksLoading = useSignal(false);
  const showTrackForm = useSignal(false);
  const newTrackName = useSignal('');
  const newTrackWkt = useSignal('');
  const newTrackDevice = useSignal('');
  const savingTrack = useSignal(false);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl || !uid) { loading.value = false; return; }

    const svc = createExpeditionService(config);
    const res = await svc.getByUid(uid);

    if (!res.success || !res.data) {
      error.value = res.error ?? 'Expedición no encontrada';
      loading.value = false;
      return;
    }

    expedition.value = res.data;

    // Load participants immediately
    const partRes = await svc.getParticipants(res.data.id);
    if (partRes.success && partRes.data) participants.value = partRes.data;

    loading.value = false;
  });

  const loadTabData = $(async (tab: DetailTab) => {
    activeTab.value = tab;
    if (tabLoaded.value.has(tab) || !expedition.value) return;

    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const id = expedition.value.id;

    if (tab === 'participants') {
      const res = await svc.getParticipants(id);
      if (res.success && res.data) participants.value = res.data;
    } else if (tab === 'equipment') {
      const res = await svc.getEquipment(id);
      if (res.success && res.data) equipment.value = res.data;
    } else if (tab === 'budget') {
      const res = await svc.getBudget(id);
      if (res.success) budget.value = res.data;
    } else if (tab === 'itinerary') {
      const res = await svc.getItinerary(id);
      if (res.success) itinerary.value = res.data;
    } else if (tab === 'safety') {
      const res = await svc.getSafetyPlan(id);
      if (res.success && res.data) {
        safetyPlan.value = res.data;
        spEmergencyName.value = res.data.emergencyContactName ?? '';
        spEmergencyPhone.value = res.data.emergencyContactPhone ?? '';
        spLocalRescue.value = res.data.localRescueService ?? '';
        spEvacuationPlan.value = res.data.evacuationPlan ?? '';
      }
    } else if (tab === 'tracks') {
      // tracks loaded on demand when dayId selected
    } else if (tab === 'debrief') {
      const res = await svc.getDebrief(id);
      if (res.success && res.data) debrief.value = res.data;
    }

    tabLoaded.value = new Set([...tabLoaded.value, tab]);
  });

  const activateExpedition = $(async () => {
    if (!expedition.value) return;
    activating.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const res = await svc.activate(expedition.value.uid);
    activating.value = false;
    if (res.success) {
      expedition.value = { ...expedition.value, status: ExpeditionStatus.Active };
    }
  });

  const closeExpedition = $(async () => {
    if (!expedition.value) return;
    closing.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const res = await svc.close(expedition.value.uid);
    closing.value = false;
    if (res.success) {
      expedition.value = { ...expedition.value, status: ExpeditionStatus.Completed };
    }
  });

  const saveSafetyPlan = $(async () => {
    if (!expedition.value) return;
    savingSafety.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const data = {
      expeditionId: expedition.value.id,
      emergencyContactName: spEmergencyName.value.trim() || undefined,
      emergencyContactPhone: spEmergencyPhone.value.trim() || undefined,
      localRescueService: spLocalRescue.value.trim() || undefined,
      evacuationPlan: spEvacuationPlan.value.trim() || undefined,
    };
    const res = safetyPlan.value
      ? await svc.updateSafetyPlan(expedition.value.id, data)
      : await svc.createSafetyPlan(data);
    savingSafety.value = false;
    if (res.success && res.data) {
      safetyPlan.value = res.data;
      showSafetyForm.value = false;
    }
  });

  const loadDayTracks = $(async (dayId: number) => {
    selectedDayId.value = dayId;
    tracksLoading.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const [tracksRes, waypointsRes] = await Promise.all([
      svc.getItineraryDayTracks(dayId),
      svc.getItineraryDayWaypoints(dayId),
    ]);
    if (tracksRes.success && tracksRes.data) dayTracks.value = tracksRes.data;
    if (waypointsRes.success && waypointsRes.data) dayWaypoints.value = waypointsRes.data;
    tracksLoading.value = false;
  });

  const createDayTrack = $(async () => {
    if (!newTrackName.value.trim() || !newTrackWkt.value.trim() || selectedDayId.value == null) return;
    savingTrack.value = true;
    const config = getServiceConfig();
    const svc = createExpeditionService(config);
    const res = await svc.createItineraryDayTrack({
      itineraryDayId: selectedDayId.value,
      name: newTrackName.value.trim(),
      trackDataWkt: newTrackWkt.value.trim(),
      gpsDevice: newTrackDevice.value.trim() || undefined,
    });
    savingTrack.value = false;
    if (res.success && res.data) {
      dayTracks.value = [...dayTracks.value, res.data];
      newTrackName.value = '';
      newTrackWkt.value = '';
      newTrackDevice.value = '';
      showTrackForm.value = false;
    }
  });

  if (loading.value) {
    return (
      <div class="p-6 flex justify-center items-center min-h-64">
        <div class="animate-spin rounded-full h-10 w-10 border-b-2 border-emerald-600" />
      </div>
    );
  }

  if (error.value || !expedition.value) {
    return (
      <div class="p-6">
        <div class="bg-red-50 dark:bg-red-900/20 text-red-700 dark:text-red-300 rounded-xl p-4">
          {error.value || 'Expedición no encontrada'}
        </div>
        <Link href="/mountaineering" class="mt-4 inline-block text-sm text-emerald-600 hover:underline">← Volver</Link>
      </div>
    );
  }

  const exp = expedition.value;
  const detailTabs: { id: DetailTab; label: string }[] = [
    { id: 'overview', label: 'Resumen' },
    { id: 'participants', label: `Participantes (${participants.value.length})` },
    { id: 'equipment', label: 'Equipamiento' },
    { id: 'budget', label: 'Presupuesto' },
    { id: 'itinerary', label: 'Itinerario' },
    { id: 'safety', label: 'Plan de Seguridad' },
    { id: 'tracks', label: 'Tracks GPS' },
    { id: 'debrief', label: 'Debrief' },
  ];

  return (
    <div class="p-6 max-w-5xl mx-auto">
      {/* Breadcrumb */}
      <nav class="text-sm text-gray-500 dark:text-gray-400 mb-4">
        <Link href="/mountaineering" class="hover:text-emerald-600">Montañismo</Link>
        <span class="mx-2">›</span>
        <span class="text-gray-900 dark:text-white">{exp.name}</span>
      </nav>

      {/* Header */}
      <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-6 mb-6">
        <div class="flex flex-col sm:flex-row sm:items-start justify-between gap-4">
          <div>
            <div class="flex items-center gap-3 flex-wrap">
              <h1 class="text-2xl font-bold text-gray-900 dark:text-white">{exp.name}</h1>
              {exp.status != null && (
                <span class={`text-xs px-2.5 py-1 rounded-full font-medium ${STATUS_COLORS[exp.status] ?? ''}`}>
                  {STATUS_LABELS[exp.status] ?? ''}
                </span>
              )}
            </div>
            <div class="flex flex-wrap gap-4 mt-2 text-sm text-gray-500 dark:text-gray-400">
              {exp.startDate && <span>Inicio: {new Date(exp.startDate).toLocaleDateString('es')}</span>}
              {exp.endDate && <span>Fin: {new Date(exp.endDate).toLocaleDateString('es')}</span>}
            </div>
            {exp.description && (
              <p class="mt-3 text-gray-600 dark:text-gray-400 text-sm">{exp.description}</p>
            )}
          </div>

          {/* Actions */}
          <div class="flex gap-2 flex-shrink-0">
            {exp.status === ExpeditionStatus.Draft && (
              <button
                onClick$={activateExpedition}
                disabled={activating.value}
                class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-xs font-medium rounded-lg transition-colors"
              >
                {activating.value ? 'Activando...' : 'Activar'}
              </button>
            )}
            {exp.status === ExpeditionStatus.Active && (
              <button
                onClick$={closeExpedition}
                disabled={closing.value}
                class="px-3 py-1.5 bg-gray-600 hover:bg-gray-700 disabled:opacity-50 text-white text-xs font-medium rounded-lg transition-colors"
              >
                {closing.value ? 'Cerrando...' : 'Cerrar expedición'}
              </button>
            )}
          </div>
        </div>
      </div>

      {/* Detail tabs */}
      <div class="border-b border-gray-200 dark:border-slate-700 mb-6">
        <nav class="-mb-px flex space-x-6 overflow-x-auto">
          {detailTabs.map(tab => (
            <button
              key={tab.id}
              onClick$={() => loadTabData(tab.id)}
              class={`py-3 px-1 border-b-2 text-sm font-medium whitespace-nowrap transition-colors ${
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

      {/* Overview */}
      {activeTab.value === 'overview' && (
        <div class="grid grid-cols-1 sm:grid-cols-3 gap-4">
          <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 text-center">
            <p class="text-3xl font-bold text-gray-900 dark:text-white">{participants.value.length}</p>
            <p class="text-sm text-gray-500 dark:text-gray-400 mt-1">Participantes</p>
          </div>
          <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 text-center">
            <p class="text-3xl font-bold text-gray-900 dark:text-white">{equipment.value.length}</p>
            <p class="text-sm text-gray-500 dark:text-gray-400 mt-1">Equipos registrados</p>
          </div>
          <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 text-center">
            <p class="text-sm font-medium text-gray-900 dark:text-white mt-2">
              {exp.status != null ? STATUS_LABELS[exp.status] : '—'}
            </p>
            <p class="text-sm text-gray-500 dark:text-gray-400 mt-1">Estado</p>
          </div>
        </div>
      )}

      {/* Participants */}
      {activeTab.value === 'participants' && (
        <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700">
          {participants.value.length === 0 ? (
            <div class="text-center py-12">
              <p class="text-gray-500 dark:text-gray-400 text-sm">Sin participantes</p>
            </div>
          ) : (
            <div class="divide-y divide-gray-100 dark:divide-slate-700">
              {participants.value.map(p => (
                <div key={p.uid} class="flex items-center gap-4 p-4">
                  <div class="w-9 h-9 bg-purple-100 dark:bg-purple-900/30 rounded-full flex items-center justify-center text-xs font-medium text-purple-600">
                    {p.userId?.toString().slice(0, 2)}
                  </div>
                  <div>
                    <p class="text-sm font-medium text-gray-900 dark:text-white">Usuario {p.userId}</p>
                    <p class="text-xs text-gray-500 dark:text-gray-400 capitalize">
                      {['Miembro', 'Líder', 'Médico', 'Guía'][p.role] ?? 'Participante'}
                    </p>
                  </div>
                  <div class="ml-auto">
                    <span class={`text-xs px-2 py-0.5 rounded-full ${p.status === 1 ? 'bg-emerald-100 dark:bg-emerald-900/30 text-emerald-700 dark:text-emerald-300' : 'bg-yellow-100 dark:bg-yellow-900/30 text-yellow-700 dark:text-yellow-300'}`}>
                      {p.status === 1 ? 'Confirmado' : 'Pendiente'}
                    </span>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}

      {/* Equipment */}
      {activeTab.value === 'equipment' && (
        <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700">
          {equipment.value.length === 0 ? (
            <div class="text-center py-12">
              <p class="text-gray-500 dark:text-gray-400 text-sm">Sin equipamiento registrado</p>
            </div>
          ) : (
            <div class="divide-y divide-gray-100 dark:divide-slate-700">
              {equipment.value.map(eq => (
                <div key={eq.uid} class="flex items-center gap-4 p-4">
                  <div>
                    <p class="text-sm font-medium text-gray-900 dark:text-white">{eq.equipmentName}</p>
                    {eq.quantity != null && (
                      <p class="text-xs text-gray-500 dark:text-gray-400">Cantidad: {eq.quantity}</p>
                    )}
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}

      {/* Budget & Itinerary */}
      {(activeTab.value === 'budget' || activeTab.value === 'itinerary') && (
        <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700">
          <p class="text-gray-500 dark:text-gray-400 text-sm">
            {activeTab.value === 'budget' ? 'Gestión de presupuesto próximamente' : 'Itinerario próximamente'}
          </p>
        </div>
      )}

      {/* ─── SAFETY PLAN TAB ─────────────────────────────────────────── */}
      {activeTab.value === 'safety' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Plan de Seguridad</h2>
            <button
              onClick$={() => { showSafetyForm.value = !showSafetyForm.value; }}
              class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
            >
              {safetyPlan.value ? 'Editar' : 'Crear'}
            </button>
          </div>

          {showSafetyForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
              <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                <input
                  type="text"
                  placeholder="Contacto de emergencia"
                  value={spEmergencyName.value}
                  onInput$={(e) => { spEmergencyName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Teléfono de emergencia"
                  value={spEmergencyPhone.value}
                  onInput$={(e) => { spEmergencyPhone.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Servicio de rescate local"
                  value={spLocalRescue.value}
                  onInput$={(e) => { spLocalRescue.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <textarea
                  placeholder="Plan de evacuación"
                  value={spEvacuationPlan.value}
                  onInput$={(e) => { spEvacuationPlan.value = (e.target as HTMLTextAreaElement).value; }}
                  rows={3}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500 resize-none"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showSafetyForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={saveSafetyPlan}
                  disabled={savingSafety.value}
                  class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
                >
                  {savingSafety.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {!safetyPlan.value && !showSafetyForm.value ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">No hay plan de seguridad registrado</p>
            </div>
          ) : safetyPlan.value ? (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5">
              <dl class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                {safetyPlan.value.emergencyContactName && (
                  <div>
                    <dt class="text-xs text-gray-500 dark:text-gray-400 mb-1">Contacto de emergencia</dt>
                    <dd class="text-sm font-medium text-gray-900 dark:text-white">{safetyPlan.value.emergencyContactName}</dd>
                  </div>
                )}
                {safetyPlan.value.emergencyContactPhone && (
                  <div>
                    <dt class="text-xs text-gray-500 dark:text-gray-400 mb-1">Teléfono</dt>
                    <dd class="text-sm font-medium text-gray-900 dark:text-white">{safetyPlan.value.emergencyContactPhone}</dd>
                  </div>
                )}
                {safetyPlan.value.localRescueService && (
                  <div class="sm:col-span-2">
                    <dt class="text-xs text-gray-500 dark:text-gray-400 mb-1">Servicio de rescate</dt>
                    <dd class="text-sm text-gray-900 dark:text-white">{safetyPlan.value.localRescueService}</dd>
                  </div>
                )}
                {safetyPlan.value.evacuationPlan && (
                  <div class="sm:col-span-2">
                    <dt class="text-xs text-gray-500 dark:text-gray-400 mb-1">Plan de evacuación</dt>
                    <dd class="text-sm text-gray-900 dark:text-white whitespace-pre-wrap">{safetyPlan.value.evacuationPlan}</dd>
                  </div>
                )}
              </dl>
            </div>
          ) : null}
        </div>
      )}

      {/* ─── TRACKS TAB ─────────────────────────────────────────────── */}
      {activeTab.value === 'tracks' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Tracks GPS del Itinerario</h2>
          </div>

          <div class="mb-4 flex items-center gap-3">
            <label class="text-sm text-gray-600 dark:text-gray-400 font-medium">ID día:</label>
            <input
              type="number"
              placeholder="ID del día de itinerario"
              onBlur$={async (e) => {
                const val = parseInt((e.target as HTMLInputElement).value);
                if (!isNaN(val)) await loadDayTracks(val);
              }}
              class="w-36 px-3 py-1.5 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
            />
          </div>

          {selectedDayId.value != null && (
            <div class="flex items-center justify-between mb-4">
              <p class="text-sm text-gray-500 dark:text-gray-400">Día #{selectedDayId.value}</p>
              <button
                onClick$={() => { showTrackForm.value = !showTrackForm.value; }}
                class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
              >
                <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
                </svg>
                Agregar track
              </button>
            </div>
          )}

          {showTrackForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
              <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                <input
                  type="text"
                  placeholder="Nombre del track *"
                  value={newTrackName.value}
                  onInput$={(e) => { newTrackName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Dispositivo GPS (opcional)"
                  value={newTrackDevice.value}
                  onInput$={(e) => { newTrackDevice.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="WKT: LINESTRING(lon lat, ...) *"
                  value={newTrackWkt.value}
                  onInput$={(e) => { newTrackWkt.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showTrackForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createDayTrack}
                  disabled={savingTrack.value || !newTrackName.value.trim() || !newTrackWkt.value.trim()}
                  class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
                >
                  {savingTrack.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {tracksLoading.value ? (
            <div class="flex justify-center py-10"><div class="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600" /></div>
          ) : selectedDayId.value == null ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">Ingresa el ID de un día de itinerario para cargar sus tracks</p>
            </div>
          ) : dayTracks.value.length === 0 && dayWaypoints.value.length === 0 ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">No hay tracks ni waypoints en este día</p>
            </div>
          ) : (
            <div class="space-y-4">
              {dayTracks.value.length > 0 && (
                <div>
                  <h3 class="text-sm font-semibold text-gray-700 dark:text-gray-300 mb-2">Tracks ({dayTracks.value.length})</h3>
                  <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
                    {dayTracks.value.map(track => (
                      <div key={track.uid} class="flex items-start gap-4 p-4">
                        <div class="w-9 h-9 bg-teal-100 dark:bg-teal-900/30 rounded-lg flex items-center justify-center flex-shrink-0">
                          <svg class="w-4 h-4 text-teal-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 20l-5.447-2.724A1 1 0 013 16.382V5.618a1 1 0 011.447-.894L9 7m0 13l6-3m-6 3V7m6 10l4.553 2.276A1 1 0 0021 18.382V7.618a1 1 0 00-.553-.894L15 4m0 13V4m0 0L9 7" />
                          </svg>
                        </div>
                        <div class="flex-1">
                          <p class="font-medium text-gray-900 dark:text-white">{track.name}</p>
                          <div class="flex gap-3 mt-1 text-xs text-gray-400 dark:text-gray-500">
                            {track.totalDistance != null && <span>{track.totalDistance} km</span>}
                            {track.gpsDevice && <span>📡 {track.gpsDevice}</span>}
                          </div>
                        </div>
                      </div>
                    ))}
                  </div>
                </div>
              )}
              {dayWaypoints.value.length > 0 && (
                <div>
                  <h3 class="text-sm font-semibold text-gray-700 dark:text-gray-300 mb-2">Waypoints ({dayWaypoints.value.length})</h3>
                  <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
                    {dayWaypoints.value.map(wp => (
                      <div key={wp.uid} class="flex items-start gap-4 p-4">
                        <div class="w-8 h-8 bg-purple-100 dark:bg-purple-900/30 rounded-full flex items-center justify-center flex-shrink-0">
                          <svg class="w-4 h-4 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" /><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" /></svg>
                        </div>
                        <div class="flex-1">
                          <p class="font-medium text-gray-900 dark:text-white">{wp.name}</p>
                          {wp.notes && <p class="text-xs text-gray-400 dark:text-gray-500 italic mt-0.5">{wp.notes}</p>}
                        </div>
                      </div>
                    ))}
                  </div>
                </div>
              )}
            </div>
          )}
        </div>
      )}

      {/* ─── DEBRIEF TAB ─────────────────────────────────────────────── */}
      {activeTab.value === 'debrief' && (
        <div>
          <h2 class="text-lg font-semibold text-gray-900 dark:text-white mb-4">Debrief de la Expedición</h2>
          {!debrief.value ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">No hay debrief registrado para esta expedición</p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 space-y-4">
              {debrief.value.date && (
                <p class="text-xs text-gray-500 dark:text-gray-400">{new Date(debrief.value.date).toLocaleDateString('es')}</p>
              )}
              {debrief.value.technicalNotes && (
                <div>
                  <h3 class="text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wide mb-1">Notas técnicas</h3>
                  <p class="text-sm text-gray-900 dark:text-white whitespace-pre-wrap">{debrief.value.technicalNotes}</p>
                </div>
              )}
              {debrief.value.teamNotes && (
                <div>
                  <h3 class="text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wide mb-1">Notas del equipo</h3>
                  <p class="text-sm text-gray-900 dark:text-white whitespace-pre-wrap">{debrief.value.teamNotes}</p>
                </div>
              )}
              {debrief.value.equipmentNotes && (
                <div>
                  <h3 class="text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wide mb-1">Notas de equipamiento</h3>
                  <p class="text-sm text-gray-900 dark:text-white whitespace-pre-wrap">{debrief.value.equipmentNotes}</p>
                </div>
              )}
              {debrief.value.recommendations && (
                <div>
                  <h3 class="text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wide mb-1">Recomendaciones</h3>
                  <p class="text-sm text-gray-900 dark:text-white whitespace-pre-wrap">{debrief.value.recommendations}</p>
                </div>
              )}
            </div>
          )}
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Expedición — ClimbEdge',
};
