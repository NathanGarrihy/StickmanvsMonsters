using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health = 2;

    public GameObject deathEffect;

    //  Applies damage to enemies
    //  My game its only 1 hit but did it
    //  using this method for ease of adding
    //  potentially in next version of game release
    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            KillEnemy();
        }
    }

    //  Method called when enemy is killed
    void KillEnemy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
