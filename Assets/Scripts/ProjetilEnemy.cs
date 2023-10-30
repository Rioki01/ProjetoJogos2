using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilEnemy : MonoBehaviour
{
    //tempo de vida do projetil
    public float tempo = 1;
    public int dano = 10;
    public float radius = 5f;
    private Rigidbody rigidBody;
    public Transform firePoint = null;

    //Seguir alvo


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        Destroy(gameObject, tempo);
    }

    // se entrar em um collider, o destroi

    void OnCollisionEnter(Collision collision)
    {       
        if(collision.gameObject.tag == "Players")
        {
            CharacterStats enemyStat = collision.transform.GetComponent<CharacterStats>();
            enemyStat.ReceberDano(dano);
            //destroy dps de #tempo segundos.
            Destroy(gameObject);
        }
        //|| collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "Portal"
        else if (collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "Pickups" || collision.gameObject.tag == "Destrutivel")
        {
            Physics.IgnoreLayerCollision(8,7);
            Physics.IgnoreLayerCollision(8,9);
        }
        else if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Portal")
        {
            Destroy(gameObject);
        }
    }
} 
