using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignUp : MonoBehaviour
{
    public GameObject signUp;
    public GameObject login;

    public Button signUpBtn;
    public Button cancelBtn;

    public TMP_InputField IDInputSign;
    public TMP_InputField PWInputSign;
    public TMP_InputField PWCheckInputSign;

    public DataManager dataManager;

    public void Start()
    {
        signUpBtn.onClick.AddListener(OnClickSignUp);
        cancelBtn.onClick.AddListener(OnClickCancel);
    }

    public void OnClickSignUp()
    {
        string id = IDInputSign.text.Trim();
        string pw = PWInputSign.text.Trim();
        string pwCheck = PWCheckInputSign.text.Trim();
        
        if (string.IsNullOrEmpty(id))
        {
            Debug.Log("회원가입 실패 - 아이디를 입력하세요.");
            return;
        }

        // 비밀번호 확인이 일치하는지 확인
        if (pw != pwCheck)
        {
            Debug.Log("회원가입 실패 - 비밀번호가 일치하지 않습니다.");
            return;
        }

        // 모든 조건이 만족되면 회원가입 성공
        Debug.Log("회원가입 성공");
        dataManager.SaveData(GameManager.instance.userData);
    }

    public void OnClickCancel()
    {
        Debug.Log("회원가입 취소");
        signUp.SetActive(false);
        login.SetActive(true);
    }
}
