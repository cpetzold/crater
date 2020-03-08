public class Village : Card {

    public Village() : base("Village", "+1 Action +2 Cards", 1, CardType.SKILL) { }

    public override void Play(int index, ActionQueue actionQueue) {
        actionQueue.Enqueue(new DiscardAction(index));
        actionQueue.Enqueue(new DrawAction(2));
    }
}