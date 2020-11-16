using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    int diceRollOne;
    int diceRollTwo;
    int FinalRoll;
    int counter;
    int SelectedRoll;
    int Bet;
    int Stagetracker = 0;

    //Dice Sprites
    public GameObject[] DieOne;
    public GameObject[] DieTwo;

    //Betting Buttons
    public GameObject BettingButtons;

    //Value Select Buttons
    public GameObject SelectButtons;

    void Start()
    {
        diceRollOne = Random.Range(1, 7);
        diceRollTwo = Random.Range(1, 7);
    }

    void FixedUpdate()
    {
        if(Stagetracker == 1)
        {
            BettingButtons.SetActive(false);
            SelectButtons.SetActive(true);
        }
        if(Stagetracker == 2)
        {
            SelectButtons.SetActive(false);
            if (counter < 201)
            {
                if(counter % 8 == 0)
                {
                    RollStage();
                }
                counter++;
            }
        }
        if(Stagetracker == 3)
        {
            PostGame();
        }
    }
    
    //Betting Buttons
    public void ButtonPressTen()
    {
        Bet = 10;
        Stagetracker++;
    }
    public void ButtonPressTwentyFive()
    {
        Bet = 25;
        Stagetracker++;
    }
    public void ButtonPressFifty()
    {
        Bet = 50;
        Stagetracker++;
    }

    //Select Buttons
    public void SelectDiceRoll2()
    {
        SelectedRoll = 2;
        Stagetracker++;
    }
    public void SelectDiceRoll3()
    {
        SelectedRoll = 3;
        Stagetracker++;
    }
    public void SelectDiceRoll4()
    {
        SelectedRoll = 4;
        Stagetracker++;
    }
    public void SelectDiceRoll5()
    {
        SelectedRoll = 5;
        Stagetracker++;
    }
    public void SelectDiceRoll6()
    {
        SelectedRoll = 6;
        Stagetracker++;
    }
    public void SelectDiceRoll7()
    {
        SelectedRoll = 7;
        Stagetracker++;
    }
    public void SelectDiceRoll8()
    {
        SelectedRoll = 8;
        Stagetracker++;
    }
    public void SelectDiceRoll9()
    {
        SelectedRoll = 9;
        Stagetracker++;
    }

    public void SelectDiceRoll10()
    {
        SelectedRoll = 10;
        Stagetracker++;
    }
    public void SelectDiceRoll11()
    {
        SelectedRoll = 11;
        Stagetracker++;
    }
    public void SelectDiceRoll12()
    {
        SelectedRoll = 12;
        Stagetracker++;
    }

    void RollStage()
    {
        DieOne[diceRollOne - 1].SetActive(false);
        DieTwo[diceRollTwo - 1].SetActive(false);

        diceRollOne = Random.Range(1,7);
        diceRollTwo = Random.Range(1,7);

        DieOne[diceRollOne - 1].SetActive(true);
        DieTwo[diceRollTwo - 1].SetActive(true);

        if(counter == 200)
        {
            FinalRoll = diceRollOne + diceRollTwo;
            Debug.Log(FinalRoll);
            Stagetracker++;
        }
    }

    void PostGame()
    {
        if(FinalRoll == SelectedRoll)
        {
            //Win
            Debug.Log("Winner");
            //Bet * Multiplier
        }
        else
        {
            Debug.Log("Loser");
            //Lose
        }
    }
}
