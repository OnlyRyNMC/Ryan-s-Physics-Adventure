using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Makes us able to use events in unity
using UnityEngine.Events;

public class FloorButton : MonoBehaviour
{
    //Creating a tag to compare if the player is touching the button
    const string PLAYER_TAG = "Player";
    public UnityEvent ButtonPressed;
    public UnityEvent ButtonReleased;

    //If player touches something
    private void OnTriggerEnter(Collider other){
        //If something collides with something with the "player" tag
        if (other.CompareTag(PLAYER_TAG)){
            //Print to console "button pressed"
            Debug.Log("Button Pressed");
            //Do the action
            ButtonPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag(PLAYER_TAG)){
            Debug.Log("Button Released");
            ButtonReleased.Invoke();
        }
    }
}
