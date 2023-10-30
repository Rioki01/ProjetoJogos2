using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] private int CurrencyValue;
    //checa se levou dano
    
    //dropa items ao morrer.
    //[SerializeField] private bool podeAtacar;
    private float tempoMorte = 5f;

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
        //Se não está morto, dropa o loot, isso impede um bug de cristais infinitos.
        if (!isDead)
        {
            Currency.instance.UpdateCurrency(CurrencyValue * level);
        }
        isDead = true;
        //remove todos coliders ao morrer.
        Collider[] deathcollider = gameObject.GetComponentsInChildren<Collider>();
        foreach(Collider col in deathcollider)
        {
            col.enabled = false;
        }
        //desativa VFX de fogo
        //FirePrefab.SetActive(false);
        Destroy(gameObject, tempoMorte);
    }

    public override void DarStun(int stun)
    {
        if (stun > 0)
        {
            isStunned = true;
            Debug.Log("IsStunned!");
        }
        else
        {
            isStunned = false;
        }
    }

    public override void startVariaveis()
    {
        level = 1;
        MudarVidaPara(vidaMaxima);
        defesaMaxima = 0;
        MudarDefesaPara(defesaMaxima);
        isDead = false;
        isOnFire = false;
        isRooted = false;
        isStunned = false;
        //podeAtacar = true;

        //Esconde as barras de vida
        healthBar.HideHealthBar();
        defenseBar.HideDefenseBar();
    }
}
