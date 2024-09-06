using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //initialize variables for the camera views
    
    public Camera driverCamera;
    public Camera mainCamera;

    //variable yo track which camera is currently active
    private bool isMainCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        //store a reference to the main camera at the start
        //mainCamera = Camera.main; //this code is causing an error when reverting back to main camera from driver camera

        //ensure the main camera is active and driver camera is inactive at the start
        mainCamera.enabled = true; //refers to the main camera in the scene
        driverCamera.enabled = false;

        //disable  the driver camera's audio listener
        driverCamera.GetComponent<AudioListener>().enabled = false;

        Debug.Log("Main Camera is active at start,");
    }

    // Update is called once per frame
    void Update()
    {
        //check if "z" key is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //toggle the camera views
            ToggleCamera();
        }
        
    }


    void ToggleCamera()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found! Make sure it's tagges as 'Main Camera");
            return;
        }

        //if the main camera is currently active, switch to the driver camera
         if (isMainCameraActive)
         {
            mainCamera.enabled = false;
            driverCamera.enabled = true;
            Debug.Log("Switch to Driver Camera");

            //disable main camera's audiolistener and enable driver camera's audiolistener
            mainCamera.GetComponent<AudioListener>().enabled = false;
            driverCamera.GetComponent<AudioListener>().enabled = true;

            Debug.Log("Switch to Driver Camera");
         }
         else
         {
             mainCamera.enabled = true;
             driverCamera.enabled = false;

            //enable main camera's audiolistener and disable driver camera's audiolistener
            mainCamera.GetComponent<AudioListener>().enabled = true;
            driverCamera.GetComponent<AudioListener>().enabled = false;

            Debug.Log("Switch to main Camera");
         }

          //update the active camera state
          isMainCameraActive = !isMainCameraActive;
          Debug.Log("Camera toggled: isMainCameraActive = " + isMainCameraActive);

    }
}
