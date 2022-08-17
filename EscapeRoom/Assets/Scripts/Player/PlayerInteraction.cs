using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float _interactDiastance = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.Log("레이캐스트 쐈음");
            if (Physics.Raycast(ray, out hit, _interactDiastance))
            {
                Debug.Log("레이캐스트 맞음");
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<DoorScript>().ChangeDoorState();
                }
            }
        }

    }
}
