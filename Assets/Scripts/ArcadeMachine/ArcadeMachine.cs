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
    private Renderer rendererArcade;
    private Light2D light2D;

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

    public void setWorking(bool working) {
        isWorking = working;
        if (isWorking) {
            light2D.intensity = 0.4f;
            rendererArcade.material.SetColor("_EmissionColor", startEmissionColor);
        } else {
            light2D.intensity = 0f;
            rendererArcade.material.SetColor("_EmissionColor", new Color());
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
            float errorChance = Random.Range(0.0f, 1.0f);

            if (errorChance < 0.1f) {
                setWorking(false);
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
        setWorking(true);
    }
}
