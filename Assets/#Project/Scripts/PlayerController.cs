using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerActions playerInput;
    private Rigidbody rb;
    public bool isPaused = false; // pour l'UI

    [SerializeField] private float speed = 10.0f;

    private void Awake() 
    {
        playerInput = new PlayerActions();
        rb = GetComponent<Rigidbody>();            
    }
    
    private void OnEnable() 
    {
        playerInput.Enable();
    }
    
    private void OnDisable() 
    {
        playerInput.Disable();
    }


    private void Pause()
    {
        if(Time.timeScale == 1f && isPaused == false)
		{
			Time.timeScale = 0f;
		}
		else if(Time.timeScale == 0f && isPaused == true)
		{
			Time.timeScale = 1f;
		}
    }

    void FixedUpdate() // utilisation de la physics
    {
        Vector2 moveInput = playerInput.Gameplay.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0 , moveInput.y);
        rb.velocity = movement * speed;

    }

    private void Update() 
    {
        if(playerInput.Gameplay.Pause.triggered)
        {
            Pause();
            isPaused = !isPaused;
        }
    }
}
