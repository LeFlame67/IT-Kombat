using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Player player;
    private bool canCombo = true;
    private float comboWindow = 0.5f;
    private float comboTimer = 0f;

    private int comboCount = 0;
    private int[] comboSequence = new int[3]; // Max 3 hits en combo

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameManager.GameState.Battle)
            return;

        HandleMovement();
        HandleCombat();
        HandleCombo();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            player.Jump();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Right))
            player.MoveRight();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Left))
            player.MoveLeft();
    }

    private void HandleCombat()
    {
        // Bloqueo
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Down))
        {
            player.Block(true);
            return;
        }
        else
        {
            player.Block(false);
        }

        // Ataques
        if (Input.GetKeyDown(KeyCode.E))
            ExecuteAttack(0); // Puño ligero

        if (Input.GetKeyDown(KeyCode.R))
            ExecuteAttack(1); // Puño fuerte

        if (Input.GetKeyDown(KeyCode.T))
            ExecuteAttack(2); // Patada ligera

        if (Input.GetKeyDown(KeyCode.Y))
            ExecuteAttack(3); // Patada fuerte

        if (Input.GetKeyDown(KeyCode.U))
            player.SpecialMove(); // Movimiento especial
    }

    private void ExecuteAttack(int attackType)
    {
        switch (attackType)
        {
            case 0:
                player.LightPunch();
                break;
            case 1:
                player.HeavyPunch();
                break;
            case 2:
                player.LightKick();
                break;
            case 3:
                player.HeavyKick();
                break;
        }

        // Sistema de combos
        if (canCombo)
        {
            comboSequence[comboCount] = attackType;
            comboCount++;
            comboTimer = comboWindow;
            canCombo = false;
            Invoke("AllowCombo", 0.3f);
        }
    }

    private void HandleCombo()
    {
        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
        else if (comboCount > 0)
        {
            CheckCombo();
            comboCount = 0;
        }
    }

    private void CheckCombo()
    {
        if (comboCount >= 2)
        {
            Debug.Log($"¡COMBO! {comboCount} golpes encadenados");
            // Aquí puedes añadir lógica adicional para bonificación de daño
        }
    }

    private void AllowCombo()
    {
        canCombo = true;
    }
}
