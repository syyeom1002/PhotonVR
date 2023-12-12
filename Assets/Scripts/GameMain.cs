using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnpoints;
    void Start()
    {
        NetworkManager.instance.callbackEvent.AddListener(this.NetworkCallbackEventHandler);
        NetworkManager.instance.Init();
        NetworkManager.instance.Connect();
    }

    private void NetworkCallbackEventHandler(NetworkManager.eCallbackType callbackType)
    {
        switch (callbackType)
        {
            case NetworkManager.eCallbackType.ON_JOINED_ROOM:
                this.OnJoinedRoomRoomHandler();
                break;
            case NetworkManager.eCallbackType.ON_PLAYER_ENTERED_ROOM:
                this.OnPlayerEnteredRoomHandler();
                break;
        }
    }

    private void OnPlayerEnteredRoomHandler()
    {
        Debug.Log("OnPlayerEnteredRoomHandler");
    }
    private void OnJoinedRoomRoomHandler()
    {
        Debug.Log("OnjoinedRoomHandler");
        this.CreateNetworkRig();
    }
    private void CreateNetworkRig()
    {
        int idx=Random.Range(0, spawnpoints.Length);
        var point = this.spawnpoints[idx];
        GameObject go= PhotonNetwork.Instantiate("NetworkRig", Vector3.zero, Quaternion.identity);
        var networkRig = go.GetComponent<NetworkRig>();
        if (networkRig.pv.IsMine)
        {
            var hardwareRig = GameObject.FindObjectOfType<HardwareRig>();
            hardwareRig.SetPositionAndRotation(point.position,point.rotation);
        }
    }
}
