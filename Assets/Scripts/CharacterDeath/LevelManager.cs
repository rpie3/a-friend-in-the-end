using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterDeath {
    public class LevelManager : MonoBehaviour
    {
        void Start()
        {
            DialogCanvas.Instance.QueueDialog("(Today's the big day!)");    
            DialogCanvas.Instance.QueueDialog("(I'd better hurry, don't want to be late!)");    
            MusicManager.Instance.PlayGrasslandTheme();
        }
    }
}
