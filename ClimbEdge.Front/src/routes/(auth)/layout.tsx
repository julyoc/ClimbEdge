import { component$, Slot, useContextProvider } from '@builder.io/qwik';
import { AuthContext, useAuthStore } from '~/contexts/auth.context';
import { useAuthCheck } from '~/hooks/use-auth-check';

export default component$(() => {
    const authStore = useAuthStore();

    useContextProvider(AuthContext, authStore);

    // Verificar autenticación al cargar
    useAuthCheck();

    return (
        <div class="min-h-screen bg-slate-50">
            <Slot /> {/* <== This is where the route will be inserted */}
        </div>
    );
});
