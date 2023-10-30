using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    //Seta o nome do item para:
    public override string darNome()
    {
        return "Healing Item";
    }

    public override void Update(PlayerStats player, int stacks)
    {
        player.ReceberCura(1 + (2 * stacks));
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowMedickitItem();
    }
}
