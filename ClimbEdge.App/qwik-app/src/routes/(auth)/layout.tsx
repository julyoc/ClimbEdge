import { component$, Slot } from '@builder.io/qwik';
import { DocumentHead } from '@builder.io/qwik-city';

export default component$(() => {
    return (
        <div class="min-h-screen bg-slate-50">
            <Slot /> {/* <== This is where the route will be inserted */}
        </div>
    );
});
export const head: DocumentHead = {
    title: "Accounts",
    meta: [
        {
            name: "description",
            content: "Authentication pages for ClimbEdge"
        }
    ]
};