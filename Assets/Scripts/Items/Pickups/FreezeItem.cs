using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeItem : Item
{
     public override string darNome()
    {
        return "Freeze Item";
    }

    public override void OnHit(PlayerStats player, CharacterStats enemy, int stacks)
    {
        //congela o inimigo
        //Chance 0 + stacks/20
        float randomNumber = Random.Range(0, 20);
        if(randomNumber <= stacks)
        {
            enemy.DarFreeze(stacks, 1);
            //Debug.Log("Is Frozen!");
        }
        //Debug.Log("miss freeze! o numero random foi" + randomNumber);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowIceItem();
    }
}
