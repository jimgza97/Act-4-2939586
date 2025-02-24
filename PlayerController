using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    public Transform attackPoint; // Asigna este Transform en el Inspector
    private float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    private string lastDirection = "Down";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        // Cambiar la dirección del sprite
        if (movement.x > 0) { lastDirection = "Right"; spriteRenderer.sprite = spriteRight; }
        else if (movement.x < 0) { lastDirection = "Left"; spriteRenderer.sprite = spriteLeft; }
        else if (movement.y > 0) { lastDirection = "Up"; spriteRenderer.sprite = spriteUp; }
        else if (movement.y < 0) { lastDirection = "Down"; spriteRenderer.sprite = spriteDown; }

        // Manejo del ataque
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed; // Usar linearVelocity para movimiento
    }

    void Attack()
    {
        if (attackPoint == null)
        {
            Debug.LogWarning("⚠️ AttackPoint no está asignado en el Inspector.");
            return;
        }

        // Cambiar la posición del attackPoint según la última dirección
        switch (lastDirection)
        {
            case "Up": attackPoint.localPosition = new Vector3(0, 0.5f, 0); break;
            case "Down": attackPoint.localPosition = new Vector3(0, -0.5f, 0); break;
            case "Left": attackPoint.localPosition = new Vector3(-0.5f, 0, 0); break;
            case "Right": attackPoint.localPosition = new Vector3(0.5f, 0, 0); break;
        }

        // Detectar enemigos en el rango de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        Debug.Log($"Hit enemies: {hitEnemies.Length}"); // Para depuración

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(1); // Inflige daño al enemigo
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        // Dibujar la zona de ataque en la escena para depuración
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
