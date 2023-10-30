using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_LichController : MonoBehaviour
{
    //adiciona um navmesh para controlar com AI
    private NavMeshAgent agent = null;
    private Animator animator = null;
    private EnemyStat stats = null;
    private float tempoUltimoAtaque = 0;
    private bool pertoPlayer = false;
    private Transform alvo;
    public GameObject[] AlvosPossiveis;

    //ATACK COLLIDERS
    public GameObject projetilPrefab;
    [SerializeField]
    private GameObject bloodPrefab;
    [SerializeField]
    private GameObject bloodPrefabLarge;
    public Transform firePoint;
    public float forcaProjetil = 5;
    //[SerializeField] private float distanciaParar = 3;

    private void Start()
    {
        GetReferences();
    }
    private void Update()
    {
        alvo = AcharPlayers();
        andarAlvo();
    }



    private void andarAlvo()
    {
        //se o inimigo estiver vivo, então:
        if (stats.isDead == false)
        {
            //Se não estiver stunado, então:
            if (stats.isStunned == false)
            {
                if (stats.isHurt == false)
                {
                    agent.SetDestination(alvo.position);
                    float distanciaAlvo = Vector3.Distance(transform.position, alvo.position);
                    animator.SetBool("IsWalking", true);
                    rotacionarInimigo();
                    if (distanciaAlvo <= agent.stoppingDistance)
                    {
                        animator.SetBool("IsWalking", false);
                        //checa o alvo e da dano.

                        if (!pertoPlayer)    //coloca um tempo antes de atacar
                        {
                            pertoPlayer = true;
                            tempoUltimoAtaque = Time.time;
                        }
                        if (Time.time >= tempoUltimoAtaque + stats.attackSpeed)
                        {
                            tempoUltimoAtaque = Time.time;
                            animator.SetTrigger("Attack");
                            AtacarAlvo();
                        }
                    }
                    else
                    {
                        if (pertoPlayer)
                            pertoPlayer = false;
                    }
                }
                else
                {
                    //animator.SetTrigger("IsHurt");
                    //Cria blood splatters e o adiciona como child.
                    Instantiate(bloodPrefab, transform.position, Quaternion.identity);
                    stats.isHurt = false;
                }
            }
            else
            {
                //desativa a AI se estiver com stun/root.
                IsStunned();
            }
        }
        else
        {
            //desativa a AI
            agent.enabled = false;
            //Ativa animação de morte
            animator.SetTrigger("IsDead");
        }
    }

    private void IsStunned()
    {
        agent.speed = 0;
        animator.SetBool("IsStunned", true);
    }

    private void rotacionarInimigo()
    {
        transform.LookAt(alvo);

        //Faz o inimigo não girar para olhar pra cima ou baixo.
        Vector3 direcao = alvo.position - transform.position;
        Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = rotacao;
    }
    private void AtacarAlvo()
    {
        GameObject projetil = Instantiate(projetilPrefab, firePoint.position, firePoint.rotation);
        //pega a rigidbody e aplica
        Rigidbody projetilRB = projetil.GetComponent<Rigidbody>();
        projetilRB.AddForce(firePoint.up * forcaProjetil);

    }

    private void SpawnEnemies()
    {

    }

    private void ExplodeArea()
    {

    }

    private void CreateStunArea()
    {

    }


    public Transform AcharPlayers()
    {
        AlvosPossiveis = GameObject.FindGameObjectsWithTag("Players");
        float distanciaCurta = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject go in AlvosPossiveis)
        {
            float distanciaAtual;
            distanciaAtual = Vector3.Distance(transform.position, go.transform.position);
            if (distanciaAtual < distanciaCurta)
            {
                distanciaCurta = distanciaAtual;
                trans = go.transform;
            }
        }
        return trans;
    }

    private void GetReferences()
    {
        alvo = AcharPlayers();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stats = GetComponent<EnemyStat>();

    }
}
