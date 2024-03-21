using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    public static Overlord instance;

    private bool triggered;

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggered
            || col == null 
            || col.tag != "Player" 
            || DarknessScenario.secondPhase == false) return;

        if (Harbinger.instance.HasTrumpet())
        {
            DarknessScenario.instance.StartEnding();
        }
        else
        {
            DarknessScenario.instance.SmallTalk();
        }
    }

    public void Kill()
    {
        GetComponent<Animator>().SetBool("Trigger", true);
        triggered = true;
    }
}
