using System;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var currentColisionItemTag = other.tag;
        
        if(!string.IsNullOrEmpty(currentColisionItemTag) && !string.Equals(currentColisionItemTag, "Boundary", StringComparison.OrdinalIgnoreCase))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } 
    }
}