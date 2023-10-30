using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    //Currency.instance
    public int chestPrice;
    public GameObject chestPriceText;
    [SerializeField]
    public GameObject[] chestLoot;
    [SerializeField]
    float[] itemsPercentages;
    public GameObject chestOpen;
    public GameObject chestOpenPrefab;
    public GameObject spawnPosition;
    public int currentLevel;
    //Checa o dinheiro dos jogadores.
    public int currentMoney;
    [SerializeField] public KeyCode teclaOpenP1 = KeyCode.E;
    [SerializeField] public KeyCode teclaOpenP2 = KeyCode.Keypad5;

    void Start()
    {
        //toda vez que o bau spawnar, checa o level atual, e muda seu preço.
        chestPrice = LoopManager.instance.currentLevel * 10;
        chestPriceText.GetComponent<TextMesh>().text = chestPrice.ToString();

    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Players")
        {
            if (Input.GetKeyDown(teclaOpenP1) || Input.GetKeyDown(teclaOpenP2))
            {
                OnBuy();
            }
        }
    }
    private void OnBuy()
    {
        //atualiza o dinheiro do jogador, e testa se é possivel comprar.
        currentMoney = Currency.instance.QuantidadeCurrency;
        if (currentMoney >= chestPrice)
        {
            Destroy(gameObject);
            Currency.instance.UpdateCurrency(-chestPrice);
            Instantiate(chestLoot[GetRandomSpawn()], spawnPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(chestOpen, transform.position, Quaternion.identity);
            Instantiate(chestOpenPrefab, spawnPosition.transform.position, Quaternion.identity);
            
        }
    }
    private int GetRandomSpawn()
    {
        float randomValue = Random.Range(0f, 1f);
        float numForAdd = 0;
        float total = 0;
        //loop para colocar as porcentagens
        for (int i = 0; i < itemsPercentages.Length; i++)
        {
            total += itemsPercentages[i];
        }

        //adiciona items para porcentagem
        for (int i = 0; i < chestLoot.Length; i++)
        {
            if(itemsPercentages[i] / total + numForAdd >= randomValue)
            {
                return i;
            }
            else
            {
                numForAdd += itemsPercentages[i] / total;
            }
        }
        //para nao retornar erro
        return 0;
    }
}
