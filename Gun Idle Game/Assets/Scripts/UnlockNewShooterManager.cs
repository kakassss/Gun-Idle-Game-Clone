using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Actually LevelManager 
public class UnlockNewShooterManager : MonoBehaviour
{
    public static UnlockNewShooterManager instance;

    private BankManager bankManager;

    [HideInInspector]
    public int Level;
    private int levelIndex;


    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider slider;

    public bool canLevelUp = false;
    
    public int[] nextLevelExp = new int[]
    {        
        
    };

    public List<Shooter> shooters = new List<Shooter>();
    private Shooter shooter;
    private void Awake()
    {
        instance = this;
        
        bankManager = FindObjectOfType<BankManager>();
        LockShooters();
    }
    private void LockShooters()
    {       
        foreach (Shooter myshooters in shooters)
        {
            myshooters.gameTapCollider.enabled = false;
            myshooters.enabled = false;

            if (myshooters.myLevel == AllLevels.Level5 && Level >= 5 && myshooters.canShoot)
            {
                myshooters.gameTapCollider.enabled = true;
                myshooters.enabled = true;
            }
            if (myshooters.myLevel == AllLevels.Level10 && Level >= 10 && myshooters.canShoot)
            {
                myshooters.gameTapCollider.enabled = true;
                myshooters.enabled = true;
            }
            if (myshooters.myLevel == AllLevels.Level15 && Level >= 15 && myshooters.canShoot)
            {
                myshooters.gameTapCollider.enabled = true;
                myshooters.enabled = true;
            }
        }
    }  
    // Start is called before the first frame update
    void Start()
    {        
        Level = PlayerPrefs.GetInt("Level", 1);
        levelIndex = 0;      
    }
    private void Update()
    {
        LockShooters();
        levelText.text = "Level:" + Level.ToString();

        if (slider.value >= nextLevelExp[levelIndex])
        {
            canLevelUp = true;
        }
        else
            canLevelUp = false;
    }
    public void FillSlider(float amount)
    {
        slider.value += amount;
        bankManager.currentExp += (int)amount;
    }
    public void CanLevelUp()
    {
        Debug.Log(nextLevelExp[levelIndex]+"current1");
        if (slider.value >= nextLevelExp[levelIndex])      
        {         
            canLevelUp = true;
            if (canLevelUp)
            {
                if (slider.value >= nextLevelExp[levelIndex] )
                    slider.value = 0;

                slider.value -= nextLevelExp[levelIndex];
                Level++;
                levelIndex++;

                slider.maxValue = nextLevelExp[levelIndex];
                Debug.Log(nextLevelExp[levelIndex] + "current2");
            }
        }
        
    }
    
    
}
