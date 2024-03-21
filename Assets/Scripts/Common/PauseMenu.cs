using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseWindow;

    private bool paused;

    public static PauseMenu instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pauseWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void ToggleHint()
    {

    }
    
    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            pauseWindow.SetActive(true);
            Harbinger.instance?.DisableInput();
        }
        else
        {
            Time.timeScale = 1;
            pauseWindow.SetActive(false);
            Harbinger.instance?.EnableInput();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
