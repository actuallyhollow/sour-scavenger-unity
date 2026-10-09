## Unity Prototype ##

*Note: This is an experimental Unity sandbox. The final game title, theme, and characters are currently WIP.*

### ⚙️ Core Mechanics ###
Prototyping a survival loop where the player must collect randomly spawned items to maintain a constantly depleting bar. 
- Beneficial items restore the bar.
- Harmful items deplete the bar or consume a player life.
- Rare items may give powerful effects.
- Difficulty scales as the timer progresses.

### ⚠️ Crucial Setup (Git LFS) ###
Because this Unity project uses large assets (like Mixamo animations or textures), Git LFS **must** be installed before cloning the repository. Otherwise, 3D models and textures will be corrupted.

**1. Install Git LFS:**
Download the installer from [git-lfs.com](https://git-lfs.com/) and run it (or use a package manager like Homebrew: `brew install git-lfs`).

**2. Initialize LFS:**
Open a terminal or command prompt and run:
`git lfs install`

**3. Clone the Repository:**
Once LFS is active, safely clone the project:
`git clone https://github.com/actuallyhollow/survival-prototype-unity.git`

### ✏️ Development Notes ###
- **Cross-Platform Compatibility:**
The `.gitattributes` file is configured to force `LF` line endings. This prevents artificial merge conflicts or tracking errors when working across different operating systems.
- **Asset Renaming:**
If a file, folder, or Scene needs to be renamed, **only do it inside the Unity Editor**. Never rename files in an external IDE or file explorer, as this will break the `.meta` tracking files.