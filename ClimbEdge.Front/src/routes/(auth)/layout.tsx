import { component$, Slot } from '@builder.io/qwik';

export default component$(() => {
    return (
        <div class="min-h-screen bg-slate-50">
            <Slot /> {/* <== This is where the route will be inserted */}
        </div>
    );
});
