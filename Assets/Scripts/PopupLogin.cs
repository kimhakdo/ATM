using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class PopupLogin : MonoBehaviour
{
    public GameObject loginPopup; //로그인 팝업
    public GameObject mainPopup;  //메인 팝업
    public GameObject signUpPopup; //회원가입 팝업

    public TMP_InputField iDInput; //ID 입력창
    public TMP_InputField pWInput; //PW 입력창

    public Button loginBtn;        //로그인 버튼
    public Button signUpBtn;       //회원가입 버튼
    private void Start()
    {
        loginBtn.onClick.AddListener(OnClickLogin); //로그인 버튼 클릭시 이벤트
        signUpBtn.onClick.AddListener(OnClickSignUp); //회원가입 버튼 클릭시 이벤트
    }

    public void OnClickLogin()
    { 
        loginPopup.SetActive(false); //로그인 팝업 비활성화
        mainPopup.SetActive(true);   //메인 팝업 활성화
    }

    public void OnClickSignUp()
    {
        loginPopup.SetActive(false); //로그인 팝업 비활성화
        signUpPopup.SetActive(true); //회원가입 팝업 활성화
    }

    public void OnLogin()
    {
        string id = iDInput.text; //ID 입력창에 입력된 값
        string pw = pWInput.text; //PW 입력창에 입력된 값

        if()
        {
            OnClickLogin();
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }
}
