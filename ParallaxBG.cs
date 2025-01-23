using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{

    private Renderer objRender;
    private Material objMaterial;

    public float offset; //deslocamento
    public float offsetForca;
    public float offsetVelocidade;

    public string sortingLayer;
    public int orderLayer;
    // Start is called before the first frame update
    void Start()
    {
        objRender = GetComponent<Renderer>();
        objMaterial = objRender.material;

        objRender.sortingLayerName = sortingLayer;
        objRender.sortingOrder = orderLayer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += offsetForca;
        objMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocidade, 0));
    }
}
