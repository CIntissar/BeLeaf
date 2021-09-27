using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController charactController;
    public Vector2 moveVector;
    public float movementSpeed;

    
    public void Move(InputAction.CallbackContext context) // MOUVEMENT
    {
        moveVector = context.ReadValue<Vector2>(); // A checker
    }
    
    public void Pause(InputAction.CallbackContext context) // PAUSE - MENU?
    {
        //Ajouter la pause
        if(Time.timeScale == 1f)
		{
			Time.timeScale = 0f;
		}
		else(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
		}
    }
    
    public void Interaction(InputAction.CallbackContext context) // INTERACTION - ACTION
    {
        // CLick qui déclenche l'interaction avec objet
        // Utiliser son arme
    }

    public void Weapon(InputAction.CallbackContext context) // CHANGE WEAPON
    {
        //switch des armes
        // Trois types d'armes
        // Sprinkler / Canon / Cutter -> only Sprinkler si j'arrive pas plus
    }

    // public void CameraMoving(InputAction.CallbackContext context)
    // {
    //     // Fonction qui consiste à manipuler la direction du personnage par le biais de la souris
    //     // Pas sur de le faire
    // }

    void Update()
    {    
        Vector2 movement = new Vector2(moveVector.x,moveVector.y) * movementSpeed;

        charactController.Move(movement * Time.deltaTime);
    }
}
