using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogWindow;

    protected bool currentDialogFinished;

    protected IEnumerator PlayDialog(string[] dialog, bool waitForKeys)
    {
        dialogWindow.SetActive(true);

        yield return new WaitForEndOfFrame();

        var dialogs = new Queue<string>(dialog);

        WriteText(dialogs.Dequeue(), waitForKeys);

        while (dialogs.Count > 0)
        {
            if (currentDialogFinished)
            {
                if (waitForKeys == false)
                {
                    yield return new WaitForSecondsRealtime(1f);
                    WriteText(dialogs.Dequeue(), waitForKeys);
                }
                else if (Input.anyKey && currentDialogFinished)
                {
                    WriteText(dialogs.Dequeue(), waitForKeys);
                }
            }

            yield return new WaitForEndOfFrame();
        }

        while (currentDialogFinished == false || (Input.anyKey == false && waitForKeys))
        {
            yield return new WaitForEndOfFrame();
        }

        if (waitForKeys == false)
        {
            yield return new WaitForSecondsRealtime(1f);
        }

        dialogWindow.SetActive(false);
    }

    protected void WriteText(string text, bool waitForKeys)
    {
        StartCoroutine(WriteTextByLetters(text, waitForKeys));
    }

    protected IEnumerator WriteTextByLetters(string text, bool waitForKeys)
    {
        currentDialogFinished = false;
        var currentText = string.Empty;

        foreach (var letter in text)
        {
            currentText += letter;
            dialogText.text = currentText;
            AudioManager.instance.PlayTalk();
            yield return new WaitForSeconds(0.035f);
        }

        if (waitForKeys)
        {
            dialogText.text = currentText + " >>";
        }

        currentDialogFinished = true;
    }
}
