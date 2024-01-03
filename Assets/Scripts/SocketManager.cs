using UnityEngine;
using UnityEngine.UI;
using SocketIOClient;
using System.Net.Sockets;
using TMPro;

public class SocketManager : MonoBehaviour
{
    private SocketIOUnity _socket;

    [SerializeField] private TextMeshProUGUI _urlInput;
    [SerializeField] public Button _connectButton;

    void Start()
    {
        _connectButton.onClick.AddListener(ConnectToServer);
    }

    void ConnectToServer()
    {
        string serverURL = _urlInput.text;

        if (!string.IsNullOrEmpty(serverURL))
        {
            System.Uri uri = new System.Uri(serverURL);
            _socket = new SocketIOUnity(uri);
            _socket.On("test", OnTestBroadcast);
            _socket.Connect();
        }
        else
        {
            Debug.LogError("Please enter a valid server URL.");
        }
    }

    void OnTestBroadcast(SocketIOResponse response)
    {
        // Handle the "test" broadcasted data here
        Debug.Log("Received test broadcast: " + response.ToString());
    }
}

