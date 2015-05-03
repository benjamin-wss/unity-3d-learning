using UnityEngine;

public class PickupRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var pickupTransformRotation = new Vector3(15, 30, 45);

        transform.Rotate(pickupTransformRotation * Time.deltaTime);
    }
}
