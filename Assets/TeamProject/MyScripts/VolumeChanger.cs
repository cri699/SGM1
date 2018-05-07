using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour {

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text text;

    
    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        text.text = "Volume: "+slider.value + "%";
        AudioListener.volume = slider.value / 100;
    }
}
