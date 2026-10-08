using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SScorceHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI healthtext;
    [SerializeField] private GameObject LosePanel;


    [SerializeField] private float health = 5f;
    [SerializeField] private float score;

    private void Start()
    {
        healthtext.text = "Health: " + health;
    }
    private void Update()
    {
        if (health == 0)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillBox"))
        {
            health -= 1f;
            healthtext.text = "Health: " + health;
        }
        if (collision.CompareTag("Pumpkin"))
        {
            score += 100f;
            scoretext.text = "Score: " + score;
        }
        if (collision.CompareTag("Bomb"))
        {
            health -= 1f;
            healthtext.text = "Health: " + health;

        }
    }
}
