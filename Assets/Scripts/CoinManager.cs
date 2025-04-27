using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coinCount = 0;
    public Text coinCounterText;
    public GameObject winPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateCoinUI();
        winPanel.SetActive(false);
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();

        if (coinCount >= 100)
        {
            WinGame();
        }
    }

    void UpdateCoinUI()
    {
        if (coinCounterText != null)
            coinCounterText.text = "Coins: " + coinCount.ToString() + "/100";
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
