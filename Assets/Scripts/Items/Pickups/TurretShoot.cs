using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerAttackBehavior playerAttacking;
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject projPrefab;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        playerAttacking = GetComponentInParent<PlayerAttackBehavior>();
    }

    private void Update()
    {
        if(playerAttacking.shooting == true)
        {
            GameObject projetilTurret = Instantiate(projPrefab, firePoint.position, firePoint.rotation);
            projetilTurret.transform.parent = gameObject.transform;
            Rigidbody projetilRB = projetilTurret.GetComponent<Rigidbody>();
            projetilRB.AddForce(firePoint.up * 500);
            playerAttacking.shooting = false;
        }
    }

}
