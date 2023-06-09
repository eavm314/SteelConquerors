using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public List<Character> troops;

    public GameObject PrefabCard;

    public int troopSelected = -1;

    void Start()
    {
        for (int i = 0; i < troops.Count; i++)
        {
            GameObject go = Instantiate(PrefabCard);
            go.transform.SetParent(transform);
            go.transform.position = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Image img = go.GetComponent<Image>();
            img.sprite = troops[i].DeckCard;

            Button button = go.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            int troop = i;
            button.onClick.AddListener(()=> { troopSelected = troop; });
        }
    }

}
