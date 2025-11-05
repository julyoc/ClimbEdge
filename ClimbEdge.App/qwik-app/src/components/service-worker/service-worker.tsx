import { component$, useVisibleTask$ } from '@builder.io/qwik';

export const ServiceWorkerRegistration = component$(() => {
  // eslint-disable-next-line qwik/no-use-visible-task
  useVisibleTask$(() => {
    if ('serviceWorker' in navigator) {
      // Register the service worker when the component mounts
      navigator.serviceWorker.register('/sw.js')
        .then((registration) => {
          console.log('SW registered: ', registration);
        })
        .catch((registrationError) => {
          console.log('SW registration failed: ', registrationError);
        });
    }
  });

  return null; // This component doesn't render anything
});
