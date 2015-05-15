using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed;

    // Use this for initialization
    void Start()
    {
        var boltRigidBody = GetComponent<Rigidbody>();
        boltRigidBody.velocity = transform.forward*Speed;
    }
}
