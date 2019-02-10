using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCard : MonoBehaviour {
    public Card card;
    public Text cardName;
    public Text health;
    public Text cost;
    public Text strength;
    public Text description;
    public Image artwork;
    // Use this for initialization
    void Start() {
        description.text = card.description;
        cardName.text = card.name;
        artwork.sprite = card.artwork;
        health.text = card.health.ToString();
        cost.text = card.cost.ToString();
        strength.text = card.strength.ToString();
    }

}