using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineFireDamage : Item
{
    //Gasolina, queima os inimigos ao acertar-los!
    //Seta o nome do item para:
    public override string darNome()
    {
        return "Gasoline Item";
    }

    public override void OnHit(PlayerStats player, CharacterStats enemy, int stacks)
    {
        //coloca o inimigo em chamas
        //Chance 0 + stacks/10
        float randomNumber = Random.Range(0, 10);
        if (randomNumber <= stacks)
        {
            enemy.DarFire(stacks, 1);
            //Debug.Log("Is on Fire!");
        }
        //Debug.Log("miss on fire! o numero random foi: " + randomNumber);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowGasolineItem();
    }
}
