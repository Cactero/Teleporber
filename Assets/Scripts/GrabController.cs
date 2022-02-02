using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public KeyCode Grab;
    public PlayerMovement playerMovement;
    public OrbBehavior orbBehavior;

    public Transform grabDetect;
    public Transform orbHolder;
    public float rayDist;
    public bool isHoldingSomething;
    
    public GameObject activeOrb;
    public GameObject lastActiveOrb = null;
    public GameObject grabCheckedOrb;

    public Sprite inactiveOrbSprite;
    public Sprite activeOrbSprite;
    
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        
        if (grabCheck.collider != null && grabCheck.collider.tag == "Orb")
        {
            grabCheckedOrb = grabCheck.collider.gameObject;
            if (Input.GetKeyDown(Grab) && !isHoldingSomething)
            {   
                grabCheckedOrb.transform.parent = orbHolder;
                grabCheckedOrb.transform.position = orbHolder.position;
                grabCheckedOrb.GetComponent<Rigidbody2D>().isKinematic = true;

                isHoldingSomething = true;
                
                lastActiveOrb.GetComponent<SpriteRenderer>().sprite = inactiveOrbSprite;
                lastActiveOrb.layer = LayerMask.NameToLayer("orbLayer");
                activeOrb = grabCheckedOrb;
                activeOrb.GetComponent<SpriteRenderer>().sprite = activeOrbSprite;
                activeOrb.layer = LayerMask.NameToLayer("activeOrbLayer");
            }

            else if (Input.GetKeyDown(Grab) && isHoldingSomething)
            {
                grabCheckedOrb.transform.parent = null;
                grabCheckedOrb.GetComponent<Rigidbody2D>().isKinematic = false;
                grabCheckedOrb.GetComponent<Rigidbody2D>().velocity = playerMovement.rb.velocity;

                isHoldingSomething = false;

                lastActiveOrb = activeOrb;
            }
        }
    }
}
