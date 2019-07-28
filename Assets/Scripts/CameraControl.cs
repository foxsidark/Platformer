using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject P;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tr=transform.position;
        tr.x = P.transform.position.x;
        
        tr.y = Mathf.Abs(P.transform.position.y - tr.y) > 0.01 ? P.transform.position.y : tr.y;
        transform.position = tr;
    }
}
