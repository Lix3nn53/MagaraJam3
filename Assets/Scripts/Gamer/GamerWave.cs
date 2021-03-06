using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerWave : MonoBehaviour
{
    public static GamerWave Instance;
    public int gamerPerSpawn = 1;
    public int cooldown = 5;
    private GamerSpawner[] spawners;
    private int nextSpawner = 0;
    private int spawnCountDown = 0;

    void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawners = GetComponentsInChildren<GamerSpawner>();

        InvokeRepeating("RunEverySecond", 1, 1);
    }

    private void RunEverySecond()
    {
        if (spawnCountDown > 0) {
            spawnCountDown--;
        } else {
            for (int i = 0; i < gamerPerSpawn; i++) {
                bool spawned = spawnGamer();
                if (!spawned) break;
            }
            spawnCountDown = cooldown;
        }
    }

    public bool spawnGamer() {
        ArcadeMachine machine = ArcadeMachineManager.Instance.GetAvailable();
        if (machine != null) {
            spawners[nextSpawner].spawnGamer(machine);

            nextSpawner++;
            if(nextSpawner == spawners.Length) {
                nextSpawner = 0;
            }
            return true;
        }
        return false;
    }

    public Transform GetRandomExitPoint() {
        int random = Random.Range(0, spawners.Length);

        return spawners[random].transform;
    }
}
