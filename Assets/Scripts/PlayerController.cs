using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private PickupController pickupController;
    void Awake()
    {
        GameObject pickupSpawnPoint = GameObject.Find("PickupSpawnPoints") as
       GameObject; //find the PickupSpawnPoints GameObject
        pickupController = pickupSpawnPoint.GetComponent<PickupController>();
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            // pickupController.Collected(hit.gameObject);
            StartCoroutine(pickupController.Collected(hit.gameObject));
        }
    }
}
