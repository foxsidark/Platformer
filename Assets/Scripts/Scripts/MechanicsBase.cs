using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechanicsBase 
{
    
    public bool flagExecute = true;

    public abstract void ExecuteMechanics(GameObject Character, GameObject Skill);
}
