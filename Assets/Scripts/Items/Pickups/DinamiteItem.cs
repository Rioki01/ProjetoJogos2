using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamiteItem : Item
{
    //Explode os inimigos em contato.
    public override string darNome()
    {
        return "Dinamite Item";
    }

    public override void OnHit(PlayerStats player, CharacterStats enemy, int stacks)
    {
        //congela o inimigo
        //Chance 0 + stacks/20
        float randomNumber = Random.Range(0, 10);
        if (randomNumber <= stacks)
        {
            enemy.DarExplosion(stacks, 5);
            //Debug.Log("BOOM!");
        }
        //Debug.Log("miss Explosion! o numero random foi" + randomNumber);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowDinamiteItem();
    }
}
