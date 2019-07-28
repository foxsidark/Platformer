using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Begin;
    private Transform B;
    private Transform E;
    private float SmesYMin=1.14f;
    private float SmesXMax = 6f;
    private float SmesYMax = 2f;
    void Start()
    {
        
    }
    private GameObject GenerateBlockF(GameObject G)
    {
        B = G.GetComponent<GenerateBlock>().Begin;
        E = G.GetComponent<GenerateBlock>().End;
        
        int rand = Random.Range(0, 5);
        Vector2 Pos;
       
        if (rand >= 2)
        {
            Pos.x = Random.Range(0, SmesXMax);
            Pos.y = XFunction(Pos.x);
            Pos.x += E.transform.position.x;
            Pos.y += G.transform.position.y;
        }
        else
        {
            Pos.x = Random.Range(B.transform.position.x, E.transform.position.x);
            Pos.y = Random.Range(SmesYMin, SmesYMax);
            Pos.y += G.transform.position.y;
        }
       

        GameObject Gtmp = Instantiate(G);
        Gtmp.transform.position= Pos;
        return Gtmp;
    }
    private float XFunction(float x)
    {
        return -(x / 2) * (x / 2) + 2;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Begin= GenerateBlockF(Begin);
    }
}
