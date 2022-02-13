using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [Header("Controls")]
    public KeyCode Grab;
    [Header("Objects")]
    public GameObject activeOrb;
    public GameObject lastActiveOrb = null;
    public GameObject grabCheckedOrb;
    [Header("Sprites")]
    public Sprite inactiveOrbSprite;
    public Sprite activeOrbSprite;
    [Header("Transforms")]
    public Transform grabDetect;
    public Transform orbHolder;

    [Header("Scripts")]
    private PlayerMovement playerMovement;

    [Header("Values")]
    public float rayDist;
    public bool isHoldingSomething;
    private bool isInWall;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Orb")
        {
            grabCheckedOrb = grabCheck.collider.gameObject;
            if (isInWall)
            {
                return;
            }

            if (Input.GetKeyDown(Grab) && !isHoldingSomething)
            {
                grabCheckedOrb.transform.parent = orbHolder;
                grabCheckedOrb.transform.position = orbHolder.position;
                grabCheckedOrb.GetComponent<Rigidbody2D>().isKinematic = true;

                isHoldingSomething = true;

                if (lastActiveOrb != null)
                {
                    lastActiveOrb.GetComponent<SpriteRenderer>().sprite = inactiveOrbSprite;
                    lastActiveOrb.layer = LayerMask.NameToLayer("orbLayer");
                }

                activeOrb = grabCheckedOrb;
                activeOrb.GetComponent<SpriteRenderer>().sprite = activeOrbSprite;
                activeOrb.layer = LayerMask.NameToLayer("activeOrbLayer");
            }
        }

        else if (Input.GetKeyDown(Grab) && isHoldingSomething)
        {
            activeOrb.transform.parent = null;
            activeOrb.GetComponent<Rigidbody2D>().isKinematic = false;
            activeOrb.GetComponent<Rigidbody2D>().velocity = playerMovement.rb.velocity;

            isHoldingSomething = false;

            lastActiveOrb = activeOrb;
        }
    }


    /* 
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("whatIsGround"))
            {
                CircleCollider2D orbHolderCollider = orbHolder.GetComponent<CircleCollider2D>();
                orbHolderCollider.radius = 0.2f;
                isInWall = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("whatIsGround"))
            {
                CircleCollider2D orbHolderCollider = orbHolder.GetComponent<CircleCollider2D>();
                orbHolderCollider.radius = 0f;
                isInWall = false;
            }
        } */

    private void OnDrawGizmosSelected()
    {
        if (transform.localScale.x > 0)
        {
            Debug.DrawRay(grabDetect.position, Vector3.right * rayDist, Color.cyan);
        }
        else
        {
            Debug.DrawRay(grabDetect.position, Vector3.left * rayDist, Color.cyan);
        }
    }
}
