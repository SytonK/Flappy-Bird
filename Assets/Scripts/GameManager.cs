using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCollision playerCollision;
    public GameObject gameOverMenu;
    public GameObject scoreCanvas;
    public ScoreManager scoreManager;
    public TextMeshProUGUI ScoreValue;
    public GameObject startCanvas;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerCollision.lose.AddListener(OnLose);
        Pause();
    }

    private void OnLose()
    {
        Pause();
        gameOverMenu.SetActive(true);
        scoreCanvas.SetActive(false);
        ScoreValue.SetText(scoreManager.GetScore().ToString());
        Debug.Log("siln");
        audioSource.Play();
    }

    public void Play()
    {
        startCanvas.SetActive(false);
        Unpause();
        gameOverMenu.SetActive(false);
        scoreCanvas.SetActive(true);
        scoreManager.ResetScore();
        DestroyPipes();
        playerMovement.ResetPosition();
        audioSource.Stop();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        playerMovement.enabled = false;
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        playerMovement.enabled = true;
    }

    private void DestroyPipes()
    {
        PipeMovement[] pipes = FindObjectsOfType<PipeMovement>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
}
