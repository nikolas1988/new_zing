﻿using Assets.Scripts.Managers;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Assets.Scripts.UI.Game;
using Facebook.Unity;
using Assets.Scripts.UI.Game.CheckCards;
using Assets.Scripts.Infastructure.PARSER;

public class GameScript : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private PhotonView _currentPhotonView;
    [SerializeField]
    private Text BluePlayerNameValue;

    [SerializeField]
    private Text RedPlayerNameValue;

    [SerializeField]
    private Text DealerName;
    [SerializeField]
    private GameObject DealerImage;

    [SerializeField]
    private Text CardsBlueText;

    [SerializeField]
    private Text PointsBlueText;
    [SerializeField]
    private Text ZingBlueText;

    [SerializeField]
    private Text TotalBlueText;

    [SerializeField]
    private Text CardsRedText;

    [SerializeField]
    private Text PointsRedText;
    [SerializeField]
    private Text ZingRedText;

    [SerializeField]
    private Text TotalRedText;
    [SerializeField]
    private Text Text;

    [SerializeField]
    private Text LeaveGameText;

    private List<RoomListing> _roomListings;

    private RoomListingMenu _roomListingMenu;


    private bool isGameStarted = false;
   

    private ZingDealer _zingDealer;

    private List<string> RemainingCardsList;


    void Awake()
    {
       
    }

     void OnEnable()
    {
      
       
    }
    // Start is called before the first frame update
    void Start()
    {

        ParseJson json = new ParseJson();
        var root = json.DeserializeGame();

        if (MasterManager.GameSettings.DefaultLanguage == "English")
        {
            CardsBlueText.text = root.cards[0].english;
            PointsBlueText.text = root.points[0].english;
            ZingBlueText.text = root.zings[0].english;
            TotalBlueText.text = root.total[0].english;

            CardsRedText.text = root.cards[0].english;
            PointsRedText.text = root.points[0].english;
            ZingRedText.text = root.zings[0].english;
            TotalRedText.text = root.total[0].english;

            Text.text = root.dealer[0].english;

            LeaveGameText.text = root.leave[0].english;
        }
        if (MasterManager.GameSettings.DefaultLanguage == "Spanish")
        {
            CardsBlueText.text = root.cards[1].spanish;
            PointsBlueText.text = root.points[1].spanish;
            ZingBlueText.text = root.zings[1].spanish;
            TotalBlueText.text = root.total[1].spanish;

            CardsRedText.text = root.cards[1].spanish;
            PointsRedText.text = root.points[1].spanish;
            ZingRedText.text = root.zings[1].spanish;
            TotalRedText.text = root.total[1].spanish;

            Text.text = root.dealer[1].spanish;

            LeaveGameText.text = root.leave[1].spanish;
        }
        if (MasterManager.GameSettings.DefaultLanguage == "Portugales")
        {
            CardsBlueText.text = root.cards[2].portuguese;
            PointsBlueText.text = root.points[2].portuguese;
            ZingBlueText.text = root.zings[2].portuguese;
            TotalBlueText.text = root.total[2].portuguese;

            CardsRedText.text = root.cards[2].portuguese;
            PointsRedText.text = root.points[2].portuguese;
            ZingRedText.text = root.zings[2].portuguese;
            TotalRedText.text = root.total[2].portuguese;

            Text.text = root.dealer[2].portuguese;

            LeaveGameText.text = root.leave[2].portuguese;
        }
        if (MasterManager.GameSettings.DefaultLanguage == "Russian")
        {
            CardsBlueText.text = root.cards[3].russian;
            PointsBlueText.text = root.points[3].russian;
            ZingBlueText.text = root.zings[3].russian;
            TotalBlueText.text = root.total[3].russian;

            CardsRedText.text = root.cards[3].russian;
            PointsRedText.text = root.points[3].russian;
            ZingRedText.text = root.zings[3].russian;
            TotalRedText.text = root.total[3].russian;

            Text.text = root.dealer[3].russian;
            LeaveGameText.text = root.leave[3].russian;
        }
            _currentPhotonView.RPC("UpdatePlayersName", RpcTarget.All);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 4) {
          
           
            isGameStarted = true;
            photonView.RPC("StartGame", PhotonNetwork.CurrentRoom.GetPlayer(1), isGameStarted);
         
        }
    }

    

   

    // Update is called once per frame
    void Update()
    {
        try
        {

            var players = PhotonNetwork.CurrentRoom.Players;
            foreach (var current in players)
            {
                
                
                if (players[current.Key].CustomProperties["State"].Equals("inactive"))
                {
                    //ako jedan od igraca nije aktivan aktivirace se ova linija koda
                   // Debug.Log("radi");
                    //_currentPhotonView.RPC("ReadLine", players[current.Key]);
                }
            }


        }
        catch (Exception ex)
        {
            //Debug.Log("tacno");
        }



    }


  

    [PunRPC]
    public void UpdatePlayersName()
    {
        Dictionary<int, Player> value = PhotonNetwork.CurrentRoom.Players;
        BluePlayerNameValue.text = "";
        RedPlayerNameValue.text = "";
        foreach (var vv in value)
        {
           
            
            if (PhotonNetwork.CurrentRoom.GetPlayer(vv.Key).CustomProperties["Team"].Equals("Blue"))
            {
                BluePlayerNameValue.text += PhotonNetwork.CurrentRoom.GetPlayer(vv.Key).NickName;

            }
            else
            {
                RedPlayerNameValue.text += PhotonNetwork.CurrentRoom.GetPlayer(vv.Key).NickName;
            }

            

        }


       
        
    }


    void DisplayProfilePic(IGraphResult result)
    {

        if (result.Texture != null)
        {

            UnityEngine.UI.Image ProfilePic = DealerImage.GetComponent<UnityEngine.UI.Image>();
            ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 64, 64), new Vector2());
            Texture2D tempTex = result.Texture;

            byte[] value = tempTex.EncodeToPNG();

            _currentPhotonView.RPC("SetPictureDealer", RpcTarget.Others, value, DealerName.text);
        }

    }

    [PunRPC]
    public void SetPictureDealer(byte[] value, string NickName)
    {
        Texture2D tex = new Texture2D(64, 64);

        tex.LoadImage(value);
        // Assign texture to renderer's material.
        //GetComponent<Renderer>().material.mainTexture = tex;
        UnityEngine.UI.Image ProfilePic = DealerImage.GetComponent<UnityEngine.UI.Image>();
        ProfilePic.sprite = Sprite.Create(tex, new Rect(0, 0, 64, 64), new Vector2());

        DealerName.text = NickName;
    }



    [PunRPC]
    public void StartGame(bool state)
    {
        isGameStarted = state;
        Dictionary<int, Player> value = PhotonNetwork.CurrentRoom.Players;
        if (SideOfTeam.CurrentPlayerSide == 1)
        {
            DealerName.text = PhotonNetwork.CurrentRoom.GetPlayer(1).NickName;
        }
        else
        {
            var fff = value.Keys;
            foreach (var temp in fff)
            {
                if (temp == 2)
                {
                    DealerName.text = PhotonNetwork.CurrentRoom.GetPlayer(2).NickName;
                }
                else
                {
                    DealerName.text = PhotonNetwork.CurrentRoom.GetPlayer(temp).NickName;
                }
            }


        }

        FB.API("/me/picture?type=square&height=64&width=64", HttpMethod.GET, DisplayProfilePic);
        if (SideOfTeam.CurrentPlayerSide == 1 && isGameStarted)
        {
            _zingDealer = new ZingDealer();
            string[] remaingCardArray = new string[_zingDealer.RemainingCards.Count];
            int intValue = 0;
            RemainingCardsList = new List<string>();
            foreach (var obj in _zingDealer.RemainingCards)
            {

                remaingCardArray[intValue] = obj.name;
                Debug.Log("a:" + obj.name);
                RemainingCardsList.Add(obj.name);
                intValue++;
            }
        }
    }
   
}
