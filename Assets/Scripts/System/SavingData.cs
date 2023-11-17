using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavingData
{
    public float[] PlayerPos;
    public float[] PlayerAngles;

    public SavingData(CustomCharacterController player)
    {
        PlayerPos = new float[3];
        PlayerPos[0] = player.transform.position.x;
        PlayerPos[1] = player.transform.position.y;
        PlayerPos[2] = player.transform.position.z;
    }
}

