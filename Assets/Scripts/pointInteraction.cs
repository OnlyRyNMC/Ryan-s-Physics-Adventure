using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importing unities input system
using UnityEngine.InputSystem;


public class pointInteraction : MonoBehaviour {
    [SerializeField]
    private InputActionReference playersInputs;
    float pointerInputValue;
    bool fire;
    private new Camera camera;
    private GameObject leftTrap;
    private GameObject rightTrap;
    private GameObject thirdLeftDoor;
    private GameObject thirdRightDoor;
    private GameObject Cube7;
    private GameObject Cube10;

    private void Awake(){
        playersInputs.action.performed += context => pointerInputValue = context.action.ReadValue<float>();
    }

    // Setting the camera position
    private void Start(){
        camera = Camera.main;
    }

    // Check to see whether to "fire" or not
    void Update(){
        if (pointerInputValue == 1){
            if (fire == false){
                Fire();
            }
        }
        else if (pointerInputValue == 0){
            fire = false;
        }
    }

    // Firing function (checking to see what you hit and change the animation state)
    void Fire() {
        fire = true;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 7f)) {
            Debug.Log("Shot " + hit.transform.name);
            //If the player clicks the doors handle, the animation state will change
            if (hit.transform.CompareTag("DoorHandle")) {
                hit.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
            }
            //If the lever is clicked, the levers animation state will change
            else if (hit.transform.CompareTag("Lever")) {
                hit.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
                //This line finds the game object in my scene called "leftTrap"
                leftTrap = GameObject.Find("leftTrap");
                //When the levers pulled, the traps in the scene will have there animation state changed
                leftTrap.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
                //This line finds the game object in my scene called "rightTrap"
                rightTrap = GameObject.Find("rightTrap");
                rightTrap.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
            } 
            //If the key is pressed by the player, the doors animation state will change
            else if (hit.transform.CompareTag("Key")) {
                thirdLeftDoor = GameObject.Find("thirdLeftDoor");
                thirdLeftDoor.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
                thirdRightDoor = GameObject.Find("thirdRightDoor");
                thirdRightDoor.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
            }
            //If this specific lever is pressed, the certain cube will move
            else if (hit.transform.CompareTag("Lever1")){
                hit.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
                Cube7 = GameObject.Find("Cube7");
                Cube7.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
            }
            
            //This is the lever that works as a elevator for my player, where if the lever is pressed, the platform raises
            else if (hit.transform.CompareTag("Lever2")){
                hit.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
                Cube10 = GameObject.Find("Cube10");
                Cube10.transform.GetComponentInParent<Animator>().SetTrigger("ChangeState");
            }
        }
    }
}