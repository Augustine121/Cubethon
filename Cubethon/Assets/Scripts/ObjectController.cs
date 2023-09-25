using System;
using System.Collections;
using UnityEngine;

namespace Chapter.Command
{
    [Serializable]
    public class Obstacle
    {
        private Vector3 initialPosition;
        private Quaternion initialRotation;
        [SerializeField]
        private Rigidbody obstacle;

        public Vector3 getInitialPosition()
        {
            return initialPosition;
        }
        public Quaternion getInitialRotation()
        {
            return initialRotation;
        }
        public void TurnOnGravity()
        {
            obstacle.useGravity = true;
        }
        public void TurnOffGravity()
        {
            obstacle.useGravity = false;
        }
        public void ResetPosition()
        {
            obstacle.transform.position = initialPosition;
            obstacle.transform.rotation = initialRotation;
        }
        public Obstacle(Rigidbody rb)
        {
            obstacle = rb;
            initialPosition = obstacle.transform.position;
            initialRotation = obstacle.transform.rotation;
        }
    }
    public class ObjectController : Observer
    {
        private PlayerController playerController;
        public Obstacle[] obstacles;
        private bool activateGravity;

        void Update()
        {
            foreach (Obstacle ob in obstacles)
            {
                if (activateGravity)
                {
                    ob.TurnOnGravity();
                }
                else
                {
                    ob.TurnOffGravity();
                }
            }
        }

        public override void Notify(Subject subject)
        {
            foreach (Obstacle ob in obstacles)
            {
                if (!playerController)
                {
                    playerController = subject.GetComponent<PlayerController>();
                }
                if (playerController)
                {
                    if (ob.getInitialPosition().z - playerController.distance <= 10)
                    {
                        activateGravity = true;
                    }
                    else
                    {
                        activateGravity = false;
                    }
                }
            }
        }
    }
}