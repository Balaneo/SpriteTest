using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animator : MonoBehaviour
{
    public enum EDirection
    {
        SouthEast,
        SouthWest
    };

    //Animator
    private Animator _animator;

    public AnimatorOverrideController _animController;

    //Animator Controller variables.
    public bool isWalking;
    public float walkDirectionVertical;

	// Use this for initialization
	void Start ()
    {
        //Get Animator Component
        _animator = GetComponent<Animator>();
        _animator.runtimeAnimatorController = _animController;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update Animator Controller Variables
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetFloat("WalkDirectionVertical", walkDirectionVertical);
	}

    //Sets NPC Direction with raw float value. -1 for left, 1 for right.
    public void SetNPCDirection(float newDirection)
    {
        this.transform.localScale = new Vector3(newDirection, 1.0f, 1.0f);
    }

    //Sets NPC Direction with enum value. Easier to understand but more costly.
    public void SetNPCDirection(EDirection newDirection)
    {
        switch(newDirection)
        {
            case EDirection.SouthEast:
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;

            case EDirection.SouthWest:
                this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                break;

            default:
                print("Invalid argument passed in SetNPCDirection()");
                break;
        }
    }
}
