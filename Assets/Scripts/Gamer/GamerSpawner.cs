using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerSpawner : MonoBehaviour
{
    public GameObject gamerPrefab;

    public void spawnGamer(ArcadeMachine arcadeMachine) {
        GameObject go = Instantiate(gamerPrefab, transform.position, Quaternion.identity);

        Gamer gamer = go.GetComponent<Gamer>();
        gamer.SetTargetMachine(arcadeMachine);
    }
}
