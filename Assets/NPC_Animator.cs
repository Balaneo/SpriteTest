using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animator : MonoBehaviour
{
    //Animator
    private Animator _animator;

    //Animator Controller variables.
    public bool isWalking;
    public float walkDirectionVertical;

	// Use this for initialization
	void Start ()
    {
        //Get Animator Component
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update Animator Controller Variables
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetFloat("WalkDirectionVertical", walkDirectionVertical);
	}
}
