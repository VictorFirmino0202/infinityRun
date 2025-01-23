using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Propriedades do Chao
    [Header("Configuração Do Chão")]
    public float        chaoDestruido;
    public float        chaoTamanho;
    public float        chaoVelocidade;
    public GameObject   chaoPrefab;

    [Header("Configuração Do Obstáculo")]
    public float        obstTempo;
    public float        obstVelocidade;
    public GameObject   obstPrefab;

    [Header("Configuração Do Coin")]
    public float        coinTempo;
    public GameObject   coinPrefab;

    [Header("Configuração UI")]
    public int          pontosPlayer;
    public int          vidasPlayer;
    public Text         txtPontos;
    public Text         txtVidas;
    public Text         txtMetros;

    [Header("Controle de Distância")]
    public int          metrosPercorridos = 0;

    [Header("Controle de Som e Efeitos")]
    public AudioSource  fxGame;
    public AudioClip    fxCoin;
    public AudioClip    fxPulo;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
        StartCoroutine("SpawnCoin");
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstaculo()
    { 
        yield return new WaitForSeconds(obstTempo);
        GameObject ObstaculoTemporario = Instantiate(obstPrefab);
        StartCoroutine("SpawnObstaculo");

        yield return new WaitForSeconds(1.5f);
        StartCoroutine("SpawnCoin");

    }

    IEnumerator SpawnCoin()
    {
        int randomMoedas = Random.Range(1, 5);
        Debug.Log("Moedas sorteadas:" + randomMoedas);
        for (int contagem = 1; contagem <= randomMoedas; contagem++)
        {
            yield return new WaitForSeconds(coinTempo);
            GameObject objSpawnTemporario = Instantiate(coinPrefab);
            objSpawnTemporario.transform.position = new Vector3(objSpawnTemporario.transform.position.x, objSpawnTemporario.transform.position.y, 0);
            
        }

    }

    public void Pontos(int qtdPontos)
    {
        pontosPlayer += qtdPontos;
        txtPontos.text = pontosPlayer.ToString();
    }

    void DistanciaPercorrida()
    {
        metrosPercorridos++;
        txtMetros.text = metrosPercorridos.ToString() + " M";
    }
}
