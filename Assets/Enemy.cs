using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 3f;
    public int maxHealth = 3; // Vida máxima del enemigo
    private int currentHealth;

    private Transform player;
    private Rigidbody2D rb;
    private bool isPlayerInRange = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();

        // Hace que el enemigo no sea afectado por la física
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Inicializa la vida del enemigo
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        isPlayerInRange = (distance < detectionRange);

        if (isPlayerInRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * moveSpeed; // Se mueve hacia el jugador
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Se detiene cuando el jugador está fuera del rango
        }
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("⚔️ Enemigo recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para destruir al enemigo cuando su vida llegue a 0
    void Die()
    {
        Debug.Log("💀 Enemigo eliminado");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("💥 El jugador colisionó con el enemigo");
            // Llamar al método TakeDamage del enemigo al colisionar con el jugador
            TakeDamage(1); // Cambia el valor "1" por el daño que deseas infligir
        }
    }
}
