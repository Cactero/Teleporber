using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    public Sprite inactiveOrb;
    public Sprite activeOrb;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = inactiveOrb;
    }
    
    public void SetActiveOrb(GameObject Orb)
    {
        Orb.GetComponent<SpriteRenderer>().sprite = activeOrb;
    }

    public void SetInactiveOrb(GameObject Orb)
    {
        Orb.GetComponent<SpriteRenderer>().sprite = inactiveOrb;
    }
}
