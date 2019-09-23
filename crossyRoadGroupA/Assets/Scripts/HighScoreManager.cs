using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public int[] highScores = new int[10];

    private void Awake()
    {
        ReadHighScores();
    }

    public void OnGameEnd(int score)
    {
        SaveHighScores(score);
    }

    private SaveData CreateSaveDataObject()
    {
        SaveData save = new SaveData();
        for (int i = 0; i < highScores.Length; i++)
        {
            save.highScores[i] = highScores[i];
        }
        return save;
    }

    public void SaveHighScores(int newScore)
    {
        highScores[0] = 22;
        highScores[1] = 21;
        highScores[2] = 15;
        highScores[3] = 12;
        highScores[4] = 11;
        highScores[5] = 8;
        highScores[6] = 3;
        highScores[7] = newScore;
        highScores[8] = 0;
        highScores[9] = 0;

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

            for (int i = 0; i < highScores.Length; i++)
            {
                highScores[i] = save.highScores[i];
            }
        }
        Debug.Log("Date loaded");
    }
}
