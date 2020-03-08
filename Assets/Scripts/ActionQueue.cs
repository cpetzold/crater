using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class ActionQueue : ScriptableObject {
    private Queue<Action> actions = new Queue<Action>();

    public void Enqueue(Action action) {
        actions.Enqueue(action);
    }

    public Action RunNext(GameState gameState) {
        if (this.actions.Count == 0) {
            return null;
        }

        Action nextAction = actions.Dequeue();
        nextAction.Run(gameState);
        return nextAction;
    }

    public void RunAll(GameState gameState) {
        while (this.RunNext(gameState) != null) { }
    }
}