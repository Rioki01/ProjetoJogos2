using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrutivel : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] private bool podeAtacar;

    public GameObject PrefabDestruido;

     private void Start()
    {
        startVariaveis();
    }

    public void darDano(CharacterStats statsDano)
    {
        statsDano.ReceberDano(damage);
    }
    public override void Morto()
    {
        base.Morto();
        Instantiate(PrefabDestruido,transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public override void startVariaveis()
    {
        vidaMaxima = 10;
        MudarVidaPara(vidaMaxima);
        healthBar.SetVidaMaxima(vidaMaxima);
        isDead = false;
    }
}
