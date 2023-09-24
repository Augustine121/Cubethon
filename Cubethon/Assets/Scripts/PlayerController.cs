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
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (jump)
        {
            jump = false;
            rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (left)
        {
            left = false;
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (right)
        {
            right = false;
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

    }
    public void Jump()
    {
        jump = true;
    }
    public void MoveLeft()
    {
        left = true;
    }
    public void MoveRight()
    {
        right = true;
    }
}