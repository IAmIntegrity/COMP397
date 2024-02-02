using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerMotor playerMotor;
    private PlayerLook playerLook;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private void Awake()
    {
        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Jump.performed += ctx => playerMotor.Jump();
    }

    void Update()
    {
        playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
