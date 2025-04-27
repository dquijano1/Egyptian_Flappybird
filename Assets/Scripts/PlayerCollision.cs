using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverPanel; // Assign in Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            Time.timeScale = 0f; // Pause the game when dead
        }
    }
}
