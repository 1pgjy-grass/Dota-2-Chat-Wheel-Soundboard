# Dota-2-Chat-Wheel-Soundboard
This is a modification to [Dota-2-Chat-Wheel-Soundboard](https://github.com/derdanielb/Dota-2-Chat-Wheel-Soundboard) created by derdanielb. Now it gives you ability to specify sounds (avi format only) you want play in game.

![Soundboard](https://raw.githubusercontent.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/master/readme/application.png "Soundboard")

## Installation
For this setup two downloads are needed: The soundboard and an audio driver.
### Downloads

1. Download the precompiled [Chat Wheel Soundboard](https://github.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/releases/download/v1.1/ChatWheelSoundboard.zip)
2. Download the tool [VB-Audio Virtual Cable](https://vb-audio.com/Cable/index.htm)
(Any other audio tool that can send playback sound to a recording device will work)

### Setup (4 Steps)

*Please remember your previous settings if change anything.*

1. __install the VB-Audio Virtual Cable:__
Setup requires to be run in Administrator Mode. Please refer to tool documentation (actually it is only a one-button-installation).
NOTE: Any other audio tool that can emulate playback sound to a recording source will work aswell.


2. __set system's sound setting:__
Right click the volumn icon in task bar to open sound setting dialog. Make sure virtual cable output is set as default device in recording tab. 
![system-sound-setting-1](https://raw.githubusercontent.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/master/readme/system-sound-setting-1.png "system-sound-setting-1")</br>
Also make sure your real audio device is set as default device in playback tab. ![system-sound-setting-2](https://raw.githubusercontent.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/master/readme/system-sound-setting-2.png "system-sound-setting-2")

3. __run chatWheelSoundboard.exe and config__
![application-setting](https://raw.githubusercontent.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/master/readme/application-setting.png "application-setting")

4. __set dota2's audio setting__
![dota2-audio-setting](https://raw.githubusercontent.com/1pgjy-grass/Dota-2-Chat-Wheel-Soundboard/master/readme/dota2-audio-setting.png "dota2-audio-setting")

Now everything is ready.

## Requirements
- .NET 4.5.2
- Audio tool to send sound from playback source to recording source. I recommend [VB-Audio Virtual Cable](https://www.vb-audio.com/Cable/index.htm#DownloadCable).

## Limitations
It is not possible to use your mircophone and soundboard at the same time, since both require to be steams recording device.