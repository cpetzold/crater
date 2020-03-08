using UnityEngine;

public enum CardType {
    ATTACK,
    SKILL,
    POWER
};

[SerializeField]
public abstract class Card {
    public string name;
    public string description;
    public int cost;
    public CardType type;

    public Card(string name, string description, int cost, CardType type) {
        this.name = name;
        this.description = description;
        this.cost = cost;
        this.type = type;
    }

    public abstract void Play(int index, ActionQueue actionQueue);
}