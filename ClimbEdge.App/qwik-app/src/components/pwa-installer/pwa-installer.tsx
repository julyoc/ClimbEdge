import { component$, useSignal, useVisibleTask$, $ } from '@builder.io/qwik';

export const PWAInstaller = component$(() => {
  const showInstallPrompt = useSignal(false);
  const deferredPrompt = useSignal<any>(null);

  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(() => {
    // Listen for the beforeinstallprompt event
    const handleBeforeInstallPrompt = (e: Event) => {
      // Prevent the mini-infobar from appearing on mobile
      e.preventDefault();
      // Stash the event so it can be triggered later
      deferredPrompt.value = e;
      // Show the install button
      showInstallPrompt.value = true;
    };

    const handleAppInstalled = () => {
      console.log('PWA was installed');
      showInstallPrompt.value = false;
      deferredPrompt.value = null;
    };

    window.addEventListener('beforeinstallprompt', handleBeforeInstallPrompt);
    window.addEventListener('appinstalled', handleAppInstalled);

    return () => {
      window.removeEventListener('beforeinstallprompt', handleBeforeInstallPrompt);
      window.removeEventListener('appinstalled', handleAppInstalled);
    };
  });

  const handleInstallClick = $(() => {
    if (deferredPrompt.value) {
      // Show the install prompt
      deferredPrompt.value.prompt();
      
      // Wait for the user to respond to the prompt
      deferredPrompt.value.userChoice.then((choiceResult: any) => {
        if (choiceResult.outcome === 'accepted') {
          console.log('User accepted the install prompt');
        } else {
          console.log('User dismissed the install prompt');
        }
        deferredPrompt.value = null;
        showInstallPrompt.value = false;
      });
    }
  });

  return (
    <>
      {showInstallPrompt.value && (
        <div class="fixed bottom-4 right-4 bg-emerald-600 text-white p-4 rounded-lg shadow-lg z-50">
          <div class="flex items-center gap-3">
            <div>
              <p class="font-semibold">Install ClimbEdge</p>
              <p class="text-sm opacity-90">Add to your home screen for a better experience</p>
            </div>
            <div class="flex gap-2">
              <button
                onClick$={() => showInstallPrompt.value = false}
                class="px-3 py-1 text-sm bg-emerald-700 rounded hover:bg-emerald-800"
              >
                Later
              </button>
              <button
                onClick$={handleInstallClick}
                class="px-3 py-1 text-sm bg-white text-emerald-600 rounded hover:bg-gray-100"
              >
                Install
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
});
