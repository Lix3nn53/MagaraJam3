using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerSpawner : MonoBehaviour
{
    public GameObject[] gamerPrefabs;

    public void spawnGamer(ArcadeMachine arcadeMachine) {
        int random = Random.Range(0, gamerPrefabs.Length);

        GameObject gamerPrefab = gamerPrefabs[random];

        GameObject go = Instantiate(gamerPrefab, transform.position, Quaternion.identity);

        Gamer gamer = go.GetComponent<Gamer>();
        gamer.SetTargetMachine(arcadeMachine);
    }
}
