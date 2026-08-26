using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Intro, Menu, CharacterSelect, ArenaSelect, Battle, Paused, GameOver }
    public GameState CurrentState { get; private set; }

    [SerializeField] private AudioManager audioManager;
    private Player selectedPlayer1;
    private Player selectedPlayer2;
    private Arena selectedArena;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeState(GameState.Intro);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Estado cambiado a: {newState}");

        switch (newState)
        {
            case GameState.Intro:
                LoadScene("Intro");
                break;
            case GameState.Menu:
                LoadScene("Menu");
                break;
            case GameState.CharacterSelect:
                LoadScene("CharacterSelect");
                break;
            case GameState.ArenaSelect:
                LoadScene("ArenaSelect");
                break;
            case GameState.Battle:
                LoadScene("Battle");
                break;
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetSelectedPlayers(Player player1, Player player2)
    {
        selectedPlayer1 = player1;
        selectedPlayer2 = player2;
    }

    public void SetSelectedArena(Arena arena)
    {
        selectedArena = arena;
    }

    public Player GetSelectedPlayer1() => selectedPlayer1;
    public Player GetSelectedPlayer2() => selectedPlayer2;
    public Arena GetSelectedArena() => selectedArena;

    public void PauseGame()
    {
        if (CurrentState == GameState.Battle)
        {
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (CurrentState == GameState.Paused)
        {
            ChangeState(GameState.Battle);
            Time.timeScale = 1f;
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        ChangeState(GameState.Menu);
    }
}
