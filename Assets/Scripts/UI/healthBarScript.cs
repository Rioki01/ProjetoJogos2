using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradiente;
    public Image barraVida;


    //VIDA
    public void SetVidaMaxima(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
        barraVida.color = gradiente.Evaluate(1f); 
    }
    public void SetVida(int vida)
    {
        slider.value = vida;
        barraVida.color = gradiente.Evaluate(slider.normalizedValue);
    }

    public void HideHealthBar()
    {
        gameObject.SetActive(false);
    }
    public void ShowHealthBar()
    {
        gameObject.SetActive(true);
    }
}
