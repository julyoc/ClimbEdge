import type { RequestHandler } from "@builder.io/qwik-city";

export const onGet: RequestHandler = async ({ send, headers }) => {
  headers.set("Content-Type", "text/plain");
  headers.set("Cache-Control", "public, max-age=86400"); // Cache for 24 hours
  
  send(200, `# Robots.txt for ClimbEdge
# Generated automatically

# Allow all crawlers to access the entire site
User-agent: *
Allow: /

# Disallow access to sensitive areas (add as needed)
Disallow: /api/
Disallow: /admin/
Disallow: /private/
Disallow: /_debug/
Disallow: /tmp/

# Allow specific paths that might be blocked by default
Allow: /api/public/

# Crawl delay (optional - uncomment if needed)
# Crawl-delay: 1

# Sitemap location
Sitemap: https://climbedge.summitexplorerjd.ec/sitemap.xml

# Additional crawlers (if you want specific rules)
User-agent: Googlebot
Allow: /

User-agent: Bingbot
Allow: /

# Block bad bots (uncomment if needed)
# User-agent: BadBot
# Disallow: /`);
};
