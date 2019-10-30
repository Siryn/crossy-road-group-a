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

        for (int i = 0; i < highScores.Length; i++)
        {
            if (newScore > highScores[i])
            {
                highScores[i] = newScore;
                return;
            }
        }

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
