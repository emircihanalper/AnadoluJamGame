using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolume : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void UpdateBGMVolume()
    {
        audioManager.SetBGMVolume(bgmSlider.value);
        PlayerPrefs.SetFloat("bgm", bgmSlider.value);

    }

    public void UpdateSFXVolume()
    {
        audioManager.SetSFXVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("sfx", sfxSlider.value);
    }
}
