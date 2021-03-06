using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public float speed = 1f;
    public float stopDistance = 0.1f;
    public int requiredPlaySeconds = 10;
    public int angrySeconds = 5;
    public GameObject happyEmotion;
    public GameObject angryEmotion;
    private float currentAngry = 0;
    private ArcadeMachine targetMachine;
    private int currentStep = 0;
    private IsometricCharacterAnimation isoAnimation;
    private SpriteRenderer spriteRenderer;
    private Color32[] colors = new Color32[] { new Color32(0, 12, 24, 0), new Color32(120, 0, 0, 0), new Color32(0, 24, 0, 0) };

    private GamerScenarioStage stage = GamerScenarioStage.Enter;
    private Transform exitPoint;
    private bool happy = true;
    enum GamerScenarioStage 
    {
        Enter,
        Playing,
        Exit
    }


    private void Awake()
    {
        isoAnimation = GetComponentInChildren<IsometricCharacterAnimation>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        int random = Random.Range(0, colors.Length);

        spriteRenderer.material.SetColor("_EmissionColor", colors[random]);

        // transform.position = new Vector3(transform.position.x, transform.position.y, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == GamerScenarioStage.Enter) {
            if (targetMachine == null) {
                isoAnimation.SetDirection(new Vector2());
                return;
            }
            if (currentStep > targetMachine.getStepCount()) {
                isoAnimation.SetDirection(new Vector2());
                stage = GamerScenarioStage.Playing;
                targetMachine.OnGamerStartPlaying();
                
                StartCoroutine(PlayerPlayOnMachineCoroutine());
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
        } else if (stage == GamerScenarioStage.Exit) {
            if (currentStep == -3) {
                return;
            } else if (currentStep == -2) {
                OnExitDoor();
                currentStep = -3;
                return;
            }

            Vector2 destination;

            if (currentStep == -1) {
                if (exitPoint == null) {
                    exitPoint = GamerWave.Instance.GetRandomExitPoint();
                }

                destination = new Vector2(exitPoint.position.x, exitPoint.position.y);
            } else {
                destination = targetMachine.getDestination(currentStep);
            }

            float distance = Vector2.Distance(transform.position, destination);

            if (distance < stopDistance) {
                currentStep--;
                return;
            }

            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            Vector2 move = Vector2.MoveTowards(transform.position, destination, step);

            isoAnimation.SetDirection(move - new Vector2(transform.position.x, transform.position.y));
            transform.position = new Vector3(move.x, move.y, transform.position.z);
        }
    }

    public void SetTargetMachine(ArcadeMachine arcadeMachine) {
        targetMachine = arcadeMachine;
        targetMachine.OnGamerTarget();
    }

    IEnumerator PlayerPlayOnMachineCoroutine()
    {
        float currentPlayTime = 0;
        for (;;) {
            if (targetMachine.isWorking) {
                currentPlayTime += 0.5f;

                if ((int) currentPlayTime >= requiredPlaySeconds) {
                    this.happy = true;
                    break;
                }
            } else {
                currentAngry += 0.5f;
                if ((int) currentAngry >= angrySeconds) {
                    this.happy = false;
                    break;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }

        if (this.happy) {
            happyEmotion.SetActive(true);
        } else {
            angryEmotion.SetActive(true);
        }

        currentStep--;
        stage = GamerScenarioStage.Exit;
        targetMachine.OnGamerStopPlaying();
    }

    private void OnExitDoor() {
        if (happy) {
            GameManager.Instance.AddScore(1);
            GameManager.Instance.AddCustomerSatisfaction(+1);
            AudioManager.Instance.Play("CustomerHappy");
        } else {
            GameManager.Instance.AddCustomerSatisfaction(-1);
            AudioManager.Instance.Play("CustomerSad");
        }

        StartCoroutine(DestroyWithDelay());
    }

    // Play effect while player is playing on this machine
    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
