import { createContextId, useContext, useContextProvider, useSignal } from '@builder.io/qwik';

export interface MenuStore {
  isCollapsed: { value: boolean };
  isMobileMenuOpen: { value: boolean };
}

export const MenuContext = createContextId<MenuStore>('menu-context');

export const useMenuStore = () => {
  const isCollapsed = useSignal(false);
  const isMobileMenuOpen = useSignal(false);

  return {
    isCollapsed,
    isMobileMenuOpen,
  };
};

export const useMenuContext = () => {
  const context = useContext(MenuContext);
  if (!context) {
    throw new Error('useMenuContext must be used within a MenuContextProvider');
  }
  return context;
};
