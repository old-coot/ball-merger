
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(Progress progress)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.yo";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        ProgressGameData progressData = new ProgressGameData(progress);
        binaryFormatter.Serialize(fileStream, progressData);
        fileStream.Close();
    }

    public static ProgressGameData Load()
    {
        string path = Application.persistentDataPath + "/progress.yo";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            ProgressGameData progressData = binaryFormatter.Deserialize(fileStream) as ProgressGameData;
            fileStream.Close();
            return progressData;
        }
        else
        {
            Debug.Log("No file");
            return null;
        }
    }

    public static void DeleteFile()
    {
        string path = Application.persistentDataPath + "/progress.yo";
        File.Delete(path);
    }
}