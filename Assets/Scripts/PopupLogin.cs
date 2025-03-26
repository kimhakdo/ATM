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
    public GameObject errorPopup; //에러 팝업

    public TMP_InputField iDInput; //ID 입력창
    public TMP_InputField pWInput; //PW 입력창
    public TMP_Text errorText;     //에러 텍스트

    public Button loginBtn;        //로그인 버튼
    public Button signUpBtn;       //회원가입 버튼
    public Button errorBtn;        //에러 버튼

    public SignUp signUp;          //회원가입 스크립트
    public DataManager dataManager; //데이터 매니저
    public UIManager uiManager;     //UI 매니저

    private void Start()
    {
        loginBtn.onClick.AddListener(OnClickLogin); //로그인 버튼 클릭시 이벤트
        signUpBtn.onClick.AddListener(OnClickSignUp); //회원가입 버튼 클릭시 이벤트
        errorBtn.onClick.AddListener(OnClickError); //에러 버튼 클릭시 이벤트
    }

    // 로그인 클릭
    public void OnClickLogin()
    {
        string inputId = iDInput.text.Trim();
        string inputPw = pWInput.text.Trim();

        if (string.IsNullOrEmpty(inputId) || string.IsNullOrEmpty(inputPw))
        {
            Debug.Log("로그인 실패 - 아이디와 비밀번호를 입력하세요.");
            
            errorPopup.SetActive(true); //에러 팝업 활성화
            errorText.text = "아이디와 비밀번호를 입력하세요.";

            return;
        }

        // 저장된 사용자 정보 로드
        dataManager.LoadData(inputId);

        if (GameManager.instance.userData != null && GameManager.instance.userData.ID == inputId && GameManager.instance.userData.PW == inputPw)
        {
            Debug.Log("로그인 성공!");

            loginPopup.SetActive(false); // 로그인 팝업 비활성화
            mainPopup.SetActive(true);   // 메인 팝업 활성화
            uiManager.Refresh(GameManager.instance.userData); //UI 매니저에 사용자 정보 갱신
        }
        else
        {
            Debug.Log("로그인 실패 - 아이디 또는 비밀번호가 잘못되었습니다.");

            errorPopup.SetActive(true); //에러 팝업 활성화
            errorText.text = "아이디 또는 비밀번호가 잘못되었습니다.";
        }
    }

    public void OnClickSignUp()
    {
        loginPopup.SetActive(false); //로그인 팝업 비활성화
        signUpPopup.SetActive(true); //회원가입 팝업 활성화
    }

    public void OnClickError()
    {
        errorPopup.SetActive(false); //에러 팝업 비활성화
    }

}
