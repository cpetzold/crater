using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject {
    public CardList deck;
    public CardList hand;
    public CardList discard;

    public ActionQueue actionQueue;

    public void DrawCardFromDeck() {
        if (this.deck.cards.Count > 0) {
            Card topCard = this.deck.cards[0];
            this.hand.Add(topCard);
            this.deck.Remove(topCard);
        }
    }

    public void PlayCardFromHand(int index) {
        Card card = this.hand.cards.ElementAt(index);
        if (card != null) {
            card.Play(index, this.actionQueue);
        }

        // TEMP?: Run all actions enqueued by this card
        this.actionQueue.RunAll(this);
    }

    public void DiscardFromHand(int index) {
        Card card = this.hand.cards.ElementAt(index);
        if (card != null) {
            this.discard.Add(card);
            this.hand.Remove(card);
        }
    }
}