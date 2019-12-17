# Unity 3D / C# / Visual Studio - Original house visit development - 'Archviz'

*December 2019 - Development time: 10 days*

> 🔨 House visit made with Unity 3D (ver. 2019.2.4f1). Visit a non existing house in a realistic 3D environment. There are 3 modes: First person mode, Spot points mode or Cinematic mode. you can select which mode you want to use in the main menu.

* * *

![03-building3.png](images/03-building3.png)

## 1. Installation

### 1.1 Windows x86_64

#### 1.1.1 Windows Installer

Download the installer [here](https://drive.google.com/open?id=1ge26sNREoVhetAXvAMiVUBR2xhc7l5BA) [xxxMb] and just follow the instructions.

#### 1.1.2 Zip version

Download the zip with the game [here](https://drive.google.com/open?id=132E5ejLU5oWoKGphxwqQsrJybRMVBZgi) [xxxGb] and unzip forest-windows64.zip on your computer.

In 'archviz-windows64' launch forest-project.exe by clicking on it to play.

### 1.2 Mac OSX

Download the zip with the game [here](https://drive.google.com/open?id=1z-Ep5Kwq5RcbGIM-JlVLDDj9Zol4g6vG) [xxxGb] and unzip forest-mac-osx.zip on your computer.

In 'archviz-mac-osx' launch build-macsos.app by clicking on it to play.

Warning: It's not an approved Mac App Store application so you will have to select 'allow apps downloaded from anywhere' or click on 'open anyway' on the alert box if you want to launch the game.


### 1.4 Scripts for reviewing

Scripts used are in the [script folder](https://github.com/Raigyo/unity-3d-game-forest/tree/master/scripts) on this repository.

*-------*

## 2. About

This application is a showcase in which you can visit a house. The house has been 'build' by me using Unity 3D, some assets from the asset store, Probuilder3D et Progrid components and even a ruler.

### 2.1. How to play

#### 2.1.1. Spots points view mode

Navigate in the different rooms by clicking with left button on the differents arrows around you (like in *Google Street Maps*).

You can rotate the view using your mouse and zoom in / out using the scroll button of your mouse.

- 'Escape' / 'P': show / hide pause menu with continue or back to menu.

#### 2.1.2. First person view mode

Same view than in 'FPS' games. Use arrows to move and the mouse to look around.

- 'Escape' / 'P': show / hide pause menu with continue or back to menu.


#### 2.1.3. Cinematic view mode

Nothing to do here, just watch the cinematic!

- 'Escape' / 'P': show / hide pause menu with continue or back to menu.

*-------*

## 3. Techniques / Assets / Scripts

![01-building.png](images/01-building.png)

### 3.1. Intro scene (scene name: intro)

#### 3.1.1. Menu

You can select between the different views modes.

The view selected is managed by Scriptable Objects (that can be sused as 'global' variables between scenes).

The three versions of the showcase are just one scene with some GameObjects displayed (especially cameras) or not according to the value in the Scriptable Objects. This value is reset each time we comme back to the intro scene.

### 3.2. Application scene (scene name: archviz)

#### 3.2.1. The house

Made with several assets from the Unity asset store including *ArchVizPRO Interior Vol.3* and *ArchVizPRO Interior Vol.3*.

![02-building2.png](images/02-building2.png)

#### 3.2.2. Lights

The most difficult part to manage according to me. In that kind of application they are very important for the atmosphere.

There are several realtime lights:

- Two directionnal lights (key and backlights), without shadows. They are enhanced with [Aura 2 - Volumetric Lighting & Fog - Raphael Ernaelsten](https://assetstore.unity.com/packages/tools/particles-effects/aura-2-volumetric-lighting-fog-137148)
- Four points lights are used in realtime in the room and living

Baked lights:

- Many lightmaps / baked (= prerendered) lights are used in the differents rooms including spot lights and point lights
- There are reflexion probes in each rooms

On each camera (on camera per mode), there is post processing: the one provided by Unity and [MadGoat SSAA & Resolution Scale - MadGoat Studio](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/madgoat-ssaa-resolution-scale-86368))

![04-building4.png](images/04-building4.png)

#### 3.2.3. Script: [HitBehaviour.cs](scripts/HitBehaviour.cs)

Script that uses raycast especially in Spot Points Mode to manage the click on arrows.

It could be used for some other actions in each mode because the camera used is send by LevelManager.cs.

#### 3.2.4. Script: [MenuManager.cs](scripts/MenuManager.cs)

Used only in menu to selct the game mode.

#### 3.2.5. Script: [LevelManager.cs](scripts/LevelManager.cs)

Manage what's displayed on the screen according the mode played.

#### 3.2.6. Script: [SpotCamMouseMovements.cs](scripts/SpotCamMouseMovements.cs)

Manage the control of the mouse in Spot Play Mode. Many settings can be edited in the editor.

#### 3.2.7. Script: [SpotCamChangeRoom.cs](scripts/SpotCamChangeRoom.cs)

Detect in which room we want to go in Spot Play Mode.

#### 3.2.8. Script: [Mirror.cs](scripts/Mirror.cs)

Manage the realistic reflexion in mirrors.

#### 3.2.9. Script: [Rotator.cs](scripts/Rotator.cs)

Manage the rotation of the food in the micro-wave.

#### 3.2.11. Cinematics

Cinematic mode has been made with the asset [Pegasus - Procedural Worlds](https://assetstore.unity.com/packages/tools/animation/pegasus-65397). Useful to make cinematic / cut scenes quite quickly (better than animator or cinemachine).

![05-building5.png](images/05-building5.png)

*-------*

## 4. Credits

### 4.1. Video, Music & Sounds



### 4.2. Assets used

[ArchVizPRO Interior Vol.3 - ArchVizPRO](https://assetstore.unity.com/packages/3d/environments/archvizpro-interior-vol-3-62337)
[ArchVizPRO Interior Vol.6 - ArchVizPRO](https://assetstore.unity.com/packages/3d/environments/urban/archvizpro-interior-vol-6-120489)
[Aura 2 - Volumetric Lighting & Fog - Raphael Ernaelsten](https://assetstore.unity.com/packages/tools/particles-effects/aura-2-volumetric-lighting-fog-137148)
[Candle Flames - Rivermill Studios](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/candle-flames-48044)
[Classic Picture Frame - Vertex Studio](https://assetstore.unity.com/packages/3d/props/furniture/classic-picture-frame-59038)
[Clock - VIS Games](https://assetstore.unity.com/packages/3d/props/interior/clock-4250)
[Footwear Collection - 3D Everything](https://assetstore.unity.com/packages/3d/props/clothing/footwear-collection-52313)
[Free Smartphone - Vertex Studio](https://assetstore.unity.com/packages/3d/props/electronics/free-smartphone-90324)
[House Furniture Pack - Finward Studios](https://assetstore.unity.com/packages/3d/props/house-furniture-pack-88646)
[Kitchen Appliances with Packaging - Robot Skeleton](https://assetstore.unity.com/packages/3d/props/electronics/kitchen-appliances-with-packaging-155472)
[Kitchen Props Free - Jake Sullivan](https://assetstore.unity.com/packages/3d/props/interior/kitchen-props-free-80208)
[MadGoat SSAA & Resolution Scale - MadGoat Studio](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/madgoat-ssaa-resolution-scale-86368)
[Modern UI Pack - Michsky](https://assetstore.unity.com/packages/tools/gui/modern-ui-pack-150824)
[Pegasus - Procedural Worlds](https://assetstore.unity.com/packages/tools/animation/pegasus-65397)
[Realistic Furniture And Interior Props Pack - Sevastian Marevoy](https://assetstore.unity.com/packages/3d/props/furniture/realistic-furniture-and-interior-props-pack-120379)
[Shoes Mens / Ladies - Kobra Game Studios](https://assetstore.unity.com/packages/3d/props/clothing/shoes-mens-ladies-73134)
[Substance in Unity - Allegorithmic](https://assetstore.unity.com/packages/tools/utilities/substance-in-unity-110555)
[Suburb Neighborhood House Pack Modular - Finward Studios](https://assetstore.unity.com/packages/3d/environments/urban/suburb-neighborhood-house-pack-modular-72712)
[Ultra Washing Machine PBR - 00Laboratories](https://assetstore.unity.com/packages/3d/props/electronics/ultra-washing-machine-pbr-144339)
[Umbrella PRO - Indie_G](https://assetstore.unity.com/packages/3d/props/clothing/umbrella-pro-55277)
[Zone - Complete Main Menu UI - Michsky](https://assetstore.unity.com/packages/tools/gui/zone-complete-main-menu-ui-144619)
[zz Ruler - orange030](https://assetstore.unity.com/packages/tools/utilities/zz-ruler-365)

### 4.3. Fonts

- [FontSpace - Font Curiosity](https://www.fontspace.com/)

### 4.4. Softwares

- [Audacity](https://www.audacityteam.org/)
- [Inno Setup - Installer](http://www.jrsoftware.org/isinfo.php)

*-------*

## 5. Useful links & Greetings

- [Brackeys Game Dev Tutorials](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA)
- [DitzelGames](https://www.youtube.com/channel/UCdedu-nAwMACE5WbVcmp3Bg)
- [Epitome](https://www.youtube.com/channel/UCsaXQNLxeHvwJdDUrICGufA)
- [IMERSITY](https://www.youtube.com/channel/UCCCf8Z1iY3yXQUxcnarA0Ag)
- [Info Gamer](https://www.youtube.com/channel/UCyoayn_uVt2I55ZCUuBVRcQ)
- [inScope Studios](https://www.youtube.com/channel/UCyVsCcTte38YC9CxJtw3hBQ)
- [Jason Weimann - Unity 3D College](https://www.youtube.com/channel/UCX_b3NNQN5bzExm-22-NVVg)
- [Learn Everything Fast](https://www.youtube.com/channel/UCG5XadFg6icC2TcF0I5DIig)
- [Raywenderlich](https://www.raywenderlich.com/)
- [SpeedTutor](https://www.youtube.com/channel/UCwYuQIa9lgjvDiZryUVtFGw)
- [Sykoo](https://www.youtube.com/channel/UCNJvwJ6daLmw4_gUKTw4cSg)
- [Sylvain - Créateur 3D](https://www.youtube.com/channel/UC8BM2xQlXcK4Vt3OqfOmj9g)
- [TUTO UNITY FR](https://www.youtube.com/channel/UCJRwb5W4ZzG43J5_dViL6Fw)
- [Unity Guruz](https://www.youtube.com/channel/UCgd3l8iA5zBYVa4sQ6-ONFw)
- [Unity Learn](https://learn.unity.com/)
- [Unity Pour les nuls](https://www.youtube.com/channel/UCuU8cONIgZ182KheI1s6HqQ)
- [Unity3D With Scott](https://www.youtube.com/channel/UC9hfBvn17qSIrdFwAk56oZg)

*-------*

## 6. Contact (Github / Linked In)

- [My Github](https://github.com/Raigyo)
- [My LinkedIn](https://www.linkedin.com/in/vincent-chilot/)
