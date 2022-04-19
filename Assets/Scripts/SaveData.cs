using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveGame(float unlocks, float volume)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        float[] data = new float[2];

        data[0] = unlocks;
        data[1] = volume;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadGame()
    {
        string path = Application.persistentDataPath + "/save.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            float[] data = formatter.Deserialize(stream) as float[];
            stream.Close();

            return data;
        } 
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }
}
