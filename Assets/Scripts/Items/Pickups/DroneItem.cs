using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneItem : Item
{
    public override string darNome()
    {
        return "Drone Item";
    }

    public override void OnHit(PlayerStats player, CharacterStats enemy, int stacks)
    {
        enemy.ReceberDano(stacks * 1);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowDroneItem();
    }
}
