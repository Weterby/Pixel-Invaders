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
    private Text _scoreText;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        health.fillAmount = player.Health / player.MaxHealth;

        _scoreText.text = "Score: 0";
    }

    private void Update()
    {
        Debug.Log(health.fillAmount);
    }
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }
    public void CalculateHealth()
    {
        health.fillAmount = player.Health / player.MaxHealth;
    }
}
