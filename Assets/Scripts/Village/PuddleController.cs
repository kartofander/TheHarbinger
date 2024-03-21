using UnityEngine;

public class PuddleController : Objective
{
    public PuddleVictim[] victims;
    public AudioSource audioSource;
    private bool triggered;

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            triggered = true;
            GetComponent<Animator>().SetBool("Trigger", true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggered || col == null || col.tag != "Player") return;

        if (Harbinger.instance.GetCurrentSpeed() <= 6) return;

        triggered = true;
        if (victims?.Length > 0)
        {
            audioSource.Play();
        }
        GetComponent<Animator>().SetBool("Trigger", true);
    }

    private void TriggerVictims()
    {
        foreach (var victim in victims)
        {
            victim.Trigger();
        }
    }

    public override bool IsActive()
    {
        return !triggered && victims.Length > 0;
    }
}
