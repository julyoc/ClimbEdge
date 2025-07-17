import { component$, Slot } from '@builder.io/qwik';
import FooterComponent from '~/components/footer-component';
import HeaderComponent from '~/components/header-component';

export default component$(() => {
    return (
        <>
            <HeaderComponent />
            <Slot /> {/* <== This is where the route will be inserted */}
            <FooterComponent />
        </>
    );
});