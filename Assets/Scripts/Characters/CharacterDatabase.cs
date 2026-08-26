using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    [SerializeField] private Player[] characters = new Player[10];

    public static CharacterDatabase Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public Player GetCharacter(int index)
    {
        if (index >= 0 && index < characters.Length)
            return characters[index];
        return null;
    }

    public Player[] GetAllCharacters() => characters;

    public void InitializeCharacters()
    {
        // Aquí se configuran los 10 personajes
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] == null)
            {
                GameObject charObject = new GameObject($"Character_{i + 1}");
                characters[i] = charObject.AddComponent<Player>();
                characters[i].playerID = i;
                characters[i].playerName = $"Personaje_{i + 1}";
            }
        }
    }
}
