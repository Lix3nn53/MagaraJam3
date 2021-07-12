using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Experimental.Rendering.Universal;

public class ArcadeMachine : Interractable
{
    public Transform[] steps;
    private Color startEmissionColor;

    public bool isEmpty = true;
    public bool isWorking = true;
    public float errorChance = 0.1f;
    public GameObject faultElectricIcon;
    public GameObject faultDiskIcon;
    private Renderer rendererArcade;
    private Light2D light2D;
    private FaultType faultType = FaultType.Electric;

    public enum FaultType 
    {
        Electric,
        Disk,
    }

    // Start is called before the first frame update
    void Start()
    {
       rendererArcade = GetComponentInChildren<Renderer>();
       startEmissionColor = rendererArcade.material.GetColor("_EmissionColor");
       light2D = GetComponentInChildren<Light2D>();
    }

    public Vector2 getDestination(int step) {
        if (steps.Length == step) {
            return new Vector2(transform.position.x + 0.6f, transform.position.y - 0.1f);        
        } else {
            Transform stepTransform = steps[step].transform;
            return new Vector2(stepTransform.position.x, stepTransform.position.y);
        }
    }

    public int getStepCount() {
        return steps.Length;
    }

    public bool isAvailable() {
        return isEmpty && isWorking;
    }

    // TODO add error type
    public void setWorking(bool working, FaultType faultType) {
        isWorking = working;
        if (isWorking) {
            light2D.intensity = 0.4f;
            rendererArcade.material.SetColor("_EmissionColor", startEmissionColor);
                faultElectricIcon.SetActive(false);
                faultDiskIcon.SetActive(false);
        } else {
            light2D.intensity = 0f;
            rendererArcade.material.SetColor("_EmissionColor", new Color());
            AudioManager.Instance.Play("MachineShowdownElectric");
            this.faultType = faultType;

            if (faultType == FaultType.Electric) {
                faultElectricIcon.SetActive(true);
            } else if (faultType == FaultType.Disk) {
                faultDiskIcon.SetActive(true);
            }
        }
    }

    public void OnGamerTarget() {
        isEmpty = false;
    }

    public void OnGamerStartPlaying() {
        StartCoroutine(GamerPlayingEffectCoroutine());
    }

    // Play effect while player is playing on this machine
    IEnumerator GamerPlayingEffectCoroutine()
    {
        bool tickOne = true;
        for (;;) {
            float errorRandom = Random.Range(0.0f, 1.0f);

            if (errorRandom < errorChance) {
                int faultRandom = Random.Range(0, 2);
                if (faultRandom == 0) {
                    setWorking(false, FaultType.Electric);
                } else {
                    setWorking(false, FaultType.Disk);
                }
            }

            if (!isWorking || isEmpty) {
                break;
            }

            if (tickOne) {
                light2D.intensity = 0.4f;
            } else {
                light2D.intensity = 0f;
            }

            tickOne = !tickOne;

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnGamerStopPlaying() {
        isEmpty = true;
        if (isWorking) {
            light2D.intensity = 0.4f;
            rendererArcade.material.SetColor("_EmissionColor", startEmissionColor);
        } else {
            light2D.intensity = 0f;
            rendererArcade.material.SetColor("_EmissionColor", new Color());
        }
    }
    public override void OnInterract() {
        if (!Player.Instance.HasTool()) return;

        if (Player.Instance.GetCurrentTool() == faultType) {
            setWorking(true, FaultType.Electric);
            AudioManager.Instance.Play("MachineStart");
            Player.Instance.SetHasTool(false);
        }
    }
}
