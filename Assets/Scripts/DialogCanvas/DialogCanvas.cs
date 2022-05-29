using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static DialogCanvas Instance;

    [SerializeField] public DialogBox dialogBox;

    public bool IsDialogShowing()
    {
        return dialogBox.animator.GetBool("dialogIsOpen") == true;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
