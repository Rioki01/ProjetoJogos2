using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script para pegar currency.
public class PlayerCurrencyPickups : MonoBehaviour
{
    public enum Pickups {Cristais};
    public Pickups currentObject;
    //public PickupObject currentObject;
    public int PickupQuantidade;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Players")
        {
            if(currentObject == Pickups.Cristais)
            {
                Destroy(gameObject);
                Currency.instance.UpdateCurrency(PickupQuantidade);
            }
        }
    }

}
