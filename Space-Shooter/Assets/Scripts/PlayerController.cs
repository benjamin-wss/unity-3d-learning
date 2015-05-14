using System;
using UnityEngine;

[Serializable]
public class Boundry
{
    public float MinimumClampForXAxis;
    public float MaximumClampForXAxis;
    public float MinimumClampForZAxis;
    public float MaximumClampForZAxis;
}

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundry GameBoundry;

    public GameObject Shot;
    public Transform ShowSpawn;
    public float FireRate;

    private float _nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + FireRate;
            Instantiate(Shot, ShowSpawn.position, ShowSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var playerRigidBody = GetComponent<Rigidbody>();
        var movementVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerRigidBody.velocity = movementVector * Speed;

        playerRigidBody.position = new Vector3(
                Mathf.Clamp(
                    playerRigidBody.position.x,
                    GameBoundry.MinimumClampForXAxis,
                    GameBoundry.MaximumClampForXAxis),
                0.0f,
                Mathf.Clamp(
                    playerRigidBody.position.z,
                    GameBoundry.MinimumClampForZAxis,
                    GameBoundry.MaximumClampForZAxis));

        playerRigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -Tilt);
    }
}