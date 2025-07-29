# Build stage
FROM node:22-alpine as build

# Set working directory
WORKDIR /app

# Install dependencies first (for better caching)
COPY package*.json ./
RUN npm ci --only=production --silent

# Copy source code
COPY . .

# Build the application
RUN npm run build

# Production stage
FROM node:22-alpine as production

# Install dumb-init for proper signal handling
RUN apk add --no-cache dumb-init

# Create app directory and user
WORKDIR /app
RUN addgroup -g 1001 -S nodejs
RUN adduser -S qwik -u 1001

# Copy built application from build stage
COPY --from=build --chown=qwik:nodejs /app/dist ./dist
COPY --from=build --chown=qwik:nodejs /app/package*.json ./

# Install only production dependencies
RUN npm ci --only=production --silent && npm cache clean --force

# Switch to non-root user
USER qwik

# Expose port
EXPOSE 3000

# Set environment to production
ENV NODE_ENV=production
ENV PORT=3000

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
  CMD node --version || exit 1

# Start the application with dumb-init for proper signal handling
ENTRYPOINT ["dumb-init", "--"]
CMD ["node", "dist/entry.preview.js"]