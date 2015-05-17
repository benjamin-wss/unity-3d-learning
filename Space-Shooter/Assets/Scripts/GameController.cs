using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Hazzard;
    public Vector3 BaseSpawnPosition;

    void Start()
    {
        var randomizedSpawnPosition = new Vector3(Random.Range(-BaseSpawnPosition.x, BaseSpawnPosition.x), BaseSpawnPosition.y, BaseSpawnPosition.z);
        var spawnRotation = Quaternion.identity;
        SpawnWaves(Hazzard, randomizedSpawnPosition, spawnRotation);
    }

    private static void SpawnWaves(GameObject hazzard, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(hazzard, spawnPosition, spawnRotation);
    }
}
