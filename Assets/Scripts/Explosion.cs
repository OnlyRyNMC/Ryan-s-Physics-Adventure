using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField] private float delay = 1f;
    [SerializeField] private float power = 50f;
    [SerializeField] private float radius = 1f;
    [SerializeField] private GameObject particles;
    [SerializeField] private AudioSource clip;
    AudioSource speaker;


    //Class my game button can call to start the explosion
    public void Run(){
        speaker = GetComponent<AudioSource>();
        StartCoroutine("ExpLODE");
    }

    //Class the buttton at the end of my game can call to play the ending music
    public void Music(){
        clip.Play();
        }

        // Code to make anything in the given radius push back by a certain amount
        IEnumerator ExpLODE(){
        while (true){
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hit in colliders){
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                
                if (rb != null)
                    rb.AddExplosionForce(power, transform.position, radius, 3.0f);
                }
                // Making the pitch of the sound effect change 
                speaker.pitch = Random.Range(0.8f, 1.2f);
                speaker.Play();
                
                //Destroying the particles from the explosion
                if (particles != null){
                    GameObject clone = Instantiate(particles, transform.position, transform.rotation);
                    Destroy(clone, 1f);
                }
                //Check to see if the explosion should occur again after a set delay
                yield return new WaitForSeconds(delay);
            }
        }
    }


