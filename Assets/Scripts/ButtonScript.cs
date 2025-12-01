using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{


    public TMP_Text buttonText;

    public GameObject player;

    public void ButtonMethod()
    {               
            LevelManager.instance.playerHealth = 3;
            print("Player Health back to " + LevelManager.instance.playerHealth);
            buttonText.text = "Success!";
            player.transform.position = new Vector3(0f, 0f, 0f);
            FindFirstObjectByType<AudioManager>().PlayClip("ButtonClick");
    }

    public void L1Button()
    {
        SceneManager.LoadScene("Level1");
        FindFirstObjectByType<AudioManager>().PlayClip("ButtonClick");
    }
    public void L2Button()
    {
        SceneManager.LoadScene("Level2");
        FindFirstObjectByType<AudioManager>().PlayClip("ButtonClick");
    }
    public void QuitMenuButton()
    {
        SceneManager.LoadScene("Menu");
        FindFirstObjectByType<AudioManager>().PlayClip("ButtonClick");
    }

}
