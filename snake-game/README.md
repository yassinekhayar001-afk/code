# Snake (Web)

Ce dossier contient une version Web du jeu Snake. Elle fonctionne dans un navigateur moderne (Chrome/Edge/Firefox) et peut être empaquetée en application Android ou en `.exe` Windows via un wrapper WebView.

## Lancer localement

Ouvrez `index.html` dans un navigateur ou servez le dossier :

```bash
python -m http.server 8080
```

Puis ouvrez `http://localhost:8080/snake-game/`.

## Empaquetage Android (Capacitor)

1. Installez Node.js 18+.
2. Dans ce dossier :

```bash
npm init -y
npm install @capacitor/core @capacitor/cli
npx cap init snake-game com.example.snake --web-dir .
```

3. Ajoutez Android :

```bash
npm install @capacitor/android
npx cap add android
npx cap open android
```

4. Lancez depuis Android Studio.

## Empaquetage Windows `.exe`

Option simple avec Electron :

```bash
npm init -y
npm install electron --save-dev
```

Créez un `main.js` :

```js
const { app, BrowserWindow } = require("electron");

const createWindow = () => {
  const win = new BrowserWindow({ width: 900, height: 700 });
  win.loadFile("index.html");
};

app.whenReady().then(createWindow);
```

Ajoutez un script dans `package.json` :

```json
"scripts": {
  "start": "electron ."
}
```

Puis lancez :

```bash
npm run start
```

Pour créer un `.exe`, utilisez `electron-builder` (voir documentation officielle).
