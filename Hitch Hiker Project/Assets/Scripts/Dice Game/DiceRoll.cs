using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRoll : MonoBehaviour
{
    int diceRollOne;
    int diceRollTwo;
    int FinalRoll;
    int counter;
    int SelectedRoll;
    int Bet;
    int multiplyer;
    int Stagetracker = 0;
    float timer;

    //Dice Sprites
    public GameObject[] DieOne;
    public GameObject[] DieTwo;

    //Betting Buttons
    public GameObject BettingButtons;

    //Value Select Buttons
    public GameObject SelectButtons;

    //Exit Button
    public GameObject Exit;

    //Money Check Text
    public GameObject MoneyCheck;

    //SFX
    public AudioSource StageChange;
    public AudioSource Winner;
    public AudioSource Loser;
    public AudioSource RollSFX;

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
            Exit.SetActive(false);
            MoneyCheck.SetActive(false);
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
        if(Stagetracker == 4)
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                SceneManager.LoadScene("DialogueSystem");
            }
        }
    }

    //Exit game if you have no money
    public void LeaveGame()
    {
        SceneManager.LoadScene("DialogueSystem");
    }
    
    //Betting Buttons
    public void ButtonPressTen()
    {
        if(PlayerPrefs.GetInt("cMoney") < 10)
        {
            MoneyCheck.SetActive(true);
        }
        else
        {
            Bet = 10;
            Stagetracker++;
            StageChange.Play();
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") - 10);
        }    
    }
    public void ButtonPressTwentyFive()
    {
        if (PlayerPrefs.GetInt("cMoney") < 25)
        {
            MoneyCheck.SetActive(true);
        }
        else
        {
            Bet = 25;
            Stagetracker++;
            StageChange.Play();
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") - 25);
        }
    }
    public void ButtonPressFifty()
    {
        if (PlayerPrefs.GetInt("cMoney") < 50)
        {
            MoneyCheck.SetActive(true);
        }
        else
        {
            Bet = 50;
            Stagetracker++;
            StageChange.Play();
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") - 50);
        }
    }

    //Select Buttons
    public void SelectDiceRoll2()
    {
        SelectedRoll = 2;
        multiplyer = 36;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll3()
    {
        SelectedRoll = 3;
        multiplyer = 18;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll4()
    {
        SelectedRoll = 4;
        multiplyer = 12;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll5()
    {
        SelectedRoll = 5;
        multiplyer = 9;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll6()
    {
        SelectedRoll = 6;
        multiplyer = 7;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll7()
    {
        SelectedRoll = 7;
        multiplyer = 6;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll8()
    {
        SelectedRoll = 8;
        multiplyer = 7;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll9()
    {
        SelectedRoll = 9;
        multiplyer = 9;
        StageChange.Play();
        Stagetracker++;
    }

    public void SelectDiceRoll10()
    {
        SelectedRoll = 10;
        multiplyer = 12;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll11()
    {
        SelectedRoll = 11;
        multiplyer = 18;
        StageChange.Play();
        Stagetracker++;
    }
    public void SelectDiceRoll12()
    {
        SelectedRoll = 12;
        multiplyer = 36;
        StageChange.Play();
        Stagetracker++;
    }

    void RollStage()
    {
        DieOne[diceRollOne - 1].SetActive(false);
        DieTwo[diceRollTwo - 1].SetActive(false);

        diceRollOne = Random.Range(1,7);
        diceRollTwo = Random.Range(1,7);

        RollSFX.Play();

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
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + (Bet * multiplyer));
            Winner.Play();
            Stagetracker++;
        }
        else
        {
            Debug.Log("Loser");
            Loser.Play();
            Stagetracker++;
            //Lose
        }
    }
}
