using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Send : MonoBehaviour
{
    public DataManager dataManager;

    public PopupBank popupBank;

    public TMP_InputField sendID;
    public TMP_InputField sendCash;

    public TMP_Text errorScreen;     //에러 스크린

    public GameObject errorPopup;    //에러 팝업

    public UserData userData;


    public void TransferMoney()
    {
        userData = GameManager.instance.userData;

        string senderId = userData.ID; // 현재 로그인된 사용자 ID
        string receiverId = sendID.text; // 송금 대상 ID
        int amount = int.Parse(sendCash.text); // 송금 금액

        // 파일 경로 설정
        string senderFilePath = Application.persistentDataPath + "/" + senderId + ".json";
        string receiverFilePath = Application.persistentDataPath + "/" + receiverId + ".json";

        // 파일이 존재하는지 확인
        if (File.Exists(receiverFilePath))
        {
            // 수신자의 데이터 로드
            string receiverJson = File.ReadAllText(receiverFilePath);
            UserData receiver = JsonUtility.FromJson<UserData>(receiverJson);

            // 송금자의 잔액이 충분한지 확인
            if (userData.Balance >= amount)
            {
                // 송금자 잔액 차감
                userData.Balance -= amount;
                // 수신자 잔액 증가
                receiver.Balance += amount;

                // 변경된 정보 저장
                string updatedSenderJson = JsonUtility.ToJson(userData);
                File.WriteAllText(senderFilePath, updatedSenderJson);

                string updatedReceiverJson = JsonUtility.ToJson(receiver);
                File.WriteAllText(receiverFilePath, updatedReceiverJson);

                Debug.Log("송금 완료: " + amount + "이(가) " + receiverId + "에게 전송되었습니다.");


                
                ShowError("송금 완료: " + amount + "이(가) " + receiverId + "에게 전송되었습니다.");

                GameManager.instance.uiManager.Refresh(userData);
            }
            else
            {
                ShowError("잔액이 부족합니다.");
            }
        }
        else
        {
            ShowError("사용자 정보를 찾을 수 없습니다.");
        }
    }

    // 에러 메시지를 표시하는 함수
    private void ShowError(string message)
    {
        errorScreen.text = message; // 에러 메시지 설정
        errorPopup.SetActive(true); // 에러 팝업 표시
    }
}
