using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;
    public float currentVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        PlayerStats stats = parent.GetComponent<PlayerStats>();
        Animator animator = parent.GetComponent<Animator>();
        stats.isDashing = true;
        animator.SetTrigger("IsDashing");
        movement.velocidadeDash = dashVelocity;
        
    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        PlayerStats stats = parent.GetComponent<PlayerStats>();
        stats.isDashing = false;
        movement.velocidadeDash = 1;
    }
}
