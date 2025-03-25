[System.Serializable]
public class UserData
{
    public string Name;
    public int Cash;
    public int Balance;
    public string ID;
    public string PW;


    public UserData(string name, int cash, int balance, string id, string pw)
    {
        Name = name;
        Cash = cash;
        Balance = balance;
        ID = id;
        PW = pw;

    }
}
