using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI CashText;
    public TextMeshProUGUI BalanceText;
    public InputField InputField;
    public void Refresh(UserData data)
    { 
        NameText.text = data.Name;
        CashText.text = data.Cash.ToString("N0");
        BalanceText.text = data.Balance.ToString("N0");
    }
}
