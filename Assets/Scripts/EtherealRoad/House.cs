using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource doorOpenSource;

    public void OpenDoor()
    {
        doorOpenSource.Play();
        animator.SetBool("doorHasOpened", true);
    }

    public void Start()
    {
        if (GameController.control.playerHasMetReaper)
        {
            int hash = Animator.StringToHash("DoorOpen");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
