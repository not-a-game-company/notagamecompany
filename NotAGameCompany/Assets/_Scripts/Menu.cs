using System;
using System.Collections;
using System.Collections.Generic;
using UdpKit;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class Menu : Bolt.GlobalEventListener
{
    public Button joinGameButtonPrefab;
    public GameObject serverListPanel;
    public List<Button> joinServerButtons = new List<Button>();
    public float buttonSpacing;
    private void Start()
    {
        string username = UnityEngine.Random.Range(0, 20).ToString();
        
        PlayerPrefs.SetString("username", username);
        
        print(PlayerPrefs.GetString("username"));
    }

    public void StartServer()
    {
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            if (BoltNetwork.IsServer)
            {
                int randomInt = UnityEngine.Random.Range(0, 9999);
                string matchName = "Test Match" + randomInt;

                BoltNetwork.SetServerInfo(matchName, null);
                BoltNetwork.LoadScene("MainScene");
            }
        }
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)//called when server is created or destroyed
    {
        ClearSessions();
       
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            Button joinGameButtonClone = Instantiate(joinGameButtonPrefab);
            joinGameButtonClone.transform.parent = serverListPanel.transform;
            joinGameButtonClone.transform.localPosition = new Vector3(0,buttonSpacing * joinServerButtons.Count,0);
            joinGameButtonClone.gameObject.SetActive(true);
            
            joinGameButtonClone.onClick.AddListener(() => JoinGame(photonSession));
          
            joinServerButtons.Add(joinGameButtonClone);
        }
    }

    private void JoinGame(UdpSession photonSession)
    {
        BoltNetwork.Connect(photonSession);
    }

    private void ClearSessions()
    {
        foreach (Button button in joinServerButtons)
        {
            Destroy(button.gameObject);
            
        }
        joinServerButtons.Clear();
    }

}
