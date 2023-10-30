using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsHealthItem : Item
{
    public override string darNome()
    {
        return "Pills Item";
    }
    public override void Start()
    {
    }
    public override void OnPickupStat(PlayerStats player)
    {
        //adiciona 25 de vida a mais para o player.
        player.setMaxHealth(25);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowAdrenalineItem();
    }
}
