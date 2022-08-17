using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float _interactDiastance = 3f;

    void Update()
    {
        UIManager.Instance.OffInteractionUI();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _interactDiastance))
        {
            if (hit.collider.CompareTag("LeftDoor"))
            {
                UIManager.Instance.OnInteractionUI();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<LeftDoorScript>().ChangeDoorState();
                }
            }
            else if (hit.collider.CompareTag("RightDoor"))
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<RightDoorScript>().ChangeDoorState();
                }
                
            }
        }

    }
}
