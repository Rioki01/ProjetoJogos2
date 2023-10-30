using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    //location spawns
    [SerializeField]public Transform[] spawners;
    public int spawnIndex;
    //duraçao das waves.
    public int waveDuration;
    //tempo atual da wave
    private float waveTimer;
    //intervalo entre as waves
    private float spawnInterval;
    //tempo de spawn durante a wave
    private float spawnTimer;

    //lista de inimigos atuais
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        GenerateWave();
    }
    private void FixedUpdate()
    {
        //se o timer de spawn for 0, spawna um inimigo, se não diminui seu tempo
        if(spawnTimer <= 0)
        {
            //checa se há inimigos para spawnar, caso não, gera uma nova wave.
            if(enemiesToSpawn.Count>0)
            {
                //spawna e remove da lsita o inimigo criado.
                GameObject enemy = Instantiate(enemiesToSpawn[0], spawners[spawnIndex].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                //adiciona o inimigo a lista atual no round
                //spawnedEnemies.Add(enemy);
                //adiciona o tempo para o proximo spawn.
                spawnTimer = spawnInterval;
            }
            else
            {
                //acaba a wave se não há inimigo.
                waveTimer = 0;
            }
            //a cada spawn, muda o lugar que ira nascer.
            if (spawnIndex + 1 <= spawners.Length - 1)
            {
                spawnIndex++;
            }
            else
            {
                spawnIndex = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
        //gera uma nova wave, caso o tempo seja 0, e não há inimigos spawnados.
        //&& spawnedEnemies.Count <= 5
        if (waveTimer <= 0)
        {
            currentWave++;
            GenerateWave();
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();
        //cria um intervalo fixo de tempo, com a quantidade de inimigos gerados na wave.
        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }
    public void GenerateEnemies()
    {
        //gera uma lista temporaria de inimigos toda vez que a wave for gerada.
        List<GameObject> generatedEnemies = new List<GameObject>();
        //enquanto o valor da wave for maior que 0, e não há X inimigos na tela, continua o while loop
        while(waveValue> 0 || generatedEnemies.Count < 30)
        {
            //gera uma lista, e checa o preço do inimigo, se a "compra" for possivel, o spawna.
            int randomEnemyId = Random.Range(1, enemies.Count);
            int randEnemyCost = enemies[randomEnemyId].cost;
            if(waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randomEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }

        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    //adiciona um sistema de preço para os inimigos, desse modo o game pode "comprar" inimigos com o tempo de jogo.
    public GameObject enemyPrefab;
    public int cost;
}
