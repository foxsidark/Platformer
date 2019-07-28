using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Sprite[] Stand;
    public Sprite[] Up;
    public Sprite[] LeftRight;
    public Sprite[] Down;
    SpriteRenderer rd;
    private Sprite[] Control;
    void Start()
    {
         rd=gameObject.GetComponent<SpriteRenderer>();
        Control = Stand;
    }

    // Update is called once per frame
    private int I = 0;
    public int Speed = 6;
    void FixedUpdate()
    {

        AnimationHelp();
    }
    public void StartAnimationStand()
    {
        Control = Stand;
        I = 0;
        Ispeedl = 0;
    }
    public void StartAnimationUp()
    {
        Control = Up;
        I = 0;
        Ispeedl = 0;
    }
    public void StartAnimationLeftRight()
    {
        Control = LeftRight;
        I = 0;
        Ispeedl = 0;
    }
    public void StartAnimationDown()
    {
        Control = Down;
        I = 0;
        Ispeedl = 0;
    }
    private int Ispeedl = 0;
    private void AnimationHelp()
    {
        if (I >= Control.Length) I = 0;
        rd.sprite = Control[I];
        if (Ispeedl > Speed)
        {
            Ispeedl = 0;
            I++;
        }
        Ispeedl++;
    }
}