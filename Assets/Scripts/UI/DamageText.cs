using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    private float tempoMorte = 0.4f;
    private Vector3 scaleChange;
    void Start()
    {
        Destroy(gameObject, tempoMorte);
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    }
    private void Update()
    {
        transform.position += transform.up * 5 * Time.deltaTime;
        this.scaleChange = -scaleChange;
    }
}
