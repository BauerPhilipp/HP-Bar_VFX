using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCourageManager : MonoBehaviour
{
    [SerializeField] float healthUpdateSpeed = 1f;
    [SerializeField] int healthUpdateAmount = 1;
    [SerializeField] float healthResetSpeed = 1f;
    [SerializeField] HealthbarManipulator healthbarManipulator;
    PlayerController playerController;

    private int startHealth;
    private int currentHealth;
    private bool coroutineAktive = false;

    private bool setHealthColoRoutineIsRunning = false;
    private VFXManager vfxManager;


    private Color orangeColor = new Color(1, .6f, 0);
    private Color yellowColor = Color.yellow;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        vfxManager = FindObjectOfType<VFXManager>();
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
        SetHealthbarColor();
        if (healthbarManipulator.MaxHealth) { return; }
        if (!playerController.IsMoving) { return; }
        if (coroutineAktive) { return; }
    
        StartCoroutine(SetHealthbar());

    }

    private void SetHealthbarColor()
    {
        if (healthbarManipulator.MaxHealth && !setHealthColoRoutineIsRunning)
        {
            //Debug.Log("Yellow coroutine started");
            setHealthColoRoutineIsRunning = true;
            StartCoroutine(SetHealthbarColorRoutine());
        }

    }


    //Couragemode is active
    private IEnumerator SetHealthbarColorRoutine()
    {
        healthbarManipulator.HealthbarColor = orangeColor;
        vfxManager.PlayVFX = true; //start vfx
        while (healthbarManipulator.MaxHealth)
        {
            currentHealth -= healthUpdateAmount;
            healthbarManipulator.Health = currentHealth;
            yield return new WaitForSeconds(healthResetSpeed);
        }
        vfxManager.PlayVFX = false; //end vfx

        healthbarManipulator.HealthbarColor = yellowColor;

        setHealthColoRoutineIsRunning = false;
    }

    private IEnumerator SetHealthbar()
    {
        coroutineAktive = true;
        currentHealth += healthUpdateAmount;
        healthbarManipulator.Health = currentHealth;
        //Debug.Log(healthbarManipulator.Health);
        yield return new WaitForSeconds(healthUpdateSpeed);
        coroutineAktive = false;

    }

}
