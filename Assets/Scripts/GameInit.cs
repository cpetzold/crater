using UnityEngine;

public class GameInit : MonoBehaviour {
    public GameState gameState;

    void Start() {
        for (int i = 0; i < 100; i++) {
            gameState.deck.Add(new Village());
        }

        gameState.DrawCardFromDeck();
    }
}
