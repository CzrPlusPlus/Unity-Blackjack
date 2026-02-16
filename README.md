# ♦ Blackjack Simulator ♦
## Overview
This is a simple game made from scratch where the player plays 30 hands of blackjack against the dealer. Every hand is a $25 bet unless the player chooses to double down. 
Try to finish the game with a net-positive balance or just sit back and enjoy some blackjack with some nice relaxing music (thank you to LudoLoon Studio for the free music!).

## Try the Game Yourself
Try the game [here](https://czr838.itch.io/blackjacksimv2). The game should be full screen for correct display of UI. <br>
The password is: **unity**

## Images & Video Demonstration
<p align="center">
  <img src ="https://github.com/CzrPlusPlus/Unity-Blackjack/blob/main/screenshots/UnityProject.PNG" width="300" height="300" />
  <img src ="https://github.com/CzrPlusPlus/Unity-Blackjack/blob/main/screenshots/blackjack3.PNG" width="300" height="auto" />
  <img src ="https://github.com/CzrPlusPlus/Unity-Blackjack/blob/main/screenshots/blackjack4.PNG" width="300" height="auto" />
</p>
<video src="https://github.com/CzrPlusPlus/Unity-Blackjack/blob/main/screenshots/Movie_003.mp4" width="600" controls></video>


## Areas of Improvement 
- **UI!!!!!!** <br>
All of the UI elements & prefab instantiating are done using *world coordinates*. This is **NOT** good implementation.
Need to utilize Canvas better and use Rect Transform, Anchors, and Pivots. The game is pretty much designed exclusively for 16:9 1920x1080 display.
