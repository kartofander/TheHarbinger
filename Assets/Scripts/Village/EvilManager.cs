using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilManager : MonoBehaviour
{
    public GameObject pointsBubble;

    public static EvilManager instance;

    private int currentEvil;
    private const int requiredEvil = 280;

    void Awake()
    {
        instance = this;
        currentEvil = 0;
    }

    void Start()
    {
        EvilCounter.instance.UpdateValue(currentEvil);
    }

    void Update()
    {
        
    }

    public void AddEvilPoints(int points, Vector3 position)
    {
        currentEvil += points;
        CheckStatus();
        EvilCounter.instance.UpdateValue(currentEvil);

        var bubble = Instantiate(pointsBubble, position, Quaternion.identity);
        bubble.GetComponent<PointsBubble>().Init(points);
    }

    private void CheckStatus()
    {
        if (currentEvil >= requiredEvil)
        {
            VillageScenario.instance.StartExitSequence();
        }
    }
}
