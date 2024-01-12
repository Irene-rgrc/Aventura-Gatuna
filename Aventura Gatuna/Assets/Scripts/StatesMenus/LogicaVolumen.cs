using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float valorSlider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume=slider.value;
    }

    public void CambiarSlider(float valor) {
        valorSlider = valor;
        PlayerPrefs.SetFloat("volumenAudio", valorSlider);
        AudioListener.volume = slider.value;
    }
}
