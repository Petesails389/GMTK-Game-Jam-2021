using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonDetailUI : MonoBehaviour
{
    public static PersonDetailUI instance;
    [SerializeField] GameObject overlay;
    Lover currentLoverShowing;

    [Header("References")]
    [SerializeField] public TextMeshProUGUI nameText;
    [SerializeField] public TooltipTriggerUI itemToolTip;
    [SerializeField] List<Image> personalityIcons = new List<Image>();
    [SerializeField] List<TooltipTriggerUI> personalityTooltip = new List<TooltipTriggerUI>();
    [SerializeField] List<Image> heartBarIcons = new List<Image>();
    [SerializeField] Image soulMateIcon;

    [Header("Sprites")]

    [SerializeField] Sprite heartBarFull, heartBarEmpty;

    [SerializeField] Sprite gotoSoulMateSprite;

    [SerializeField] Image inventoryItem;

    [SerializeField] Item noneItem;

    void Awake()
    {
        instance = this;
    }

    public static void SetTrait(int _index, LoverDetails loverDetails)
    {
        instance.personalityIcons[_index].sprite = loverDetails.personalities[0].icon;
    }

    public static void UpdateHeartBar(int newValue)
    {
        int i = 0;
        foreach (Image im in instance.heartBarIcons)
        {
            if (i < newValue)
            {
                im.sprite = instance.heartBarFull;
            }
            else
            {
                im.sprite = instance.heartBarEmpty;
            }
            i++;
        }
    }

    public static void Set(Lover _lover)
    {
        instance.currentLoverShowing = _lover;

        instance.overlay.SetActive(false);

        instance.SetLoverName(_lover.details.loverName);
        UpdateHeartBar(_lover.loveBar.currentValue);
        instance.SetPersonalities(_lover.details.personalities);

        if (_lover.hasItem())
        {
            instance.SetItem(_lover.item);
        }
        else
        {
            instance.SetItem(instance.noneItem);
        }
    }

    void SetItem(Item _item)
    {
        instance.inventoryItem.sprite = _item.icon;
        instance.itemToolTip.content = _item.content;
        instance.itemToolTip.header = _item.header;
    }

    void SetLoverName(string _name)
    {
        nameText.text = _name;
    }

    void SetPersonalities(List<Personality> _personalities)
    {
        personalityIcons[0].sprite = _personalities[0].icon;
        personalityTooltip[0].header = _personalities[0].personalityName;
        personalityTooltip[0].content = _personalities[0].personalityTooltip;
    }

    void Update()
    {
        if (currentLoverShowing != null)
        {
            UpdateHeartBar(currentLoverShowing.loveBar.currentValue);
        }
    }
}
