import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createBoardService } from 'climbedge-shared/services/BoardService';
import { createClimbRouteService } from 'climbedge-shared/services/ClimbRouteService';
import { createClimbZoneService } from 'climbedge-shared/services/ClimbZoneService';
import type { GetBoardDTO } from 'climbedge-shared/types/BoardDTO';
import type { GetClimbRouteDTO } from 'climbedge-shared/types/ClimbRouteDTO';
import type { GetClimbZoneDTO } from 'climbedge-shared/types/ClimbZoneDTO';
import { BoardVisibility } from 'climbedge-shared/types/BoardDTO';

type Tab = 'boards' | 'routes' | 'zones';

export default component$(() => {
  const activeTab = useSignal<Tab>('boards');

  // Boards
  const boards = useSignal<GetBoardDTO[]>([]);
  const boardsLoading = useSignal(true);
  const showBoardForm = useSignal(false);
  const newBoardName = useSignal('');
  const newBoardDesc = useSignal('');
  const boardSaving = useSignal(false);
  const boardError = useSignal('');

  // Routes
  const routes = useSignal<GetClimbRouteDTO[]>([]);
  const routesLoading = useSignal(true);

  // Zones
  const zones = useSignal<GetClimbZoneDTO[]>([]);
  const zonesLoading = useSignal(true);
  const showZoneForm = useSignal(false);
  const newZoneName = useSignal('');
  const newZoneLocation = useSignal('');
  const zoneSaving = useSignal(false);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl) return;

    const boardSvc = createBoardService(config);
    const routeSvc = createClimbRouteService(config);
    const zoneSvc = createClimbZoneService(config);

    const [boardRes, routeRes, zoneRes] = await Promise.all([
      boardSvc.getAll(),
      routeSvc.getAll(),
      zoneSvc.getAll(),
    ]);

    if (boardRes.success && boardRes.data) boards.value = boardRes.data;
    boardsLoading.value = false;

    if (routeRes.success && routeRes.data) routes.value = routeRes.data;
    routesLoading.value = false;

    if (zoneRes.success && zoneRes.data) zones.value = zoneRes.data;
    zonesLoading.value = false;
  });

  const createBoard = $(async () => {
    if (!newBoardName.value.trim()) return;
    boardSaving.value = true;
    boardError.value = '';
    const config = getServiceConfig();
    const svc = createBoardService(config);
    const res = await svc.create({
      name: newBoardName.value.trim(),
      description: newBoardDesc.value.trim() || undefined,
      visibility: BoardVisibility.Private,
      boardConfigId: 1,
    });
    boardSaving.value = false;
    if (res.success && res.data) {
      boards.value = [res.data, ...boards.value];
      newBoardName.value = '';
      newBoardDesc.value = '';
      showBoardForm.value = false;
    } else {
      boardError.value = res.error ?? 'Error al crear el board';
    }
  });

  const createZone = $(async () => {
    if (!newZoneName.value.trim()) return;
    zoneSaving.value = true;
    const config = getServiceConfig();
    const svc = createClimbZoneService(config);
    const res = await svc.create({
      name: newZoneName.value.trim(),
      isPublic: true,
      isIndoor: false,
    });
    zoneSaving.value = false;
    if (res.success && res.data) {
      zones.value = [res.data, ...zones.value];
      newZoneName.value = '';
      newZoneLocation.value = '';
      showZoneForm.value = false;
    }
  });

  const tabs: { id: Tab; label: string }[] = [
    { id: 'boards', label: 'Boards' },
    { id: 'routes', label: 'Rutas' },
    { id: 'zones', label: 'Zonas' },
  ];

  return (
    <div class="p-6 max-w-7xl mx-auto">
      {/* Header */}
      <div class="flex items-center justify-between mb-6">
        <div>
          <h1 class="text-2xl font-bold text-gray-900 dark:text-white">Escalada</h1>
          <p class="text-gray-500 dark:text-gray-400 text-sm mt-1">Gestiona tus boards, rutas y zonas de escalada</p>
        </div>
      </div>

      {/* Tabs */}
      <div class="border-b border-gray-200 dark:border-slate-700 mb-6">
        <nav class="-mb-px flex space-x-8">
          {tabs.map(tab => (
            <button
              key={tab.id}
              onClick$={() => { activeTab.value = tab.id; }}
              class={`py-3 px-1 border-b-2 text-sm font-medium transition-colors ${
                activeTab.value === tab.id
                  ? 'border-emerald-500 text-emerald-600 dark:text-emerald-400'
                  : 'border-transparent text-gray-500 dark:text-gray-400 hover:text-gray-700 dark:hover:text-gray-300 hover:border-gray-300'
              }`}
            >
              {tab.label}
            </button>
          ))}
        </nav>
      </div>

      {/* BOARDS TAB */}
      {activeTab.value === 'boards' && (
        <div>
          <div class="flex justify-end mb-4">
            <button
              onClick$={() => { showBoardForm.value = !showBoardForm.value; }}
              class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Nuevo Board
            </button>
          </div>

          {showBoardForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-5 mb-6">
              <h3 class="text-sm font-semibold text-gray-900 dark:text-white mb-4">Crear nuevo board</h3>
              <div class="space-y-3">
                <input
                  type="text"
                  placeholder="Nombre del board *"
                  value={newBoardName.value}
                  onInput$={(e) => { newBoardName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Descripción (opcional)"
                  value={newBoardDesc.value}
                  onInput$={(e) => { newBoardDesc.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                {boardError.value && (
                  <p class="text-red-500 text-xs">{boardError.value}</p>
                )}
              </div>
              <div class="flex justify-end gap-3 mt-4">
                <button
                  onClick$={() => { showBoardForm.value = false; boardError.value = ''; }}
                  class="px-4 py-2 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 dark:hover:text-white transition-colors"
                >
                  Cancelar
                </button>
                <button
                  onClick$={createBoard}
                  disabled={boardSaving.value || !newBoardName.value.trim()}
                  class="px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
                >
                  {boardSaving.value ? 'Creando...' : 'Crear board'}
                </button>
              </div>
            </div>
          )}

          {boardsLoading.value ? (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {[1, 2, 3].map(i => (
                <div key={i} class="h-40 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
              ))}
            </div>
          ) : boards.value.length === 0 ? (
            <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <svg class="w-12 h-12 text-gray-300 dark:text-slate-500 mx-auto mb-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5z" />
              </svg>
              <p class="text-gray-500 dark:text-gray-400">No hay boards aún</p>
              <button
                onClick$={() => { showBoardForm.value = true; }}
                class="mt-3 text-sm text-emerald-600 hover:underline"
              >
                Crear tu primer board
              </button>
            </div>
          ) : (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {boards.value.map(board => (
                <Link
                  key={board.uid}
                  href={`/climbing/boards/${board.uid}`}
                  class="block bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5 hover:border-emerald-400 hover:shadow-md transition-all"
                >
                  <div class="flex items-start justify-between mb-3">
                    <div class="w-10 h-10 bg-blue-100 dark:bg-blue-900/30 rounded-lg flex items-center justify-center">
                      <svg class="w-5 h-5 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5z" />
                      </svg>
                    </div>
                    <span class="text-xs px-2 py-0.5 rounded-full bg-gray-100 dark:bg-slate-700 text-gray-500 dark:text-gray-400">
                      {board.visibility === BoardVisibility.Public ? 'Público' : board.visibility === BoardVisibility.Organization ? 'Organización' : 'Privado'}
                    </span>
                  </div>
                  <h3 class="font-semibold text-gray-900 dark:text-white truncate">{board.name}</h3>
                  {board.description && (
                    <p class="text-xs text-gray-500 dark:text-gray-400 mt-1 line-clamp-2">{board.description}</p>
                  )}
                </Link>
              ))}
            </div>
          )}
        </div>
      )}

      {/* ROUTES TAB */}
      {activeTab.value === 'routes' && (
        <div>
          {routesLoading.value ? (
            <div class="space-y-3">
              {[1, 2, 3, 4].map(i => (
                <div key={i} class="h-16 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
              ))}
            </div>
          ) : routes.value.length === 0 ? (
            <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400">No hay rutas registradas</p>
            </div>
          ) : (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 overflow-hidden">
              <table class="w-full text-sm">
                <thead>
                  <tr class="border-b border-gray-200 dark:border-slate-700">
                    <th class="text-left px-5 py-3 text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wider">Ruta</th>
                    <th class="text-left px-5 py-3 text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wider hidden sm:table-cell">Zona</th>
                    <th class="text-left px-5 py-3 text-xs font-semibold text-gray-500 dark:text-gray-400 uppercase tracking-wider hidden md:table-cell">Dificultad</th>
                    <th class="text-right px-5 py-3"></th>
                  </tr>
                </thead>
                <tbody class="divide-y divide-gray-100 dark:divide-slate-700">
                  {routes.value.map(route => (
                    <tr key={route.uid} class="hover:bg-gray-50 dark:hover:bg-slate-700/50 transition-colors">
                      <td class="px-5 py-4">
                        <p class="font-medium text-gray-900 dark:text-white">{route.name}</p>
                        {route.description && (
                          <p class="text-xs text-gray-500 dark:text-gray-400 truncate max-w-xs">{route.description}</p>
                        )}
                      </td>
                      <td class="px-5 py-4 text-gray-500 dark:text-gray-400 hidden sm:table-cell">
                        {route.climbZoneId ?? '—'}
                      </td>
                      <td class="px-5 py-4 hidden md:table-cell">
                        {route.difficultyScaleId ? (
                          <span class="px-2 py-0.5 text-xs font-medium bg-orange-100 dark:bg-orange-900/30 text-orange-700 dark:text-orange-300 rounded-full">
                            {route.difficultyScaleId}
                          </span>
                        ) : '—'}
                      </td>
                      <td class="px-5 py-4 text-right">
                        <Link href={`/climbing/routes/${route.uid}`} class="text-xs text-emerald-600 hover:underline">
                          Ver
                        </Link>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </div>
      )}

      {/* ZONES TAB */}
      {activeTab.value === 'zones' && (
        <div>
          <div class="flex justify-end mb-4">
            <button
              onClick$={() => { showZoneForm.value = !showZoneForm.value; }}
              class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
              </svg>
              Nueva Zona
            </button>
          </div>

          {showZoneForm.value && (
            <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-600 p-5 mb-6">
              <h3 class="text-sm font-semibold text-gray-900 dark:text-white mb-4">Crear zona de escalada</h3>
              <div class="space-y-3">
                <input
                  type="text"
                  placeholder="Nombre de la zona *"
                  value={newZoneName.value}
                  onInput$={(e) => { newZoneName.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
                <input
                  type="text"
                  placeholder="Ubicación (opcional)"
                  value={newZoneLocation.value}
                  onInput$={(e) => { newZoneLocation.value = (e.target as HTMLInputElement).value; }}
                  class="w-full px-3 py-2 border border-gray-300 dark:border-slate-600 rounded-lg text-sm bg-white dark:bg-slate-700 text-gray-900 dark:text-white focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div class="flex justify-end gap-3 mt-4">
                <button
                  onClick$={() => { showZoneForm.value = false; }}
                  class="px-4 py-2 text-sm text-gray-600 dark:text-gray-400 hover:text-gray-900 transition-colors"
                >
                  Cancelar
                </button>
                <button
                  onClick$={createZone}
                  disabled={zoneSaving.value || !newZoneName.value.trim()}
                  class="px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
                >
                  {zoneSaving.value ? 'Creando...' : 'Crear zona'}
                </button>
              </div>
            </div>
          )}

          {zonesLoading.value ? (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {[1, 2, 3].map(i => (
                <div key={i} class="h-28 bg-gray-100 dark:bg-slate-700 rounded-xl animate-pulse" />
              ))}
            </div>
          ) : zones.value.length === 0 ? (
            <div class="text-center py-16 bg-white dark:bg-slate-800 rounded-xl border border-dashed border-gray-300 dark:border-slate-600">
              <p class="text-gray-500 dark:text-gray-400">No hay zonas registradas</p>
            </div>
          ) : (
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {zones.value.map(zone => (
                <div
                  key={zone.uid}
                  class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5"
                >
                  <div class="flex items-center gap-3 mb-2">
                    <div class="w-9 h-9 bg-green-100 dark:bg-green-900/30 rounded-lg flex items-center justify-center">
                      <svg class="w-4 h-4 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                      </svg>
                    </div>
                    <h3 class="font-semibold text-gray-900 dark:text-white">{zone.name}</h3>
                  </div>
                  {zone.description && (
                    <p class="text-xs text-gray-500 dark:text-gray-400">{zone.description}</p>
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
  title: 'Escalada — ClimbEdge',
};
