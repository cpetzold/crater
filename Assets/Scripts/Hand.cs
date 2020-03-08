using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : MonoBehaviour {
    public GameState gameState;
    public GameObject cardPrefab;
    public float cardSpeed;

    public float width;
    public float minCardDistance;
    public float maxCardDistance;

    public float heightBetweenCards;
    public float depthBetweenCards;

    public float rotationIncrement = 0.1f;

    List<GameObject> cardObjects;
    int selectedCardIndex;

    public float rotateForce = 1;

    void Awake() {
        this.cardObjects = new List<GameObject>();
    }

    public void CardAdded(int index) {
        Card card = this.gameState.hand.cards[index];

        GameObject cardObject = Instantiate(cardPrefab, this.transform);
        cardObject.transform.localPosition = new Vector3(-5.0f, 0, -2.0f);
        cardObject.GetComponent<CardUI>().UpdateFromCard(card);
        this.cardObjects.Insert(index, cardObject);
    }

    public void CardRemoved(int index) {
        GameObject cardObject = this.cardObjects.ElementAt(index);
        if (cardObject) {
            this.cardObjects.Remove(cardObject);
            Destroy(cardObject);
        }
    }

    void Update() {
        float distanceBetweenCards = Mathf.Clamp(this.width / this.cardObjects.Count, this.minCardDistance, this.maxCardDistance);
        float actualWidth = distanceBetweenCards * (this.cardObjects.Count - 1.0f);

        // Play card from hand
        if (Input.GetMouseButtonUp(0) && Input.mousePosition.y > 300) {
            if (selectedCardIndex >= 0) {
                this.gameState.PlayCardFromHand(selectedCardIndex);
            }
        }

        selectedCardIndex = -1;
        for (int i = 0; i < this.cardObjects.Count; i++) {
            float shiftedIndex = i - ((this.cardObjects.Count - 1) / 2.0f);
            GameObject cardObject = this.cardObjects[i];
            if (cardObject.GetComponent<CardDrag>().IsDragging()) {
                selectedCardIndex = i;
                continue;
            }


            Vector3 targetPosition = new Vector3(shiftedIndex * distanceBetweenCards, Mathf.Abs(shiftedIndex) * -this.heightBetweenCards, shiftedIndex * -this.depthBetweenCards);
            cardObject.transform.localPosition = Vector3.Lerp(cardObject.transform.localPosition, targetPosition, Time.deltaTime * this.cardSpeed);
            Vector3 targetRotation = new Vector3();
            targetRotation.z = Mathf.LerpAngle(cardObject.transform.localEulerAngles.z, shiftedIndex * -this.rotationIncrement, Time.deltaTime * this.cardSpeed);
            cardObject.transform.localEulerAngles = targetRotation;
        }
    }

}
