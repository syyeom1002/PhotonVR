using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public enum eCallbackType
    {
        ON_JOINED_ROOM,
        ON_PLAYER_ENTERED_ROOM
    }

    public static NetworkManager instance;

    [SerializeField]
    private string gameVersion = "0.0.1";

    public UnityEvent<eCallbackType> callbackEvent = new UnityEvent<eCallbackType>();

    private void Awake()
    {
        if (NetworkManager.instance != null && NetworkManager.instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            NetworkManager.instance = this;
        }
    }

    // private void Start()
    // {
    //     //Test
    //     this.Init();
    //     this.Connect();
    // }

    public void Init()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            //������ ���� 
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //������ ���� ���� 
            PhotonNetwork.GameVersion = this.gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� ���ӵ�");
        PhotonNetwork.JoinLobby();  //�κ� ���� 
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���Խ��ϴ�.");
        PhotonNetwork.JoinRandomOrCreateRoom();//���� ������ ���� ������ ���� �� 
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat("��({0})�� ���Խ��ϴ�.", PhotonNetwork.CurrentRoom.Name);
        this.callbackEvent.Invoke(eCallbackType.ON_JOINED_ROOM);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogFormat("[OnJoinRandomFailed] : {0}", message);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("[OnPlayerEnteredRoom] : {0}", newPlayer.NickName);

        this.callbackEvent.Invoke(eCallbackType.ON_PLAYER_ENTERED_ROOM);
    }
}