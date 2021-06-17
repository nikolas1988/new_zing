﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddGoldCoins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlus()
    {
        Debug.Log("radi sve");
    }

    public void OnPointerEnter()
    {
        var components = gameObject.GetComponents<Component>();


        foreach (var com in components)
        {
            var vv = com.GetType();
            if (typeof(Image).IsAssignableFrom(vv))
            {
                var image2 = (Image)com;
                image2.sprite = Resources.Load<Sprite>("main_page/GoldAddCoinsOver");
            }
        }
    }

    public void OnPointerExit()
    {
        var components = gameObject.GetComponents<Component>();


        foreach (var com in components)
        {
            var vv = com.GetType();
            if (typeof(Image).IsAssignableFrom(vv))
            {
                var image2 = (Image)com;
                image2.sprite = Resources.Load<Sprite>("main_page/GoldAddCoins");
            }
        }
    }
}
