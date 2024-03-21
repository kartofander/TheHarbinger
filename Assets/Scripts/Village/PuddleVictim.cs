using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleVictim : MonoBehaviour
{
    private const int evilPoints = 15;

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            GetComponent<Animator>().SetBool("Trigger", true);
        }
    }

    public void Trigger()
    {
        GetComponent<Animator>().SetBool("Trigger", true);
        EvilManager.instance.AddEvilPoints(evilPoints, transform.position);
    }
}
