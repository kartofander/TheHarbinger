using UnityEngine;

public class Harbinger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject objectivesHint;
    private Rigidbody2D playerRB;

    public GameObject skateHint;
    public AudioSource walkSound;

    private bool hasSkate;
    private bool onSkate;

    private bool hasTrumpet;

    private float currentSpeed;

    public static Harbinger instance;

    private bool controlsEnabled;


    void Awake()
    {
        instance = this;
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (controlsEnabled)
        {
            MoveOnInput();
            Skate();
        }
    }

    public void EnableSkate()
    {
        hasSkate = true;
        skateHint.SetActive(true);
    }

    public void EnableTrumpet()
    {
        hasTrumpet = true;
        animator.SetBool("HasTrumpet", true);

        if (VillageScenario.EndPhase == false)
        {
            AudioManager.instance?.PlayTrumpet();
        }
    }

    public void ToggleObjectivesHint()
    {
        objectivesHint.SetActive(!objectivesHint.activeSelf);
    }

    void MoveOnInput()
    {
        var inputMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float speed = 5 + (onSkate ? 3 : 0);
        var moveVelocity = inputMove.normalized * speed;

        playerRB?.MovePosition(playerRB.position + moveVelocity * Time.fixedDeltaTime);

        animator.SetFloat("Magnitude", moveVelocity.magnitude);

        currentSpeed = moveVelocity.magnitude;

        if (moveVelocity.magnitude > 0.0001f)
        {
            animator.SetFloat("Horizontal", inputMove.x);
            if (walkSound.isPlaying == false && onSkate == false)
            {
                walkSound.pitch = Random.Range(0.8f, 1f);
                walkSound.Play();
            }
        }
    }

    void Skate()
    {
        if (hasSkate == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSkate = !onSkate;
            animator.SetBool("OnSkate", onSkate);
        }
    }

    public void Disappear()
    {
        animator.SetTrigger("Disappear");
    }

    public void Appear()
    {
        animator.SetTrigger("Appear");
    }

    public void EnableInput()
    {
        controlsEnabled = true;
    }

    public void DisableInput()
    {
        controlsEnabled = false;
    }

    public void Troll()
    {
        animator.SetTrigger("Troll");
    }

    public bool HasTrumpet()
    {
        return hasTrumpet;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
