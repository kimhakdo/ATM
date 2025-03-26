using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string GetFilePath(string userID)
    {
        return Application.persistentDataPath + "/" + userID + ".json";
    }

    private void Awake()
    {
        Debug.Log("저장 경로: " + Application.persistentDataPath);
    }

    public void SaveData(UserData data)
    {
        if (data == null)
        {
            Debug.LogError("저장하려는 데이터가 null입니다!");
            return;
        }

        string filePath = GetFilePath(data.ID);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"데이터 저장 완료: {filePath}");
    }

    public void LoadData(string userID)
    {
        string filePath = GetFilePath(userID);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameManager.instance.userData = JsonUtility.FromJson<UserData>(json);

            if (GameManager.instance.userData == null)
            {
                Debug.LogWarning("JSON 데이터가 잘못되어 기본값을 사용합니다."); 
            }
        }
        else
        {
            Debug.LogWarning($"[{userID}] 저장된 데이터가 없어 기본값을 생성합니다.");
        }
    }

}