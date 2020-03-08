

public class DrawAction : Action {
    int numCards;

    public DrawAction(int numCards) {
        this.numCards = numCards;
    }

    public override void Run(GameState gameState) {
        for (int i = 0; i < this.numCards; i++) {
            gameState.DrawCardFromDeck();
        }
    }
}