using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        float randomPositionX = Random.Range(-50f, 50f);
        float randomPositionZ = Random.Range(-50f, 50f);
        Vector3 randomPosition = new Vector3(randomPositionX, 1f, randomPositionZ);

        Data data = FindObjectOfType<Data>();

        GameObject playerObject = PhotonNetwork.Instantiate("Player", randomPosition, Quaternion.identity);
        PlayerController player = playerObject.GetComponent<PlayerController>();
    }
}
