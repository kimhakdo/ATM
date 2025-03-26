using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransferManager : MonoBehaviour
{
    public TMP_InputField receiverIdInput; // 받는 사람 ID 입력창
    public TMP_InputField amountInput; // 송금할 금액 입력창
    public TMP_Text statusText; // 상태 메시지 표시

    public Button sendButton; // 송금 버튼

    public DataManager dataManager; // 데이터 관리 클래스

    private void Start()
    {
        sendButton.onClick.AddListener(OnSendMoney);
    }

    // 송금 버튼 클릭 이벤트
    public void OnSendMoney()
    {
        string senderId = GameManager.instance.userData.ID; // 현재 로그인한 유저 ID
        string receiverId = receiverIdInput.text.Trim(); // 입력한 수신자 ID
        int amount;

        // 입력 값 검증
        if (string.IsNullOrEmpty(receiverId) || !int.TryParse(amountInput.text.Trim(), out amount) || amount <= 0)
        {
            ShowStatus("잘못된 입력입니다. 금액을 올바르게 입력하세요.", Color.red);
            return;
        }

        // 송금할 대상의 데이터 불러오기
        UserData receiverData = dataManager.LoadData(receiverId)?.dataList.Find(user => user.userID == receiverId);

        if (receiverData == null)
        {
            ShowStatus("수신자 ID를 찾을 수 없습니다.", Color.red);
            return;
        }

        UserData senderData = GameManager.instance.userData;

        // 보낼 금액이 충분한지 확인
        if (senderData.Cash < amount)
        {
            ShowStatus("잔액이 부족합니다.", Color.red);
            return;
        }

        // 송금 진행
        senderData.Cash -= amount;
        receiverData.Cash += amount;

        // 변경된 데이터 저장
        dataManager.SaveData(senderId, senderData);
        dataManager.SaveData(receiverId, receiverData);

        ShowStatus($"송금 성공! {receiverId}님께 {amount}골드 송금 완료.", Color.green);
    }

    private void ShowStatus(string message, Color color)
    {
        statusText.text = message;
        statusText.color = color;
    }
}
