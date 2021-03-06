using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Assets.Scripts.UI.Game.Utils;
using System.Linq;

namespace Assets.Scripts.UI.Game.CheckCards
{
    public class ZingDealer
    {
        public const int NumberOfCards = 52;
        /// <summary>
        /// This List represents dealer's cards
        /// </summary>
        public List<GameObject> RemainingCards { get; private set; }

        public List<string> RemainingCardsList { get; set; }
        public List<GameObject> TalonCards { get; private set; }

        public GameObject LastCard { get; private set; }
        public List<GameObject> CardsOfFirstPlayers { get; private set; }

        public List<string> CardsOfFirstPlayersList { get; set; }
        public List<GameObject> CardsOfSecondPlayers { get; private set; }
        public List<string> CardsOfSecondPlayersList { get; set; }
        public List<GameObject> CardsOfThirdPlayers { get; private set; }

        public List<string> CardsOfThirdPlayersList { get; set; }
        public List<GameObject> CardsOfFourthPlayers { get; private set; }

        public List<string> CardsOfFourthPlayersList { get; set; }

        private readonly Random _random;

       

        public ZingDealer(string vv)
        {
            _random = new Random();


            InitAllCards();
            InitTalon();
            InitLastCard();
            InitCardsForPlayers();
        }

        public ZingDealer(string v,string vv)
        {
            _random = new Random();


            InitAllCards();
            InitTalon();
            InitLastCard();
            InitCardsForPlayersTwo();
        }

        public ZingDealer(string v, string vv,string vvv)
        {
            _random = new Random();


            InitAllCards();
            InitTalon();
            InitLastCard();
            InitCardsForPlayersThree();
        }

        public ZingDealer(string v, string vv, string vvv,string vvvv)
        {
            _random = new Random();


            InitAllCards();
            InitTalon();
            InitLastCard();
            InitCardsForPlayersFourth();
        }

        public ZingDealer()
        {

        }

        public void AddCardToTalon()
        {
            // TODO: Dodati kartu na talon.
        }

        /// <summary>
        /// Load all Prefab Cards.
        /// </summary>
        private void InitAllCards()
        {
            RemainingCards = new List<GameObject>(NumberOfCards);

            // Load all Card prefabs
            // NOTE: All prefabs must be in Resources folder. In this case cards are in Assets/Resources/Prefabs/CardPrefabs.
            //var prefabs = Resources.LoadAll("Prefabs/CardPrefabs");
            var prefabs = Resources.LoadAll("Prefabs/CardPrefabsSvg");
            foreach (var prefab in prefabs)
            {
                var go = prefab as GameObject;
                go.transform.position = new Vector3(0f, 0f);
                go.transform.localPosition = new Vector3(0f, 0f);
                // go.transform.localScale = new Vector3(0.789f, 0.789f, 0);
                // Init all cards
                VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                visualCard.BaseCard = card;

                RemainingCards.Add(go);
            }

            System.Random rand = new System.Random();

            var mix = ShuffleCard.Shuffle<GameObject>(RemainingCards, rand);

            RemainingCards = mix.ToList<GameObject>();
            RemainingCardsList = new List<string>();
            foreach (var prefab in RemainingCards)
            {

                RemainingCardsList.Add(prefab.name);
                //    Debug.Log(prefab.name);
                // var go = prefab as GameObject;

                //    // Init all cards
                //    VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                //    Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                //    visualCard.BaseCard = card;
            }
        }

        private void InitLastCard()
        {
            LastCard = RemainingCards.ToArray().GetValue(RemainingCards.Count - 1) as GameObject;
        }


        private void InitTalon()
        {
            TalonCards = new List<GameObject>();


            TalonCards.Add(RemainingCards.ToArray().GetValue(RemainingCards.Count - 2) as GameObject);
            TalonCards.Add(RemainingCards.ToArray().GetValue(RemainingCards.Count - 3) as GameObject);
            TalonCards.Add(RemainingCards.ToArray().GetValue(RemainingCards.Count - 4) as GameObject);
            TalonCards.Add(RemainingCards.ToArray().GetValue(RemainingCards.Count - 5) as GameObject);

            //List<Card> cards = new List<Card>();

            //foreach (var go in TalonCards)
            //{
            //    cards.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);
            //}

            //cards = CardsSorter.SortCards(cards);

            //TalonCards = new List<GameObject>();

            //foreach (var card in cards)
            //{

            //    TalonCards.Add(card.Owner);

            //}

        }

