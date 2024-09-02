using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //initialize private variables
    private float speed = 5.0f;  //a member variable
    private float turnSpeed = 30.0f; 
    private float horizontalInput;
    private float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //move vehicle left or right
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        


        
    }
}
