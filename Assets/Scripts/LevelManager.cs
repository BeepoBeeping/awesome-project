using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int highScore;
    public int playerHealth = 3;
    public GameObject player;

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }


    //these methods are globally accessible

    public void CheckHealth()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 3;
            player.transform.position = new Vector3(469f, 1f, 459f);
        }
    }
    public void SetHighScore(int score)
    {
        highScore = score;
    }
    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHealth(int health)
    {
        playerHealth = health;
    }
    public int GetHealth()
    {
        return playerHealth;
    }
}
