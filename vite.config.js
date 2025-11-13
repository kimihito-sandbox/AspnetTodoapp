import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'
export default defineConfig({
  appType: 'custom',
  root: './Assets',
  build: {
    outDir: '../wwwroot',
    manifest: true,
    rollupOptions: {
      input: './Assets/main.js',
    },
  },
  plugins: [
    tailwindcss(),
  ],
})
