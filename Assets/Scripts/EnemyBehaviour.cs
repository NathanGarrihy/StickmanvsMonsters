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
    // temp variable for speed calculations
    private int tempPlayerScore;
    //  private methods 
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        tempPlayerScore = playerScore;
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
        // playerScore read from game controller every time 
        speed = 10f;
        //  If statements to shorten else if's for speed increment
        //  Calculations to increase speed based on score
        //  10,000 -> 100,000
        if (tempPlayerScore >= 10000 && tempPlayerScore < 20000)
        {
            speed += 100f;
            tempPlayerScore /= 10000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 20000 && tempPlayerScore < 30000)
        {
            speed += 200f;
            tempPlayerScore /= 20000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 30000 && tempPlayerScore < 40000)
        {
            speed += 300f;
            tempPlayerScore /= 30000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 40000 && tempPlayerScore < 50000)
        {
            speed += 400f;
            tempPlayerScore /= 40000;   // /= 10000, so it enters next if statement
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 50000 && tempPlayerScore < 60000)
        {
            speed += 500f;
            tempPlayerScore /= 50000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 60000 && tempPlayerScore < 70000)
        {
            speed += 600f;
            tempPlayerScore /= 60000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 70000 && tempPlayerScore < 80000)
        {
            speed += 700f;
            tempPlayerScore /= 70000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 80000 && tempPlayerScore < 90000)
        {
            speed += 800f;
            tempPlayerScore /= 80000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 90000 && tempPlayerScore < 100000)
        {
            speed += 900f;
            tempPlayerScore /= 90000;
            //Debug.Log(playerScore);
        }

        //  Calculations to increase speed based on score
        //  Scores from 1,000 -> 10,000
        if (tempPlayerScore >= 1000 && tempPlayerScore < 2000)
        {
            speed += 10;
            tempPlayerScore -= 1000; // -= 1000, so it enters next if statement
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 2000 && tempPlayerScore < 3000)
        {
            speed += 20f;
            tempPlayerScore -= 2000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 3000 && tempPlayerScore < 4000)
        {
            speed += 30f;
            tempPlayerScore -= 3000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 4000 && tempPlayerScore < 5000)
        {
            speed += 40f;
            tempPlayerScore -= 4000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 5000 && tempPlayerScore < 6000)
        {
            speed += 50f;
            tempPlayerScore -= 5000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 6000 && tempPlayerScore < 7000)
        {
            speed += 60f;
            tempPlayerScore -= 6000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 7000 && tempPlayerScore < 8000)
        {
            speed += 70f;
            tempPlayerScore -= 7000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 8000 && tempPlayerScore < 9000)
        {
            speed += 80f;
            tempPlayerScore -= 8000;
            //Debug.Log(playerScore);
        }
        else if (tempPlayerScore >= 9000 && tempPlayerScore < 10000)
        {
            speed += 90f;
            tempPlayerScore -= 9000;
            //Debug.Log(playerScore);
        }

        //  Calculations to increase speed based on score
        //  Scores from 100 - 1,000 points
        if (tempPlayerScore >= 0 && tempPlayerScore < 100)
        {
            speed += 1f;
            //Debug.Log("score 0 +"+storedScore);
        }
        else if (tempPlayerScore >= 100 && tempPlayerScore < 200)
        {
            speed += 2f;
            //Debug.Log("score 100 +"+storedScore);
        }
        else if (tempPlayerScore >= 200 && tempPlayerScore < 300)
        {
            speed += 3f;
            //ebug.Log("score 200 +" +storedScore);
        }
        else if (tempPlayerScore >= 300 && tempPlayerScore < 400)
        {
            speed += 4f;
        }
        else if (tempPlayerScore >= 400 && tempPlayerScore < 500)
        {
            speed += 5f;
        }
        else if (tempPlayerScore >= 500 && tempPlayerScore < 600)
        {
            speed += 6f;
        }
        else if (tempPlayerScore >= 600 && tempPlayerScore < 700)
        {
            speed += 7f;
        }
        else if (tempPlayerScore >= 700 && tempPlayerScore < 800)
        {
            speed += 8f;
        }
        else if (tempPlayerScore >= 800 && tempPlayerScore < 900)
        {
            speed += 9f;
        }
        else if (tempPlayerScore >= 900 && tempPlayerScore < 1000)
        {
            speed += 10f;
        }
        //Debug.Log("SPEED =" + speed);

        rb.velocity = new Vector2(-1 * speed, 0);
        storedScore = playerScore;

    }   //  end of IncreaseSpeed()
}   //  end of class
