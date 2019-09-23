using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int[] highScores;

    public SaveData()
    {
        highScores = new int[10];
    }
}
