using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float Tumble;

    void Start()
    {
        var currentRidigBody = GetComponent<Rigidbody>();
        currentRidigBody.angularVelocity = Random.insideUnitSphere*Tumble;
    }
}
