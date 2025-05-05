using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int maxBounceCount = 4; 
    private int currentBounce = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentBounce++;

        
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
        }

        
        if (currentBounce >= maxBounceCount)
        {
            Destroy(gameObject); 
        }
    }
}
