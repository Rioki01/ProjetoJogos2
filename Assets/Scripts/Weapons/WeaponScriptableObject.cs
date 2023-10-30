using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Novo Item",menuName = "Arma")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject projetilPrefab;

    public GameObject ProjetilPrefab { get => projetilPrefab; private set => projetilPrefab = value; }  //Adiciona medidas de segurança, para nao ocorrer overrides em public floats.
    //status da arma

    [SerializeField] 
    float cooldownAtaque = 1f;
    public float CooldownAtaque { get => cooldownAtaque; private set => cooldownAtaque = value; }
    [SerializeField] 
    float forcaProjetil = 20;
    public float ForcaProjetil { get => forcaProjetil; private set => forcaProjetil = value; }
    [SerializeField] 
    int dano = 10;
    public int Dano { get => dano; private set => dano = value; }

    [SerializeField] int critChance;
    public int CritChance { get => critChance; private set => critChance = value; }
    [SerializeField] int stunChance;
    public int StunChance { get => stunChance; private set => stunChance = value; }
    [SerializeField] int freezeChance;
    public int FreezeChance { get => freezeChance; private set => freezeChance = value; }
    [SerializeField] int fireChance;
    public int FireChance { get => fireChance; private set => fireChance = value; }
    [SerializeField] int rootChance;
    public int RootChance { get => rootChance; private set => rootChance = value; }

}
