using UnityEngine;

public class Fade : MonoBehaviour
{
    public static Fade instance;

    void Awake()
    {
        instance = this;
    }

    public void In()
    {
        GetComponent<Animator>().SetTrigger("In");
    }

    public void Out()
    {
        GetComponent<Animator>().SetTrigger("Out");
    }
}
