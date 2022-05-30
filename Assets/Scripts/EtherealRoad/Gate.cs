using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogCanvas.Instance.QueueDialog("(Seems to be locked...)");
            DialogCanvas.Instance.QueueDialog("(I can see something shimmering on the other side of it...)");
        }
    }
}
