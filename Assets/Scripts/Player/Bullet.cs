using UnityEngine;

public class Bullet : MonoBehaviour
{
    //  private variables
    private const int DMG = 2;
    private float bulletSpeed = 30f;

    // Rigidbody intake
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    //  On collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage enemy = collision.GetComponent<EnemyDamage>();
        var enemyPassive = collision.GetComponent<ReflectEnemy>();
        if (enemyPassive)
        {
            //  Rotates bullet 180 degrees so it faces the player
            transform.localRotation *= Quaternion.Euler(0, 0, 180);
            //  Changes bullet volecity so it bounces back from enemy (at 40% slower speed)
            rb.velocity *= -.6f;
        }
        else if (enemy != null)
        {
            enemy.TakeDamage(DMG);
            Destroy(gameObject);
        }

    }

    // When bullet leaves screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
