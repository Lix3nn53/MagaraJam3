using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Experimental.Rendering.Universal;

public class ArcadeMachine : MonoBehaviour
{
    public Transform[] steps;
    private Color startEmissionColor;

    private bool isEmpty = true;
    private bool isWorking = true;
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
            return new Vector2(transform.position.x + 0.1f, transform.position.y - 0.1f);        
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
        if (working) {
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
    
    private void OnTriggerEnter2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        player.KeyGuideChange("E");
        player.KeyGuideEnable();
    }
    private void OnTriggerExit2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        player.KeyGuideDisable();
    }
}
