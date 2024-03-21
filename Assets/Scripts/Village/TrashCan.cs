using TMPro;
using UnityEngine;

public class TrashCan : Objective
{
    public TextMeshPro textMesh;
    public AudioSource sound;

    private bool playerWithinRange;
    private const int evilPoints = 10;

    private bool interactStarted;
    private float pointsLeft;
    private const float startPoints = 30f;
    private const float requiredPoints = 100f;
    private const float pointsLoss = 0.5f;
    private const float pointsGain = 10f;

    private bool triggered;

    void Start()
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        if (VillageScenario.EndPhase)
        {
            triggered = true;
            GetComponent<Animator>().SetBool("Trigger", true);
        }
    }

    void Update()
    {
        if (triggered) return;

        if (Input.GetKeyDown(KeyCode.E) && playerWithinRange)
        {
            if (interactStarted == false)
            {
                interactStarted = true;
                
                pointsLeft = startPoints;
                MashingCircle.instance.Activate();
                MashingCircle.instance.UpdateValue(pointsLeft / requiredPoints);
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
                return;
            }

            pointsLeft += pointsGain;

            if (pointsLeft >= requiredPoints)
            {
                interactStarted = false;
                MashingCircle.instance.Deactivate();
                Drop();
            }
        }
    }

    void FixedUpdate()
    {
        if (interactStarted)
        {
            pointsLeft -= pointsLoss;
            MashingCircle.instance.UpdateValue(pointsLeft / requiredPoints);

            if (pointsLeft <= 0)
            {
                interactStarted = false;
            }
        }
    }

    private void Drop()
    {
        triggered = true;
        sound.Play();
        GetComponent<Animator>().SetBool("Trigger", true);
        EvilManager.instance.AddEvilPoints(evilPoints, transform.position);
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

        if (interactStarted)
        {
            MashingCircle.instance.Deactivate();
            interactStarted = false;
        }

        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }

    public override bool IsActive()
    {
        return !triggered;
    }
}
