using System;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;

    private GameController _targetGameController;
    public int HazardKillScore;

    void Start()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            _targetGameController = gameController.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Unable to find 'GameController' object script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var currentColisionItemTag = other.tag;
        
        if(!string.IsNullOrEmpty(currentColisionItemTag) && !string.Equals(currentColisionItemTag, "Boundary", StringComparison.OrdinalIgnoreCase))
        {
            Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(other.gameObject);
            Destroy(gameObject);
            _targetGameController.AddScore(HazardKillScore);

            if (string.Equals(currentColisionItemTag, "Player", StringComparison.OrdinalIgnoreCase))
            {
                Instantiate(PlayerExplosion, transform.position, transform.rotation);
            }
        }
    }
}