# Manufactoria 2022 Mods

Collection of my mods for the game Manufactoria 2022.

You can find me (1vader#0203) on the [Pleasing Fungus](https://discord.gg/9nWhhDK) Discord server for questions, bug reports or ideas for improvements or new mods. Or you can just create an issue here.

## Mods Overview

- **RightclickDeselect**: Deselect machines when right-clicking instead of rotating them
- **Zoom**: Adds basic zooming functionality. Slightly jank but it works.

## Installation

See also [Installing BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) for additional information but the steps below should be enough.

Download BepInEx version 5.4 for your OS from the [BepInEx releases page](https://github.com/BepInEx/BepInEx/releases) and extract it in your games installation directory. You can find this directory in Steam in the game's properties under "local files". You should end up with a directory called `BepInEx` right next to the `MFT3.exe` (or `MFT3.x86_64` on Linux and `MFT3.app` on macOS).

Next, download any mods you want to use and place them in the `BepInEx/plugins` directory.

You can download the mods from the [releases page](https://github.com/benediktwerner/MF22Mods/releases) or using the links below.

On Windows you can now just start the game.

On Linux and Mac you need to perform some additional steps:

- Modify the `run_bepinex.sh` file which should now be next to the game's executable:
  - Edit `executable_name="";` to `executable_name="MFT3.x86_64"` on Linux or `executable_name="MFT3.app"`
  - Make sure the script is executable by running `chmod u+x run_bepinex.sh` in a terminal in the game directory
- You should now be able to launch the game with mods by running `./run_bepinex.sh`
- If you want to be able to launch the game with mods via Steam, additionally follow [these steps](https://docs.bepinex.dev/articles/advanced/steam_interop.html) which usually amounts to setting the game's launch options to `./run_bepinex.sh %command%` in Steam > Manufactoria 2022 > Properties. On macOS you need to specify the full path: `/full/path/to/game/run_bepinex.sh %command%` which you can get by running `pwd` in a terminal in the game directory.

<!--
To configure the mods you need to launch the game at least once after installing them. Then you can edit the configuration files in `BepInEx/config`.

Alternatively, you can install the [BepInEx.ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager) (again by downloading the files and placing them inside the `BepInEx/plugins` directory). This allows you to bring up an in-game mod settings menu by pressing `F1`.
-->

## Direct Download Links

- **RightclickDeselect**: [RightclickDeselect.dll v1.0](https://github.com/benediktwerner/MF22Mods/releases/download/rightclick-deselect-v1.0.0/RightclickDeselect.dll)
- **Zoom**: [Zoom.dll v1.0](https://github.com/benediktwerner/MF22Mods/releases/download/zoom-v1.0.0/Zoom.dll)
