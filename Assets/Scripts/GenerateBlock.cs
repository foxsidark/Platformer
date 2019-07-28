using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Block;
    public Transform Begin;
    public Transform End;
    private float Sdvig = 0.278f;
    private float Sdvig2 = 0.2965f;
    private float Sdvig3 = 0.270f;
    private GameObject G;
    private Transform T;
    private BoxCollider2D col;

    private int LennghtPlatform=20;
    void Start()
    {
        Gen();
        col = gameObject.GetComponent<BoxCollider2D>();
        col.size =new Vector2( End.position.x - Begin.position.x+ Sdvig3/3, col.size.y);
        col.offset = new Vector2((End.position.x - Begin.position.x) / 2, col.offset.y);


    }
    private void Gen()
    {
        G = Instantiate(Block[0]);
        G.transform.parent = gameObject.transform;
        G.transform.localPosition = new Vector3(0, 0, 0);
        Begin = G.transform;
        T = G.transform;
        G = Instantiate(Block[1]);
        G.transform.parent = gameObject.transform;
        G.transform.localPosition = new Vector3(T.localPosition.x + Sdvig, 0, 0);
        int CountBlock = Random.Range(0, LennghtPlatform);
        for (int i = 0; i < CountBlock; ++i)
        {
            T = GenerateMidlle(T);
        }
        G = Instantiate(Block[2]);
        G.transform.parent = gameObject.transform;
        G.transform.localPosition = new Vector3(T.localPosition.x + Sdvig3, 0, 0);
        End = G.transform;
    }
    private Transform GenerateMidlle(Transform T)
    {
        GameObject G = Instantiate(Block[1]);
        G.transform.parent = gameObject.transform;
        G.transform.localPosition = new Vector3(T.localPosition.x + Sdvig2, 0, 0);
        return G.transform;
    }

    // Update is called once per frame
    
}
