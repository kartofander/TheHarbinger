using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VillageScenario : MonoBehaviour
{
    public GameObject dialogWindow;
    public Text dialogText;
    public GameObject bolt;

    public static VillageScenario instance;

    private bool currentDialogFinished;

    public static bool EndPhase = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (EndPhase)
        {
            StartCoroutine(TheEnd());
        }
        else
        {
            StartCoroutine(Appearance());
        }
    }

    void Update()
    {
        
    }

    private IEnumerator Appearance()
    {
        Fade.instance.Out();

        Harbinger.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(1);

        Harbinger.instance.gameObject.SetActive(true);

        Harbinger.instance.Appear();

        yield return new WaitForSeconds(1);

        Harbinger.instance.EnableInput();

        AudioManager.instance.PlayVillage();

        dialogWindow.SetActive(true);
        WriteText(Texts.Controls);
        while (Input.anyKey == false || currentDialogFinished == false)
        {
            yield return new WaitForEndOfFrame();
        }
        dialogWindow.SetActive(false);
    }

    public IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(1.5f);

        Fade.instance.Out();

        Harbinger.instance.EnableInput();

        Harbinger.instance.EnableTrumpet();

        AudioManager.instance.PlayTrumpetSong();

        StartCoroutine(CreateBolts());

        yield return new WaitForSeconds(1.5f);

        dialogWindow.SetActive(true);

        yield return new WaitForEndOfFrame();

        var dialogs = new Queue<TranslatedString>(Texts.Titles);
        currentDialogFinished = false;

        WriteText(dialogs.Dequeue());

        while (dialogs.Count > 0)
        {
            if (currentDialogFinished)
            {
                yield return new WaitForSeconds(5f);
                WriteText(dialogs.Dequeue());
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartExitSequence()
    {
        StartCoroutine(Exit());
    }

    private IEnumerator Exit()
    {
        Harbinger.instance.DisableInput();

        dialogWindow.SetActive(true);

        yield return new WaitForEndOfFrame();

        var dialogs = new Queue<TranslatedString>(Texts.ExitDialog);

        WriteText(dialogs.Dequeue());

        while (dialogs.Count > 0)
        {
            if (Input.anyKey && currentDialogFinished)
            {
                WriteText(dialogs.Dequeue());
            }

            yield return new WaitForEndOfFrame();
        }

        while (currentDialogFinished == false || Input.anyKey == false)
        {
            yield return new WaitForEndOfFrame();
        }

        dialogWindow.SetActive(false);

        Harbinger.instance.Disappear();

        AudioManager.instance.StopMusic();

        yield return new WaitForSecondsRealtime(2);

        Fade.instance.In();

        yield return new WaitForSecondsRealtime(3);

        DarknessScenario.secondPhase = true;

        SceneManager.LoadScene("Darkness");
    }

    private void WriteText(TranslatedString text)
    {
        StartCoroutine(WriteTextByLetters(text));
    }

    private IEnumerator WriteTextByLetters(TranslatedString text)
    {
        currentDialogFinished = false;
        var currentText = string.Empty;

        foreach (var letter in text.GetText())
        {
            currentText += letter;
            dialogText.text = currentText;
            AudioManager.instance.PlayTalk();
            yield return new WaitForSeconds(0.03f);
        }

        dialogText.text = currentText + "  >>";

        currentDialogFinished = true;
    }

    private IEnumerator CreateBolts()
    {
        while (true)
        {
            var randDirection = Random.insideUnitCircle.normalized;
            var randDistance = Random.Range(0.5f, 3.5f);

            var randPos = Harbinger.instance.transform.position + (Vector3)(randDirection * randDistance);

            var newBolt = Instantiate(bolt, randPos, Quaternion.identity);

            yield return new WaitForEndOfFrame();

            var collider = newBolt.GetComponent<Collider2D>();
            var collisions = new List<Collider2D>();
            collider.OverlapCollider(new ContactFilter2D { }, collisions);
            foreach (var collision in collisions)
            {
                if (collision.tag == "Player" || collision.tag == "Bolt") continue;

                if (collision.tag == "DoubleCollider")
                {
                    Destroy(collision.transform.parent.gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }

            var randWait = Random.Range(0.5f, 1.5f);

            yield return new WaitForSeconds(randWait);
        }
    }
}
