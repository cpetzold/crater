using UnityEngine;
using UnityEngine.Events;

public interface IGameEventListener<T> {
    void OnEventRaised(T value);
}

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T> {
    [SerializeField]
    public E gameEvent;
    [SerializeField]
    public UER response;

    private void OnEnable() {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T value) {
        response.Invoke(value);
    }
}