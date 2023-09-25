using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float upForce;
    public float sidewaysForce;
    private bool jump;
    private bool left;
    private bool right;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    void Start()
    {
        originalPosition = rb.transform.position;
        originalRotation = rb.transform.rotation;
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (jump)
        {
            Debug.Log("Going Up");
            jump = false;
            rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (left)
        {
            Debug.Log("Going Left");
            left = false;
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (right)
        {
            Debug.Log("Going Right");
            right = false;
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

    }
    public void Jump()
    {
        if (rb.position.y >= .999 && rb.position.y <= 1.001)
        {
            jump = true;
        }
    }
    public void MoveLeft()
    {
        left = true;
    }
    public void MoveRight()
    {
        right = true;
    }
    public void ResestPosition()
    {
        rb.transform.position = originalPosition;
        rb.transform.rotation = originalRotation;
    }
}