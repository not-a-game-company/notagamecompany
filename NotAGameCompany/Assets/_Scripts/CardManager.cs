using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cards;
    //[SerializeField] private List<GameObject> hand = new List<GameObject>();
    [SerializeField] private GameObject[] hand;
    void Start()
    {

        for (int i = 0; i < hand.Length; i++)
        {
           GameObject card = Instantiate(cards[i],hand[i].transform.position, Quaternion.identity);
           card.transform.parent = hand[i].transform;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
