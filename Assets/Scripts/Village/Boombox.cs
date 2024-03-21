using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boombox : MonoBehaviour
{
    private bool playerWithinRange;

    public TextMeshPro textMesh;

    private bool triggered;

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            triggered = true;
            GetComponent<Animator>().SetBool("Trigger", true);
        }
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerWithinRange)
        {
            GetComponent<Animator>().SetBool("Trigger", true);

            if (triggered)
            {
                triggered = false;
                AudioManager.instance.PlayVillage();
            }
            else
            {
                triggered = true;
                AudioManager.instance.StopMusic();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (VillageScenario.EndPhase || col == null || col.tag != "Player") return;

        playerWithinRange = true;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col == null || col.tag != "Player") return;

        playerWithinRange = false;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }
}
