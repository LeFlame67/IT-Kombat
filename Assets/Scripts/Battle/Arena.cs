using UnityEngine;

[System.Serializable]
public class Arena : MonoBehaviour
{
    [SerializeField] public string arenaName;
    [SerializeField] public Sprite arenaBackground;
    [SerializeField] public AudioClip arenaMusic;
    [SerializeField] public Vector3 player1StartPosition = new Vector3(-5, 0, 0);
    [SerializeField] public Vector3 player2StartPosition = new Vector3(5, 0, 0);
}
