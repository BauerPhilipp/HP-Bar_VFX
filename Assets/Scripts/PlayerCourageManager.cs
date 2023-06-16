using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCourageManager : MonoBehaviour
{
    [SerializeField] float healthUpdateSpeed = 1f;
    [SerializeField] int healthUpdateAmount = 1;
    [SerializeField] HealthbarManipulator healthbarManipulator;
    PlayerController playerController;

    private int startHealth;
    private int currentHealth;
    private bool coroutineAktive = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        healthbarManipulator.Health = 3;
        startHealth = healthbarManipulator.Health;
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (!playerController.IsMoving) { return; }
        if (coroutineAktive) { return; }
        StartCoroutine(SetHealthbar());
    }

    private IEnumerator SetHealthbar()
    {
        coroutineAktive = true;
        currentHealth += healthUpdateAmount;
        healthbarManipulator.Health = currentHealth;
        Debug.Log(healthbarManipulator.Health);
        yield return new WaitForSeconds(healthUpdateSpeed);
        coroutineAktive = false;

    }

}
