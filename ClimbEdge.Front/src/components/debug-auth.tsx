import { component$ } from '@builder.io/qwik';
import { useAuth } from '~/contexts/auth.context';

export default component$(() => {
  const { user, isAuthenticated, isLoading } = useAuth();

  return (
    <div class="fixed bottom-4 right-4 bg-black text-white p-4 rounded-lg text-xs max-w-xs z-50">
      <h3 class="font-bold mb-2">Auth Debug</h3>
      <div>Loading: {isLoading.value.toString()}</div>
      <div>Authenticated: {isAuthenticated.value.toString()}</div>
      <div>User: {user.value ? JSON.stringify({
        email: user.value.email,
        firstName: user.value.firstName,
        id: user.value.id
      }, null, 2) : 'null'}</div>
    </div>
  );
});
