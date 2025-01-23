using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private Rigidbody2D obstRB;
    private GameController gameController;
    private CameraShaker cameraShaker;


    // Start is called before the first frame update
    void Start()
    {
        obstRB = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        cameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;

        //obstRB.velocity = new Vector2(-5f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * gameController.obstVelocidade * Time.smoothDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameController.vidasPlayer--;
            if (gameController.vidasPlayer <= 0)
            {
                Debug.Log("Fim do Jogo");
                gameController.txtVidas.text = "0";

            }
            else
            {
                gameController.txtVidas.text = gameController.vidasPlayer.ToString();
                Debug.Log("Colidiu com o obstaculo");
                cameraShaker.ShakeIt();
            }
        }
    }

    //esta funcao destroi qualquer objeto fora da visibilidade da camera
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
