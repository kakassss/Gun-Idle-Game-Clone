using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager instance;

    private BankManager bankManager;
    private Shooter shooter;

    private int projectileSpeedCost;
    private int projectileMoneyCost;

    private int[] Cost = new int[]
    {
        5,//0
        10,//1 
        15,//2
        20,//3
        25,//4
        30,//5
        35,//6
        40,//7
        45,//8
        50,//9
    };
    private void Awake()
    {   
        instance = this;
        bankManager = FindObjectOfType<BankManager>();   
    }
    public void IncreaseProjectileMoney(Shooter currentShooter)
    {
        currentShooter.GetComponentsInParent<Shooter>();
        currentShooter.projectileMoney += 5;
        projectileMoneyCost = Cost[currentShooter.projectileMoney / 5 -1];
        PlayerPrefs.SetInt(gameObject.name, currentShooter.projectileMoney);
        bankManager.DecreaseMoney(projectileMoneyCost);

        PlayerPrefs.Save();
        Debug.Log(currentShooter.projectileMoney + "money");
    }
    public void IncreaseProjectileSpeed(Shooter currentShooter)
    {
        currentShooter.GetComponentsInParent<Shooter>();

        currentShooter.projectileSpeed += 1;
        projectileSpeedCost = Cost[currentShooter.projectileSpeed - 1];
        PlayerPrefs.SetInt(gameObject.name, currentShooter.projectileSpeed);
        bankManager.DecreaseMoney(projectileSpeedCost);

        PlayerPrefs.Save();
        Debug.Log(currentShooter.projectileMoney + "speed");
    }
}
