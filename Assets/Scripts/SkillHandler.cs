using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
    public static SkillHandler instance;
    [SerializeField] float maxCooldown;
    [SerializeField] List<Skill> skillSlots = new List<Skill>();

    [SerializeField] List<float> cooldownTimes = new List<float>();

    [SerializeField] List<SkillAimer> skillAimers = new List<SkillAimer>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Image> cooldownImages = new List<Image>();
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int i = 0;
        foreach (Skill sk in skillSlots)
        {

            InitSkill(i, sk);
            i++;
        }

    }
    void Update()
    {
        UpdateCooldowns();

    }

    public void InitSkill(int _index, Skill _skill)
    {
        cooldownImages[_index].sprite = _skill.icon;
        skillAimers[_index].icon = _skill.icon;
        skillAimers[_index].skill = _skill;
    }



    public void StartAim(int _index)
    {
        Instantiate(skillAimers[_index]);

        cooldownTimes[_index] = maxCooldown;
        buttons[_index].interactable = false;
    }

    public void TriggerSkill(int _index, Vector2Int location)
    {
        skillSlots[_index].Trigger(location);
    }



    private void UpdateCooldowns()
    {
        for (int i = 0; i < cooldownTimes.Count; i++)
        {
            cooldownImages[i].fillAmount = 1 - cooldownTimes[i] / maxCooldown;
            if (cooldownTimes[i] > 0)
                cooldownTimes[i] -= Time.deltaTime;
            else
            {
                cooldownTimes[i] = 0;
                buttons[i].interactable = true;
            }
        }
    }
}
