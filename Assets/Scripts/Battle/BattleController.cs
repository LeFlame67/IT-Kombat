using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Image player1HealthBar;
    [SerializeField] private Image player2HealthBar;
    [SerializeField] private Text player1NameText;
    [SerializeField] private Text player2NameText;
    [SerializeField] private Text timerText;

    private Player player1;
    private Player player2;
    private Arena arena;
    private float battleTimer = 0f;
    private float roundDuration = 300f; // 5 minutos por ronda

    private void Start()
    {
        player1 = GameManager.Instance.GetSelectedPlayer1();
        player2 = GameManager.Instance.GetSelectedPlayer2();
        arena = GameManager.Instance.GetSelectedArena();

        AudioManager.Instance.PlayBattleMusic();

        InitializeBattle();
    }

    private void InitializeBattle()
    {
        // Instanciar jugadores en la arena
        player1.transform.position = arena.player1StartPosition;
        player2.transform.position = arena.player2StartPosition;

        player1NameText.text = player1.playerName;
        player2NameText.text = player2.playerName;

        UpdateHealthBars();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameManager.GameState.Battle)
            return;

        battleTimer += Time.deltaTime;
        UpdateTimerDisplay();
        UpdateHealthBars();

        // Verificar si algún jugador fue derrotado
        if (player1.GetCurrentHealth() <= 0 || player2.GetCurrentHealth() <= 0)
        {
            EndBattle();
        }
    }

    private void UpdateHealthBars()
    {
        player1HealthBar.fillAmount = player1.GetHealthPercentage();
        player2HealthBar.fillAmount = player2.GetHealthPercentage();
    }

    private void UpdateTimerDisplay()
    {
        float remaining = Mathf.Max(0, roundDuration - battleTimer);
        int minutes = (int)(remaining / 60);
        int seconds = (int)(remaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (remaining <= 0)
        {
            EndBattle();
        }
    }

    private void EndBattle()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.GameOver);
        Debug.Log("¡Batalla Terminada!");
    }
}
