using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // script para TODOS personagens.
    // Basicamente, vida,defesa,bools e dano vem daqui.
    //XP E LEVEL para scaling de dificuldade/dano.
    [SerializeField] protected int level;
    [SerializeField] protected int xp;

    //protected faz um script privado a todos, menos a child scripts.
    [SerializeField]protected int vida;
    [SerializeField]protected int vidaMaxima;

    //defesa
    [SerializeField]protected int defesa;
    [SerializeField]protected int defesaMaxima;

    //attackspeed
    [SerializeField] public float cooldownAttack;

    //dano
    [SerializeField] public int attackDamage;
    [SerializeField] public int stunChance;

    private IEnumerator enemyDamageTimer;


    //UI Barra de Vida.
    [SerializeField]public healthBarScript healthBar;
    [SerializeField]public defenseBarScript defenseBar;
    //UI de Dano e Shield.
    [SerializeField] public GameObject damageText;
    [SerializeField] public GameObject shiedText;
    [SerializeField] public GameObject healText;
    [SerializeField] public GameObject dodgeText;

    //VFX
    [SerializeField] public GameObject FirePrefab;
    [SerializeField] public GameObject IcePrefab;
    [SerializeField] public GameObject DinamitePrefab;

    //Stats
    [SerializeField]protected int dodgeChance;

    //death prefab
    [SerializeField] public GameObject deathPrefab;

    //checa se esta vivo ou morto
    [SerializeField]public bool isDead;
    //checa se esta estunado
    [SerializeField]public bool isStunned;
    //checa se esta rooted
    [SerializeField]public bool isRooted;
    //checa se esta em chamas
    [SerializeField]public bool isOnFire;
    //checa se esta congelado
    [SerializeField]public bool isFreezed;
    //checa se esta lento
    [SerializeField]public bool isSlowed;
    //para animaçoes
    [SerializeField] public bool isHurt;

    private void Start()
    {
        startVariaveis();
    }

public void checkVida()
{
    //Checa se o player esta vivo ou morto.
    if(vida <=0)
    {
        vida=0;
        Morto();
    }
    //Checa se a vida não passa do maximo.
    if(vida >= vidaMaxima)
    {
        vida = vidaMaxima;
    }
}

public void checkDefesa()
{
    if(defesa <=0)
    {
        defesa=0;
    }
    if(defesa >= defesaMaxima)
    {
        defesa = defesaMaxima;
    }
}
//para matar coisas.
//os inimigos dão override neste script em "EnemyStat".
public virtual void Morto()
    {
    //Dar override.
    }

//muda a vida em certa ação.
public void MudarVidaPara(int colocarvidaPara)
    {
    vida = colocarvidaPara;
    //quando receber dano, mudar a barra de vida.
    healthBar.SetVida(vida);
    checkVida();
    }

//muda a defesa quando se leva dano.
public void MudarDefesaPara(int colocarDefesaPara)
    {
    defesa = colocarDefesaPara;
    defenseBar.SetDefesa(defesa);
    checkDefesa();
    }


