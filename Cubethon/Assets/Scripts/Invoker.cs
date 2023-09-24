using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Chapter.Command
{
    class Invoker : MonoBehaviour
    {
        private bool isRecording;
        private bool isReplaying;
        private float replayTime;
        private float recordingTime;
        private SortedList<float, Command> recordedCommands;
        void Start()
        {
            recordedCommands = new SortedList<float, Command>();
        }
        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if (isRecording)
            {
                recordedCommands.Add(recordingTime, command);
            }

            Debug.Log("Recorded Time: " + recordingTime);
            Debug.Log("Recorded Command: " + command);
        }
        public void Record()
        {
            recordingTime = 0.0f;
            isRecording = true;
        }
        public void Replay()
        {
            replayTime = 0.0f;
            isReplaying = true;
            if (recordedCommands.Count <= 0)
            {
                Debug.LogError("No commands to replay!");
            }
            recordedCommands.Reverse();
        }
        void FixedUpdate()
        {
            if (isRecording)
            {
                recordingTime += Time.fixedDeltaTime;
            }
            if (isReplaying)
            {
                replayTime += Time.fixedDeltaTime;
                if (recordedCommands.Any())
                {
                    if (Mathf.Approximately(replayTime, recordedCommands.Keys[0]))
                    {
                        Debug.Log("Replay Time: " + replayTime);
                        Debug.Log("Replay Command: " + recordedCommands.Values[0]);
                        recordedCommands.Values[0].Execute();
                        recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    isReplaying = false;
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
        }
    }
}