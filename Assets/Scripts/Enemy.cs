using UnityEngine;

// use this to manage collisions

public class Enemy : MonoBehaviour
{
    // == set this up to publish an event to the system
    // == when killed

    // public fields 
    // used from GameController enemy.ScoreValue
   public int ScoreValue { get { return scoreValue; } }

    //  Delegate type to use for event
    public delegate void EnemyKilled(Enemy enemy);

    //  Create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;

    //  Private fields 
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private AudioClip crashSound;
    // Sounds for getting hit by bullet, spawning
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip spawnSound;

    private float explosionDuration = 0.5f;

    private SoundController sc;

    //  Private methods 
    // Start is called before the first frame update
    private void Start()
    {
        sc = SoundController.FindSoundController();
        PlaySound(spawnSound);
    }

    //  Plays sound clip once
    private void PlaySound(AudioClip clip)
    {
        if (sc)
        {
            sc.PlayOneShot(clip);
        }
    }

    //  On collision
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        var player = whatHitMe.GetComponent<PlayerController>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if(player)  // if player != null
        {
            PlaySound(crashSound);
            // destroy the player
            // give the player points
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if(bullet)
        {
            // play die sound
            PlaySound(dieSound);
            // destroy bullet
            Destroy(bullet.gameObject);
            // publish event to system (gives player points)
            PublishEnemyKilledEvent();
            // show explosion
            GameObject explosion = Instantiate(explosionEffect,
                                               transform.position,
                                               transform.rotation);
            Destroy(explosion, explosionDuration);
            // destroy game object
            Destroy(gameObject);
        }
    }

    // When enemy leaves screen
    private void OnBecameInvisible()
    {
        scoreValue = 10;
        PublishEnemyKilledEvent();
        Destroy(gameObject);
    }

    private void PublishEnemyKilledEvent()
    {
        // make sure someone is listening
        if(EnemyKilledEvent != null)   
        {
            EnemyKilledEvent(this);
        }
    }
}
