using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepiteGround : MonoBehaviour
{
    private GameController gameController;
    private bool chaoInstanciado = false;



    // Start is called before the first frame update
    void Start()
    {
        //acesso a todas as variaveis do script GameController
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(chaoInstanciado == false)
        {
            if (transform.position.x <= 0)
            {
                chaoInstanciado = true;
                GameObject objetoTemporario = Instantiate(gameController.chaoPrefab);
                objetoTemporario.transform.position = new Vector3(transform.position.x + gameController.chaoTamanho, transform.position.y, 0);
                Debug.Log("O chao foi instanciado!");
            }
        }

        if (transform.position.x < gameController.chaoDestruido)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * gameController.chaoVelocidade * Time.deltaTime);
    }
}
