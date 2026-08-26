using UnityEngine;
using UnityEngine.UI;

public class ArenaSelectController : MonoBehaviour
{
    [SerializeField] private ArenaButton[] arenaButtons;
    [SerializeField] private Text arenaSelectText;

    private void Start()
    {
        AudioManager.Instance.PlayMenuMusic();

        for (int i = 0; i < arenaButtons.Length; i++)
        {
            int index = i;
            arenaButtons[i].button.onClick.AddListener(() => OnArenaSelected(index));
        }
    }

    private void OnArenaSelected(int arenaIndex)
    {
        Arena selectedArena = arenaButtons[arenaIndex].arena;
        arenaSelectText.text = $"Arena Seleccionada: {selectedArena.arenaName}";
        Debug.Log($"Arena seleccionada: {selectedArena.arenaName}");

        GameManager.Instance.SetSelectedArena(selectedArena);
        Invoke("GoToBattle", 1f);
    }

    private void GoToBattle()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Battle);
    }
}

[System.Serializable]
public class ArenaButton
{
    public Button button;
    public Arena arena;
    public Image arenaImage;
}
