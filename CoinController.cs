using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody2D coinRB;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        coinRB = GetComponent<Rigidbody2D>();
        coinRB.velocity = new Vector2 (-6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameController.fxGame.PlayOneShot(gameController.fxCoin);
            Debug.Log("Player Pegou a Moeda");
            gameController.Pontos(1);
            Destroy(this.gameObject);
        }
    }

    //esta funcao destroi qualquer objeto fora da visibilidade da camera
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
