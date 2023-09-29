# ThreatDemo

## Hardware
- Varjo - XR3
- Base station x 2
- HTC Vive controller x 2
- HTC Vive tracker x1 (with a belt to tie the tracker in front of the belly of users)

## Hardware
- Varjo Base: update to the latest version (newer than 3.5.0)
- Unity 2020.3.20f1

## Scenes
- Assets/Scenes/Scene for Experiments/MRMapTraining.unity
- Assets/Scenes/Scene for Experiments/MRMapExploration.unity
- Assets/Scenes/Scene for Experiments/MRMapPointing.unity
- Assets/Scenes/Scene for Experiments/MRMapMapDrawing.unity

## System Design

## Procedure

### Lobby Room
- Participants start in the lobby room.
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/Lobby%20Room.png?raw=true" width="40%" height="40%">

### Practice
- Press “P” to teleport to the practice area.
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/Training%20Area.png?raw=true" width="40%" height="40%">

- 2 target waypoints (E1, E2) are set on the building in the practice.
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/TearDrop%20Target.png?raw=true" width="20%" height="20%">

- A circle will appear when participants approach the target waypoint (when the distance between the user and the target position is less than 30m).
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/Ground%20Target%20Indicator.png?raw=true" width="20%" height="20%">

- Participants can use a trackpad to control their translation.

- In the practice, the experimenter can press “T” (or not if only training for locomotion) to set a timer to show participants what the timer looks like in the experiment. The timer will not be reset between two practice trials.

- Once ready, ask participants to press the trigger button on the Vive controller to go to the starting position of the first trial.
