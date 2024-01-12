using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float valorSlider;
    public Image panelBrillo;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("billo", 0.5f);  
        panelBrillo.color=new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b,slider.value);
    }

    public void CambiarSlider(float valor) {
        valorSlider = valor;
        PlayerPrefs.SetFloat("billo", valorSlider);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }
}
