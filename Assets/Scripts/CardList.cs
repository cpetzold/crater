using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardList : ScriptableObject {
    public List<Card> cards = new List<Card>();
    public IntEvent cardAdded;
    public IntEvent cardRemoved;

    // void Awake() {
    //     this.cards.Clear();
    // }

    public void Add(Card card) {
        this.cards.Add(card);
        this.cardAdded.Raise(cards.Count - 1);
    }

    public void Remove(Card card) {
        int index = cards.IndexOf(card);
        this.cards.RemoveAt(index);
        this.cardRemoved.Raise(index);
    }
}