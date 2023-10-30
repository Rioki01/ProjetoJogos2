using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : ArrowController
{
    //tempo de vida do projetil
    public float tempo = 10;
    private Rigidbody rigidBody;
    PlayerStats playerStats;
    [SerializeField]
    private GameObject prefabQuebrado;
    ArrowController arrowController;
    //pega os stats e items do player.
    [SerializeField]

    public Transform alvo;
    public GameObject[] AlvosPossiveis;

    public float Speed = 10f;
    Quaternion rotGoal;
    Vector3 direction;
    public Vector3 velocity = Vector3.zero;

    //Stats do projetil, que seram pegos do scriptable object.
    protected int danoAtual;
    protected float velocidadeAtual;
    protected float cooldownAtual;
    protected int stunAtual;

    private void Awake()
    {
        velocidadeAtual = weaponData.ForcaProjetil;
        cooldownAtual = weaponData.CooldownAtaque;
        Destroy(gameObject, tempo);
    }

    protected override void Start()
    {
        base.Start();
        firePoint = null;
        //animatorFlecha = GetComponent<Animator>();
        arrowController = FindObjectOfType<ArrowController>();
        rigidBody = GetComponent<Rigidbody>();
        playerStats = GetComponentInParent<PlayerStats>();
        danoAtual = playerStats.attackDamage;
        stunAtual = playerStats.stunChance;
        //adiciona o stats do player e remove o parent, se não a flecha move com o player.
        transform.parent = null;
    }
    protected override void Update()
    {
        //Remove os instantiates do script original.
    }

    protected override void Atirar()
    {
        //Remove os instantiates do script original.
    }

    // Segue a tag se estiver perto.
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Inimigo_Target")
        {
        AcharInimigos();
        alvo = AcharInimigos();
        //Rotaciona para X alvo.
        direction = (alvo.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(Vector3.one);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, Speed);
        //se move ao alvo
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, 20f * Time.deltaTime);
        }
    }

    // se entrar em um collider, o destroi
    void OnCollisionEnter(Collision collision)
    {       
        if(collision.gameObject.tag == "Inimigo")
        {
            //Deixa projetil imovel e gruda-o ao inimigo
            //rigidBody.isKinematic = true;
            //transform.SetParent(collision.transform);
            //pega a variavel de vida e da dano ao inimigo
            CharacterStats enemyStat = collision.transform.GetComponent<CharacterStats>();
            enemyStat.ReceberDano(danoAtual);
            playerStats.CallItemOnHit(enemyStat);
            Destroy(gameObject);
            //destroy dps de #tempo segundos.
        } 
        else if (collision.gameObject.tag == "Destrutivel")
        {
            CharacterStats enemyStat = collision.transform.GetComponent<CharacterStats>();
            enemyStat.ReceberDano(danoAtual);
            Instantiate(prefabQuebrado, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Portal" )
        {
            Instantiate(prefabQuebrado, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Portal")
        {
            Instantiate(prefabQuebrado, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Players")
        {
            Destroy(gameObject);
        }
        


    }

    public Transform AcharInimigos()
    {
        AlvosPossiveis = GameObject.FindGameObjectsWithTag("Inimigo");
        float distanciaCurta = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject go in AlvosPossiveis)
        {
            float distanciaAtual;
            distanciaAtual = Vector3.Distance(transform.position, go.transform.position);
            if(distanciaAtual < distanciaCurta)
            {
                distanciaCurta = distanciaAtual;
                trans = go.transform;
            }
        }
        return trans;
    }
} 
