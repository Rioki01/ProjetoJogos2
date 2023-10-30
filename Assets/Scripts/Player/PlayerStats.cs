using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    Animator animator;
    //este arquivo é filho de CharacterStats
    public CameraShake cameraShake;
    public int vidaUpdate;
    //Cria a lista de items que o jogador tem atualmente.
    public List<ItemList> items = new List<ItemList>();
    [SerializeField]
    private GameObject bloodPrefab;
    [SerializeField]
    public EquipedItemsPrefabs equipeditemsPrefabs;

    public bool isDashing;

    private void Start()
    {
        startVariaveis();
    }

    public override void Morto()
    {
        isDead = true;
        //Deixa o game em camera lenta quando morrer
        
        Destroy(gameObject);
    }


    public override void ReceberDano(int dano)
    {
        if(isDashing == false)
        {
            if (defesa == 0)  //se a defesa for 0, logo remove vida, senão remove defesa.
            {
                int vidadepoisDano = vida - dano;
                MudarVidaPara(vidadepoisDano);
                healthBar.ShowHealthBar();
                defenseBar.ShowDefenseBar();
                if (damageText)
                {
                    ShowFloatingText();
                }
                animator.SetTrigger("IsHurt");
                //Cria blood splatters
                Instantiate(bloodPrefab, transform.position, Quaternion.identity);
                //Hitstop
                //FindObjectOfType<HitStop>().SlowmoTime(0.2f);
                //Camera Shake
                //StartCoroutine(cameraShake.Shake(.15f,.02f)); //Tremores muito fortes!!
            }
            else
            {
                int defesadepoisDano = defesa - dano;
                MudarDefesaPara(defesadepoisDano);
                if (shiedText)
                {
                    ShowFloatingTextShield();
                }
            }

            void ShowFloatingText()
            {
                //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
                var go = Instantiate(damageText, transform.position, Quaternion.identity);
                go.GetComponent<TextMesh>().text = dano.ToString();
            }


            //Instancia o texto com dano.
            void ShowFloatingTextShield()
            {
                //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
                var goShield = Instantiate(shiedText, transform.position, Quaternion.identity);
                goShield.GetComponent<TextMesh>().text = dano.ToString();
            }
            
        }
        else
        {
            //Instancia o texto com dano.
            void ShowFloatingDodgeText()
            {
                //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
                var goDodge = Instantiate(dodgeText, transform.position, Quaternion.identity);
            }
            ShowFloatingDodgeText();
            Debug.Log("Dash!");
        }
    }

    public override void ReceberCura(int cura)
    {
        if (vida < vidaMaxima)
        {
            int vidaUpdate = vida + cura;
            ShowFloatingTextHeal();
            MudarVidaPara(vidaUpdate);
            //Hitstop
        }
        else //se a vida for maior ou igual a vida maxima, esconder as barras de vida.
        {
            healthBar.HideHealthBar();
            defenseBar.HideDefenseBar();
        }

        void ShowFloatingTextHeal()
        {
            //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
            var go = Instantiate(healText, transform.position, Quaternion.identity);
            go.GetComponent<TextMesh>().text = cura.ToString();
        }
    }
    void Update()
    {
        //Checa os items do jogador, para adicionar/remover stats.
 
    }

    public override void startVariaveis()
    {
        //Seta Vidad
        vidaMaxima = 100;
        MudarVidaPara(vidaMaxima);
        healthBar.SetVidaMaxima(vidaMaxima);
         
        //attack speed
        cooldownAttack = 1f;

        //dano
        attackDamage = 10;

        //stun
        stunChance = 0;

        //Seta Defesa
        defesaMaxima = 0;
        MudarDefesaPara(defesaMaxima);
        defenseBar.SetDefesaMaxima(defesaMaxima);

        //Estados do personagem.
        isDead = false;
        isRooted = false;
        isOnFire = false;
        isStunned = false;
        isSlowed = false;
        StartCoroutine(CallItemUpdate());
        animator = GetComponent<Animator>();
        equipeditemsPrefabs = GetComponent<EquipedItemsPrefabs>();

        healthBar.HideHealthBar();
        defenseBar.HideDefenseBar();
    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in items)
        {
            i.item.Update(this, i.stacks);
        }
        //Atualiza e checa a cada 1 segundo.
        yield return new WaitForSeconds(1);
        //Loopa a funçao
        StartCoroutine(CallItemUpdate());
    }

    //Código para checar os items quando der dano em algum inimigo.
    public void CallItemOnHit(CharacterStats enemy)
    {
        foreach (ItemList i in items)
        {
            i.item.OnHit(this, enemy, i.stacks);
        }
    }
}
