## Sour Scavenger Unity ##
A Unity-based 3D implementation of a fast-paced custom survival game, **Sour Scavenger**. The project offers a low-poly interactive environment with real-time player controls, while adopting an arcade-style loop of managing a constantly draining health bar, dodging explosive hazards, and setting high scores.

### 🚧 Status ###
**Active [v1.0.0]** - Initial release featuring core game loop, dynamic item spawners, audio cues, and score tracking.

### 🎯 Goals ###
1. **Practice Unity Systems** - Design modular gameplay loops, spawner logic, and 3D asset integration.
2. **Implement Game States** - Manage health decay and life counts cleanly using custom C# scripts.
3. **Build Responsive UI** - Integrate real-time HUD indicators, pause menus, and player score tracking.

### 🎮 Rules ###
**How to Play**
* **Scavenge Resources** - Navigate the map as a raccoon to collect lemons spawning around the arena.
* **Manage Health** - Prevent your constantly-draining health bar from depleting to avoid losing a life.
* **Survive Hazards** - Dodge volatile bombs disguised as lemon trees to survive as long as possible.

**Consumables and Hazards**
* **🍋 Lemons** - Serving as the raccoon's main snack, restores a chunk of health.
* **💣 Bombs** - Detonating on contact, instantly depletes a portion of health.
* **🍄 Mushrooms** - Awarding a rare treat, grants an extra life that can be hoarded.

**Game End States**
* **Defeat** - Running out of health and exhausting all remaining lives.
* **High Score** - Surviving the longest to establish a new personal record time.

**Controls and Input**
* **Moving** - Use `WASD` or `Arrow` Keys to navigate the arena.
* **Pause** - Press `Escape` to pause session or return to the menu.
* **Interact** - Use `Left Click` or `Space` to select UI options.

### 🚀 Running ###
**Prerequisites and Setup**
* **System Dependencies** - Requires [Unity 6][unity-url] or higher and [Git LFS][lfs-url] for large asset handling.
* **Initialize LFS** - Open your terminal and run `git lfs install` to initialize Git LFS (run once globally).
* **Clone Repository** - Open your terminal and run `git clone https://github.com/actuallyhollow/sour-scavenger-unity.git`.

**Opening in Unity Editor**
* **Add Project** - Open `Unity Hub`, click `Add > Add project from disk`, and select `sour-scavenger` root folder.
* **Launch Scene** - In the Unity Project panel, navigate to `Assets/Scenes/` and double-click `MainGame.unity`.
* **Play Game** - Click the `Play` button (`Ctrl+P` / `Cmd+P`) at the top of the Unity Editor to start playing.

### ✏️ Feedback ###
* **Report an Issue** - To report a bug or request a feature, please open a ticket on the [Issues][issues-url] tracker.
* **Join the Discussion** - To share code or gameplay critiques, please visit the [Discussions][discussions-url] board.
* **Show Your Support** - If you enjoyed playing or exploring the project, consider leaving a ⭐️!

### 📖 Credits ###
* **Author** - Designed and developed by [Omar Idris][author-url] (`@actuallyhollow`).
* **Assets** - Environment & Character models by [Quaternius][quaternius-url].
* **Audios** - UI audio by [Kenney][kenney-url] and gameplay SFX from [FreeSound][freesound-url].
* **License** - Check the [LICENSE][license-url] file for details.

<!-- Source References -->
[unity-url]: https://unity.com/
[lfs-url]: https://git-lfs.com/
[issues-url]: https://github.com/actuallyhollow/sour-scavenger/issues
[discussions-url]: https://github.com/actuallyhollow/sour-scavenger/discussions
[author-url]: https://github.com/actuallyhollow
[quaternius-url]: https://quaternius.com/
[kenney-url]: https://kenney.nl/
[freesound-url]: https://freesound.org/
[license-url]: ./LICENSE