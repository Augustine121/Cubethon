using Chapter.Command;
using UnityEngine;

namespace Chapter.Command
{
    public class PlayerCollision : MonoBehaviour
    {
        public MovementController movement;

        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}