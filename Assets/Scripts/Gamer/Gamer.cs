using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public float speed = 1f;
    public float stopDistance = 0.1f;
    private ArcadeMachine targetMachine;
    private int currentStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ArcadeMachine arcade in GameManager.Instance.arcadeMachines) {
            if (arcade.isEmpty) {
                targetMachine = arcade;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep > targetMachine.getStepCount()) return;

        Vector2 destination = targetMachine.getDestination(currentStep);

        float distance = Vector2.Distance(transform.position, destination);

        if (distance < stopDistance) {
            currentStep++;
            return;
        }

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        Vector2 move = Vector2.MoveTowards(transform.position, destination, step);

        transform.position = new Vector3(move.x, move.y, transform.position.z);
    }
}
