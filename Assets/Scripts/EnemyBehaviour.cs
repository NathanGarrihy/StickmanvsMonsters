using UnityEngine;

// move left when things start
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour
{
    //  private fields 
    private Rigidbody2D rb;
    private int storedScore;
    [SerializeField] private float speed = 6f;
    private int playerScore = GameController.playerScore;

    //  private methods 
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //  do while because initial values are the same
        do
        {
            IncreaseSpeed();
        } while (storedScore != playerScore);
    }   //  end of Update()

    //  Code to increase enemy speed based off of score
    //  Called in update whenever the score stored is != player score
    private void IncreaseSpeed()
    {
        speed = 10f;
        //  If statements to shorten else if's for speed increment
        //  Calculations to increase speed based on score
        //  10,000 -> 100,000
        if (playerScore >= 10000 && playerScore < 20000)
        {
            speed += 100f;
            playerScore /= 10000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 20000 && playerScore < 30000)
        {
            speed += 200f;
            playerScore /= 20000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 30000 && playerScore < 40000)
        {
            speed += 300f;
            playerScore /= 30000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 40000 && playerScore < 50000)
        {
            speed += 400f;
            playerScore /= 40000;   // /= 10000, so it enters next if statement
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 50000 && playerScore < 60000)
        {
            speed += 500f;
            playerScore /= 50000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 60000 && playerScore < 70000)
        {
            speed += 600f;
            playerScore /= 60000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 70000 && playerScore < 80000)
        {
            speed += 700f;
            playerScore /= 70000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 80000 && playerScore < 90000)
        {
            speed += 800f;
            playerScore /= 80000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 90000 && playerScore < 100000)
        {
            speed += 900f;
            playerScore /= 90000;
            //Debug.Log(playerScore);
        }

        //  Calculations to increase speed based on score
        //  Scores from 1,000 -> 10,000
        if (playerScore >= 1000 && playerScore < 2000)
        {
            speed += 10;
            playerScore -= 1000; // -= 1000, so it enters next if statement
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 2000 && playerScore < 3000)
        {
            speed += 20f;
            playerScore -= 2000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 3000 && playerScore < 4000)
        {
            speed += 30f;
            playerScore -= 3000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 4000 && playerScore < 5000)
        {
            speed += 40f;
            playerScore -= 4000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 5000 && playerScore < 6000)
        {
            speed += 50f;
            playerScore -= 5000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 6000 && playerScore < 7000)
        {
            speed += 60f;
            playerScore -= 6000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 7000 && playerScore < 8000)
        {
            speed += 70f;
            playerScore -= 7000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 8000 && playerScore < 9000)
        {
            speed += 80f;
            playerScore -= 8000;
            //Debug.Log(playerScore);
        }
        else if (playerScore >= 9000 && playerScore < 10000)
        {
            speed += 90f;
            playerScore -= 9000;
            //Debug.Log(playerScore);
        }

        //  Calculations to increase speed based on score
        //  Scores from 100 - 1,000 points
        if (playerScore >= 0 && playerScore < 100)
        {
            speed += 1f;
            //Debug.Log("score 0 +"+storedScore);
        }
        else if (playerScore >= 100 && playerScore < 200)
        {
            speed += 2f;
            //Debug.Log("score 100 +"+storedScore);
        }
        else if (playerScore >= 200 && playerScore < 300)
        {
            speed += 3f;
            //ebug.Log("score 200 +" +storedScore);
        }
        else if (playerScore >= 300 && playerScore < 400)
        {
            speed += 4f;
        }
        else if (playerScore >= 400 && playerScore < 500)
        {
            speed += 5f;
        }
        else if (playerScore >= 500 && playerScore < 600)
        {
            speed += 6f;
        }
        else if (playerScore >= 600 && playerScore < 700)
        {
            speed += 7f;
        }
        else if (playerScore >= 700 && playerScore < 800)
        {
            speed += 8f;
        }
        else if (playerScore >= 800 && playerScore < 900)
        {
            speed += 9f;
        }
        else if (playerScore >= 900 && playerScore < 1000)
        {
            speed += 10f;
        }
        //Debug.Log("SPEED =" + speed);

        rb.velocity = new Vector2(-1 * speed, 0);
        storedScore = playerScore;

    }   //  end of IncreaseSpeed()
}   //  end of class
