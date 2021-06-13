using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionCheck : ScriptableObject
{
    
    public abstract bool Check(LoverDetails _details);
    public abstract bool CheckWorldObject(WorldObject _object);

}
