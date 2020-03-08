using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityVoidEvent : UnityEvent<Void> { }

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Events/Game Event")]
public class GameEvent : BaseGameEvent<Void> {
    public void Raise() {
        Raise(new Void());
    }
}

