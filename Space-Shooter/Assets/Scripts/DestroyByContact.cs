using System;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;

    void OnTriggerEnter(Collider other)
    {
        var currentColisionItemTag = other.tag;
        
        if(!string.IsNullOrEmpty(currentColisionItemTag) && !string.Equals(currentColisionItemTag, "Boundary", StringComparison.OrdinalIgnoreCase))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (string.Equals(currentColisionItemTag, "Player", StringComparison.OrdinalIgnoreCase))
            {
                Instantiate(PlayerExplosion, transform.position, transform.rotation);
            }
        }
    }
}