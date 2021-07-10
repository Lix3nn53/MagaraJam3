using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public Transform arcade;
    public float speed = 1f;
    public float stopDistance = 0.1f;
    private Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector2(arcade.position.x, arcade.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, destination);

        if (distance < stopDistance) return; 

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        Vector2 move = Vector2.MoveTowards(transform.position, destination, step);

        transform.position = new Vector3(move.x, move.y, transform.position.z);
    }
}
