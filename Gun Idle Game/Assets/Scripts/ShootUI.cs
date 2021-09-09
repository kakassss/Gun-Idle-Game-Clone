using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootUI : MonoBehaviour
{
    [SerializeField] Image lockImage;
    [SerializeField] TextMeshProUGUI lockText;
    [SerializeField] GameObject unlockButton;


    private UnlockNewShooterManager UnlockNewShooterManager;
    private Shooter shooter;

    
    public GameObject[] UIthings1 = new GameObject[]
    {

    };
    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<Shooter>();
        
        UnlockNewShooterManager = FindObjectOfType<UnlockNewShooterManager>();
    }
    
    public void UnlockShooter(Shooter shooter)
    {
        bool canOpen1 = false;
        bool canOpen2 = false;

            if(UnlockNewShooterManager.Level >= 5)
            {
                shooter.GetComponent<Shooter>();
                shooter.canShoot = true;
                for (int y = 0; y < 3; y++)
                {
                    UIthings1[y].gameObject.SetActive(false);
                }
            canOpen1 = true;
            }
            if (UnlockNewShooterManager.Level >= 10 && canOpen1)
            {
                shooter.GetComponent<Shooter>();
                shooter.canShoot = true;
                for (int y = 3; y < 6; y++)
                {
                    UIthings1[y].gameObject.SetActive(false);
                }
            canOpen2 = true;
            }
            if (UnlockNewShooterManager.Level >= 15 && canOpen2)
            {
                shooter.GetComponent<Shooter>();
                shooter.canShoot = true;
                for (int y = 6; y < 9; y++)
                {
                    UIthings1[y].gameObject.SetActive(false);
                }
            }
        
    }
}
