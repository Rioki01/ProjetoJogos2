using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defenseBarScript : MonoBehaviour
{

    public Slider sliderDefesa;
    public Image barraDefesa;


    //DEFESA
    public void SetDefesaMaxima(int defesa)
    {
        sliderDefesa.maxValue = defesa;
        sliderDefesa.value = defesa;
    }
    public void SetDefesa(int defesa)
    {
        sliderDefesa.value = defesa;
    }

    public void HideDefenseBar()
    {
        gameObject.SetActive(false);
    }
    public void ShowDefenseBar()
    {
        gameObject.SetActive(true);
    }
}
