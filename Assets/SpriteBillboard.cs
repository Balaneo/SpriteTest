using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    //Player Camera
    private GameObject playerCamera;

	// Use this for initialization
	void Start ()
    {
        //Find player camera
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Set Look At target based on player camera but ignoring Y-Axis
        Vector3 targetPostition = new Vector3(  playerCamera.transform.position.x,
                                                transform.position.y,
                                                playerCamera.transform.position.z
                                                );

        //Look at target
        transform.LookAt(targetPostition);
    }
}
