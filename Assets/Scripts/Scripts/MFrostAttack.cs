using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFrostAttack : MechanicsBase
{
    // Start is called before the first frame update
    public override void ExecuteMechanics(GameObject Character, GameObject Skill)
    {
        if (flagExecute)
        {
            float ArmorRas = RaschetSecond(Character.GetComponent<CharacterBase>().FireRes);
            float ArmorRasSecond = Raschet (Character.GetComponent<CharacterBase>().FrostRes);
            Character.GetComponent<CharacterBase>().HpCur -= Skill.GetComponent<CharacterBase>().FrostAttack * ArmorRas * ArmorRasSecond;
        }

    }
    private float CoefRas = 2f;
    private float Raschet(float x)
    {
        return Mathf.Pow(1 / CoefRas, x);
    }
    private float RaschetSecond(float x)
    {
        return Mathf.Pow(CoefRas, x);
    }
}
