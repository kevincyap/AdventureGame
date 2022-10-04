using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int health;
    public static HealthBar instance;
    public bool playerHealth = false;
    void Start() {
        if (playerHealth) {
            slider.maxValue = PublicVars.maxHealth;
            health = PublicVars.maxHealth;
            slider.value = health;
            instance = this;
        }
    }
    public void AddHealth(int diff) {
        health = Mathf.Min(PublicVars.maxHealth, health + diff);
        slider.value = health;
    }
    public void TakeDamage(int damage) {
        health -= damage;
        slider.value = health;
    }
    public void SetHealth(int health) {
        this.health = health;
        slider.value = health;
    }
    public void SetMaxHealth(int max) {
        slider.maxValue = max;
    }
}
