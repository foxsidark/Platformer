using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator an;
    public Transform []tr;
    private bool flagJump=false;
    private bool flagMoveRight = false;
    private bool flagMoveLeft = false;


    private Rigidbody2D rb;
    private CharacterBase st;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        st = GetComponent<CharacterBase>();
    }
   
    private  void StopRun()
    {
        an.SetBool("Run", false);
        Vector2 Speed = rb.velocity;
        Speed.x = 0;
        rb.velocity = Speed;
       
    }
    private void MoveRight()
    {
        an.SetBool("Run", true);
        Vector2 Speed = rb.velocity;
        Speed.x = st.SpeedMove;
        rb.velocity = Speed;
        Vector2 scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        gameObject.transform.localScale = scale;
    }
    private void MoveLeft()
    {
        an.SetBool("Run", true);
        Vector2 Speed = rb.velocity;
        Speed.x = -st.SpeedMove;
        rb.velocity = Speed;
        Vector2 scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x)*(-1);
        gameObject.transform.localScale = scale;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (flagMoveRight)
        {
            MoveRight();
        }
        if (flagMoveLeft)
        {
            MoveLeft();
        }
        if (!flagMoveRight&&!flagMoveLeft)
        {
            StopRun();
        }
        
        
        


    }
    private int CheckHit(Transform tr1)
    {
        RaycastHit2D hit = Physics2D.Raycast(tr1.position, -Vector2.up);
        if (hit.collider != null)
        {

            if ((hit.point.y - tr1.position.y) == 0)
            {
                flagJump = true;
                an.SetBool("Jump", false);
                return 1;

            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    void Update()
    {
        int tmpInt = 0;
        foreach(var tmp in tr)
        {
            tmpInt+=CheckHit(tmp);
        }
        if (tmpInt == 0)
        {
            an.SetBool("Jump", true);
            flagJump = false;
        }


        #region


        if (Input.GetKeyDown(KeyCode.D))
        {
            flagMoveRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            flagMoveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            flagMoveLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            flagMoveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShotBegin();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ShotStop();
        }
        #endregion

    }

    public void Right()
    {
        flagMoveRight = true;
    }
    public void UnRight()
    {
        flagMoveRight = false;
    }
    public void Left()
    {
        flagMoveLeft = true;
    }
    public void UnLeft()
    {
        flagMoveLeft = false;
    }
    public void Jump()
    {
        if (flagJump)
        {

            an.SetBool("Jump", true);
            flagJump = false;
            rb.AddForce(new Vector2(0, st.JumpForced), ForceMode2D.Impulse);

        }

    }
    public void ShotBegin()
    {
        an.SetBool("Shot", true);
    }
    public void ShotStop()
    {
        an.SetBool("Shot", false);
    }

}
