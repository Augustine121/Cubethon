using Chapter.Command;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("Collision Alert!");
            FindObjectOfType<GameManager>().StartReplay();
        }
    }
}