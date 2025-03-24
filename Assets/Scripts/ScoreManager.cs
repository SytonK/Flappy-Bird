using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public PlayerCollision playerCollision;
    
    private TextMeshProUGUI textMeshProUGUI;
    
    private AudioSource audioSource;
    
    private int score = 0;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        playerCollision.score.AddListener(OnScore);
    }

    private void OnScore()
    {
        score++;
        textMeshProUGUI.text = score.ToString();
        audioSource.Play();
    }

    public int GetScore()
    {
        return score;
    }
    
    public void ResetScore()
    {
        score = 0;
        if (textMeshProUGUI != null) {
            textMeshProUGUI.text = score.ToString();
        }
    }
}
