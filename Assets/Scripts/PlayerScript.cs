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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigBod.GetComponent<Rigidbody>();
        LevelManager.instance.SetHighScore(50);
        reset = gameObject.AddComponent<ButtonScript>();
        audioSource = GetComponent<AudioSource>();
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
    }

    public void PlaySoundEffect(bool jump)
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }

    private void OnGUI()
    {
        //read variable from LevelManager singleton
        int health = LevelManager.instance.GetHealth();

        string text = "Health: " + health;       

        // define debug text area
        GUI.contentColor = Color.white;
        GUILayout.BeginArea(new Rect(350f, 10f, 1600f, 1600f));
        GUILayout.Label($"<size=48>{text}</size>");
        GUILayout.EndArea();

      
    }

}
