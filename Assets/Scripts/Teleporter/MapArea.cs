using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    public event EventHandler OnFixTeleporter;
    public event EventHandler OnPlayerEnter;
    public event EventHandler OnPlayerExit;
    private List<MapAreaCollider> mapAreaColliderList;
    private State state;
    private float progress;
    [SerializeField] private float progressSpeed;

    public enum State
    {
        Neutral,
        On,
    }
    private void Awake()
    {
        mapAreaColliderList = new List<MapAreaCollider>();
        foreach(Transform child in transform)
        {
            MapAreaCollider mapAreaCollider = child.GetComponent<MapAreaCollider>();
            if(mapAreaCollider != null)
            {
                mapAreaColliderList.Add(mapAreaCollider);
                mapAreaCollider.OnPlayerEnter += MapAreaCollider_OnPlayerEnter;
                mapAreaCollider.OnPlayerExit += MapAreaCollider_OnPlayerExit;
            }
        }
        state = State.Neutral;
        //Action test
    }

    private void MapAreaCollider_OnPlayerEnter(object sender, EventArgs e)
    {
        OnPlayerEnter?.Invoke(this, EventArgs.Empty);   
    }
    private void MapAreaCollider_OnPlayerExit(object sender, EventArgs e)
    {
        //Quando player sai, checa todos coliders, se estiver um player, ainda não saiu.
        bool hasPlayerInside = false;
        foreach (MapAreaCollider mapAreaCollider in mapAreaColliderList)
        {
            if(mapAreaCollider.GetPlayerMapAreasList().Count > 0)
            {
                hasPlayerInside = true;
            }
        }
        if(!hasPlayerInside)
        {
            OnPlayerExit?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.Neutral:
                //Cria uma lista e checa se nessa lista há os mesmos que na lista do MapAreaCollider.
                //isso impede que um player esteja em duas areas ao mesmo tempo.
                List<PlayerInTeleporter> playerMapAreaInsideList = new List<PlayerInTeleporter>();

                foreach (MapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                    foreach (PlayerInTeleporter playerMapAreas in mapAreaCollider.GetPlayerMapAreasList())
                    {
                        if (!playerMapAreaInsideList.Contains(playerMapAreas))
                        {
                            playerMapAreaInsideList.Add(playerMapAreas);
                        }
                    }
                }

                
                progress += playerMapAreaInsideList.Count * progressSpeed * Time.deltaTime;
                //Debug.Log("Players: " + playerMapAreaInsideList.Count + "Progresso: " + progress);
                if(progress >= 1f)
                {
                    state = State.On;
                    //Invoca o global event
                    OnFixTeleporter?.Invoke(this, EventArgs.Empty);
                    Debug.Log("On");
                }
                break;
            case State.On:
                break;
        }

    }
    public float GetProgress()
    {
        return progress;
    }


}
