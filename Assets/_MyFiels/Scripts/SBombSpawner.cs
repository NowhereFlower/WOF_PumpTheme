using System.Collections;
using UnityEngine;

public class SBombSpawner : MonoBehaviour
{
    public GameObject BombPumpkin;

    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1.0f;
    private void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIn = Random.Range(0, spawnPoints.Length);
            Transform spawnpoint = spawnPoints[spawnIn];

            GameObject spawnedBombPumpkin = Instantiate(BombPumpkin, spawnpoint.position, spawnpoint.rotation);
            Destroy(spawnedBombPumpkin, 5f);
        }
    }
}
