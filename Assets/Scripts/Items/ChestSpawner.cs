using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public List<Enemy> chests = new List<Enemy>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> chestsToSpawn = new List<GameObject>();

    //location spawns
    [SerializeField] public Transform[] spawners;
    public int spawnIndex;
    //duraçao das waves.


    private void Start()
    {
        GenerateWave();
    }
    private void FixedUpdate()
    {
        //checa se há inimigos para spawnar, caso não, gera uma nova wave.
        if (chestsToSpawn.Count > 0)
        {
            //spawna e remove da lsita o inimigo criado.
            GameObject enemy = Instantiate(chestsToSpawn[0], spawners[spawnIndex].position, Quaternion.identity);
            chestsToSpawn.RemoveAt(0);
            //adiciona o inimigo a lista atual no round
            //spawnedEnemies.Add(enemy);
            //adiciona o tempo para o proximo spawn.
        }
        //a cada spawn, muda o lugar que ira nascer.
        if (spawnIndex + Random.Range(1,2) <= spawners.Length - 1)
        {
            spawnIndex++;
        }
        else
        {
            spawnIndex = 0;
        }
    }
   

    public void GenerateWave()
    {
        waveValue = Random.Range(11,16);
        GenerateChest();
        //cria um intervalo fixo de tempo, com a quantidade de inimigos gerados na wave.
    }
    public void GenerateChest()
    {
        //gera uma lista temporaria de inimigos toda vez que a wave for gerada.
        List<GameObject> generatedChests = new List<GameObject>();
        //enquanto o valor da wave for maior que 0, e não há X inimigos na tela, continua o while loop
        while (waveValue > 0)
        {
            //gera uma lista, e checa o preço do inimigo, se a "compra" for possivel, o spawna.
            int randomChestId = Random.Range(1, chests.Count);
            int randChestCost = chests[randomChestId].cost;
            if (waveValue - randChestCost >= 0)
            {
                generatedChests.Add(chests[randomChestId].enemyPrefab);
                waveValue -= randChestCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }

        }
        chestsToSpawn.Clear();
        chestsToSpawn = generatedChests;
    }
}

[System.Serializable]
public class Chests
{
    //adiciona um sistema de preço para os inimigos, desse modo o game pode "comprar" inimigos com o tempo de jogo.
    public GameObject chestPrefab;
    public int cost;
}
