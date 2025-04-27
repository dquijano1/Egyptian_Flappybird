using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    [SerializeField] private GameObject getReady;
    [SerializeField] private GameObject prompt_panel;
    
    [SerializeField] 
    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }
    private IEnumerator HidePromptPanelAfterDelay(float delay)
    {
    yield return new WaitForSeconds(delay);
    prompt_panel.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {   
        prompt_panel.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(true);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        getReady.SetActive(false);
        playButton.SetActive(false);
        prompt_panel.SetActive(true);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
        StartCoroutine(HidePromptPanelAfterDelay(5f));
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {   
        
        score++;
        scoreText.text = score.ToString();
    }

}
