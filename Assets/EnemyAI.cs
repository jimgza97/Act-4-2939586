using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRadius = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Asegúrate de que el jugador tenga esta etiqueta
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
