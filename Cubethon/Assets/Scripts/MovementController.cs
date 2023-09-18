using UnityEngine;

namespace Chapter.Command
{
    public class MovementController : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1,
            Right = 1
        }

        public Rigidbody rb;
        public float forwardForce;
        public float sidewaysForce;
        public float upForce;

        public void Turn(Direction direction)
        {
            if (direction == Direction.Left)
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            if (direction == Direction.Right)
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        public void Jump()
        {
            if ((rb.position.y < 1.1 && rb.position.y > 0.9))
                rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}