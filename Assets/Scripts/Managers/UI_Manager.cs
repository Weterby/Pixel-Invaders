using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private int _score;

    private Player player;

    [SerializeField]
    private Image health;
    [SerializeField]
    private Image shield;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject deathScreen;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        health.fillAmount = player.HealthPoints / player.MaxHealth;
        shield.fillAmount = player.ShieldPoints / player.MaxShield;
        _scoreText.text = "Score: 0";
    }
    private void Update()
    {
        //Debug.Log(player.ShieldPoints);
        //Debug.Log(player.MaxShield);
    }
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }
    public void CalculateHealth()
    {
        health.fillAmount = player.HealthPoints / player.MaxHealth;
    }

    public void CalculateShield()
    {
        shield.fillAmount = player.ShieldPoints / player.MaxShield;
    }

    public void OnPlayerDeath()
    {
        StartCoroutine(DeathScreenDelay());
    }

    private IEnumerator DeathScreenDelay()
    {
        GameObject.Find("GameUI").SetActive(false);
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(2);
    }
}
