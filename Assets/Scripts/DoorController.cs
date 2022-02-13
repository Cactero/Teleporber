using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        {
            animator = GetComponent<Animator>();
        }
    }
    public void OpenDoor()
    {
        animator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("DoorOpen", false);
    }
}
