using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField]
    private CustomCharacterController characterController;


    public void SaveData()
    {
        BinarySave.SaveData(characterController);
    }

    public void LoadData()
    {
        var data = BinarySave.LoadData();

        characterController.transform.position = new Vector3(data.PlayerPos[0], data.PlayerPos[1], data.PlayerPos[2]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadData();
        }
    }
}
