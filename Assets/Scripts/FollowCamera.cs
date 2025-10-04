using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerCamera;
    public float distance = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; 
        }
    }

    void FixedUpdate()
    {
        if (playerCamera == null) return;

        Vector3 targetPos = playerCamera.position + playerCamera.forward * distance;
        Quaternion targetRot = playerCamera.rotation;

        rb.MovePosition(targetPos);
        rb.MoveRotation(targetRot);
    }
}
