using UnityEngine;

// use this to manage collisions

public class ReflectEnemy : MonoBehaviour
{
    //  Score reference for GameController
    public int ScoreValue { get { return scoreValue; } }

    //  Private serialized fields
    [SerializeField] private int scoreValue = 20;
    //  Sound effects
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip ricochetSound;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private GameObject explosionEffect;

    private float explosionDuration = 0.5f;
    private SoundController sc;

    //  Fields for enemy killed event
    public delegate void PassiveEnemyKilled(ReflectEnemy passiveEnemy);
    public static PassiveEnemyKilled PassiveEnemyKilledEvent;


    //  Private methods 
    // Start is called before the first frame update
    private void Start()
    {
        sc = SoundController.FindSoundController();
        PlaySound(spawnSound);
    }

    // Plays sound clip once
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

        if (player)  // if player != null
        {
            PlaySound(crashSound);
            // destroy the player
            // give the player points
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if (bullet)
        {
            // Play ricochet & die sound
            PlaySound(ricochetSound);
            PlaySound(dieSound);
            PublishPassiveEnemyKilledEvent();
            //  Explosion
            GameObject explosion = Instantiate(explosionEffect,
                                               transform.position,
                                               transform.rotation);
            Destroy(explosion, explosionDuration);
            Destroy(gameObject);
            // destroy game object
        }
    }

    //  When enemy leaves the screen
    private void OnBecameInvisible()
    {
        scoreValue = 10;
        PublishPassiveEnemyKilledEvent();
        Destroy(gameObject);
    }

    private void PublishPassiveEnemyKilledEvent()
    {
        //  Make sure someone is listening
        if (PassiveEnemyKilledEvent != null)
        {
            PassiveEnemyKilledEvent(this);
        }
    }
}
