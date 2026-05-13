using System.IO;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    PlayerData playerData;

    private void Start()
    {
        playerData = PlayerData.Instance;
    }

    public void SaveData()
    {
        //string json = JsonUtility.ToJson(playerData);
        //Debug.Log(json);

        //using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        //{
        //    writer.Write(json);
        //}

        string json = JsonUtility.ToJson(playerData, true);

        string path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        Debug.Log(json);

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(json);
        }

        Debug.Log("Save Complete");
    }

    public void LoadData()
    {
        //string json = string.Empty;
        //using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        //{
        //    json = reader.ReadToEnd();
        //}

        //PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        //LoadHere

        string path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        if (!File.Exists(path))
        {
            Debug.Log("No Save File");
            return;
        }

        string json = string.Empty;

        using (StreamReader reader = new StreamReader(path))
        {
            json = reader.ReadToEnd();
        }

        JsonUtility.FromJsonOverwrite(json, playerData);

        Debug.Log("Load Complete");
    }

}