//checa se a entidade tem escudo, se não da dano.
public virtual void ReceberDano(int dano)
{
    //se a defesa for 0, logo remove vida, senão remove defesa.
        if(dano - defesa < 0)
        {
            int vidadepoisDano = vida - (dano - defesa);
            isHurt = true;
            MudarVidaPara(vidadepoisDano);
            healthBar.ShowHealthBar();
            defenseBar.ShowDefenseBar();
                //Ativa popup de dano.
                if (damageText)
                {
                ShowFloatingText();
                }
        }
        else
        {
            int defesadepoisDano = defesa - dano;
            MudarDefesaPara(defesadepoisDano);
            healthBar.ShowHealthBar();
            defenseBar.ShowDefenseBar();
            if (shiedText)
            {
                ShowFloatingTextShield();
            }
        }

    //Instancia o texto com dano.
        void ShowFloatingText()
        {
        //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
        var go = Instantiate(damageText, transform.position, Quaternion.identity); 
        go.GetComponent<TextMesh>().text = dano.ToString();
        }

        //Instancia o texto com Shield.
        void ShowFloatingTextShield()
        {
            //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
            var goShield = Instantiate(shiedText, transform.position, Quaternion.identity);
            goShield.GetComponent<TextMesh>().text = dano.ToString();
        }

    }
    public virtual void ReceberCura(int cura)
    {
        //Cura
    }

    //FUNÇÕES DE GAMEPLAY/RNG

    //Cura a entidade
    public void Curar(int cura)
    {
        int vidadepoisCura = vida + cura;
        MudarVidaPara(vidadepoisCura);
    }
    //Da escudo a entidade.
    public void Shield(int defesaGanha)
    {
        int defesaDepois = defesa + defesaGanha;
        MudarDefesaPara(defesaDepois);
    }


    //Stuna a entidade
    public virtual void DarStun(int stun)
    {
        //Stuns the entity
    }


        //Congela a entidade
    public virtual void DarFreeze(int stack, int dano)
    {
       //
       isFreezed = true;
       IcePrefab.SetActive(true);
       ShowFloatingFrozenText();
       enemyDamageTimer = OnDamageTimer(stack + 3.0f);
       StartCoroutine(enemyDamageTimer);
        //isFreezed = false;

        void ShowFloatingFrozenText()
        {
            //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
            var goShield = Instantiate(shiedText, transform.position, Quaternion.identity);
            goShield.GetComponent<TextMesh>().text = "Congelado!".ToString();
        }
    }
    //Deixa a entidade lenta
    public virtual void DarSlow()
    {
       //
       isSlowed = true;
    }
    //Coloca a entidade em Chamas
    public virtual void DarFire(int stack, int dano)
    {
        //Calcular chance aqui
        isOnFire = true;
        FirePrefab.SetActive(true);
        //transforma a flecha em parent, para checar os stats do player.
        enemyDamageTimer = OnDamageTimer(stack + 2.0f);
        ShowFloatingFireText();
        StartCoroutine(enemyDamageTimer);

        void ShowFloatingFireText()
        {
            //Instancia o texto, na posição do inimigo, sem rotação e como uma child.
            var goShield = Instantiate(damageText, transform.position, Quaternion.identity);
            goShield.GetComponent<TextMesh>().text = "Em Chamas!".ToString();
        }
    }
    public virtual void DarExplosion(int stack, int dano)
    {
        //spawna um prefab que da dano e explode no inimigo
        //Dano estaca com a quantidade de items.
        ReceberDano(stack * 10);
        //Instancia um prefab, que explode na hora.
        Instantiate(DinamitePrefab, transform.position, transform.rotation, transform.parent);
        
    }

    private IEnumerator OnDamageTimer(float waitTime)
    {
        //cria um timer, e quando o timer for igual o tempo stack + x, retorna null.
        //a cada waittime(stack + 2s)/2 dar 3 de dano.
        float tempo = 0.0f;
        while (tempo < waitTime)
        {
            yield return new WaitForSeconds(waitTime/2);
            if(!isDead)
            { 
                ReceberDano(3);
            }
            tempo = tempo + 1.0f;
        }
        stopsVFX();
        yield return null;
    }

    //Prende a entidade no lugar
    public virtual void DarRoot()
    {
       //
       isRooted = true;
    }

    public virtual void stopsVFX()
    {
        //stops fire
        isOnFire = false;
        FirePrefab.SetActive(false);
        //stops Freeze
        isFreezed = false;
        IcePrefab.SetActive(false);
    }

    public void setMaxHealth(int newhealth)
    {
        vidaMaxima += newhealth;
        MudarVidaPara(vida + newhealth);
        healthBar.SetVida(vida);
    }

    public void setMaxShield(int newshield)
    {
        defesaMaxima += newshield;
        MudarDefesaPara(defesa + newshield);
        defenseBar.SetDefesa(defesa);
    }



    //Variaveis de inicio, o player sempre tera essas variaveis ao começar um jogo novo.
    public virtual void startVariaveis()
    {
        //Seta Vida
        vidaMaxima = 100;
        MudarVidaPara(vidaMaxima);
        healthBar.SetVidaMaxima(vidaMaxima);
        healthBar.HideHealthBar();

        //Seta Defesa
        defesaMaxima = 5;
        MudarDefesaPara(defesaMaxima);
        defenseBar.SetDefesaMaxima(defesaMaxima);
        defenseBar.HideDefenseBar();

        //Estados do personagem.
        isDead = false;
        isRooted = false;
        isOnFire = false;
        isStunned = false;
        isSlowed =false;

        //seta os VFX
        FirePrefab.SetActive(false);


    }
}

