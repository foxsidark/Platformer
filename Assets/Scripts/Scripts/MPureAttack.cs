using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPureAttack : MechanicsBase
{
    // Start is called before the first frame update
    public override void ExecuteMechanics(GameObject Character, GameObject Skill)
    {
        if (flagExecute)
        {
            Character.GetComponent<CharacterBase>().HpCur -= Skill.GetComponent<CharacterBase>().PureAttack ;
        }

    }
   
}
