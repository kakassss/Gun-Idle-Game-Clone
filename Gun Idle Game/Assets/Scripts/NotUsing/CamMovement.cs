using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float dragspeed = 2;
    private Vector3 dragOrigin;

    [SerializeField] Camera myCam;

    Rigidbody2D myrb;
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        myCam = Camera.main;
    }
    private void Update()
    {

        cc();


    }
    private void LateUpdate()
    {
        Vector3 viewPos = myCam.transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 2220);
        myCam.transform.position = viewPos;
    }


    private Vector3 a1;
    private Vector3 a2;
    private Vector3 a3;

    
    private void cc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            a1 = myCam.ScreenToWorldPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(0))
        {
            a2 = a1 - myCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 move = new Vector2(0, a2.y );

            //myCam.transform.Translate(-move * Time.deltaTime);

            if (Input.GetMouseButtonUp(0))
            {
                myrb.AddForce(-move * Time.deltaTime * dragspeed);


            }
        }
        


    }
    
    
    

    Vector3 move;
    private void CameraMovement1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = myCam.ScreenToWorldPoint(Input.mousePosition);
            return;
        }
        if (!Input.GetMouseButton(0))
            return;

        Vector3 difference = dragOrigin - myCam.ScreenToWorldPoint(Input.mousePosition);
        move = new Vector3(0, difference.y * dragspeed, 0);

        Debug.Log(difference.y);
        //myCam.transform.position += move * Time.deltaTime;
        //myCam.transform.Translate(-move * Time.deltaTime, Space.World);
        if(difference.y >= 0.1f)
        {
            myCam.transform.Translate(-move * Time.deltaTime, Space.World);
        }
        if (difference.y <= 0.1f)
        {
            myCam.transform.Translate(move * Time.deltaTime, Space.World);
        }



    }
    

}
