using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> troopsPrefabs;

    [SerializeField] private GameObject PrefabCard;

    public int troopSelected;

    public int gold;

    [SerializeField] private TextMeshProUGUI goldText;

    void Start()
    {
        troopSelected = -1;
        gold = 100;

        UpdateGold();
    }

    public void CreateCards()
    {
        for (int i = 0; i < troopsPrefabs.Count; i++)
        {

            GameObject troopCard = Instantiate(PrefabCard);
            troopCard.transform.SetParent(transform);
            troopCard.transform.position = Vector3.zero;
            troopCard.transform.localScale = Vector3.one;

            Image img = troopCard.GetComponent<Image>();
            img.sprite = troopsPrefabs[i].GetComponent<Character>().deckCard;

            TextMeshProUGUI text = troopCard.GetComponentInChildren<TextMeshProUGUI>();
            text.text = troopsPrefabs[i].GetComponent<Character>().price.ToString();

            Button button = troopCard.GetComponent<Button>();
            button.onClick.RemoveAllListeners();


            int troopIndex = i;
            button.onClick.AddListener(() => {
                troopSelected = troopIndex;
            });
        }
    }

    public void UpdateGold()
    {
        goldText.text = gold.ToString();
    }

}
