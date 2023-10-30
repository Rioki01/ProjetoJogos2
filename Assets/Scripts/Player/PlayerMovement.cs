using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    #region
    public static Transform instancia;
    private void Awake()
    {
        instancia = this.transform;
    }
    #endregion


    Animator animator;

    [SerializeField] private Rigidbody rigidbdy;
    //velocidade da rotação
    [SerializeField] private float velocidaderot = 360;
    //velocidade do personagem.

    [SerializeField] public float velocidade = 5;
    [SerializeField] public float velocidadeDash = 1;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    //inpute do jogador
    private Vector3 input;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerInput();
        OlharDir();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        input = new Vector3(Input.GetAxisRaw(inputNameHorizontal),0,Input.GetAxisRaw(inputNameVertical));
        
        
    }
    private void OlharDir()
    {
        //pega posição atual do personagem e a rotação, e aplica no transform, movimentando o model.
        if (input != Vector3.zero)
        {
        animator.SetBool("IsWalking",true);
        var posicao = (transform.position + input.ToIso() - transform.position);
        var rotacao = Quaternion.LookRotation(posicao,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotacao, velocidaderot * Time.deltaTime);
        }
        else
        {
        animator.SetBool("IsWalking",false);
        }
    }
    private void Move()
    {
        rigidbdy.MovePosition(transform.position + (transform.forward * input.magnitude) * velocidade * velocidadeDash * Time.deltaTime);
        
    }
}
