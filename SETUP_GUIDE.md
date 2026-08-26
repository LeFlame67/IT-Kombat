# Guía de Configuración - IT Kombat

## 📋 Pasos Iniciales

### 1. Clonar el Repositorio
```bash
git clone https://github.com/LeFlame67/IT-Kombat.git
cd IT-Kombat
```

### 2. Abrir en Unity
- Abre Unity Hub
- Click en "Add project from disk"
- Selecciona la carpeta del proyecto
- Asegúrate de que estés usando Unity 2021 LTS o superior

### 3. Estructura de Carpetas
Asegúrate de crear las siguientes carpetas en `Assets/`:
```
Assets/
├── Audio/
│   ├── Music/
│   │   ├── intro_music.mp3
│   │   ├── menu_music.mp3
│   │   └── battle_music.mp3
│   └── SFX/
├── Sprites/
│   ├── Characters/ (10 sprites de personajes)
│   ├── Backgrounds/ (5 fondos)
│   └── UI/
├── Scenes/
│   ├── Intro.unity
│   ├── Menu.unity
│   ├── CharacterSelect.unity
│   ├── ArenaSelect.unity
│   └── Battle.unity
└── Scripts/ (ya están creados)
```

## 🎵 Configuración de Audio

### AudioManager Setup
1. En la escena, crea un GameObject llamado "AudioManager"
2. Añade el script `AudioManager.cs`
3. Añade dos AudioSource:
   - Uno para música
   - Otro para efectos de sonido
4. En el Inspector, asigna los clips de audio correspondientes

## 🎮 Configuración de Personajes

### CharacterDatabase Setup
1. Crea un GameObject llamado "CharacterDatabase"
2. Añade el script `CharacterDatabase.cs`
3. En el Inspector, configura 10 personajes:
   - Nombre del personaje
   - Sprite del personaje
   - Stats (daño, salud, etc.)

### Personajes Placeholder
Cada personaje debe tener:
- Nombre único
- Sprite (puede ser cualquier imagen temporalmente)
- Stats de combate

## 🎨 Configuración de Arenas

### Arena Setup
1. Para cada arena, crea un GameObject con el script `Arena.cs`
2. Configura:
   - Nombre de la arena
   - Sprite de fondo
   - Clip de audio (opcional)
   - Posiciones de spawn de jugadores

### Las 4 Arenas
- Arena 1: Oficina Futurista
- Arena 2: Edificio Industrial
- Arena 3: Fábrica/Planta
- Arena 4: Estacionamiento

## 🎬 Configuración de Escenas

### Escena: Intro
1. Crea una escena llamada "Intro.unity"
2. Elementos:
   - Canvas con texto "IT KOMBAT"
   - GameObject con IntroScreenController.cs
   - Referencias a AudioManager

### Escena: Menu
1. Crea una escena llamada "Menu.unity"
2. Elementos:
   - Canvas con botones: "Versus", "Settings", "Exit"
   - Script MainMenuController.cs

### Escena: CharacterSelect
1. Crea una escena llamada "CharacterSelect.unity"
2. Elementos:
   - Grid de 10 botones (personajes)
   - Imágenes de personajes
   - Textos de selección
   - Script CharacterSelectController.cs

### Escena: ArenaSelect
1. Crea una escena llamada "ArenaSelect.unity"
2. Elementos:
   - Grid de 4 botones (arenas)
   - Imágenes de arenas
   - Script ArenaSelectController.cs

### Escena: Battle
1. Crea una escena llamada "Battle.unity"
2. Elementos:
   - Imagen de fondo (arena)
   - Dos GameObjects para los jugadores
   - HUD con barras de salud
   - Timer
   - Script BattleController.cs

## ⚙️ Configuración Build Settings

1. Ve a File → Build Settings
2. Añade todas las escenas en este orden:
   - Intro
   - Menu
   - CharacterSelect
   - ArenaSelect
   - Battle
3. Establece la resolución a 1920x1080

## 🔧 Configuración de Input

En Unity Input Manager (Edit → Project Settings → Input Manager):
- Los controles ya usan KeyCode.E, R, T, Y, U, WASD, Espacio
- No necesitas configuración adicional

## ✅ Checklist de Setup

- [ ] Repositorio clonado
- [ ] Proyecto abierto en Unity
- [ ] Carpetas de Assets creadas
- [ ] AudioManager configurado
- [ ] CharacterDatabase configurado
- [ ] 4 Arenas creadas
- [ ] Todas las escenas creadas
- [ ] Assets asignados en las escenas
- [ ] Build Settings configurado

## 🚀 Próximos Pasos

1. Añade los audios MP3 a la carpeta Audio/Music/
2. Añade los sprites de personajes a Sprites/Characters/
3. Añade los fondos a Sprites/Backgrounds/
4. Configura cada escena con los elementos correspondientes
5. ¡Prueba el juego!

## 📝 Notas

- Si en algún momento algo no funciona, revisa la consola (Window → General → Console)
- Todos los scripts tienen comentarios explicativos
- El proyecto está diseñado para ser expandible y fácil de modificar

---

¡Estás listo para empezar! 🎮
