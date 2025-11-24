using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    public Rigidbody enemyRigBod;
    public float xvel;
    public float yvel;
    public float zvel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRigBod.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelManager.instance.playerHealth -= 1;
            print(LevelManager.instance.playerHealth);
        }
    }

   
}
