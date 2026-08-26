using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField] private CharacterButton[] characterButtons;
    [SerializeField] private Text player1SelectText;
    [SerializeField] private Text player2SelectText;

    private Player selectedPlayer1;
    private Player selectedPlayer2;
    private int playersSelected = 0;

    private void Start()
    {
        AudioManager.Instance.PlayMenuMusic();

        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i;
            characterButtons[i].button.onClick.AddListener(() => OnCharacterSelected(index));
        }
    }

    private void OnCharacterSelected(int characterIndex)
    {
        Player selectedCharacter = characterButtons[characterIndex].player;

        if (playersSelected == 0)
        {
            selectedPlayer1 = selectedCharacter;
            player1SelectText.text = $"P1 Seleccionó: {selectedCharacter.playerName}";
            playersSelected++;
            Debug.Log($"Jugador 1 seleccionó: {selectedCharacter.playerName}");
        }
        else if (playersSelected == 1 && selectedCharacter != selectedPlayer1)
        {
            selectedPlayer2 = selectedCharacter;
            player2SelectText.text = $"P2 Seleccionó: {selectedCharacter.playerName}";
            playersSelected++;
            Debug.Log($"Jugador 2 seleccionó: {selectedCharacter.playerName}");

            // Ambos jugadores seleccionados, ir a selección de arena
            Invoke("GoToArenaSelect", 1f);
        }
    }

    private void GoToArenaSelect()
    {
        GameManager.Instance.SetSelectedPlayers(selectedPlayer1, selectedPlayer2);
        GameManager.Instance.ChangeState(GameManager.GameState.ArenaSelect);
    }
}

[System.Serializable]
public class CharacterButton
{
    public Button button;
    public Player player;
    public Image characterImage;
}
