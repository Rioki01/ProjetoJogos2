using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Comida : Item
{
    public GameObject prefab;
    public override string darNome()
    {
        return "Comida";
    }

}
