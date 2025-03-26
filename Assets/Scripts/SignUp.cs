using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SignUp : MonoBehaviour
{
    public GameObject signUp;
    public GameObject login;

    public Button signUpBtn;
    public Button cancelBtn;

    public TMP_InputField IDInputSign;
    public TMP_InputField PWInputSign;
    public TMP_InputField PWCheckInputSign;
    public TMP_InputField NameInputSign;


    public PopupLogin popupLogin;

    public DataManager dataManager;


    public string filePath;

    public void Start()
    {
        // 파일 경로 설정 (정확한 경로 지정)
        filePath = Path.Combine(Application.persistentDataPath, "userData.json");

        // 경로가 제대로 설정되었는지 확인
        Debug.Log("파일 경로: " + filePath);
        signUpBtn.onClick.AddListener(OnClickSignUp);
        cancelBtn.onClick.AddListener(OnClickCancel);
    }

    public void OnClickSignUp()
    {
        string id = IDInputSign.text.Trim();
        string pw = PWInputSign.text.Trim();
        string pwCheck = PWCheckInputSign.text.Trim();
        string name = NameInputSign.text.Trim();

        if (string.IsNullOrEmpty(id))
        {
            Debug.Log("회원가입 실패 - ID 를 입력하세요.");

            popupLogin.errorPopup.SetActive(true);
            popupLogin.errorText.text = "ID 를 입력하세요.";
            return;
        }

        if (string.IsNullOrEmpty(name))
        {
            Debug.Log("회원가입 실패 - 이름을 입력하세요.");

            popupLogin.errorPopup.SetActive(true);
            popupLogin.errorText.text = "이름을 입력하세요.";
            return;
        }



        // 비밀번호 확인이 일치하는지 확인
        if (pw != pwCheck)
        {
            Debug.Log("회원가입 실패 - 비밀번호가 일치하지 않습니다.");

            popupLogin.errorPopup.SetActive(true);
            popupLogin.errorText.text = "비밀번호가 일치하지 않습니다.";
            return;
        }

        UserData newUser = new UserData(name, 100000, 50000, id, pw);
        newUser.ID = id;
        newUser.PW = pw;
        newUser.Name = NameInputSign.text;
        newUser.Cash = 100000;
        newUser.Balance = 50000;

        // 모든 조건이 만족되면 회원가입 성공
        dataManager.SaveData(newUser);

    }

    public void OnClickCancel()
    {
        Debug.Log("회원가입 취소");
        signUp.SetActive(false);
        login.SetActive(true);
    }


}
