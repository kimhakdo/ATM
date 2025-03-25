using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/userData.json";
        Debug.Log("저장 경로: " + filePath);
    }

    public void Start()
    {
        LoadData();
    }
    public void SaveData(UserData data)
    {
        if (data == null)
        {
            Debug.LogError("저장하려는 데이터가 null입니다!");
            return;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameManager.instance.userData = JsonUtility.FromJson<UserData>(json);

            if (GameManager.instance.userData == null) // JSON이 잘못 저장된 경우
            {
                Debug.LogWarning("JSON 데이터가 잘못되어 기본값을 사용합니다.");
                SetDefaultUserData();
            }
        }
        else
        {
            Debug.LogWarning("저장된 데이터가 없어 기본값을 생성합니다.");
            SetDefaultUserData();
        }
    }

    private void SetDefaultUserData()
    {
        GameManager.instance.userData = new UserData("김학도", 100000, 50000);
        SaveData(GameManager.instance.userData);
    }
}