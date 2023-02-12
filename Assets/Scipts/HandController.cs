using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;


    public float speed = 2f;
    public float handRotSpeed = 20f;

    public float handspeed;
    public float angle = 280f;
    public bool isGrab = false;


    float totalLeftAngle = 0;
    float totalRightAngle = 0 ;

    bool actionOne = false;
   
    void Update()
    {
        float leftJoy = Input.GetAxis("ControllerHorizontal");
        float rightjoy = Input.GetAxis("ControllerVertical");


        //Debug.Log("l"+leftJoy+"   "+rightjoy);
        if (leftJoy == 1&&!isGrab)
        {
           

            if (totalLeftAngle < angle)
            {
                rotOne(one);
                rot(two);
                rot(three);
                totalLeftAngle += handRotSpeed * Time.deltaTime;
               // Debug.Log("Angle: " + totalLeftAngle);
            }
            else
            {
                totalLeftAngle = angle;
            }
        }
        if (leftJoy==0) {
            

            if (totalLeftAngle > 0)
            {
                InverseRotOne(one);
                InverseRot(two);
                InverseRot(three);
                totalLeftAngle -= handRotSpeed * Time.deltaTime;
            }
            else
            {
                totalLeftAngle = 0;
            }
        }





        if (rightjoy == 1 && !isGrab)
        {
            if (totalRightAngle < angle)
            {
                rot(four);
                rot(five);
                totalRightAngle += handRotSpeed * Time.deltaTime;
            }
            else
            {
                totalRightAngle = angle;
            }
        }

        if (rightjoy==0) {
            if (totalRightAngle > 0)
            {
                InverseRot(four);
                InverseRot(five);
                totalRightAngle -= handRotSpeed * Time.deltaTime;

            }
            else { 
            totalRightAngle= 0;
            }
        }

        if (leftJoy == 1 && rightjoy == 1 && totalLeftAngle == angle && totalRightAngle == angle)
        {
            isGrab = true;
        }
        else { 
            isGrab= false;
        }

        //if (Input.GetButton("Jump")) {
        //    actOne();
        //}

        if (Input.GetButton("LeftBumper")) {
            transform.Rotate(Vector3.forward, -handspeed * Time.deltaTime);
        }
        if (Input.GetButton("RightBumper"))
        {
            transform.Rotate(Vector3.forward, handspeed * Time.deltaTime);
        }


    }

 
    void rot(GameObject b)
    {
    
            //  curAngle = 90;
            b.transform.Rotate(Vector3.right,-angle*Time.deltaTime*speed);
            b.transform.GetChild(0).Rotate(Vector3.right, -angle * Time.deltaTime * speed);
            b.transform.GetChild(0).GetChild(0).Rotate(Vector3.right, -angle * Time.deltaTime * speed* 2);
     
      
    }

    void InverseRot(GameObject b)
    {
      
            b.transform.Rotate(Vector3.right, angle * Time.deltaTime * speed);
            b.transform.GetChild(0).Rotate(Vector3.right, angle * Time.deltaTime * speed);
            b.transform.GetChild(0).GetChild(0).Rotate(Vector3.right, angle * Time.deltaTime * speed*2);

      
       
    }
    void rotOne(GameObject o)
    {
       
            o.transform.Rotate(Vector3.right, -angle * Time.deltaTime );
            o.transform.GetChild(0).Rotate(Vector3.right, -angle*Time.deltaTime*2);
    }
    void InverseRotOne(GameObject o)
    {
        o.transform.Rotate(Vector3.right, angle * Time.deltaTime);
        o.transform.GetChild(0).Rotate(Vector3.right, angle * Time.deltaTime * 2);
    }


    void actOne() {
        if (!actionOne)
        {
            rotOne(one);
            rot(two);
            rot(four);
            rot(five);
        }
        else { 
        InverseRotOne(one);
            InverseRot(two);
            InverseRot(four);
            InverseRot(five);
        
        }

      
    }
}
