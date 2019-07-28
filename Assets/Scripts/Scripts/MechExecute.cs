using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechExecute : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, MechanicsBase> keyValuePairsMech=new Dictionary<string, MechanicsBase>();
    void Start()
    {
        MPhisAttack mPhisAttack=new MPhisAttack();
        keyValuePairsMech.Add("PhisAttack",(MechanicsBase) mPhisAttack);
        MPureAttack mPureAttack  = new MPureAttack();
        keyValuePairsMech.Add("PureAttack", (MechanicsBase)mPureAttack);
        MFireAttack mFireAttack = new MFireAttack();
        keyValuePairsMech.Add("FireAttack", (MechanicsBase)mFireAttack);
        MFrostAttack mFrostAttack  = new MFrostAttack();
        keyValuePairsMech.Add("FrostAttack", (MechanicsBase)mFrostAttack);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<MechName>())
        {
            foreach(string tmp in col.gameObject.GetComponent<MechName>().NameMech)
            {
               if(keyValuePairsMech[tmp]!=null)
                {
                    keyValuePairsMech[tmp].ExecuteMechanics(gameObject, col.gameObject);
                }
            }
        }

        //Debug.Log("OnCollisionEnter2D");
    }
}
