using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool checkForwards = false;
    public bool checkLeft = false;
    public bool checkRight = false;
    public bool checkBackwards = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello, World!");
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            checkForwards = true;
        }
        if (Input.GetKey("a"))
        {
            checkLeft = true;
        }
        if (Input.GetKey("d"))
        {
            checkRight = true;
        }
        if (Input.GetKey("s"))
        {
            checkBackwards = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkForwards)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            checkForwards = false;
        }
        if (checkLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            checkLeft = false;
        }
        if (checkRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            checkRight = false;
        }
        if (checkBackwards)
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
            checkBackwards = false;
        }
    }
}
