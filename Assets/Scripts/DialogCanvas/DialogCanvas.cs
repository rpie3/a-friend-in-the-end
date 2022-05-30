using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static DialogCanvas Instance;

    [SerializeField] DialogBox dialogBox;

    [SerializeField] List<string> dialogQueue = new List<string>(); 

    public delegate void OnAllDialogDismissed();
    public OnAllDialogDismissed onDismiss;

    public void SetOnAllDialogDismissed(OnAllDialogDismissed callback)
    {
        onDismiss = callback;
    }

    public void QueueDialog(string newDialog)
    {
        if (dialogQueue.Count > 0) 
        {
            if (dialogQueue[dialogQueue.Count - 1] != newDialog)
            {
                dialogQueue.Add(newDialog);
            }
        }
        else
        {
            dialogQueue.Add(newDialog);
        }
    }

    public bool IsDialogShowing()
    {
        return dialogBox.animator.GetBool("dialogIsOpen") == true;
    }

    public void CloseDialog()
    {
        if (IsDialogShowing())
        {
            dialogBox.closeDialog();
        }
    }

    void FixedUpdate()
    {
        if (dialogQueue.Count != 0)
        {
            DisplayQueuedDialog();
        }
        
    }

    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs() {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1))
        {
            if (dialogQueue.Count > 0)
            {
                dialogQueue.RemoveAt(0);
            }
            if (dialogQueue.Count == 0 && IsDialogShowing())
            {
                dialogBox.closeDialog();
                if (onDismiss != null)
                {
                    onDismiss();
                    onDismiss = null;
                }
            }
        }
    }

    void DisplayQueuedDialog()
    {
        dialogBox.setDialogText(dialogQueue[0]);
        if (!IsDialogShowing())
        {
            dialogBox.openDialog();
        }
    }

    public void Open()
    {
        dialogBox.openDialog();
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
