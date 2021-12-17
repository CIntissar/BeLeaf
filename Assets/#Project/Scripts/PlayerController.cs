using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerActions playerInput;
    public SprinklerBehavior sprinkle;
    public CanonBehavior canon;
    private Rigidbody rb;
    public bool isPaused = false; // pour l'UI
    public bool sprinklerOn;
    public bool canonOn;
    public Animator animator;
    public SpriteRenderer spriteR; 

   
    [SerializeField] private float speed = 10.0f;

    private void Awake() 
    {
        playerInput = new PlayerActions();
        rb = GetComponent<Rigidbody>();    

    }
    
    private void Start() 
    {
        animator = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>(); 
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
        //FlipSprite(moveInput);

        print(rb.velocity);

        if(rb.velocity != Vector3.zero )
        {
            animator.SetBool("isWalking",true);
            if(moveInput.x < 0)
            {
                FlipSprite(true);
            }
            else if(moveInput.x > 0)
            {
                FlipSprite(false);
            }
        }
        else
        {
            animator.SetBool("isWalking",false);
        }

    }

    private void Update() 
    {  

        // PAUSE
        if(playerInput.Gameplay.Pause.triggered)
        {
            Pause();
            isPaused = !isPaused;
        }

        // WEAPON - SPRINKLER
        if(playerInput.Gameplay.Weapon_Sprinkler.triggered)
        {
            Debug.Log("WET!");
            transform.GetChild(0).gameObject.SetActive(true); // sprinkler
            sprinklerOn = true;            
            transform.GetChild(1).gameObject.SetActive(false); // canon
            canonOn = false;
        }
        // WEAPON - CANON
        if(playerInput.Gameplay.Weapon_Canon.triggered)
        {
            Debug.Log("CRISTALLIZE!");
            transform.GetChild(1).gameObject.SetActive(true); // canon
            canonOn = true;
            transform.GetChild(0).gameObject.SetActive(false); // sprinkler
            sprinklerOn = false; 
        }
        // WEAPON - CUTTER

        // ...

        // WEAPON - INTERACTION
        if(playerInput.Gameplay.Interaction.triggered)
        {
            if(sprinklerOn == true)
            {
                Debug.Log("Water in your face!");
                sprinkle.Water();
            }
            else if(canonOn == true) 
            {
                Debug.Log("Feed in your face!");
                canon.Fire();
            }

            
            /*DO A LOT OF THINGS XDDDD
            Interaction avec objet
            passer les dialogues ou aide
            */
        }


    }

    void FlipSprite(bool isLeft)
    {
        if(animator != null)
        {
            spriteR.flipX = isLeft;
            canon.Flip(true);
            sprinkle.Flip(true);
        }
        // if(moveInput.x < 0)
        // {
        //     if(animator != null)
        //     {
        //         spriteR.flipX = true;
        //         canon.Flip(true);
        //         sprinkle.Flip(true);
        //     }

        // }
        // else if(moveInput.x > 0)
        // {
        //     if(animator != null)
        //     {
        //         spriteR.flipX = false;
        //         canon.Flip(false);
        //         sprinkle.Flip(false);

        //     }
        // }

    }
}
