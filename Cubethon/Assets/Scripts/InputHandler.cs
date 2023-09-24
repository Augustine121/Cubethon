using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker invoker;
        private bool isReplaying;
        private bool isRecording;
        private PlayerController playerController;
        private PlayerCollision playerCollision;
        private Command Left, Right, Jump;

        void Start()
        {
            invoker = gameObject.AddComponent<Invoker>();
            playerController = FindObjectOfType<PlayerController>();

            Left = new MoveLeft(playerController);
            Right = new MoveRight(playerController);
            Jump = new Jump(playerController);

            isRecording = true;
            invoker.Record();
        }

        void Update()
        {
            if (!isReplaying && isRecording)
            {
                if (Input.GetKey("a"))
                    invoker.ExecuteCommand(Left);

                if (Input.GetKey("d"))
                    invoker.ExecuteCommand(Right);

                if (Input.GetKey("space"))
                    invoker.ExecuteCommand(Jump);
            }
        }
    }
}
