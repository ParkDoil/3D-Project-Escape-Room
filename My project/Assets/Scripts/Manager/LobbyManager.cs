using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _nickname;

    [SerializeField]
    private Button _joinButton;
    private TextMeshProUGUI _joinButtonText;

    private void deactivateJoinButton(string message)
    {
        _joinButton.interactable = false;
        _joinButtonText.text = message;
    }

    private void activateJoinButton()
    {
        _joinButton.interactable = true;
        _joinButtonText.text = "�����ϱ�";
    }

    void Awake()
    {
        // ��ư�� �ؽ�Ʈ ����
        _joinButtonText = _joinButton.GetComponentInChildren<TextMeshProUGUI>();

        // ��ư �̺�Ʈ �޼ҵ� ����
        _joinButton.onClick.AddListener(OnClickedJoinButton);

        // ������ ������ ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        // UI ǥ�� ����
        deactivateJoinButton("���� �õ� ��");
    }

    public override void OnConnectedToMaster()
    {
        // �α� ����
        Debug.Log("������ ������ ���� ��..");

        // ��ư Ȱ��ȭ
        activateJoinButton();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        // ���� �ٽ� �õ�
        PhotonNetwork.ConnectUsingSettings();

        // ��ư ��Ȱ��ȭ
        deactivateJoinButton("������ �õ� ��");
    }

    private static readonly RoomOptions RandomRoomOptions = new RoomOptions()
    {
        MaxPlayers = 20
    };


    private void OnClickedJoinButton()
    {
        if(_nickname.text.Length == 0)
        {
            Debug.Log("�г����� �Է��ϼ���.");

            return;
        }

        Data data = FindObjectOfType<Data>();
        data.Nickname = _nickname.text;
        Debug.Log($"�Էµ� �г��� : {data.Nickname}");
        PhotonNetwork.JoinOrCreateRoom("Metaverse", RandomRoomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // �α� ����
        Debug.Log("�濡 ������.");

        // ���� �̵�
        PhotonNetwork.LoadLevel("Main");
    }
}
