using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TranslatedText : MonoBehaviour
{
    public Text textElement;
    public TextMeshPro textMeshProElement;
    public string textKey;

    void Start()
    {
        TranslationManager.instance.OnLanguageChange += UpdateTranslation;
    }

    void UpdateTranslation()
    {
        if (textElement != null)
        {
            textElement.text = Texts.uiTranslations[textKey].GetText();
        }
        if (textMeshProElement != null)
        {
            textMeshProElement.text = Texts.uiTranslations[textKey].GetText();
        }
    }
}
