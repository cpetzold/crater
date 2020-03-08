using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityIntEvent : UnityEvent<int> { }

[CreateAssetMenu(fileName = "New Int Event", menuName = "Game Events/Int Event")]
public class IntEvent : BaseGameEvent<int> { }

