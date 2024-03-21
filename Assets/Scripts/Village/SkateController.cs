using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkateController : MonoBehaviour
{
    private bool playerWithinRange;

    public TextMeshPro textMesh;

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            Destroy(gameObject);
        }

        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerWithinRange)
        {
            Harbinger.instance.EnableSkate();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col == null || col.tag != "Player") return;

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
