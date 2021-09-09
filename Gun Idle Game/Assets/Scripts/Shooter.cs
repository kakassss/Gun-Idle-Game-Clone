using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public enum AllLevels
{
    Level5,
    Level10,
    Level15
};
public class Shooter : MonoBehaviour
{
    public static Shooter instance;
    
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileSpawn;

    private bool mouseClick;

    private IEnumerator shootOto;

    private ShootManager sm;


    [HideInInspector]
    public int projectileSpeed;
    [HideInInspector]
    public int projectileMoney;
    [HideInInspector]
    public int projectileExp;


    public Collider2D gameTapCollider;
    public bool canShoot;

    public AllLevels myLevel;
    private void Awake()
    {
        instance = this;

        shootOto = ShootbyScript();
        mouseClick = false;

        projectileSpeed = PlayerPrefs.GetInt(gameObject.name, 1);
        projectileMoney = PlayerPrefs.GetInt(gameObject.name, 5);
        projectileExp = PlayerPrefs.GetInt("pExp", 3);

        PlayerPrefs.DeleteAll();
        sm = GetComponent<ShootManager>();
    }
    private void Start()
    {
        StartCoroutine(shootOto);
    }
    private void Update()
    {
        Debug.Log(projectileSpeed);
    }
    private void OnMouseDown()
    {
        StopCoroutine(shootOto);
        mouseClick = true;

        GameObject projectileGo = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
        projectileGo.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
    }
    private void OnMouseUp()
    {
        mouseClick = false;
        StartCoroutine(shootOto);
    }
    private void OtomaticShoot()
    {
        if (!mouseClick)
        {
            StartCoroutine(ShootbyScript());
        }
    }
    private IEnumerator ShootbyScript()
    {
        while (!mouseClick)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject projectileGo = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            projectileGo.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        }
    }
    
}
