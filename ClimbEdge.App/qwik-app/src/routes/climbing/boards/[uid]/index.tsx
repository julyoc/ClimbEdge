import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';
import { Link, useLocation, type DocumentHead } from '@builder.io/qwik-city';
import { getServiceConfig } from '~/hooks/use-service-config';
import { createBoardService } from 'climbedge-shared/services/BoardService';
import { createUserSessionService } from 'climbedge-shared/services/UserSessionService';
import { useAuth } from '~/contexts/auth.context';
import type { GetBoardDTO, GetBoardMemberDTO } from 'climbedge-shared/types/BoardDTO';
import type { GetSessionDTO } from 'climbedge-shared/types/SessionDTO';

export default component$(() => {
  const location = useLocation();
  const { user } = useAuth();
  const uid = location.params['uid'];

  const board = useSignal<GetBoardDTO | null>(null);
  const members = useSignal<GetBoardMemberDTO[]>([]);
  const sessions = useSignal<GetSessionDTO[]>([]);
  const loading = useSignal(true);
  const activeSession = useSignal<GetSessionDTO | null>(null);
  const startingSession = useSignal(false);
  const error = useSignal('');

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(async () => {
    const config = getServiceConfig();
    if (!config.baseUrl || !uid) { loading.value = false; return; }

    const boardSvc = createBoardService(config);
    const sessionSvc = createUserSessionService(config);

    const [boardRes, sessRes] = await Promise.all([
      boardSvc.getByUid(uid),
      sessionSvc.getSessions({ activeOnly: false, page: 1, pageSize: 10 }),
    ]);

    if (boardRes.success && boardRes.data) {
      board.value = boardRes.data;
      const membersRes = await boardSvc.getMembers(boardRes.data.id);
      if (membersRes.success && membersRes.data) members.value = membersRes.data;
    } else {
      error.value = boardRes.error ?? 'Board no encontrado';
    }

    if (sessRes.success && sessRes.data) {
      sessions.value = sessRes.data;
      activeSession.value = sessRes.data.find(s => !s.endedAt) ?? null;
    }

    loading.value = false;
  });

  const startSession = $(async () => {
    if (!board.value || !user.value) return;
    startingSession.value = true;
    const config = getServiceConfig();
    const sessionSvc = createUserSessionService(config);
    const res = await sessionSvc.start({ boardId: board.value.id, userId: user.value.id });
    startingSession.value = false;
    if (res.success && res.data) {
      activeSession.value = res.data;
      sessions.value = [res.data, ...sessions.value];
    }
  });

  const endSession = $(async () => {
    if (!activeSession.value) return;
    const config = getServiceConfig();
    const sessionSvc = createUserSessionService(config);
    const res = await sessionSvc.end(activeSession.value.uid);
    if (res.success) {
      sessions.value = sessions.value.map(s =>
        s.uid === activeSession.value!.uid ? { ...s, endedAt: new Date().toISOString() } : s
      );
      activeSession.value = null;
    }
  });

  if (loading.value) {
    return (
      <div class="p-6 flex justify-center items-center min-h-64">
        <div class="animate-spin rounded-full h-10 w-10 border-b-2 border-emerald-600" />
      </div>
    );
  }

  if (error.value || !board.value) {
    return (
      <div class="p-6">
        <div class="bg-red-50 dark:bg-red-900/20 text-red-700 dark:text-red-300 rounded-xl p-4">
          {error.value || 'Board no encontrado'}
        </div>
        <Link href="/climbing" class="mt-4 inline-block text-sm text-emerald-600 hover:underline">← Volver a Escalada</Link>
      </div>
    );
  }

  return (
    <div class="p-6 max-w-6xl mx-auto">
      {/* Breadcrumb */}
      <nav class="text-sm text-gray-500 dark:text-gray-400 mb-4">
        <Link href="/climbing" class="hover:text-emerald-600">Escalada</Link>
        <span class="mx-2">›</span>
        <span class="text-gray-900 dark:text-white">{board.value.name}</span>
      </nav>

      {/* Header */}
      <div class="flex flex-col sm:flex-row sm:items-center justify-between gap-4 mb-6">
        <div>
          <h1 class="text-2xl font-bold text-gray-900 dark:text-white">{board.value.name}</h1>
          {board.value.description && (
            <p class="text-gray-500 dark:text-gray-400 text-sm mt-1">{board.value.description}</p>
          )}
        </div>
        <div>
          {activeSession.value ? (
            <button
              onClick$={endSession}
              class="flex items-center gap-2 px-4 py-2 bg-red-600 hover:bg-red-700 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <span class="w-2 h-2 bg-white rounded-full animate-pulse" />
              Finalizar sesión
            </button>
          ) : (
            <button
              onClick$={startSession}
              disabled={startingSession.value}
              class="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-50 text-white text-sm font-medium rounded-lg transition-colors"
            >
              <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M14.828 14.828a4 4 0 01-5.656 0M9 10h1.01M15 10h1.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
              {startingSession.value ? 'Iniciando...' : 'Iniciar sesión'}
            </button>
          )}
        </div>
      </div>

      {/* Active session banner */}
      {activeSession.value && (
        <div class="bg-emerald-50 dark:bg-emerald-900/20 border border-emerald-200 dark:border-emerald-700 rounded-xl p-4 mb-6 flex items-center gap-3">
          <span class="w-3 h-3 bg-emerald-500 rounded-full animate-pulse flex-shrink-0" />
          <div>
            <p class="text-sm font-medium text-emerald-700 dark:text-emerald-300">Sesión activa</p>
            <p class="text-xs text-emerald-600 dark:text-emerald-400">
              Iniciada: {activeSession.value.startedAt ? new Date(activeSession.value.startedAt).toLocaleTimeString('es') : '—'}
            </p>
          </div>
        </div>
      )}

      <div class="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Sessions List */}
        <div class="lg:col-span-2">
          <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5">
            <h2 class="text-base font-semibold text-gray-900 dark:text-white mb-4">Sesiones</h2>
            {sessions.value.length === 0 ? (
              <p class="text-gray-500 dark:text-gray-400 text-sm text-center py-8">No hay sesiones aún</p>
            ) : (
              <div class="space-y-2">
                {sessions.value.map(session => (
                  <div key={session.uid} class="flex items-center gap-3 p-3 rounded-lg border border-gray-100 dark:border-slate-700">
                    <div class={`w-2 h-2 rounded-full flex-shrink-0 ${session.endedAt ? 'bg-gray-300' : 'bg-emerald-500 animate-pulse'}`} />
                    <div class="flex-1 min-w-0">
                      <p class="text-sm font-medium text-gray-900 dark:text-white">
                        {session.startedAt ? new Date(session.startedAt).toLocaleDateString('es', { weekday: 'short', day: 'numeric', month: 'short' }) : '—'}
                      </p>
                      <p class="text-xs text-gray-500 dark:text-gray-400">
                        {session.endedAt ? `Finalizada: ${new Date(session.endedAt).toLocaleTimeString('es')}` : 'En progreso'}
                      </p>
                    </div>
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>

        {/* Members */}
        <div>
          <div class="bg-white dark:bg-slate-800 rounded-xl border border-gray-200 dark:border-slate-700 p-5">
            <h2 class="text-base font-semibold text-gray-900 dark:text-white mb-4">
              Miembros ({members.value.length})
            </h2>
            {members.value.length === 0 ? (
              <p class="text-gray-500 dark:text-gray-400 text-sm text-center py-6">Sin miembros</p>
            ) : (
              <div class="space-y-3">
                {members.value.map(member => (
                  <div key={member.uid} class="flex items-center gap-3">
                    <div class="w-8 h-8 bg-blue-100 dark:bg-blue-900/30 rounded-full flex items-center justify-center text-xs font-medium text-blue-600">
                      {member.userId?.toString().slice(0, 2)}
                    </div>
                    <div>
                      <p class="text-sm font-medium text-gray-900 dark:text-white">Usuario {member.userId}</p>
                      <p class="text-xs text-gray-500 dark:text-gray-400 capitalize">{['Member', 'Admin', 'Owner'][member.role] ?? 'Member'}</p>
                    </div>
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
});

export const head: DocumentHead = {
  title: 'Board — ClimbEdge',
};
