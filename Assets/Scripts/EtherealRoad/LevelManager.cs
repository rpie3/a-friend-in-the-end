using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EtherealRoad {
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] public GameObject player;
        [SerializeField] public GameObject frontDoor;

        private void spawnPlayerOutsideFrontDoor()
        {
            player.transform.position = new Vector2(frontDoor.transform.position.x, frontDoor.transform.position.y - 2);
        }

        void Start()
        {
            if (GameController.control.lastScene == "MainRoom")
            {
                spawnPlayerOutsideFrontDoor();
            }
        }
    }
}
