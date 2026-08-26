using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button versusButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        AudioManager.Instance.PlayMenuMusic();

        versusButton.onClick.AddListener(OnVersusClick);
        settingsButton.onClick.AddListener(OnSettingsClick);
        exitButton.onClick.AddListener(OnExitClick);
    }

    private void OnVersusClick()
    {
        Debug.Log("Entrando a Selección de Personajes");
        GameManager.Instance.ChangeState(GameManager.GameState.CharacterSelect);
    }

    private void OnSettingsClick()
    {
        Debug.Log("Abriendo Settings");
        // TODO: Implementar panel de Settings
    }

    private void OnExitClick()
    {
        Debug.Log("Saliendo del juego");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
