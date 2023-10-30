using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmScript : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerAttackBehavior playerAttacking;
    [SerializeField] public Transform firePoint2;
    [SerializeField] public GameObject projPrefab2;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        playerAttacking = GetComponentInParent<PlayerAttackBehavior>();
    }

    private void Update()
    {
        if (playerAttacking.shooting2 == true)
        {
            GameObject projetilTurret = Instantiate(projPrefab2, firePoint2.position, firePoint2.rotation);
            projetilTurret.transform.parent = gameObject.transform;
            Rigidbody projetilRB = projetilTurret.GetComponent<Rigidbody>();
            projetilRB.AddForce(firePoint2.up * 500);
            playerAttacking.shooting2 = false;
        }
    }
}
