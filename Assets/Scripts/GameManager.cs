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
        if (uiManager != null)
        {
            uiManager.Refresh(userData);
        }
        else
        {
            Debug.LogWarning("UIManager가 할당되지 않았습니다.");
        }
    }
}
