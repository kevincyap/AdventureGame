using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int health;
    public static HealthBar instance;
    void Start() {
        slider.maxValue = PublicVars.maxHealth;
        health = 50;
        slider.value = health;
        instance = this;
    }
    public void addHealth(int diff) {
        health = Mathf.Min(PublicVars.maxHealth, health + diff);
        slider.value = health;
    }
}
