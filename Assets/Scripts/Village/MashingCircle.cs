using UnityEngine;
using UnityEngine.UI;

public class MashingCircle : MonoBehaviour
{
    public Image circle;
    public GameObject container;

    public static MashingCircle instance;

    void Awake()
    {
        instance = this;
    }

    public void Activate()
    {
        container.SetActive(true);
    }

    public void Deactivate()
    {
        container.SetActive(false);
    }

    public void UpdateValue(float value)
    {
        circle.fillAmount = value;
    }
}
