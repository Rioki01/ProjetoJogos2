using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    // Scripts para habilidades e ultimates.
    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent)
    {

    }
    public virtual void BeginCooldown(GameObject parent)
    {

    }
}
