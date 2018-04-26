using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    //Nav Mesh
    public NavMeshAgent navMeshAgent;

    //Nav Mesh Target Variables
    public GameObject[] targets;
    private int currentTargetIdx;
    private Vector3 targetPosition;
    
    //Player Camera
    private GameObject playerCamera;

    //Animator
    private NPC_Animator npcAnimator;

    //Sprite Object
    public GameObject spriteObject;    

    // Use this for initialization
    void Start ()
    {
        //Find Player Camera
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //Get Nav Mesh Component
        navMeshAgent = GetComponent<NavMeshAgent>();

        //Get Animator Script
        npcAnimator = GetComponentInChildren<NPC_Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Get next target in array if we reached intended target (wrap enabled)
        if (navMeshAgent.remainingDistance < 1.0f)
        {
            currentTargetIdx = (currentTargetIdx + 1) % targets.Length;
        }

        //Update target position from current target in array
        targetPosition = targets[currentTargetIdx].transform.position;

        //Update Nav Mesh Destination
        navMeshAgent.SetDestination(targetPosition);

        //Movement Check
        bool localIsWalking = (Vector3.Distance(transform.position, targets[currentTargetIdx].transform.position) > 1.0f);
        npcAnimator.isWalking = localIsWalking;

        if(localIsWalking == true)
        {
            //Horizontal Check
            float xMovement = Vector3.Dot(navMeshAgent.velocity, playerCamera.transform.right);
            spriteObject.transform.localScale = new Vector3(xMovement >= 0 ? 1.0f : -1.0f, 1.0f, 1.0f);

            //Vertical Check
            float zMovement = Vector3.Dot(navMeshAgent.velocity, playerCamera.transform.forward);
            npcAnimator.walkDirectionVertical = zMovement;
        }
    }
}
