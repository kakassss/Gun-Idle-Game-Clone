using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoard : MonoBehaviour
{
    private BankManager bankManager;
    [SerializeField]
    private ShootManager shootManager;

    private Shooter shooter1;

    private UnlockNewShooterManager unlockNewShooterManager;
    private void Awake()
    {
        shooter1 = GetComponentInParent<Shooter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        unlockNewShooterManager = FindObjectOfType<UnlockNewShooterManager>();
        bankManager = FindObjectOfType<BankManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bankManager.IncreaseMoney(shooter1.projectileMoney);
        

        if (!unlockNewShooterManager.canLevelUp)
        {
            bankManager.IncreaseExperience(shooter1.projectileExp);
            unlockNewShooterManager.FillSlider(shooter1.projectileExp);
        }
        Destroy(collision.gameObject);
    }
}
