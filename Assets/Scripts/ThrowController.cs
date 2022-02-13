using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    //public KeyCode throw;
    [SerializeField] private Vector2 throwingForce;
    public Vector3 mousePosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
