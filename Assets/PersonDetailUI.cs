using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PersonDetailUI : MonoBehaviour
{
    public static PersonDetailUI instance;
    [SerializeField] GameObject overlay;
    LoverDetails currentDetailsShowing;
    [Header("References")]
    [SerializeField] public TextMeshProUGUI nameText;
    [SerializeField] public TooptipTriggerUI itemToolTip;
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
        instance.traitIcons[_index].sprite = loverDetails.loveInterest.icon;
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
    public static void Set(LoverDetails _details)
    {
        instance.overlay.SetActive(false);
        Debug.Log(_details);
        instance.nameText.text = _details.loverName;
        UpdateHeartBar(_details.loveBar.currentValue);
        instance.traitIcons[0].sprite = _details.loveInterest.icon;

        if (_details.item != null)
        {
            instance.inventoryItem.sprite = _details.item.icon;
            string a = _details.item.content;
            string b = _details.item.header;
            instance.itemToolTip.content = a;
            instance.itemToolTip.header = b;
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
