using UnityEngine;

public class FlowersController : Objective
{
    private const int evilPoints = 1;
    private bool triggered;

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            triggered = true;
            GetComponent<Animator>().SetBool("Trigger", true);
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggered || col == null || col.tag != "Player") return;

        triggered = true;
        EvilManager.instance.AddEvilPoints(evilPoints, transform.position);
        GetComponent<Animator>().SetBool("Trigger", true);
    }

    public override bool IsActive()
    {
        return !triggered;
    }
}
