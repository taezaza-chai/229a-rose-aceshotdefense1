using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 4f;
    private float speed;

    private Transform player;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(1);

            Destroy(gameObject); 
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
            }

            Destroy(gameObject); 
        }
    }
}
