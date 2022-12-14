using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public bool InEncounter = false;
    TextMeshProUGUI mainText;
    CharacterMove player;
    HealthBar healthBar;
    HealthBar enemyHealthBar;
    EnemyController enemy;
    public GameObject canvas;
    bool enemyTurn = false;

    public static DialogController instance;
    void Start()
    {
        instance = this;
        mainText = canvas.transform.Find("MainText").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMove>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        enemyHealthBar = canvas.transform.Find("EnemyHealthBar").gameObject.GetComponent<HealthBar>();
    }  
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text) {
        mainText.SetText(text);
    }

    public void SetButtons(bool set) {
        canvas.transform.Find("Attack").gameObject.SetActive(set);
        canvas.transform.Find("UseItem").gameObject.SetActive(set);
    }

    public void DisplayMessage(string message) {
        canvas.SetActive(true);
        enemyHealthBar.gameObject.SetActive(false);
        SetText(message);
        SetButtons(false);
        StartCoroutine(WaitAndClose(2f));
    }

    public void StartEncounter(EnemyController enemy) {
        player.StopPlayer();
        this.enemy = enemy;
        SetText("You encounter a " + enemy.enemyName);
        InEncounter = true;
        enemyHealthBar.gameObject.SetActive(true);
        enemyHealthBar.SetMaxHealth(enemy.maxHealth);
        enemyHealthBar.SetHealth(enemy.health);
        SetButtons(true);
        canvas.SetActive(true);
    }

    public void EndEncounter() {
        InEncounter = false;
        enemyHealthBar.gameObject.SetActive(false);
        canvas.SetActive(false);
        enemyTurn = false;
    }

    void EnemyTurn() {
        int miss = Random.Range(0, 100);
        int damage = Random.Range(1, enemy.attackDamage);
        if (miss < enemy.missChance) {
            SetText(enemy.enemyName + " attacks you but misses!");
        } else {
            SetText("The " + enemy.enemyName + " attacks you for " + damage + " damage!");
            healthBar.TakeDamage(damage);
        }
    }

    public void Attack() {
        player.isAttackPressed = true;
        if (enemy == null || enemyTurn) {
            return;
        }
        int damage = Random.Range(1, 5);
        enemy.TakeDamage(damage);
        enemyHealthBar.SetHealth(enemy.health);
        string text = "You attack the " + enemy.enemyName + " for " + damage + " damage!";
        if (enemy.health <= 0) {
            text += "\nYou killed the " + enemy.enemyName + "!";
            StartCoroutine(WaitAndClose(1f));
        } else {
            StartCoroutine(WaitAndEnemyTurn());
        }
        SetText(text);
    }

    public void UseItem() {
        if (enemy != null && !enemyTurn) {
            InventoryManager.instance.SetInventory(false);
            StartCoroutine(WaitAndEnemyTurn());
        }
    }

    IEnumerator WaitAndClose(float time) {
        yield return new WaitForSeconds(time);
        EndEncounter();
    }

    IEnumerator WaitAndEnemyTurn() {
        SetButtons(false);
        enemyTurn = true;
        SetText("The " + enemy.enemyName + " is thinking...");
        yield return new WaitForSeconds(1f);
        EnemyTurn();
        yield return new WaitForSeconds(1.5f);
        SetButtons(true);
        SetText("Your turn!");
        enemyTurn = false;
    }
}
