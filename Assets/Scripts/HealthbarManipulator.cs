using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarManipulator : MonoBehaviour
{
    [SerializeField] Transform healthMask;
    [SerializeField] int maxHealth;
    [SerializeField] SpriteRenderer healthbarColor;
    int currentHealth;


    //Y boundaries of the mask
    int maxMaskPosition = 1417;
    int minMaskPosition = 260;


    public Color HealthbarColor
    {
        get 
        {
            return healthbarColor.color;
        }
        set 
        {
            healthbarColor.color = value;
        }
    }

    public bool MaxHealth { get; private set; }
    //returns the value of current health
    //if you set the value you need to get the current health and set it with the subtracted value
    public int Health
    {
        get { return currentHealth; }
        set 
        {
            if (value > maxHealth)
            {
                Debug.Log($"Value: {value} is out of Range! Range from 0 to {maxHealth}");
                value = maxHealth;
                MaxHealth = true;
                return;
            }
            currentHealth = value;
            SetHealthBar();
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
        //HealthSlider.SetMaxValue(maxHealth);
    }
    private void Update()
    {
        //Health = HealthSlider.SliderValue;
    }

    //set the maxHealth
    public int SetMaxHealth
    {
        get { return maxHealth; }
        set 
        { 
            maxHealth = value;
            //HealthSlider.SetMaxValue(maxHealth);
        }
    }

    void SetHealthBar()
    {
        if(currentHealth > 0) 
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            Debug.Log(healthPercentage);
            float maskValueRange = maxMaskPosition - minMaskPosition;
            healthMask.transform.position = new Vector3(
                healthMask.position.x, minMaskPosition + maskValueRange * healthPercentage, healthMask.position.z);
        }
        else
        {
            healthMask.transform.position = new Vector3(healthMask.position.x, minMaskPosition, healthMask.position.z);
            MaxHealth = false;
        }
    }
}
