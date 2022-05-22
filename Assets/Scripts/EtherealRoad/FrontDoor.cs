using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EtherealRoad {
    public class FrontDoor : MonoBehaviour
    {
        [SerializeField] public bool isFrontDoorLocked = false;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                attemptToEnter();
            }
        }

        void attemptToEnter()
        {
            if (!isFrontDoorLocked)
            {
                GameController.control.lastScene = "EtherealRoad";
                SceneManager.LoadScene(sceneName: "MainRoom");
            }
            else
            {
                Debug.Log("Dialog system: The door is locked.");
            }
        }
    }
}
