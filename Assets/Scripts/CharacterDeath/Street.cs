using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogCanvas.Instance.QueueDialog("(Crossing here could be dangerous.)");
            DialogCanvas.Instance.QueueDialog("(I should find a crosswalk.)");

            // if (dead)
            // {
            //     DialogCanvas.Instance.QueueDialog("(Technically, I've already crossed over.)");
            //     DialogCanvas.Instance.QueueDialog("(So what's the point?)");
            // }
        }
    }
}
