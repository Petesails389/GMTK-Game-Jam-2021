using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAimer : MonoBehaviour
{
    public Sprite icon;
    public Skill skill;
    public void Trigger(Vector2Int _loc)
    {
        skill.Trigger(_loc);
    }
}
