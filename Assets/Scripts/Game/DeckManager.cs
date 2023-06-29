using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> TroopsPrefabs;

    [SerializeField] private GameObject PrefabCard;

    private GameObject[] troopCards;

    [SerializeField] private Color colorActive;
    [SerializeField] private Color colorNoActive;

    private int _troopSelected;
    public int TroopSelected
    {
        get { return _troopSelected; }
        set
        {
            _troopSelected = value;
            Array.ForEach(troopCards, (tc) => tc.GetComponent<Image>().color = colorNoActive);

            if (_troopSelected >= 0)
            {
                troopCards[TroopSelected].GetComponent<Image>().color = colorActive;
            }
        }
    }


    private int _gold;
    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            goldText.text = _gold.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI goldText;


    void Start()
    {
        
        Gold = 100;
        CreateCards();
    }

    public void CreateCards()
    {
        troopCards = new GameObject[TroopsPrefabs.Count];

        for (int i = 0; i < troopCards.Length; i++)
        {

            troopCards[i] = Instantiate(PrefabCard);
            troopCards[i].transform.SetParent(transform);
            troopCards[i].transform.position = Vector3.zero;
            troopCards[i].transform.localScale = Vector3.one;

            Image img = troopCards[i].GetComponent<Image>();
            img.sprite = TroopsPrefabs[i].GetComponent<Character>().deckCard;

            TextMeshProUGUI text = troopCards[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = TroopsPrefabs[i].GetComponent<Character>().price.ToString();

            Button button = troopCards[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners();

            int troopIndex = i;
            button.onClick.AddListener(() => { TroopSelected = troopIndex; });
        }

        TroopSelected = -1;
    }

    public void NotEnoughGoldAlert()
    {
        Animator goldAnim = GetComponentInChildren<Animator>();
        goldAnim.SetTrigger("NotEnoughGold");

    }
}
