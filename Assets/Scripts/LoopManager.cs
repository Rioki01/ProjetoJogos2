using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script para dar manage nos leveis.
public class LoopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LoopManager instance;

    public int currentLevel;
    public Text caixaTexto;

    private void Awake()
    {
        
        if (instance != null)
        {
            GameObject.Destroy(instance);
        }
        else
        {
            instance = this;
        }
        currentLevel++;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
    }

    public void UpdateLevel()
    {
        currentLevel++;
        caixaTexto.text = currentLevel.ToString();
    }
}
