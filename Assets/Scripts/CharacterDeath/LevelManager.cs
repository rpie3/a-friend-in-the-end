using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterDeath {
    public class LevelManager : MonoBehaviour
    {
        void Start()
        {
            DialogCanvas.Instance.QueueDialog("(I better hurry! I'm going to be late!)");    
            MusicManager.Instance.PlayGrasslandTheme();
        }
    }
}
