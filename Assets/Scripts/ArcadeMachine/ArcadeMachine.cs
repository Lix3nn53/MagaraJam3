using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{
    public bool isEmpty = true;
    public List<Transform> steps;

    // Start is called before the first frame update
    void Start()
    {
       GameManager.Instance.arcadeMachines.Add(this);
    }

    public Vector2 getDestination(int step) {
        if (steps.Count == step) {
            return new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f);        
        } else {
            Transform stepTransform = steps[step].transform;
            return new Vector2(stepTransform.position.x, stepTransform.position.y);
        }
    }

    public int getStepCount() {
        return steps.Count;
    }
}
