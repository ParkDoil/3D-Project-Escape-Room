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
        // 데이터 Send()와 Receive()의 순서는 동일하게 진행하면 됨
        // 직렬화 => 내가 서버한테 데이터를 보내는 것
        if(stream.IsWriting)
        {
            // sendNext() 사용
            stream.SendNext(ClickCount);
        }
        // 역직렬화 => 서버로부터 데이터를 받은 것
        else
        {
            // ReceiveNext() 사용
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
