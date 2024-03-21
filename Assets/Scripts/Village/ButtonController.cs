using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text textObject;
    public string text;
    public ButtonType type;

    public void SetSelection(bool value)
    {
        textObject.text = text + (value ? "<" : "");
    }
}

public enum ButtonType
{
    Attack = 1,
    Run = 2,
}