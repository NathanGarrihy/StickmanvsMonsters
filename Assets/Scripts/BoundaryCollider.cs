using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoundaryCollider : MonoBehaviour
{
    // On collision with boundry
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            Destroy(enemy.gameObject);
        }

        var bullet = collision.GetComponent<Bullet>();
        if(bullet)
        {
            Destroy(bullet.gameObject);
        }
    }
}
