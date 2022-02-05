using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Transform playerCheck;
    public GameObject whatDoorWillAccept;
    
    public bool doorWillAcceptAnything;
    public DoorController doorController;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == whatDoorWillAccept.tag || doorWillAcceptAnything)
        {
            OnButton();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == whatDoorWillAccept.tag || doorWillAcceptAnything)
        {
            OffButton();
        }
    }

    void OnButton()
    {
        doorController.OpenDoor();
    }

    void OffButton()
    {
        doorController.CloseDoor();
    }
}
