using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerSpawner : MonoBehaviour
{
    public GameObject gamerPrefab;

    public void spawnGamer() {
        Instantiate(gamerPrefab, transform.position, Quaternion.identity);
    }
}
