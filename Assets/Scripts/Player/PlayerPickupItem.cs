using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{
    public Item item;
    public Items itemDrop;
    [SerializeField] public GameObject itemNameText;

    void Start()
    {
        item = AssignItem(itemDrop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Players")
        {
            //Checa qual player pegou o item.
            PlayerStats player = other.GetComponent<PlayerStats>();
            PlayerMovement playerMov = other.GetComponent<PlayerMovement>();
            //modifica a velocidade do player
            item.OnPickupSpeed(playerMov);
            //adiciona stats ao player
            item.OnPickupStat(player);
            //adiciona item prefabs no player
            item.OnPickupPrefab(player);
            //Da o popup com o nome do item
            AddItem(player);
            Destroy(this.gameObject);
        }
    }
    public void AddItem(PlayerStats player)
    {
        //Checa a lista de items do player, caso tenha um item com o mesmo nome, adiciona um, se não, cria um novo.
        foreach(ItemList i in player.items)
        {
            if (i.name == item.darNome())
            {
                i.stacks += 1;
                return;
            }
        }
        player.items.Add(new ItemList(item, item.darNome(),1));
    }
    public void ItemNamePopup()
    {

    }
    public Item AssignItem(Items itemAssign)
    {
        switch(itemAssign)
        {
            case Items.HealingItem:
                return new HealItem();
            case Items.SpeedItem:
                return new SpeedItem();
            case Items.Gasoline:
                return new GasolineFireDamage();
            case Items.Adrenaline:
                return new AttackSpeedItem();
            case Items.FreezeItem:
                return new FreezeItem();
            case Items.DinamiteItem:
                return new DinamiteItem();
            case Items.DroneItem:
                return new DroneItem();
            case Items.RoboticArm:
                return new BracoRoboticoItem();
            case Items.PillsHealth:
                return new PillsHealthItem();
            case Items.woodShield:
                return new woodenShieldItem();
            default:
                return new HealItem();
        }
    }

    public enum Items
    {
        HealingItem,
        SpeedItem,
        Gasoline,
        Adrenaline,
        FreezeItem,
        DinamiteItem,
        DroneItem,
        RoboticArm,
        PillsHealth,
        woodShield,
    }
}
