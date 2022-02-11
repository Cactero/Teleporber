using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [Header("Controls")]
    public KeyCode teleport;
    [Header("Layers")]
    public LayerMask orbLayer;
    public LayerMask activeOrbLayer;
    [Header("Vectors")]
    public Vector2 playerDestination;
    public Vector2 orbDestination;
    [Header("Values")]
    public float teleportRadius;
    public bool canTeleport;

    public bool isOrbInRadius;

    private GrabController grabController;

    void Start()
    {
        grabController = GetComponent<GrabController>();
    }

    void Update()
    {
        isOrbInRadius = Physics2D.OverlapCircle(transform.position, teleportRadius, activeOrbLayer);
        if (Input.GetKeyDown(teleport) && !grabController.isHoldingSomething && isOrbInRadius)
        {
            Teleport();
        }
        else if (Input.GetKeyDown(teleport) && !isOrbInRadius)
        {
                Debug.Log("You have to be close to the orb to teleport!");
        }
    }

    void Teleport()
    {   
        playerDestination = new Vector2 (grabController.activeOrb.transform.position.x, grabController.activeOrb.transform.position.y + 0.5f);
        orbDestination = new Vector2 (transform.position.x, transform.position.y + 0.5f);

        transform.position = playerDestination;
        grabController.activeOrb.transform.position = orbDestination;
        grabController.lastActiveOrb.SetActive(false);
    }

    private void OnDrawGizmosSelected() {
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere (transform.position, teleportRadius);
 }
 
}

/*
TO-DO:
Make it so if two orbs are in range of the player, teleport to the one that was last held. Else, teleport to the other one.
*/