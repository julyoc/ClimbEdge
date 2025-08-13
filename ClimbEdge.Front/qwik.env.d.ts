// This file can be used to add references for global types like `vite/client`.

// Add global `vite/client` types. For more info, see: https://vitejs.dev/guide/features#client-types
/// <reference types="vite/client" />

interface ImportMetaEnv {
    VITE_APP_NAME: string;
    VITE_API_BASE_URL_PATH: string;
}
