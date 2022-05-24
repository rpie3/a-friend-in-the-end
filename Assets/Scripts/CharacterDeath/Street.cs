using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogCanvas.Instance.dialogBox.setDialogText("You can't cross here!");
            DialogCanvas.Instance.dialogBox.openDialog();
            other.gameObject.GetComponent<PlayerMovement>().PushUpwards();
        }
    }
}
