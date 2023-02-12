using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    const float k_MouseSensitivityMultiplier = 0.01f;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    Vector2 lastVlo = new Vector2(0f, 0f);

    float speed = 0f;

    public float ControllerSensitivity = 90f;
        AudioClip a;
    // Start is called before the first frame update
    void Start()
    {
     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        bool unlockPressed = false, lockPressed = false;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * k_MouseSensitivityMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * k_MouseSensitivityMultiplier;

        float controllerX = Input.GetAxis("ControllerX") * ControllerSensitivity * k_MouseSensitivityMultiplier*10f;
        float controllerY = -Input.GetAxis("ControllerY") * ControllerSensitivity * k_MouseSensitivityMultiplier*10f;


        controllerX = float.Parse(controllerX.ToString("f1"));  
        controllerY = float.Parse(controllerY.ToString("f1"));

        speed =Mathf.Abs( (mouseX - lastVlo.x) + (mouseY - lastVlo.y)*50);
        lastVlo  = new Vector2(mouseX, mouseY);


      //  Debug.Log("Speed: " + speed);
        unlockPressed = Input.GetKeyDown(KeyCode.Escape);
        lockPressed = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);

       // Debug.Log("MouseX: "+ controllerX + "  MouseY:  "+ controllerY);
      
        if (unlockPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (lockPressed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        if (controllerX != 0 || controllerY != 0)
        {
            xRotation -= controllerY;
        }

        if (mouseX!=0||mouseY!=0) {
            xRotation -= mouseY;
        }
           
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
         

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
            playerBody.Rotate(Vector3.up * controllerX);
    }
}
