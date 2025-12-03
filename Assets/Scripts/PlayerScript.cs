using System;
using UnityEditor;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sfx1;  // sound effect asset from sfx folder
    public Rigidbody playerRigBod;
    public float xvel;
    public float yvel;
    public float zvel;
    ButtonScript reset;
    public int score = 0;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigBod.GetComponent<Rigidbody>();
        LevelManager.instance.SetHighScore(50);
        reset = gameObject.AddComponent<ButtonScript>();
        audioSource = GetComponent<AudioSource>();
        GetComponent<PlayerPreference>();
    }



    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            playerRigBod.linearVelocity = Vector3.forward * zvel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigBod.linearVelocity = -Vector3.forward * zvel;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigBod.linearVelocity = Vector3.left * xvel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigBod.linearVelocity = Vector3.right * xvel;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigBod.linearVelocity = Vector3.up * yvel;
            FindFirstObjectByType<AudioManager>().PlayClip("Jump");
        }

        LevelManager.instance.CheckHealth();

        transform.Rotate(0, 0.1f, 0);
        ModifyScore();
    }

    public void ModifyScore()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            score += 50;
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            score -= 50;
        }

        if (score > PlayerPreference.hiScoreAmount)
        {
            PlayerPrefs.SetInt("hiScore", score);
        }
    }

    public void PlaySoundEffect(bool jump)
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }

    private void OnGUI()
    {
        //read variable from LevelManager singleton
        int health = LevelManager.instance.GetHealth();

        string healthCount = "Health: " + health;       

        // define debug text area
        GUI.contentColor = Color.white;
        GUILayout.BeginArea(new Rect(350f, 10f, 1600f, 1600f));
        GUILayout.Label($"<size=48>{healthCount}</size>");
        GUILayout.EndArea();


        string scoreCount = "Score: " + score;

        // define debug text area
        GUI.contentColor = Color.white;
        GUILayout.BeginArea(new Rect(350f, 70f, 1600f, 1600f));
        GUILayout.Label($"<size=48>{scoreCount}</size>");
        GUILayout.EndArea();

        int highScore = PlayerPreference.hiScoreAmount;

        string highScoreAmount  = "High Score: " + highScore;

        // define debug text area
        GUI.contentColor = Color.white;
        GUILayout.BeginArea(new Rect(625f, 10f, 1600f, 1600f));
        GUILayout.Label($"<size=48>{highScoreAmount}</size>");
        GUILayout.EndArea();


    }

}
