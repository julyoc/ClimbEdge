import type { RequestHandler } from "@builder.io/qwik-city";

export const onGet: RequestHandler = async ({ send, headers }) => {
    headers.set("Content-Type", "application/xml");

    const baseUrl = "https://climbedge.summitexplorerjd.ec";

    // Define your static routes manually for now
    const routes = [
        "/",
        "/about",
        "/contact-us",
        "/help-center",
        "/privacy-policy",
        "/terms-of-service",
        "/login",
        "/register"
        // Add other static routes as needed
    ];

    const urls = routes
        .map(
            (path: string) => `
    <url>
        <loc>${baseUrl}${path}</loc>
        <priority>${path === "/" ? "1.0" : "0.8"}</priority>
        <changefreq>weekly</changefreq>
    </url>`
        ).join("\n");

    send(200, `<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
${urls}
</urlset>`);
};
