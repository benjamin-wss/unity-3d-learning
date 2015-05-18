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
            // Play laser gun sound
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        var playerRigidBody = GetComponent<Rigidbody>();

        var playerRigidbodyVeclocity = SetupPlayerRigidbodyVeclocity(Speed);
        playerRigidBody.velocity = playerRigidbodyVeclocity;

        playerRigidBody.position = GeneratePlayerRigidBodyClampingPosition(playerRigidBody, GameBoundry);
        playerRigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -Tilt);
    }

    private static Vector3 SetupPlayerRigidbodyVeclocity(float speed)
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movementVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        var playerRigidbodyVelocity = movementVector*speed;

        return playerRigidbodyVelocity;
    }

    private static Vector3 GeneratePlayerRigidBodyClampingPosition(Rigidbody playerRigidBody, Boundry gameBoundry)
    {
        var xAxisClamp = Mathf.Clamp(
            playerRigidBody.position.x,
            gameBoundry.MinimumClampForXAxis,
            gameBoundry.MaximumClampForXAxis);

        const float yAxisClamp = 0.0f;

        var zAxisClamp = Mathf.Clamp(
            playerRigidBody.position.z,
            gameBoundry.MinimumClampForZAxis,
            gameBoundry.MaximumClampForZAxis);

        var clampedPlayerPosition = new Vector3(xAxisClamp, yAxisClamp, zAxisClamp);

        return clampedPlayerPosition;
    }
}