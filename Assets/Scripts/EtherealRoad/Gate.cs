using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogCanvas.Instance.QueueDialog("(It says \"DO NOT PASS.\")");
        }
    }
}
