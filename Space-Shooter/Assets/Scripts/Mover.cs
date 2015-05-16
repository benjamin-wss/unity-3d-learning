using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed;

    /// <summary>
    /// Initialize function. 
    /// Simillar to constructor functionality.
    /// </summary>
    void Start()
    {
        var boltRigidBody = GetComponent<Rigidbody>();
        boltRigidBody.velocity = transform.forward*Speed;
    }
}
