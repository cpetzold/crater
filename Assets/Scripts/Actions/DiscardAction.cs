public class DiscardAction : Action {
    int index;

    public DiscardAction(int index) {
        this.index = index;
    }

    public override void Run(GameState gameState) {
        // TODO: Allow discarding from other places than hand
        gameState.DiscardFromHand(this.index);
    }
}