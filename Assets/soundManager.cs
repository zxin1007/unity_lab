using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
            load();
        } else{
            load();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVolume(){
        AudioListener.volume = volume.value;
    }

    public void save(){
        PlayerPrefs.SetFloat("musicVolume",volume.value);
    }

    public void load(){
        volume.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
