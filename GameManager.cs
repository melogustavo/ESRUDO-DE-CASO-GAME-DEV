using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    [Header("Game State")]
    public int lives = 3;
    public int score = 0;

    private Vector3 _respawnPoint;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var spawn = GameObject.FindWithTag("Checkpoint");
        _respawnPoint = spawn ? spawn.transform.position : Vector3.zero;
        UIManager.TryRefresh();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.TryRefresh();
    }

    public void LoseLifeAndRespawn(GameObject player)
    {
        lives--;
        UIManager.TryRefresh();
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        player.transform.position = _respawnPoint;
    }

    public void SetCheckpoint(Vector3 pos) { _respawnPoint = pos; }

    public void LoadNextLevel()
    {
        int idx = SceneManager.GetActiveScene().buildIndex;
        if (idx + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(idx + 1);
        else
            SceneManager.LoadScene("Victory");
    }
}
