using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedItem : Item
{

    //adrenalina, aumenta a attack speed do jogador!
    public GameObject prefab;

    public override string darNome()
    {
        return "Attack Speed Item";
    }
    public override void Start()
    {
    }
    public override void OnPickupStat(PlayerStats player)
    {
        player.cooldownAttack -= 0.03f;
    }
    public override void OnPickupPrefab(PlayerStats player)
    {
        player.equipeditemsPrefabs.ShowAdrenalineItem();
    }

}
