import { component$, Slot, useContextProvider } from '@builder.io/qwik';
import FooterComponent from '~/components/footer-component';
import HeaderComponent from '~/components/header-component';
import MenuComponent from '~/components/menu-component';
import { MenuContext, useMenuStore } from '~/stores/menu';

export default component$(() => {
    const menuStore = useMenuStore();
    useContextProvider(MenuContext, menuStore);

    return (
        <div class="min-h-screen bg-slate-50">
            <HeaderComponent />
            <MenuComponent />

            {/* Main Content Area */}
            <main class={`
                transition-all duration-300 pt-16 min-h-screen
                ${menuStore.isCollapsed.value ? 'md:ml-16' : 'md:ml-64'}
            `}>
                <Slot /> {/* <== This is where the route will be inserted */}
            </main>

            <FooterComponent />
        </div>
    );
});