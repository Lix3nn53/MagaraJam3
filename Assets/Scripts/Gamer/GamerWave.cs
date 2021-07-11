using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerWave : MonoBehaviour
{
    private GamerSpawner[] spawners;
    private int nextSpawner = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawners = GetComponentsInChildren<GamerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnGamer();
    }

    public void spawnGamer() {
        ArcadeMachine machine = ArcadeMachineManager.Instance.GetAvailable();
        if (machine != null) {
            spawners[nextSpawner].spawnGamer();

            nextSpawner++;
            if(nextSpawner == spawners.Length) {
                nextSpawner = 0;
            }
        }
    }
}
