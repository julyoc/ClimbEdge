import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, useLocation, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createMountainService } from 'climbedge-shared/services/MountainService';
import type {
  GetMountainDTO,
  GetMountainRouteDTO,
  GetRouteTrackDTO,
  GetRouteWaypointDTO,
  GetWeatherConditionDTO,
} from 'climbedge-shared/types/MountainDTO';
import { MountainType, RouteType } from 'climbedge-shared/types/MountainDTO';

const MOUNTAIN_TYPE_LABELS: Record<number, string> = {
  [MountainType.Mountain]: 'MontaÃ±a',
  [MountainType.Volcano]: 'VolcÃ¡n',
  [MountainType.Peak]: 'Pico',
  [MountainType.Ridge]: 'Cresta',
  [MountainType.Other]: 'Otro',
};

const ROUTE_TYPE_LABELS: Record<number, string> = {
  [RouteType.Normal]: 'Normal',
  [RouteType.Technical]: 'TÃ©cnico',
  [RouteType.Alpine]: 'Alpino',
  [RouteType.Ice]: 'Hielo',
  [RouteType.Mixed]: 'Mixto',
};

type MountainTab = 'routes' | 'tracks' | 'waypoints' | 'weather';

export default component$(() => {
  const location = useLocation();
  const uid = location.params['uid'];

  const mountain = useSignal<GetMountainDTO | null>(null);
  const routes = useSignal<GetMountainRouteDTO[]>([]);
  const loading = useSignal(true);
  const error = useSignal('');

  const activeTab = useSignal<MountainTab>('routes');

  // Selected route for tracks/waypoints
  const selectedRouteId = useSignal<number | null>(null);

  // Tracks
  const tracks = useSignal<GetRouteTrackDTO[]>([]);
  const tracksLoading = useSignal(false);
  const showTrackForm = useSignal(false);
  const newTrackName = useSignal('');
  const newTrackWkt = useSignal('');
  const newTrackDevice = useSignal('');
  const newTrackDist = useSignal('');
  const savingTrack = useSignal(false);

  // Waypoints
  const waypoints = useSignal<GetRouteWaypointDTO[]>([]);
  const waypointsLoading = useSignal(false);
  const showWaypointForm = useSignal(false);
  const newWpName = useSignal('');
  const newWpWkt = useSignal('');
  const newWpSeq = useSignal('');
  const newWpNotes = useSignal('');
  const savingWaypoint = useSignal(false);

  // Weather
  const weather = useSignal<GetWeatherConditionDTO[]>([]);
  const weatherLoading = useSignal(false);
  const showWeatherForm = useSignal(false);
  const newWxTemp = useSignal('');
  const newWxWind = useSignal('');
  const newWxCondition = useSignal('');
  const newWxRecordedAt = useSignal(new Date().toISOString().slice(0, 16));
  const savingWeather = useSignal(false);

  // Add route form
  const showRouteForm = useSignal(false);
  const newRouteName = useSignal('');
  const newRouteDesc = useSignal('');
  const savingRoute = useSignal(false);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl || !uid) { loading.value = false; return; }

    const svc = createMountainService(config);
    const mtnRes = await svc.getByUid(uid);

    if (!mtnRes.success || !mtnRes.data) {
      error.value = mtnRes.error ?? 'MontaÃ±a no encontrada';
      loading.value = false;
      return;
    }

    mountain.value = mtnRes.data;
    const routesRes = await svc.getRoutes(mtnRes.data.id);
    if (routesRes.success && routesRes.data) {
      routes.value = routesRes.data;
      if (routesRes.data.length > 0) selectedRouteId.value = routesRes.data[0].id;
    }
    loading.value = false;
  });

  const loadTabData = $(async (tab: MountainTab) => {
    activeTab.value = tab;
    if (!mountain.value) return;

    const config = getServiceConfig();
    const svc = createMountainService(config);
    const routeId = selectedRouteId.value;

    if (tab === 'tracks' && routeId != null) {
      tracksLoading.value = true;
      const res = await svc.getRouteTracks(routeId);
      if (res.success && res.data) tracks.value = res.data;
      tracksLoading.value = false;
    } else if (tab === 'waypoints' && routeId != null) {
      waypointsLoading.value = true;
      const res = await svc.getRouteWaypoints(routeId);
      if (res.success && res.data) waypoints.value = res.data;
      waypointsLoading.value = false;
    } else if (tab === 'weather') {
      weatherLoading.value = true;
      const res = await svc.getWeatherConditions(mountain.value.id);
      if (res.success && res.data) weather.value = res.data;
      weatherLoading.value = false;
    }
  });

  const reloadCurrentRoute = $(async () => {
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const routeId = selectedRouteId.value;
    if (routeId == null) return;
    if (activeTab.value === 'tracks') {
      tracksLoading.value = true;
      const res = await svc.getRouteTracks(routeId);
      if (res.success && res.data) tracks.value = res.data;
      tracksLoading.value = false;
    } else if (activeTab.value === 'waypoints') {
      waypointsLoading.value = true;
      const res = await svc.getRouteWaypoints(routeId);
      if (res.success && res.data) waypoints.value = res.data;
      waypointsLoading.value = false;
    }
  });

  const createRoute = $(async () => {
    if (!newRouteName.value.trim() || !mountain.value) return;
    savingRoute.value = true;
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const res = await svc.createRoute({
      mountainId: mountain.value.id,
      name: newRouteName.value.trim(),
      description: newRouteDesc.value.trim() || undefined,
      type: RouteType.Normal,
      difficultyScaleId: 1,
      distance: 0,
      estimatedDuration: 60,
      bestSeason: 1,
      requiresPermit: false,
      isGuided: false,
      dangerLevel: 1,
    });
    savingRoute.value = false;
    if (res.success && res.data) {
      routes.value = [...routes.value, res.data];
      if (!selectedRouteId.value) selectedRouteId.value = res.data.id;
      newRouteName.value = '';
      newRouteDesc.value = '';
      showRouteForm.value = false;
    }
  });

  const createTrack = $(async () => {
    if (!newTrackName.value.trim() || !newTrackWkt.value.trim() || selectedRouteId.value == null) return;
    savingTrack.value = true;
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const res = await svc.createRouteTrack({
      mountainRouteId: selectedRouteId.value,
      name: newTrackName.value.trim(),
      trackDataWkt: newTrackWkt.value.trim(),
      gpsDevice: newTrackDevice.value.trim() || undefined,
      totalDistance: newTrackDist.value ? parseFloat(newTrackDist.value) : undefined,
      recordedAt: new Date().toISOString(),
    });
    savingTrack.value = false;
    if (res.success && res.data) {
      tracks.value = [...tracks.value, res.data];
      newTrackName.value = '';
      newTrackWkt.value = '';
      newTrackDevice.value = '';
      newTrackDist.value = '';
      showTrackForm.value = false;
    }
  });

  const createWaypoint = $(async () => {
    if (!newWpName.value.trim() || !newWpWkt.value.trim() || selectedRouteId.value == null) return;
    savingWaypoint.value = true;
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const res = await svc.createRouteWaypoint({
      mountainRouteId: selectedRouteId.value,
      name: newWpName.value.trim(),
      locationWkt: newWpWkt.value.trim(),
      sequence: newWpSeq.value ? parseInt(newWpSeq.value) : waypoints.value.length + 1,
      notes: newWpNotes.value.trim() || undefined,
    });
    savingWaypoint.value = false;
    if (res.success && res.data) {
      waypoints.value = [...waypoints.value, res.data];
      newWpName.value = '';
      newWpWkt.value = '';
      newWpSeq.value = '';
      newWpNotes.value = '';
      showWaypointForm.value = false;
    }
  });

  const createWeather = $(async () => {
    if (!mountain.value) return;
    savingWeather.value = true;
    const config = getServiceConfig();
    const svc = createMountainService(config);
    const res = await svc.createWeatherCondition({
      mountainId: mountain.value.id,
      recordedAt: newWxRecordedAt.value ? new Date(newWxRecordedAt.value).toISOString() : new Date().toISOString(),
      temperature: newWxTemp.value ? parseFloat(newWxTemp.value) : undefined,
      windSpeed: newWxWind.value ? parseFloat(newWxWind.value) : undefined,
      condition: newWxCondition.value.trim() || undefined,
    });
    savingWeather.value = false;
    if (res.success && res.data) {
      weather.value = [res.data, ...weather.value];
      newWxTemp.value = '';
      newWxWind.value = '';
      newWxCondition.value = '';
      newWxRecordedAt.value = new Date().toISOString().slice(0, 16);
      showWeatherForm.value = false;
    }
  });

  if (loading.value) {
    return (
      <div class="p-6 flex justify-center items-center min-h-64">
        <div class="animate-spin rounded-full h-10 w-10 border-b-2 border-emerald-600" />
      </div>
    );
  }

  if (error.value || !mountain.value) {
    return (
      <div class="p-6">
        <div class="bg-red-50 dark:bg-red-900/20 text-red-700 dark:text-red-300 rounded-xl p-4">
          {error.value || 'MontaÃ±a no encontrada'}
        </div>
        <Link href="/mountaineering" class="mt-4 inline-block text-sm text-emerald-600 hover:underline">â† Volver a MontaÃ±ismo</Link>
      </div>
    );
  }

  const mtn = mountain.value;
  const tabs: { id: MountainTab; label: string }[] = [
    { id: 'routes', label: `Rutas (${routes.value.length})` },
    { id: 'tracks', label: 'Tracks GPS' },
    { id: 'waypoints', label: 'Waypoints' },
    { id: 'weather', label: 'Clima' },
  ];

  return (
    <div class="p-6 max-w-5xl mx-auto">
      {/* Breadcrumb */}
      <nav class="text-sm text-gray-500 dark:text-gray-400 mb-4">
        <Link href="/mountaineering" class="hover:text-emerald-600">MontaÃ±ismo</Link>
        <span class="mx-2">â€º</span>
        <span class="text-gray-900 dark:text-white">{mtn.name}</span>
      </nav>

      {/* Mountain card */}
      <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-6 mb-6">
        <div class="flex items-start gap-4">
          <div class="w-14 h-14 bg-orange-100 dark:bg-orange-900/30 rounded-xl flex items-center justify-center flex-shrink-0">
            <svg class="w-7 h-7 text-orange-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 17l4-8 4 4 3-5 5 9H3z" />
            </svg>
          </div>
          <div class="flex-1">
            <h1 class="text-2xl font-bold text-gray-900 dark:text-white">{mtn.name}</h1>
            <div class="flex flex-wrap gap-4 mt-2 text-sm text-gray-500 dark:text-gray-400">
              {mtn.country && <span>ðŸ“ {mtn.country}</span>}
              {mtn.elevation != null && <span>â¬† {mtn.elevation.toLocaleString()} m</span>}
              {mtn.type != null && (
                <span class="px-2 py-0.5 bg-orange-100 dark:bg-orange-900/30 text-orange-700 dark:text-orange-300 rounded-full text-xs font-medium">
                  {MOUNTAIN_TYPE_LABELS[mtn.type] ?? 'MontaÃ±a'}
                </span>
              )}
            </div>
            {mtn.description && (
              <p class="mt-3 text-gray-600 dark:text-gray-400 text-sm">{mtn.description}</p>
            )}
          </div>
        </div>
      </div>

      {/* Tabs */}
      <div class="border-b border-gray-200 dark:border-slate-700 mb-6">
        <nav class="-mb-px flex space-x-6 overflow-x-auto">
          {tabs.map(tab => (
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

      {/* Route selector for Tracks/Waypoints */}
      {(activeTab.value === 'tracks' || activeTab.value === 'waypoints') && routes.value.length > 0 && (
        <div class="mb-4 flex items-center gap-3">
          <label class="text-sm text-gray-600 dark:text-gray-400 font-medium">Ruta:</label>
          <select
            value={selectedRouteId.value ?? ''}
            onChange$={async (e) => {
              selectedRouteId.value = parseInt((e.target as HTMLSelectElement).value);
              await reloadCurrentRoute();
            }}
            class="px-3 py-1.5 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
          >
            {routes.value.map(r => (
              <option key={r.uid} value={r.id}>{r.name}</option>
            ))}
          </select>
        </div>
      )}

      {/* â”€â”€â”€ ROUTES TAB â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€ */}
      {activeTab.value === 'routes' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Rutas ({routes.value.length})</h2>
            <button
              onClick$={() => { showRouteForm.value = !showRouteForm.value; }}
              class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
            >
              <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Agregar ruta
            </button>
          </div>

          {showRouteForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
              <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                <input
                  type="text"
                  placeholder="Nombre de la ruta *"
                  value={newRouteName.value}
                  onInput$={(e) => { newRouteName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="DescripciÃ³n (opcional)"
                  value={newRouteDesc.value}
                  onInput$={(e) => { newRouteDesc.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showRouteForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createRoute}
                  disabled={savingRoute.value || !newRouteName.value.trim()}
                  class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
                >
                  {savingRoute.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {routes.value.length === 0 ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">No hay rutas registradas para esta montaÃ±a</p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
              {routes.value.map(route => (
                <div key={route.uid} class="flex items-start gap-4 p-4">
                  <div class="w-9 h-9 bg-blue-100 dark:bg-blue-900/30 rounded-lg flex items-center justify-center flex-shrink-0 mt-0.5">
                    <svg class="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 20l-5.447-2.724A1 1 0 013 16.382V5.618a1 1 0 011.447-.894L9 7m0 13l6-3m-6 3V7m6 10l4.553 2.276A1 1 0 0021 18.382V7.618a1 1 0 00-.553-.894L15 4m0 13V4m0 0L9 7" />
                    </svg>
                  </div>
                  <div class="flex-1">
                    <div class="flex items-center gap-2 flex-wrap">
                      <p class="font-medium text-gray-900 dark:text-white">{route.name}</p>
                      {route.type != null && (
                        <span class="text-xs px-2 py-0.5 bg-gray-100 dark:bg-slate-700 text-gray-500 dark:text-gray-400 rounded-full">
                          {ROUTE_TYPE_LABELS[route.type] ?? 'Ruta'}
                        </span>
                      )}
                      {route.dangerLevel != null && (
                        <span class="text-xs px-2 py-0.5 bg-orange-100 dark:bg-orange-900/30 text-orange-700 dark:text-orange-300 rounded-full font-medium">
                          Peligro {route.dangerLevel}
                        </span>
                      )}
                    </div>
                    {route.description && (
                      <p class="text-sm text-gray-500 dark:text-gray-400 mt-1">{route.description}</p>
                    )}
                    <div class="flex flex-wrap gap-3 mt-1 text-xs text-gray-400 dark:text-gray-500">
                      {route.distance > 0 && <span>{route.distance} km</span>}
                      {route.elevationGain != null && <span>â†‘ {route.elevationGain} m</span>}
                    </div>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}

      {/* â”€â”€â”€ TRACKS TAB â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€ */}
      {activeTab.value === 'tracks' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Tracks GPS</h2>
            {selectedRouteId.value != null && (
              <button
                onClick$={() => { showTrackForm.value = !showTrackForm.value; }}
                class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
              >
                <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
                </svg>
                Agregar track
              </button>
            )}
          </div>

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
                  type="number"
                  placeholder="Distancia (km)"
                  value={newTrackDist.value}
                  onInput$={(e) => { newTrackDist.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="WKT: LINESTRING(lon lat alt, ...) *"
                  value={newTrackWkt.value}
                  onInput$={(e) => { newTrackWkt.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showTrackForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createTrack}
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
          ) : tracks.value.length === 0 ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">
                {selectedRouteId.value == null ? 'Selecciona una ruta para ver sus tracks' : 'No hay tracks GPS para esta ruta'}
              </p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
              {tracks.value.map(track => (
                <div key={track.uid} class="flex items-start gap-4 p-4">
                  <div class="w-9 h-9 bg-teal-100 dark:bg-teal-900/30 rounded-lg flex items-center justify-center flex-shrink-0">
                    <svg class="w-4 h-4 text-teal-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 20l-5.447-2.724A1 1 0 013 16.382V5.618a1 1 0 011.447-.894L9 7m0 13l6-3m-6 3V7m6 10l4.553 2.276A1 1 0 0021 18.382V7.618a1 1 0 00-.553-.894L15 4m0 13V4m0 0L9 7" />
                    </svg>
                  </div>
                  <div class="flex-1">
                    <p class="font-medium text-gray-900 dark:text-white">{track.name}</p>
                    <div class="flex flex-wrap gap-3 mt-1 text-xs text-gray-400 dark:text-gray-500">
                      {track.totalDistance != null && <span>{track.totalDistance} km</span>}
                      {track.minElevation != null && <span>Min {track.minElevation} m</span>}
                      {track.maxElevation != null && <span>Max {track.maxElevation} m</span>}
                      {track.gpsDevice && <span>ðŸ“¡ {track.gpsDevice}</span>}
                      {track.recordedAt && <span>{new Date(track.recordedAt).toLocaleDateString('es')}</span>}
                    </div>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}

      {/* â”€â”€â”€ WAYPOINTS TAB â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€ */}
      {activeTab.value === 'waypoints' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Waypoints</h2>
            {selectedRouteId.value != null && (
              <button
                onClick$={() => { showWaypointForm.value = !showWaypointForm.value; }}
                class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
              >
                <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
                </svg>
                Agregar waypoint
              </button>
            )}
          </div>

          {showWaypointForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
              <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                <input
                  type="text"
                  placeholder="Nombre del waypoint *"
                  value={newWpName.value}
                  onInput$={(e) => { newWpName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="number"
                  placeholder="Secuencia"
                  value={newWpSeq.value}
                  onInput$={(e) => { newWpSeq.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="WKT: POINT(lon lat alt) *"
                  value={newWpWkt.value}
                  onInput$={(e) => { newWpWkt.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Notas (opcional)"
                  value={newWpNotes.value}
                  onInput$={(e) => { newWpNotes.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showWaypointForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createWaypoint}
                  disabled={savingWaypoint.value || !newWpName.value.trim() || !newWpWkt.value.trim()}
                  class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
                >
                  {savingWaypoint.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {waypointsLoading.value ? (
            <div class="flex justify-center py-10"><div class="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600" /></div>
          ) : waypoints.value.length === 0 ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">
                {selectedRouteId.value == null ? 'Selecciona una ruta para ver sus waypoints' : 'No hay waypoints para esta ruta'}
              </p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 divide-y divide-gray-100 dark:divide-slate-700">
              {waypoints.value.map(wp => (
                <div key={wp.uid} class="flex items-start gap-4 p-4">
                  <div class="w-8 h-8 bg-purple-100 dark:bg-purple-900/30 rounded-full flex items-center justify-center flex-shrink-0 text-xs font-bold text-purple-600">
                    {wp.sequence}
                  </div>
                  <div class="flex-1">
                    <p class="font-medium text-gray-900 dark:text-white">{wp.name}</p>
                    {wp.description && <p class="text-sm text-gray-500 dark:text-gray-400 mt-0.5">{wp.description}</p>}
                    {wp.notes && <p class="text-xs text-gray-400 dark:text-gray-500 mt-0.5 italic">{wp.notes}</p>}
                    {wp.locationWkt && (
                      <p class="text-xs text-gray-400 dark:text-gray-500 mt-0.5 font-mono">{wp.locationWkt}</p>
                    )}
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}

      {/* â”€â”€â”€ WEATHER TAB â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€ */}
      {activeTab.value === 'weather' && (
        <div>
          <div class="flex items-center justify-between mb-4">
            <h2 class="text-lg font-semibold text-gray-900 dark:text-white">Condiciones MeteorolÃ³gicas</h2>
            <button
              onClick$={() => { showWeatherForm.value = !showWeatherForm.value; }}
              class="flex items-center gap-2 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-medium rounded-lg transition-colors"
            >
              <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Registrar
            </button>
          </div>

          {showWeatherForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-4 mb-4">
              <div class="grid grid-cols-2 sm:grid-cols-4 gap-3">
                <input
                  type="datetime-local"
                  value={newWxRecordedAt.value}
                  onInput$={(e) => { newWxRecordedAt.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="CondiciÃ³n (ej: Soleado)"
                  value={newWxCondition.value}
                  onInput$={(e) => { newWxCondition.value = (e.target as HTMLInputElement).value; }}
                  class="sm:col-span-2 w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="number"
                  placeholder="Temp (Â°C)"
                  value={newWxTemp.value}
                  onInput$={(e) => { newWxTemp.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="number"
                  placeholder="Viento (km/h)"
                  value={newWxWind.value}
                  onInput$={(e) => { newWxWind.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-2 mt-3">
                <button onClick$={() => { showWeatherForm.value = false; }} class="px-3 py-1.5 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors">Cancelar</button>
                <button
                  onClick$={createWeather}
                  disabled={savingWeather.value}
                  class="px-3 py-1.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm rounded-lg transition-colors"
                >
                  {savingWeather.value ? 'Guardando...' : 'Guardar'}
                </button>
              </div>
            </div>
          )}

          {weatherLoading.value ? (
            <div class="flex justify-center py-10"><div class="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600" /></div>
          ) : weather.value.length === 0 ? (
            <div class="text-center py-12 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400 text-sm">No hay registros meteorolÃ³gicos</p>
            </div>
          ) : (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {weather.value.map(wx => (
                <div key={wx.uid} class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-4">
                  <div class="flex items-center justify-between mb-2">
                    <p class="text-xs text-gray-500 dark:text-gray-400">
                      {new Date(wx.recordedAt).toLocaleString('es', { dateStyle: 'short', timeStyle: 'short' })}
                    </p>
                    {wx.condition && (
                      <span class="text-xs px-2 py-0.5 bg-sky-100 dark:bg-sky-900/30 text-sky-700 dark:text-sky-300 rounded-full">{wx.condition}</span>
                    )}
                  </div>
                  <div class="grid grid-cols-2 gap-2 text-sm">
                    {wx.temperature != null && (
                      <div>
                        <p class="text-xs text-gray-400 dark:text-gray-500">Temperatura</p>
                        <p class="font-semibold text-gray-900 dark:text-white">{wx.temperature}Â°C</p>
                      </div>
                    )}
                    {wx.windSpeed != null && (
                      <div>
                        <p class="text-xs text-gray-400 dark:text-gray-500">Viento</p>
                        <p class="font-semibold text-gray-900 dark:text-white">{wx.windSpeed} km/h</p>
                      </div>
                    )}
                    {wx.humidity != null && (
                      <div>
                        <p class="text-xs text-gray-400 dark:text-gray-500">Humedad</p>
                        <p class="font-semibold text-gray-900 dark:text-white">{wx.humidity}%</p>
                      </div>
                    )}
                    {wx.snowDepth != null && (
                      <div>
                        <p class="text-xs text-gray-400 dark:text-gray-500">Nieve</p>
                        <p class="font-semibold text-gray-900 dark:text-white">{wx.snowDepth} cm</p>
                      </div>
                    )}
                  </div>
                  {wx.dataSource && (
                    <p class="text-xs text-gray-400 dark:text-gray-500 mt-2">Fuente: {wx.dataSource}</p>
                  )}
                </div>
              ))}
            </div>
          )}
        </div>
      )}
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Montana - ClimbEdge',
};
