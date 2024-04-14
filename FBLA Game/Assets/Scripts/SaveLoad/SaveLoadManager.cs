using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoadManager
{
    public static void Save(GameState state)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leaderboard.dc";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, state);
        stream.Close();
    }

    public static GameState Load()
    {
        string path = Application.persistentDataPath + "/leaderboard.dc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameState state = formatter.Deserialize(stream) as GameState;
            return state;
        } else
        {
            Debug.LogError("Save file not found!!! At: " + path);
            return null;
        }
    }

    public static bool HasSaved()
    {
        string path = Application.persistentDataPath + "/leaderboard.dc";
        return File.Exists(path);
    }
}
