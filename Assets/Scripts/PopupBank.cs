using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPopup;  //입금
    public GameObject withdrawPopup; //출금
    public GameObject mainPopup;     //메인버튼
    public GameObject needMoneyPopup; //실패버튼
    public GameObject sendMoneyPopup; //송금버튼

    public Button depositBtn;        //입금버튼
    public Button withdrawBtn;       //출금버튼
    public Button[] backBtn;         //뒤로가기버튼
    public Button sendMoneyBtn;      //송금버튼

    public Button needMoneyBtn;      //실패버튼
    public Button okayBtn;           //확인버튼

    public TMP_InputField inputField;    //입금금액
    public TMP_InputField outputField;   //출금금액

    public DataManager dataManager;

    private void Start()
    {
        depositBtn.onClick.AddListener(OnClickDeposit);        //입금버튼 클릭시 이벤트
        withdrawBtn.onClick.AddListener(OnClickWithdrawPopup); //출금버튼 클릭시 이벤트
        backBtn[0].onClick.AddListener(BackBtn);               //뒤로가기버튼 클릭시 이벤트
        backBtn[1].onClick.AddListener(BackBtn);               //뒤로가기버튼 클릭시 이벤트
        backBtn[2].onClick.AddListener(BackBtn);               //뒤로가기버튼 클릭시 이벤트
        needMoneyBtn.onClick.AddListener(NeedMoneyBtn);        //실패버튼 클릭시 이벤트
        okayBtn.onClick.AddListener(OkayBtn);                  //확인버튼 클릭시 이벤트
        sendMoneyBtn.onClick.AddListener(OnClickSendMoney);    //송금버튼 클릭시 이벤트


    }
    public void OnClickDeposit()        // 입금버튼 클릭시   
    {
        depositPopup.SetActive(true);   //입금팝업창 활성화
        mainPopup.SetActive(false);     //메인버튼 비활성화
    }
    public void OnClickWithdrawPopup()
    {
        withdrawPopup.SetActive(true);  //출금팝업창 활성화
        mainPopup.SetActive(false);     //메인버튼 비활성화
    }

    public void OnClickSendMoney()
    {
        sendMoneyPopup.SetActive(true); //송금팝업창 활성화
        mainPopup.SetActive(false);     //메인버튼 비활성화
    }

    public void BackBtn()
    {
        depositPopup.SetActive(false);  //입금팝업창 비활성화
        withdrawPopup.SetActive(false); //출금팝업창 비활성화
        sendMoneyPopup.SetActive(false); //송금팝업창 비활성화
        mainPopup.SetActive(true);      //메인버튼 활성화
    }
    public void NeedMoneyBtn()
    {
        needMoneyPopup.SetActive(true); //실패버튼 활성화
    }
    public void OkayBtn()
    {
        needMoneyPopup.SetActive(false); //실패버튼 비활성화
    }
    public void InMoney(int amount)
    {
        if (GameManager.instance.userData.Cash >= amount) // 돈이 충분할 때만 실행
        {
            GameManager.instance.userData.Cash -= amount;
            GameManager.instance.userData.Balance += amount;
            GameManager.instance.uiManager.Refresh(GameManager.instance.userData);
            dataManager.SaveData(GameManager.instance.userData);
        }
        else
        {
            NeedMoneyBtn(); // 돈이 부족하면 실패 팝업 실행
        }
    }

    public void CustomInMoney() //입금Text버튼
    {
        int amount = int.Parse(inputField.text);
        InMoney(amount);
    }

    public void CustomOutMoney() //출금Text버튼
    { 
        int amount = int.Parse(outputField.text);
        InMoney(-amount);
    }
}
 