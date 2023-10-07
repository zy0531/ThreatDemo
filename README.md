# ThreatDemo

## Introduction
This is the program of paper **Buzard, A.M., Davidson, J.A., Tighe, E.E., Zhao, Y., Bodenheimer, B., Creem-Regehr, S., & Stefanucci, J. (2023). Evaluating Threat Cues for the Enhancement of Safety in Virtual Navigation. 2023 IEEE International Symposium on Mixed and Augmented Reality Adjunct (ISMAR-Adjunct).**

In highly dynamic environments, the ability to detect and respond to potential threats while navigating is essential to ensure safe arrival.
However, it is often difficult to know where and when these threats may occur,given they are sometimes not visible. 
This project aims at addressing the question of how to effectively leverage augmented reality (AR) cues to visualize areas of potential threat to navigators while walking in order to promote user safety.

We developed a immersive virtual city where participants were tasked with navigating multiple segments of routes in the virtual city environment to get to predefined target locations while avoiding a potential threat.

A preliminary study shows that Ground Area AR cues led to less time in threat zones whereas Distance Text cues led to more efficient navigated routes.

## Hardware
- Varjo - XR3
- Base station x 2
- HTC Vive controller x 2
- HTC Vive tracker x1 (with a belt to tie the tracker in front of the belly of users)

## Software
- Varjo Base: update to the latest version (newer than 3.5.0)
- Unity 2020.3.20f1

## Scenes
- CScape_ThreatDemo/Assets/Scenes/Scene for Experiments

## System Design
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/System%20Design.png?raw=true" width="90%" height="90%">

### Threat Area
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/Threat%20Area%20Defination.png?raw=true" width="30%" height="30%">

### AR Cue Design
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/AR%20Cue.png?raw=true" width="40%" height="40%">

### A Segment of Route
<img src="https://github.com/zy0531/ThreatDemo/blob/main/Figures/Route.png?raw=true" width="20%" height="20%">


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
