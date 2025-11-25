using UnityEditor;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
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
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigBod.linearVelocity = Vector3.up * yvel;
        }

        LevelManager.instance.CheckHealth();

        transform.Rotate(0, 0.1f, 0);
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
