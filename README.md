# VRTVStudio
This repository contains an Unity-Project with a SteamVR Application.
The Application captures the tracking data from a SteamVR-compatible device (e.g. the vive controllers or vive tracker). The captured data is converted to be send via the UPD protocol.

## Dataformat
The data which is send via upd has the folling structure:

xPos | yPos | zPos | xRot | yRot | zRot

The datatyp is float with 32 Bits.

Rotations are mapped to range of -180 to 180 degree.

## Required Hard- and Software Setup
o Unity 2020.3.30

o SteamVR 1.2.????

o HTC Vive

o NodeJS X.X

## NodeJS Server
The Server based on NodeJS is only for testing purposes. Start the sever with the desired configuration.
If your Unity Application is working correctly the sended data is shown in the command line of the server.
// Navigate to folder
cd NodeJS

// Start the test server
node index.js
