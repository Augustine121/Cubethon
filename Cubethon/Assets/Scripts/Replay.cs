using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Command
{
    public class Replay : MonoBehaviour
    {
        private PlayerInput playerInput;
        void Start()
        {
            playerInput = FindObjectOfType<PlayerInput>();
            Debug.Log("Replay Object Created");
            playerInput.StartReplay();
        }
        public void ReplayGame()
        {
            Debug.Log("ReplayActivated");
            playerInput.StartReplay();
        }
    }
}
