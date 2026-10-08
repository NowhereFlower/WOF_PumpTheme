using System.Collections;
using UnityEngine;

public class SFruitSpawner : MonoBehaviour
{
    public GameObject Pumpkin;

    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1.0f;
    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIn = Random.Range(0, spawnPoints.Length);
            Transform spawnpoint = spawnPoints[spawnIn];

            GameObject spawnedPumpkin = Instantiate(Pumpkin, spawnpoint.position, spawnpoint.rotation);
            Destroy(spawnedPumpkin, 5f);
        }
    }
}
