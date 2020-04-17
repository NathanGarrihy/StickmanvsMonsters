using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isOnGround;
    public Transform feetPos;

    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    [SerializeField] private AudioClip dieSound;
    [SerializeField] private GameObject explosionEffect;
    private float explosionDuration = 0.5f;

    private SoundController sc;
    private static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sc = SoundController.FindSoundController();
    }

    private void PlaySound(AudioClip clip)
    {
        if (sc)
        {
            sc.PlayOneShot(clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlaySound(dieSound);
        GameObject explosion = Instantiate(explosionEffect,
                                           transform.position,
                                           transform.rotation);

        Destroy(explosion, explosionDuration);
        Destroy(gameObject);
        isDead = true;
    }

    private void OnDestroy()
    {
        Time.timeScale = 0;
    }

    public static bool playerIsDead()
    {
        return isDead;
    }

    public static void setPlayerDead(bool dead)
    {
        isDead = dead;
    }
}
