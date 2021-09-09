using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;

    private int totalMoney;
    [SerializeField] TextMeshProUGUI totalMoneyText;

    [HideInInspector]
    public int totalExperience;
    public int currentExp;

    private UnlockNewShooterManager unlockNewShooterManager;
    // Start is called before the first frame update
    void Start()
    {
        unlockNewShooterManager = FindObjectOfType<UnlockNewShooterManager>();
        instance = this;
        totalMoney = PlayerPrefs.GetInt("TotalMoney", 15);
        totalExperience = PlayerPrefs.GetInt("TotalExperience", 0);
    }
    private void Update()
    {
        totalMoneyText.text ="Money:" + totalMoney.ToString();
    }
    public void IncreaseExperience(int amount)
    {
        totalExperience += amount;
        PlayerPrefs.SetInt("TotalExperience", totalExperience);
    }
    public void IncreaseMoney(int amount)
    {
        totalMoney += amount;
        PlayerPrefs.SetInt("TotalMoney", totalMoney);
    }
    public void DecreaseMoney(int amount)
    {
        totalMoney -= amount;
        PlayerPrefs.SetInt("TotalMoney", totalMoney);
    }
}
