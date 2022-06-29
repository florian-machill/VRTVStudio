using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class TrackerData
{
    public float xPos;
    public float yPos;
    public float zPos;
    public float xRot;
    public float yRot;
    public float zRot;

    public TrackerData(Vector3 position, Quaternion rotation)
    {
        xPos = position.x;
        yPos = position.y;
        zPos = position.z;

        Vector3 eulers = (rotation * Quaternion.Euler(90,0,0)).eulerAngles;
        xRot = eulers.x;
        yRot = eulers.y;
        zRot = eulers.z;

        xRot %= 360;
        xRot = xRot > 180 ? xRot - 360 : xRot;

        yRot %= 360;
        yRot = yRot > 180 ? yRot - 360 : yRot;

        zRot %= 360;
        zRot = zRot > 180 ? zRot - 360 : zRot;
    }
    
    public byte[] GetBytes()
    {
        byte[] byteArray = BitConverter.GetBytes(xPos);   
        Array.Copy(BitConverter.GetBytes(yPos), byteArray, 4);
        Array.Copy(BitConverter.GetBytes(zPos), byteArray, 4);
        Array.Copy(BitConverter.GetBytes(xRot), byteArray, 4);
        Array.Copy(BitConverter.GetBytes(yRot), byteArray, 4);
        Array.Copy(BitConverter.GetBytes(zRot), byteArray, 4);

        return byteArray;
    }
    public override string ToString()
    {
        return xPos + " | " + yPos + " | " + zPos + " | " + xRot + " | " + yRot + " | " + zRot;
    }
}
