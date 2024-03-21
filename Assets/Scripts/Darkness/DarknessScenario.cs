using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DarknessScenario : MonoBehaviour
{
    public static bool secondPhase = false;

    public GameObject dialogWindow;
    public Text dialogText;
    public CinemachineVirtualCamera vCamera;
    public GameObject bolt;

    private bool currentDialogFinished;

    public static DarknessScenario instance;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AudioManager.instance.StopMusic();

        if (secondPhase)
        {
            StartCoroutine(Return());
        }
        else
        {
            StartCoroutine(Intro());
        }
    }

    private IEnumerator Intro()
    {
        Fade.instance.Out();

        yield return new WaitForSeconds(2);

        yield return PlayDialog(Texts.StartDialog, true);

        Harbinger.instance.Disappear();

        yield return new WaitForSeconds(2);

        Fade.instance.In();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Village");
    }

    private IEnumerator Return()
    {
        Harbinger.instance.transform.position = new Vector3(0.5492387f, -4.200801f, 0);
        Fade.instance.Out();
        Harbinger.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Harbinger.instance.gameObject.SetActive(true);
        Harbinger.instance.Appear();
        yield return new WaitForSeconds(1);
        Harbinger.instance.EnableInput();
    }

    public void SmallTalk()
    {
        StartCoroutine(BringMeTheWeapon());
    }

    private IEnumerator BringMeTheWeapon()
    {
        yield return PlayDialog(Texts.BringMeTheWeapon, false);
    }

    public void StartEnding()
    {
        StartCoroutine(WhaThe());
    }

    private IEnumerator WhaThe()
    {
        yield return PlayDialog(Texts.WhatInGoddamn, false);

        yield return new WaitForSeconds(1);

        yield return PlayDialog(Texts.Ouch, false);

        Instantiate(bolt, Overlord.instance.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Overlord.instance.Kill();

        yield return new WaitForSeconds(2);

        while (vCamera.m_Lens.OrthographicSize > 2)
        {
            vCamera.m_Lens.OrthographicSize -= 0.025f;
            yield return new WaitForEndOfFrame();
        }

        AudioManager.instance.StopMusic();

        Harbinger.instance.Troll();

        yield return new WaitForSeconds(3);

        Fade.instance.In();

        yield return new WaitForSeconds(3);

        VillageScenario.EndPhase = true;

        SceneManager.LoadScene("Village");
    }

    private IEnumerator PlayDialog(TranslatedString[] dialog, bool waitForKeys)
    {
        dialogWindow.SetActive(true);

        yield return new WaitForEndOfFrame();

        var dialogs = new Queue<TranslatedString>(dialog);

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
                else if(Input.anyKey && currentDialogFinished)
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

    private void WriteText(TranslatedString text, bool waitForKeys)
    {
        StartCoroutine(WriteTextByLetters(text, waitForKeys));
    }

    private IEnumerator WriteTextByLetters(TranslatedString text, bool waitForKeys)
    {
        currentDialogFinished = false;
        var currentText = string.Empty;

        foreach (var letter in text.GetText())
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
