using Chapter.Command;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Chapter.Command
{
    public class PlayerInput : MonoBehaviour
    {
        private Invoker invoker;
        private bool isReplaying;
        private bool isRecording;
        private Command buttonA, buttonD, buttonSpace;
        private MovementController movementController;

        void Start()
        {
            invoker = gameObject.AddComponent<Invoker>();
            movementController = FindObjectOfType<MovementController>();

            invoker.Record();
            isReplaying = false;
            isRecording = true;
            buttonA = new GoLeft(movementController);
            buttonD = new GoRight(movementController);
            buttonSpace = new Jump(movementController);
        }
        void Update()
        {
            if (!isReplaying && isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    invoker.ExecuteCommand(buttonA);

                if (Input.GetKeyUp(KeyCode.D))
                    invoker.ExecuteCommand(buttonD);

                if (Input.GetKeyUp(KeyCode.Space))
                    invoker.ExecuteCommand(buttonSpace);
            }
        }
    }
}