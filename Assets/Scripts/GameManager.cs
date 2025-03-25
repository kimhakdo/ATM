using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;
    public DataManager dataManager;

    public UIManager uiManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        userData = new UserData("김학도", 100000, 50000);
        uiManager.Refresh(userData);
        dataManager.SaveData();
    }
}
