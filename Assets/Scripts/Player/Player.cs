using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] public int playerID;
    [SerializeField] public string playerName;
    [SerializeField] public Sprite characterSprite;
    [SerializeField] public int maxHealth = 100;
    
    private int currentHealth;
    private bool isBlocking = false;
    private float blockDamageReduction = 0.5f;

    // Combat Stats
    [SerializeField] private int lightPunchDamage = 10;
    [SerializeField] private int heavyPunchDamage = 20;
    [SerializeField] private int lightKickDamage = 15;
    [SerializeField] private int heavyKickDamage = 25;
    [SerializeField] private int specialMoveDamage = 40;

    // Input
    private InputHandler inputHandler;

    private void Start()
    {
        currentHealth = maxHealth;
        inputHandler = GetComponent<InputHandler>();
    }

    public void TakeDamage(int damage)
    {
        int actualDamage = isBlocking ? (int)(damage * blockDamageReduction) : damage;
        currentHealth -= actualDamage;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        Debug.Log($"{playerName} recibe {actualDamage} daño. Salud: {currentHealth}");
    }

    public void Block(bool active)
    {
        isBlocking = active;
    }

    public bool IsBlocking() => isBlocking;

    public void Jump()
    {
        Debug.Log($"{playerName} salta");
        // Lógica de salto será implementada en el controlador
    }

    public void MoveRight()
    {
        Debug.Log($"{playerName} se mueve a la derecha");
    }

    public void MoveLeft()
    {
        Debug.Log($"{playerName} se mueve a la izquierda");
    }

    public void LightPunch()
    {
        Debug.Log($"{playerName} lanza puño ligero");
        return lightPunchDamage;
    }

    public void HeavyPunch()
    {
        Debug.Log($"{playerName} lanza puño fuerte");
        return heavyPunchDamage;
    }

    public void LightKick()
    {
        Debug.Log($"{playerName} lanza patada ligera");
        return lightKickDamage;
    }

    public void HeavyKick()
    {
        Debug.Log($"{playerName} lanza patada fuerte");
        return heavyKickDamage;
    }

    public void SpecialMove()
    {
        Debug.Log($"{playerName} utiliza movimiento especial");
        return specialMoveDamage;
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
    public float GetHealthPercentage() => (float)currentHealth / maxHealth;

    private void Die()
    {
        Debug.Log($"{playerName} ha sido derrotado");
        gameObject.SetActive(false);
    }
}
