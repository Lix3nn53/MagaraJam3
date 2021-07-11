using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public float speed = 1f;
    public float stopDistance = 0.1f;
    private ArcadeMachine targetMachine;
    private int currentStep = 0;
    private IsometricCharacterAnimation isoAnimation;
    private SpriteRenderer spriteRenderer;
    private Color32[] colors = new Color32[] { new Color32(0, 12, 24, 0), new Color32(120, 0, 0, 0), new Color32(0, 24, 0, 0) };

    private void Awake()
    {
        isoAnimation = GetComponentInChildren<IsometricCharacterAnimation>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        int random = Random.Range(0, colors.Length);

        spriteRenderer.material.SetColor("_EmissionColor", colors[random]);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetMachine == null) {
            isoAnimation.SetDirection(new Vector2());
            return;
        }
        if (currentStep > targetMachine.getStepCount()) {
            isoAnimation.SetDirection(new Vector2());
            return;
        }

        Vector2 destination = targetMachine.getDestination(currentStep);

        float distance = Vector2.Distance(transform.position, destination);

        if (distance < stopDistance) {
            currentStep++;
            return;
        }

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        Vector2 move = Vector2.MoveTowards(transform.position, destination, step);

        isoAnimation.SetDirection(move - new Vector2(transform.position.x, transform.position.y));
        transform.position = new Vector3(move.x, move.y, transform.position.z);
    }

    public void SetTargetMachine(ArcadeMachine arcadeMachine) {
        targetMachine = arcadeMachine;
        targetMachine.OnGamerTarget();
    }
}
