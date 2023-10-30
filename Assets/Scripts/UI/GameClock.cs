using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    //script para cronometro do game.
    public float timeInicio = 0;

    public Text caixaTexto;

    //para parar o tempo.
    bool timerAtivo = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(timerAtivo)
        {
        timeInicio += Time.deltaTime;
        DisplayTimer(timeInicio);
        }
    }

    void DisplayTimer(float TempoTela)
    {
        TempoTela +=1;
        float minutos = Mathf.FloorToInt(TempoTela / 60);
        float segundos = Mathf.FloorToInt(TempoTela % 60);
        caixaTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void pararTimer()
    {
        //muda a bool para falso/verdade.
        timerAtivo = !timerAtivo;
    }
}
