using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/Blocking Skill")]
public class BlockingSkill : Skill
{
    public void Trigger(NodeLink _link, Vector3 _pos)
    {
        WorldObject _newWorldObject = Instantiate(worldObject, _pos, Quaternion.identity);
        // _newWorldObject.GetComponent<BoxCollider2D>().enabled = true;
        _link.SetBlocked(true);
    }
}
