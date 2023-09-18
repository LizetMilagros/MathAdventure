using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumenFX;
    public Slider volumenMaster;
    public Toggle mute;
    
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelsPanel;

    private void Awake(){
        volumenFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumenMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }
    public void SetMute(){
        
        if(mute.isOn){
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster",-80);
        }else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }
    public void OpenPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelsPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }
    public void ChangeVolumeMaster(float v){
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v){
        mixer.SetFloat("VolFX", v);
    }
    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }

}
