using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script para dar manage na currency.
public class Currency : MonoBehaviour
{
    //Torna o script acessivel de qualquer lugar.
    public static Currency instance;

    public int QuantidadeCurrency;
    public Text caixaTexto;
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }

    public void UpdateCurrency(int valorPego)
    {
        QuantidadeCurrency += valorPego;
        caixaTexto.text = QuantidadeCurrency.ToString();
    }
}
