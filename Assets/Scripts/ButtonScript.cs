using System.Threading;
using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{


    public TMP_Text buttonText;

    public GameObject player;

    public void ButtonMethod()
    {               
            LevelManager.instance.playerHealth = 3;
            print("Player Health back to " + LevelManager.instance.playerHealth);
            buttonText.text = "Success!";
            player.transform.position = new Vector3(469f, 1f, 459f);        
    }  

}
