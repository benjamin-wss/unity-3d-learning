using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 BaseSpawnPosition;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;

    public Text ScoreText;
    private int _score;

    void Start()
    {
        _score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves(Hazard, BaseSpawnPosition, HazardCount, SpawnWait, StartWait, WaveWait));
    }

    private static IEnumerator SpawnWaves(
        [NotNull] GameObject hazzard, 
        Vector3 baseSpawnPosition, 
        int hazardCount, 
        float spawnWait,
        float startWait, 
        float waveWait)
    {
        if (hazzard == null) throw new ArgumentNullException("hazzard");

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (var i = 0; i < hazardCount; i++)
            {
                var reandomizedXAxisPosition = Random.Range(-baseSpawnPosition.x, baseSpawnPosition.x);
                var randomizedSpawnPosition = new Vector3(
                    reandomizedXAxisPosition,
                    baseSpawnPosition.y,
                    baseSpawnPosition.z);

                var spawnRotation = Quaternion.identity;

                Instantiate(hazzard, randomizedSpawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }

    public void AddScore(int kill)
    {
        _score += kill;
        UpdateScore();
    }

    private void UpdateScore()
    {
        const string scoreTextTemplate = "Score: {0}";

        ScoreText.text = string.Format(scoreTextTemplate, _score);
    }
}
