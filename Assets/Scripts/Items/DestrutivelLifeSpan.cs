using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrutivelLifeSpan : MonoBehaviour
{
    //Script para tempo de vida de objetos quebrados
    [SerializeField]
    private float tempoMorte = 5f;

    void Start()
    {
        Destroy(gameObject, tempoMorte);
    }
}
