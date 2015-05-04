using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidbody.AddForce(movement * Speed);
    }

    void OnTriggerEnter([NotNull] Collider other)
    {
        if (other == null) throw new ArgumentNullException("other");

        if (!string.IsNullOrEmpty(other.gameObject.tag) && other.gameObject.tag == "Pick_Up")
        {
            other.gameObject.SetActive(false);
        }
    }
}
