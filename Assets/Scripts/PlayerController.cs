using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject BBPrefab;
    private PlayerInputSystem playerInput;
    private float inputValue;
    private Rigidbody rb;
    [SerializeField] float moveSpeed = 2f;

    private bool isMoving = false;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }

    private void Awake()
    {
        playerInput = new PlayerInputSystem();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        BBPrefab.SetActive(true);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float input = playerInput.Movement.Move.ReadValue<float>();
        if (input == 0) 
        {
            isMoving = false;
            return; 
        }
        isMoving = true;
        Vector3 newPosition = new Vector3(transform.position.x,
            transform.position.y , transform.position.z + input * Time.deltaTime * moveSpeed);

        transform.position = newPosition;
        //rb.MovePosition(newPosition);
    }



}
