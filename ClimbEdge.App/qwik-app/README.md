# Qwik City App ⚡️

- [Qwik Docs](https://qwik.dev/)
- [Discord](https://qwik.dev/chat)
- [Qwik GitHub](https://github.com/QwikDev/qwik)
- [@QwikDev](https://twitter.com/QwikDev)
- [Vite](https://vitejs.dev/)

---

## Project Structure

This project is using Qwik with [QwikCity](https://qwik.dev/qwikcity/overview/). QwikCity is just an extra set of tools on top of Qwik to make it easier to build a full site, including directory-based routing, layouts, and more.

Inside your project, you'll see the following directory structure:

```
├── public/
│   └── ...
└── src/
    ├── components/        // UI components puros
    │   └── ...
    └── routes/            // File-based routing
    |   └── ...
    └── services/          // Lógica de dominio frontend (sin fetch)
    |   └── ...
    └── repositories/      // API REST calls
    |   └── ...
    └── stores/            // Estado global (opcional)
    |   └── ...
    └── utils/             // Funciones genéricas
        └── ...
```

- `src/routes`: Provides the directory-based routing, which can include a hierarchy of `layout.tsx` layout files, and an `index.tsx` file as the page. Additionally, `index.ts` files are endpoints. Please see the [routing docs](https://qwik.dev/qwikcity/routing/overview/) for more info.

- `src/components`: Recommended directory for components.

- `public`: Any static assets, like images, can be placed in the public directory. Please see the [Vite public directory](https://vitejs.dev/guide/assets.html#the-public-directory) for more info.

## Authentication System

This project includes a custom authentication system built with nested components that provide role-based access control.

### AuthComponent System

The authentication system consists of a container component (`AuthComponent`) and three specialized sub-components:

- **`AuthComponent`**: Main container that MUST wrap all auth sub-components
- **`AuthAnonimus`**: Renders content for anonymous/non-authenticated users
- **`Auth`**: Renders content for authenticated users (any role)
- **`AuthWithRole`**: Renders content for users with specific roles

### Usage Examples

#### Basic Usage
```tsx
import { AuthComponent, AuthAnonimus, Auth, AuthWithRole } from "~/components/auth-component";

<AuthComponent>
  <AuthAnonimus>
    <LandingPage />
  </AuthAnonimus>
  <Auth>
    <Dashboard />
  </Auth>
  <AuthWithRole roles={["Admin"]}>
    <AdminPanel />
  </AuthWithRole>
</AuthComponent>
```

#### Multiple Role Components
```tsx
<AuthComponent>
  <AuthWithRole roles={["User", "Premium"]}>
    <UserProfile />
  </AuthWithRole>
  <AuthWithRole roles={["Admin", "SuperAdmin"]}>
    <AdminSettings />
  </AuthWithRole>
</AuthComponent>
```

#### Single Component Usage
```tsx
<AuthComponent>
  <AuthAnonimus>
    <PublicContent />
  </AuthAnonimus>
</AuthComponent>
```

### Component Behavior

- **`AuthAnonimus`**: Shows content when `!isAuthenticated || isAnonymous`
- **`Auth`**: Shows content when `isAuthenticated && !isAnonymous` 
- **`AuthWithRole`**: Shows content when user is authenticated and has required roles

### Automatic Redirections

Each authentication component handles its own redirections automatically:

- **`Auth`**: Automatically redirects to `/login` if user is not authenticated and not anonymous
- **`AuthWithRole`**: 
  - Automatically redirects to `/login` if user is not authenticated and not anonymous
  - Automatically redirects to `/unauthorized` if user is authenticated but doesn't have required roles
- **`AuthAnonimus`**: No redirections - only shows content when user is not authenticated or is anonymous

The redirections happen through `useTask$` that tracks authentication state changes, ensuring real-time response to authentication status updates.

### Important Notes

⚠️ **All sub-components MUST be wrapped in `AuthComponent`**. Using them outside will throw an error:

```tsx
// ❌ This will throw an error
<Auth>
  <Content />
</Auth>

// ✅ This works correctly
<AuthComponent>
  <Auth>
    <Content />
  </Auth>
</AuthComponent>
```

### Available Roles

Roles are defined in `~/utils/rolesConst.ts`. Common roles include:
- `Guest` (automatically assigned to anonymous users)
- `User`, `Premium`, `Admin`, `SuperAdmin`
- See the file for complete list of available roles

### Authentication Context

The system uses a global authentication context (`~/contexts/auth.context.ts`) that provides:

```tsx
const { user, isAuthenticated, isAnonymous, setUser, clearAuth } = useAuth();
```

- **`user`**: Current user object with roles
- **`isAuthenticated`**: Boolean indicating if user is logged in
- **`isAnonymous`**: Boolean indicating if user is browsing as guest
- **`setUser(userData)`**: Function to set authenticated user
- **`clearAuth()`**: Function to clear authentication and set as anonymous

### Quick Start

1. Wrap your content with `AuthComponent`
2. Use appropriate sub-components based on your needs
3. Specify roles array for `AuthWithRole` components
4. Handle redirections with `/login` and `/unauthorized` routes

## Add Integrations and deployment

Use the `npm run qwik add` command to add additional integrations. Some examples of integrations includes: Cloudflare, Netlify or Express Server, and the [Static Site Generator (SSG)](https://qwik.dev/qwikcity/guides/static-site-generation/).

```shell
npm run qwik add # or `yarn qwik add`
```

## Development

Development mode uses [Vite's development server](https://vitejs.dev/). The `dev` command will server-side render (SSR) the output during development.

```shell
npm start # or `yarn start`
```

> Note: during dev mode, Vite may request a significant number of `.js` files. This does not represent a Qwik production build.

## Preview

The preview command will create a production build of the client modules, a production build of `src/entry.preview.tsx`, and run a local server. The preview server is only for convenience to preview a production build locally and should not be used as a production server.

```shell
npm run preview # or `yarn preview`
```

## Production

The production build will generate client and server modules by running both client and server build commands. The build command will use Typescript to run a type check on the source code.

```shell
npm run build # or `yarn build`
```
