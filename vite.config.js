import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'
export default defineConfig({
  appType: 'custom',
  root: './Assets',
  build: {
    outDir: '../wwwroot',
    manifest: "manifest.json",
    rollupOptions: {
      input: './Assets/main.js',
    },
  },
  plugins: [
    tailwindcss(),
  ],
})
