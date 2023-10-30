using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAreaCollider : MonoBehaviour
{
    public event EventHandler OnPlayerEnter;
    public event EventHandler OnPlayerExit;
    private List<PlayerInTeleporter> playerMapAreaList = new List<PlayerInTeleporter>();
    //Checa quando o player entra no collider do teleporter.
   private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlayerInTeleporter>(out PlayerInTeleporter playerMapAreas))
        {
            playerMapAreaList.Add(playerMapAreas);
            //Invoka o Global Event
            OnPlayerEnter?.Invoke(this, EventArgs.Empty);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<PlayerInTeleporter>(out PlayerInTeleporter playerMapAreas))
        {
            playerMapAreaList.Remove(playerMapAreas);
            OnPlayerExit?.Invoke(this, EventArgs.Empty);
        }
    }
    public List<PlayerInTeleporter> GetPlayerMapAreasList()
    {
        return playerMapAreaList;
    }

}
