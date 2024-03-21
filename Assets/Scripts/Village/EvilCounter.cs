using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilCounter : MonoBehaviour
{
    public Text text;

    public static EvilCounter instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (VillageScenario.EndPhase)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateValue(int value)
    {
        text.text = value.ToString();
    }
}
