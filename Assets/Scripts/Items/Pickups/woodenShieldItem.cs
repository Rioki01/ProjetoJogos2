using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodenShieldItem : Item
{
    // Start is called before the first frame update
    public override string darNome()
    {
        return "Wood Shield Item";
    }
    public override void Start()
    {
    }
    public override void OnPickupStat(PlayerStats player)
    {
        //adiciona 25 de vida a mais para o player.
        player.setMaxShield(25);
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowAdrenalineItem();
    }
}
