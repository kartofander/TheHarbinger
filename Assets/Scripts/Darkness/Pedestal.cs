using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    private bool playerWithinRange;

    public GameObject cast;

    public Animator animator;

    public TextMeshPro textMesh;

    private bool triggered;

    private bool takeItemAllowed;

    void Start()
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerWithinRange)
        {
            if (takeItemAllowed)
            {
                triggered = true;
                Destroy(cast);
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
                Harbinger.instance.EnableTrumpet();
            }
            else
            {
                animator.SetBool("Trigger", true);
                takeItemAllowed = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggered || col == null || col.tag != "Player") return;

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
