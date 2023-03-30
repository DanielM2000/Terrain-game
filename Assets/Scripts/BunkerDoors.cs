using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BunkerDoors : MonoBehaviour
{
    Animator anim; // declare a variable of type Animator called ‘anim’
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
    }
    // references this script to the Animator component of the parent (tower)
    void OnTriggerEnter(Collider coll)
    {
        anim.SetBool("openDoors", true); // sets the bool state to ‘true’
         // this will allow the transition arrow from the closed default state to pass onto the opening state
 }
    void OnTriggerExit(Collider coll)
    {
        anim.SetBool("openDoors", false); // sets the bool state to ‘false’
                                          // and shuts the doors PROVIDING THE
                                          //ANIMATION STATE HAS BEEN SET TO MINUS 1!
    }
}