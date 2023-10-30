using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Classe abstrata serve como base, funçoes e valores.
[System.Serializable]
public abstract class Item
{
    //todos items derivam desse script.

    public abstract string darNome();
    public Sprite icone;
    public string descricao;
    public WeaponScriptableObject weaponData;
    public PlayerMovement playerSpeed;
    public EquipedItemsPrefabs playeritemPrefabs;


    public virtual void Start()
    {
       //faz coisas ao pegar.
    }
    public virtual void Update(PlayerStats player, int stacks)
    {
        //Faz coisas sempre.
    }
    public virtual void OnHit(PlayerStats player, CharacterStats enemy, int stacks)
    {
        //faz coisas ao atingir.
    }
    public virtual void OnPickupSpeed(PlayerMovement player)
    {
        //faz coisas ao atingir.
    }
    public virtual void OnPickupStat(PlayerStats player)
    {
        //faz coisas ao atingir.
    }
    public virtual void OnPickupPrefab(PlayerStats player)
    {
        //Mostra o item ao pegar-lo
    }
}

