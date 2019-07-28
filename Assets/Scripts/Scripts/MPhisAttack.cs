using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPhisAttack : MechanicsBase
{


    // Start is called before the first frame update
    public MPhisAttack():base()
    {

    }
    public override void ExecuteMechanics(GameObject Character, GameObject Skill)
    {
        if (flagExecute)
        {
            float ArmorRas = Raschet(Character.GetComponent<CharacterBase>().PhisRes);
            Character.GetComponent<CharacterBase>().HpCur -= Skill.GetComponent<CharacterBase>().PhisAttack* ArmorRas;
        }
           
    }
    private float Raschet(float x)
    {
        return Mathf.Pow(0.9f,x);
    }
}
