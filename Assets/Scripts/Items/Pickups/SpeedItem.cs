using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
{
    public GameObject prefab;

    public override string darNome()
    {
        return "Speed Item";
    }
    public override void Start()
    {
    }
    public override void OnPickupSpeed(PlayerMovement player)
    {
        player.velocidade += 0.3f;
    }
}
