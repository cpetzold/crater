using UnityEngine;
using TMPro;

public class CardUI : MonoBehaviour {
    public TextMeshPro title;
    public TextMeshPro description;
    public TextMeshPro cost;

    public void UpdateFromCard(Card card) {
        this.title.text = card.name;
        this.description.text = card.description;
        this.cost.text = "" + card.cost;
    }
}
