using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightRotator : MonoBehaviour
{
    public float min;
    public float max;
    public float speed = 10f;
    private Light2D light2D;
    private bool increase = true;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (increase) {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
            if (transform.localEulerAngles.z >= max) {
                increase = false;
            }
        } else {
            transform.Rotate(new Vector3(0f, 0f, -speed * Time.deltaTime));
            if (transform.localEulerAngles.z <= min) {
                increase = true;
            }
        }
    }
}