        public void InitCardsForPlayers()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();



            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);


            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);


            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();

           

            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);
               
            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);
               
            }

            //Debug.Log("vv:" + ListOfCardsOfPlayers.Count);
        }

        public void InitCardsForPlayersTwo()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();


            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);


            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);


            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();



            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);

            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);

            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);

            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);

            }

            //Debug.Log("vv:" + ListOfCardsOfPlayers.Count);
        }


        public void InitCardsForPlayersThree()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();


           
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);


            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();



            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);

            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);

            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);

            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);

            }

            //Debug.Log("vv:" + ListOfCardsOfPlayers.Count);
        }

        public void InitCardsForPlayersFourth()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();
            

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();



            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);

            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);

            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);

            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);

            }

            
        }


        public void DeleteSecondPlayerCard()
        {
            // Debug.Log("ukupno karata:" + RemainingCards.Count);
            //RemainingCards.RemoveAt(0);
            //RemainingCards.RemoveAt(1);

            //RemainingCards.RemoveAt(2);
            //RemainingCards.RemoveAt(3);

            //RemainingCards.RemoveAt(4);
            //RemainingCards.RemoveAt(5);

            //RemainingCards.RemoveAt(6);
            //RemainingCards.RemoveAt(7);
            RemainingCards.RemoveRange(0, 8);
            //   Debug.Log("ukupno karata:" + RemainingCards.Count);

        }

        //public void DeleteFirstPlayerCard()
        //{
        //    RemainingCards.Remove(RemainingCards.ToArray().GetValue(2) as GameObject);
        //    RemainingCards.Remove(RemainingCards.ToArray().GetValue(3) as GameObject);

        //    RemainingCards.Remove(RemainingCards.ToArray().GetValue(6) as GameObject);
        //    RemainingCards.Remove(RemainingCards.ToArray().GetValue(7) as GameObject);
        //}

        public void InterationOverRemaingCards()
        {

            for (int i = 0; i < 15; i++)
            {
                var value = RemainingCards.ToArray().GetValue(i) as GameObject;
                Debug.Log(value.name);
            }
            //foreach (var prefab in RemainingCards)
            //{
            //  Debug.Log(prefab.name);

            //}
        }

        public void DeleteRemainingCards()
        {
            RemainingCards.RemoveRange(0, 16);
        }

        public void DeleteLastFourTalonCards()
        {

            int start = RemainingCards.Count - 5;
            RemainingCards.RemoveRange(start, 4);

        }

        public void DealCardsToPlayersFirstSecond()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();



            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);


            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);


            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();

           

            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);
                
            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);
                
            }
        }


        public void DealCardsToPlayersSecondThird()
        {
            CardsOfFirstPlayers = new List<GameObject>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();



            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(0) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(1) as GameObject);

            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(2) as GameObject);
            CardsOfThirdPlayers.Add(RemainingCards.ToArray().GetValue(3) as GameObject);


            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(4) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(5) as GameObject);

            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(6) as GameObject);
            CardsOfFourthPlayers.Add(RemainingCards.ToArray().GetValue(7) as GameObject);


            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(8) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(9) as GameObject);

            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(10) as GameObject);
            CardsOfFirstPlayers.Add(RemainingCards.ToArray().GetValue(11) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(12) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(13) as GameObject);

            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(14) as GameObject);
            CardsOfSecondPlayers.Add(RemainingCards.ToArray().GetValue(15) as GameObject);

            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();



            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);

            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);

            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);

            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);

            }
        }

        public void DealCardsToPlayersFirstSecondAI()
        {

            CardsOfFirstPlayersList = new List<string>();

            CardsOfSecondPlayersList = new List<string>();
            CardsOfThirdPlayersList = new List<string>();
            CardsOfFourthPlayersList = new List<string>();

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            CardsOfSecondPlayersList.Add(RemainingCardsList.ToArray().GetValue(0) as string);
            CardsOfSecondPlayersList.Add(RemainingCardsList.ToArray().GetValue(1) as string);
            CardsOfSecondPlayersList.Add(RemainingCardsList.ToArray().GetValue(2) as string);
            CardsOfSecondPlayersList.Add(RemainingCardsList.ToArray().GetValue(3) as string);

            CardsOfThirdPlayersList.Add(RemainingCardsList.ToArray().GetValue(4) as string);
            CardsOfThirdPlayersList.Add(RemainingCardsList.ToArray().GetValue(5) as string);

            CardsOfThirdPlayersList.Add(RemainingCardsList.ToArray().GetValue(6) as string);
            CardsOfThirdPlayersList.Add(RemainingCardsList.ToArray().GetValue(7) as string);


            CardsOfFourthPlayersList.Add(RemainingCardsList.ToArray().GetValue(8) as string);
            CardsOfFourthPlayersList.Add(RemainingCardsList.ToArray().GetValue(9) as string);

            CardsOfFourthPlayersList.Add(RemainingCardsList.ToArray().GetValue(10) as string);
            CardsOfFourthPlayersList.Add(RemainingCardsList.ToArray().GetValue(11) as string);


            CardsOfFirstPlayersList.Add(RemainingCardsList.ToArray().GetValue(12) as string);
            CardsOfFirstPlayersList.Add(RemainingCardsList.ToArray().GetValue(13) as string);

            CardsOfFirstPlayersList.Add(RemainingCardsList.ToArray().GetValue(14) as string);
            CardsOfFirstPlayersList.Add(RemainingCardsList.ToArray().GetValue(15) as string);

            foreach(var value  in CardsOfSecondPlayersList)
            {
                var prefab = Resources.Load("Prefabs/CardPrefabsSvg/" + value);
               
                    var go = prefab as GameObject;
                    go.transform.position = new Vector3(0f, 0f);
                    go.transform.localPosition = new Vector3(0f, 0f);
                // go.transform.localScale = new Vector3(0.789f, 0.789f, 0);
                // Init all cards
                    VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                    Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                    visualCard.BaseCard = card;

                    CardsOfSecondPlayers.Add(go);
                
            }

            foreach (var value in CardsOfThirdPlayersList)
            {
                var prefab = Resources.Load("Prefabs/CardPrefabsSvg/" + value);

                var go = prefab as GameObject;
                go.transform.position = new Vector3(0f, 0f);
                go.transform.localPosition = new Vector3(0f, 0f);
                // go.transform.localScale = new Vector3(0.789f, 0.789f, 0);
                // Init all cards
                VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                visualCard.BaseCard = card;

                CardsOfThirdPlayers.Add(go);

            }

            foreach (var value in CardsOfFourthPlayersList)
            {
                var prefab = Resources.Load("Prefabs/CardPrefabsSvg/" + value);

                var go = prefab as GameObject;
                go.transform.position = new Vector3(0f, 0f);
                go.transform.localPosition = new Vector3(0f, 0f);
                // go.transform.localScale = new Vector3(0.789f, 0.789f, 0);
                // Init all cards
                VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                visualCard.BaseCard = card;

                CardsOfFourthPlayers.Add(go);

            }

            foreach (var value in CardsOfFirstPlayersList)
            {
                var prefab = Resources.Load("Prefabs/CardPrefabsSvg/" + value);

                var go = prefab as GameObject;
                go.transform.position = new Vector3(0f, 0f);
                go.transform.localPosition = new Vector3(0f, 0f);
                // go.transform.localScale = new Vector3(0.789f, 0.789f, 0);
                // Init all cards
                VisualCard visualCard = go.GetComponent<VisualCard>() as VisualCard;
                Card card = new Card(visualCard.CardSignType, visualCard.CardValueType, go);
                visualCard.BaseCard = card;

                CardsOfFirstPlayers.Add(go);

            }


            List<Card> cardsFirst = new List<Card>();
            List<Card> cardsSecond = new List<Card>();
            List<Card> cardsThird = new List<Card>();
            List<Card> cardsFourth = new List<Card>();

            cardsFirst.Clear();
            cardsSecond.Clear();
            cardsThird.Clear();
            cardsFourth.Clear();

           

            foreach (var go1 in CardsOfFirstPlayers)
            {
                cardsFirst.Add((go1.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfSecondPlayers)
            {
                cardsSecond.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfThirdPlayers)
            {
                cardsThird.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            foreach (var go in CardsOfFourthPlayers)
            {
                cardsFourth.Add((go.GetComponent<VisualCard>() as VisualCard).BaseCard);

            }

            cardsFirst = CardsSorter.SortCards(cardsFirst);

            cardsSecond = CardsSorter.SortCards(cardsSecond);


            cardsThird = CardsSorter.SortCards(cardsThird);

            cardsFourth = CardsSorter.SortCards(cardsFourth);

            CardsOfSecondPlayers = new List<GameObject>();
            CardsOfFirstPlayers = new List<GameObject>();
            CardsOfThirdPlayers = new List<GameObject>();
            CardsOfFourthPlayers = new List<GameObject>();

            foreach (var card in cardsFirst)
            {
                CardsOfFirstPlayers.Add(card.Owner);
                
            }


            foreach (var card in cardsSecond)
            {
                CardsOfSecondPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsThird)
            {
                CardsOfThirdPlayers.Add(card.Owner);
                
            }

            foreach (var card in cardsFourth)
            {
                CardsOfFourthPlayers.Add(card.Owner);
               
            }
        }
    }

        
}
