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

    [SerializeField] List<GameObject> skillAimers = new List<GameObject>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Image> cooldownImages = new List<Image>();
    void Awake()
    {
        instance = this;
    }

    public void StartAim(int _index)
    {
        Instantiate(skillAimers[_index]);
        cooldownTimes[_index] = maxCooldown;
        buttons[_index].interactable=false;
    }

    public void TriggerSkill(int _index, Vector2Int location)
    {
        skillSlots[_index].Trigger(location);
    }

    void Update()
    {
        UpdateCooldowns();

    }

    private void UpdateCooldowns()
    {
        for (int i = 0; i < cooldownTimes.Count; i++)
        {
            cooldownImages[i].fillAmount = 1-cooldownTimes[i]/maxCooldown;
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
