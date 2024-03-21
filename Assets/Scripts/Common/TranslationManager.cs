using UnityEngine;

public class TranslationManager : MonoBehaviour
{
    public static TranslationManager instance;

    public Language currentLanguage { get; protected set; }

    private Language[] languages;
    private int currentIndex = 0;

    public delegate void HandleLanguageChange();
    public event HandleLanguageChange OnLanguageChange;

    void Awake()
    {
        instance = this;

        languages = new[]
        {
            Language.Ru, 
            Language.En,
        };

        UpdateLanguage();
    }

    public void PrevLanguage()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = languages.Length - 1;
        }

        UpdateLanguage();
    }

    public void NextLanguage()
    {
        currentIndex++;
        if (currentIndex >= languages.Length)
        {
            currentIndex = 0;
        }

        UpdateLanguage();
    }

    private void UpdateLanguage()
    {
        currentLanguage = languages[currentIndex];
        OnLanguageChange?.Invoke();
    }
}

public enum Language
{
    En = 1,
    Ru = 2,
}
