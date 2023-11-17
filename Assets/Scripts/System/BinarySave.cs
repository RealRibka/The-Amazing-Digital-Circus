using Palmmedia.ReportGenerator.Core.Common;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinarySave
{
    public static void SaveData(CustomCharacterController characterController)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/save.data";
        
        using(FileStream stream = new(path, FileMode.Create))
        {
            SavingData data = new(characterController);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static SavingData LoadData()
    {
        string path = Application.persistentDataPath + "/save.data";
        
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            SavingData data = formatter.Deserialize(stream) as SavingData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("SUKA NOT FOUND");
            return null;
        }
    }
}
