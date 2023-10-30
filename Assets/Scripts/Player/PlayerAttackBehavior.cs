using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base script para TODAS armas
public class PlayerAttackBehavior : MonoBehaviour
{
    //Projetil
    [Header("Weapon Prefabs")]
    public WeaponScriptableObject weaponData;
    [SerializeField]public Transform firePoint;
    Animator animator;
    PlayerStats playerStatsCooldown;

    //bools
    public bool shooting, shooting2, reloading, readyAtack;
    [SerializeField] public KeyCode teclaAtaque = KeyCode.Space;

    protected virtual void Start()
    {
        readyAtack = true;
        shooting = false;
        shooting2 = false;
        animator = GetComponent<Animator>();
        playerStatsCooldown = GetComponent<PlayerStats>();
    }

    protected virtual void Update()
    {
        if(Input.GetKey(teclaAtaque) && readyAtack)
        {
            animator.SetTrigger("IsAttacking");
            Atirar();
        }
    }
    protected virtual void Atirar()
    {
        readyAtack = false;
        shooting = true;
        shooting2 = true;
        //instancia o projetil
        GameObject projetil = Instantiate(weaponData.ProjetilPrefab, firePoint.position,firePoint.rotation);
        //transforma a flecha em parent, para checar os stats do player.
        projetil.transform.parent = gameObject.transform;
        //pega a rigidbody e aplica
        Rigidbody projetilRB = projetil.GetComponent<Rigidbody>();
        projetilRB.AddForce(firePoint.up * weaponData.ForcaProjetil);
        //Cooldown
        Invoke(nameof(ResetAtaque), playerStatsCooldown.cooldownAttack);
    }

    protected virtual void ResetAtaque()
    {
        readyAtack = true;
    }
    
}
