using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card")]
public class Card : ScriptableObject {
    public new string name;
    public Sprite artwork;
    public int health;
    public int cost;
    public int strength;
    public string description;

}