using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //public GameObject acceptedObject;
    public enum AcceptedObject
    {
        Anything,
        Orb
    };
        
    [Header("Objects")]
    public AcceptedObject acceptedObject;
    public GameObject affectedDoor;

    //[Header("Values")]    
    //public bool doorAcceptsAnything;
    private DoorController doorController;
    
    void Start()
    {
        doorController = affectedDoor.GetComponent<DoorController>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == acceptedObject.ToString() || acceptedObject == 0)
        {
            ButtonOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == acceptedObject.ToString() || acceptedObject == 0)
        {
            ButtonOff();
        }
    }

    void ButtonOn()
    {
        doorController.OpenDoor();
    }

    void ButtonOff()
    {
        doorController.CloseDoor();
    }
}
