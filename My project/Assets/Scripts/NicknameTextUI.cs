using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameTextUI : MonoBehaviourPunCallbacks, IPunObservable
{
    private TextMeshProUGUI _ui;

    private int _clickCount = 0;
    private string _nickname;

    public int ClickCount
    {
        get
        {
            return _clickCount;
        }
        set
        {
            _clickCount = value;
            Nickname = $"{_nickname} : {_clickCount}";
        }
    }

    public string Nickname
    {
        get
        {
            return _ui.text;
        }

        set
        {
            _ui.text = value;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // ������ Send()�� Receive()�� ������ �����ϰ� �����ϸ� ��
        // ����ȭ => ���� �������� �����͸� ������ ��
        if(stream.IsWriting)
        {
            // sendNext() ���
            stream.SendNext(ClickCount);
        }
        // ������ȭ => �����κ��� �����͸� ���� ��
        else
        {
            // ReceiveNext() ���
            ClickCount = (int)stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void SetNickname(string nickname)
    {
        Nickname = nickname;
    }

    public override void OnJoinedRoom()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        photonView.RPC("SetNickname", newPlayer, Nickname);
    }

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        Data data = FindObjectOfType<Data>();

        if(photonView.IsMine)
        {
            _nickname = data.Nickname;
            // Nickname = _nickname;
            ClickCount = 0;
            photonView.RPC("SetNickname", RpcTarget.Others, Nickname);
        }
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ++ClickCount;
            }
        }
    }
}
