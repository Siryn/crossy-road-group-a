using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class HighScoreManager : MonoBehaviour
{
    //public int[] highScores = new int[10];
    public List<int> highScores = new List<int>();

    private void Awake()
    {
        ReadHighScores();
    }

    private SaveData CreateSaveDataObject()
    {
        SaveData save = new SaveData();
        for (int i = 0; i < highScores.Count; i++)
        {
            save.highScores[i] = highScores[i];
            //Array.Sort(save.highScores);
            //Array.Reverse(save.highScores);
        }
        return save;
    }

    public void SaveHighScores(int newScore)
    {
        /*highScores[0] = 22;
        highScores[1] = 21;
        highScores[2] = 15;
        highScores[3] = 12;
        highScores[4] = 11;
        highScores[5] = 8;
        highScores[6] = 3;
        highScores[7] = newScore;
        highScores[8] = 0;
        highScores[9] = 0;*/

        /*for (int i = 0; i < highScores.Count; i++)
        {
            if (newScore > highScores[i])
            {
                highScores[i] = newScore;

                break;
            }
        }*/

        highScores.Add(newScore);

        highScores.Sort();
        highScores.Reverse();

        highScores.RemoveAt(10);

        SaveData save = CreateSaveDataObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Data saved with score " + newScore);
    }

    public void ReadHighScores()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.save", FileMode.Open);
            SaveData save = (SaveData)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < highScores.Count; i++)
            {
                highScores[i] = save.highScores[i];
            }
        }
        Debug.Log("Data loaded");
    }
}
