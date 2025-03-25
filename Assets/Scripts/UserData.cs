using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class UserData
{
    public string Name;
    public int Cash;
    public int Balance;

    public UserData(string name, int cash, int balance)
    {
        Name = name;
        Cash = cash;
        Balance = balance;
    }
}

public class  DataManager : MonoBehaviour
{
    public UserData userData;

    public void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        // Json 직렬화 하기
        string json = JsonUtility.ToJson(userData);
        
        //외부 폴더에 접근해서 json 파일 저장
        File.WriteAllText(Application.persistentDataPath + "/userData.json", json);
    }

    public void LoadData()
    {
        //외부 폴더에 접근해서 json 파일 읽기
        string json = File.ReadAllText(Application.persistentDataPath + "/userData.json");

        // Json 역직렬화 하기
        userData = JsonUtility.FromJson<UserData>(json);
    }
}