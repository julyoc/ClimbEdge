# ClimbEdge PWA Configuration

## ✅ PWA Features Enabled

Tu aplicación ClimbEdge ahora está configurada como una Progressive Web App (PWA) con las siguientes características:

### 🚀 Características Implementadas

1. **Web App Manifest** (`public/manifest.json`)
   - Nombre de la aplicación: "ClimbEdge - Climbing App"
   - Iconos SVG escalables (192x192 y 512x512)
   - Configuración para instalación en dispositivos móviles y desktop
   - Tema color: #10b981 (verde esmeralda)

2. **Service Worker** (Auto-generado por vite-plugin-pwa)
   - Cache automático de recursos estáticos
   - Funcionamiento offline
   - Actualizaciones automáticas

3. **Componentes PWA**
   - `PWAInstaller`: Muestra prompt de instalación personalizado
   - `ServiceWorkerRegistration`: Registra el service worker

4. **Meta Tags para Mobile**
   - Soporte para Apple Touch Icon
   - Configuración para pantalla completa en iOS
   - Meta tags de tema

### 📱 Cómo Probar la PWA

1. **Build de Producción**:
   ```bash
   npm run build:pwa
   ```

2. **Preview Local**:
   ```bash
   npm run preview
   ```

3. **Abrir en Navegador**:
   - Navegar a `http://localhost:4173`
   - En Chrome/Edge: Ver ícono de "Instalar" en la barra de direcciones
   - En móvil: Aparecer prompt de "Agregar a pantalla de inicio"

### 🎨 Personalización de Iconos

Los iconos actuales son temporales. Para personalizarlos:

1. Reemplaza `public/icon-192.svg` con tu ícono de 192x192
2. Reemplaza `public/icon-512.svg` con tu ícono de 512x512
3. Mantén el formato SVG para mejor escalabilidad

### 🔧 Configuración Avanzada

Edita `vite.config.ts` para personalizar:
- Patrones de cache del service worker
- Estrategias de actualización
- Archivos incluidos en el cache

### 📋 Requisitos PWA Cumplidos

- ✅ HTTPS (requerido en producción)
- ✅ Web App Manifest
- ✅ Service Worker
- ✅ Iconos en múltiples tamaños
- ✅ Responsive design
- ✅ Funcionamiento offline básico

### 🚀 Próximos Pasos

1. Personalizar iconos con el diseño de ClimbEdge
2. Configurar notificaciones push (opcional)
3. Implementar estrategias de cache más específicas
4. Testear en dispositivos móviles reales
5. Configurar HTTPS para producción

---

¡Tu aplicación ClimbEdge ahora puede instalarse como una app nativa en dispositivos móviles y desktop! 🎉
