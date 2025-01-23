using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float velocidade = 0f;
    public float puloForca = 650f;
    public bool eChao = true;
    public string isGroundBool = "eChao";

    private Animator anim;
    private Rigidbody2D rb;
    private GameController gameController;

    public LayerMask layerGround;
    public Transform checkGround;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MovimentaPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PuloPlayer();
        }
    }

    void MovimentaPlayer()
    {
        transform.Translate(new Vector3(velocidade, 0, 0));
    }

    private void FixedUpdate()
    {
        //"Translate" move o transform do objeto na direcao e distancia da conversao
        transform.Translate(new Vector3(velocidade, 0, 0));

        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, layerGround))
        {
            anim.SetBool(isGroundBool, true);
            eChao = true;
        }
        else
        {
            anim.SetBool(isGroundBool, false);
            eChao = false;
        }
    }

    public void PuloPlayer()
    {
        if (eChao)
        {
            gameController.fxGame.PlayOneShot(gameController.fxPulo);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, puloForca));
        }
    }
}
