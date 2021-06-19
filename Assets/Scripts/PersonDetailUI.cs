using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonDetailUI : MonoBehaviour
{
    public static PersonDetailUI instance;
    [SerializeField] GameObject overlay;
    Lover currentDetailsShowing;
    
    [Header("References")]
    [SerializeField] public TextMeshProUGUI nameText;
    [SerializeField] public TooltipTriggerUI itemToolTip;
    [SerializeField] List<Image> traitIcons = new List<Image>();
    [SerializeField] List<Image> heartBarIcons = new List<Image>();
    [SerializeField] Image soulMateIcon;

    [Header("Sprites")]

    [SerializeField] Sprite heartBarFull, heartBarEmpty;

    [SerializeField] Sprite gotoSoulMateSprite;

    [SerializeField] Image inventoryItem;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public static void SetTrait(int _index, LoverDetails loverDetails)
    {
        instance.traitIcons[_index].sprite = loverDetails.personalities[0].icon;
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
        instance.overlay.SetActive(false);
        
        instance.nameText.text = _lover.details.loverName;
        UpdateHeartBar(_lover.loveBar.currentValue);
        instance.traitIcons[0].sprite = _lover.details.personalities[0].icon;

        if (_lover.item != null)
        {
            instance.inventoryItem.sprite = _lover.item.icon;
            instance.itemToolTip.content = _lover.item.content;
            instance.itemToolTip.header =  _lover.item.header;
        } else {
            instance.inventoryItem.sprite = null;
            instance.itemToolTip.header = "Inventory";
            instance.itemToolTip.content = "It's empty";
        }
    }

    void Update()
    {
        if (currentDetailsShowing != null)
        {
            UpdateHeartBar(currentDetailsShowing.loveBar.currentValue);
        }

    }
}
