using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager I;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    void Awake() { I = this; TryRefresh(); }

    public static void TryRefresh()
    {
        if (I == null) return;
        if (I.scoreText) I.scoreText.text = $"Score: {GameManager.I.score}";
        if (I.livesText) I.livesText.text = $"Vidas: {GameManager.I.lives}";
    }
}
