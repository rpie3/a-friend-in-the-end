using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            DialogCanvas.Instance.dialogBox.closeDialog();
            SceneManager.LoadScene(sceneName: "EndCredits");
        }
    }
}
