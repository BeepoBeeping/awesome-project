using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.ChangeAudioSourceVolume("MainMenu", AudioManager.instance.musicVolume);

        AudioManager.instance.ChangeAudioSourceVolume("sfxVolume", AudioManager.instance.sfxVolume);

        PlayerPrefs.SetFloat("musicVolume", AudioManager.instance.musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", AudioManager.instance.sfxVolume);
    }
}
