﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfMoveRefactor : MonoBehaviour
{

    Canvas _tempCanvas;
    int countOfClick = 0;
    private System.Random _random;
    
    private Vector2 _endPoint;
    private float _landingToleranceRadius;

    public TimeOfMoveRefactor(Canvas valueCanvas, int click)
    {
        _tempCanvas = valueCanvas;
        countOfClick = click;


        _random = new System.Random();
        _endPoint = Vector2.zero;
        _landingToleranceRadius = 0.3f;
    }
    

    public void ConfigureDroppedCard()
    {
        var tv = (Canvas)GameScript.player.GetCurrentPlayerCanvas();

        
        int valueCard = _random.Next(0, tv.transform.childCount);

        var _tempTransoformCard = tv.transform.GetChild(valueCard);

        string CardNameClone = _tempTransoformCard.name;
        
        var index = CardNameClone.IndexOf("(");
        string CardName = CardNameClone.Substring(0, index);
       
        var tt = Resources.Load("Prefabs/CardPrefabsStartSvg/" + CardName);
        var _currentCard = (GameObject)tt;
        
        //za current card objekat je neophodno setovati svgrender order na 1
        //_currentCard.transform.localScale = new Vector3(0.23f, 0.23f);

        _random = new System.Random();
        //var valueX = _random.NextDouble() * (1 - (-0.6)) + (-0.6);
        var valueX = 400 * (1 - (-0.6)) + (-0.6);
        //float x = (float)(_endPoint.x + valueX  * _random.NextDouble() );
        float toleranceX = 2.3f;
        float x = (float)(valueX + _random.Next(-20, 20) * toleranceX);
        var value = 340 * (1.5 - 0.6) + 0.6;
        float y = (float)(_endPoint.y + _random.Next(100, 150) * _landingToleranceRadius + value);
        _currentCard.transform.position = new Vector3(x, y);


        GameObject myBrick = PhotonNetwork.Instantiate("Prefabs/CardPrefabsStartSvg/" + CardName, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

       
        
        myBrick.transform.SetParent(_tempCanvas.transform);

        //var list = BeginningOfGame.player.GetOfListOfCards();
        var list = GameScript.player.GetOfListOfCards();
        list.Add(CardName);
        // Debug.Log("prosla karta:" + list.Count);



        //BeginningOfGame.player.SetListOfCards(list);
        //BeginningOfGame.player.photonView.RPC("ChangeMoveDropedCard", RpcTarget.Others, CardName, _currentCard.transform.position, countOfClick);
        GameScript.player.SetListOfCards(list);
       // GameScript.player.photonView.RPC("ChangeMoveDropedCard", RpcTarget.Others, CardName, _currentCard.transform.position, countOfClick);
        TimeOfMoveObject.DeactiveGameObject();
        
        countOfClick++;

        Destroy(_tempTransoformCard.gameObject);

        foreach (Transform element in tv.transform)
        {
            // Debug.Log(i++);

            var firstCard = element.Find("FirstCardSelected").gameObject;
            firstCard.active = false;

        }

    }

}
