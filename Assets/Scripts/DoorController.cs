using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed;

    void Start() {
        {
            startPosition = transform.position;
            endPosition = new Vector2 (transform.position.x, transform.position.y + 2);
        }
    }
    public void OpenDoor()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(startPosition, endPosition, step);
    }

    public void CloseDoor()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(endPosition, startPosition, step);
    }
}
