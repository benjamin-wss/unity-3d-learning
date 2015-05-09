using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CounterText;
    public Text WinText;

    private Rigidbody _rigidbody;
    private int _count;

    private const string COUNT_TEXT_TEMPLATE = "Count : {0}";

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = string.Empty;
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
            _count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CounterText.text = string.Format(COUNT_TEXT_TEMPLATE, _count);
        if (_count >= 4)
        {
            WinText.text = "Win Mou!!";
        }
    }
}
