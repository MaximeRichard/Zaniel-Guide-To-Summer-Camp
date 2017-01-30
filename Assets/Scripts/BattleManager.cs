using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public GameObject ennemy;
    public List<Heros> heros;
    public GameObject gui;

    public GameObject mob;
    public GameObject boss;

    int currentHeros;
    List<Heros> downHeros;
    int phase;

    public enum BattleState
    {
        START,
        PLAYERCHOICE,
        ENNEMYCHOICE,
        WIN,
        LOSE
    }

    public BattleState currentState;

    void Start()
    {
        downHeros = new List<Heros>();
        currentState = BattleState.START;

        for (int i = 0; i < heros.Count; i++)
        {
            heros[i].Setup();
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case BattleState.START:
                SetupBattle();
                break;
            case BattleState.PLAYERCHOICE:
                break;
            case BattleState.ENNEMYCHOICE:
                EnnemyAttack();
                break;
            case BattleState.WIN:
                Destroy(ennemy);
                if(phase == 0)
                {
                    currentState = BattleState.START;
                    phase++;
                }
                else
                {
                    GameManager.LoadScene("EndingRPG", "Méli : I knew it… You’ve done it… You killed Rataking ! You freed me from his foul grip !" +
                                        "\nZaniel : How did we do that... ? What was that power …?" +
                                        "\nMéli : The legends… They were true after all ! " +
                                        "\nSkyler : This is not over… The darkness are gone but i can still feel a much stronger power emanating from somewhere...  " +
                                        "\nMéli : That must be Dragonking… But it doesn’t matter right now. I can’t maintain the summoning for much longer. You need to go back." +
                                        "\nZaniel : Wait ! What was that all about ?! " +
                                        "\nMéli : We’ll meet again soon ! Quick now !");
                }
                break;
            case BattleState.LOSE:
                Debug.Log("Lose");
                break;

        }
    }

    private void SetupBattle()
    {
        if (phase == 0)
        {
            ennemy = (GameObject)Instantiate(mob, transform.position, Quaternion.identity);
        } 
        else 
        {
            ennemy = (GameObject)Instantiate(boss, transform.position, Quaternion.identity);
        }
        ennemy.GetComponent<Ennemy>().Setup();

        currentState = BattleState.PLAYERCHOICE;
    }

    public void AttackAction()
    {
        heros[currentHeros].defend = false;

        heros[currentHeros].GetComponent<Animator>().Play("Attack");

        ennemy.GetComponent<Ennemy>().TakeDamage(heros[currentHeros].attackPower);

        currentHeros++;
        if (currentHeros >= heros.Count)
        {
            currentState = BattleState.ENNEMYCHOICE;
            currentHeros = 0;
        }

        if (ennemy.GetComponent<Ennemy>().CurrentLife <= 0)
        {
            currentState = BattleState.WIN;
        }
    }

    public void DefendAction()
    {
        heros[currentHeros].defend = true;

        currentHeros++;
        if (currentHeros >= heros.Count)
        {
            currentState = BattleState.ENNEMYCHOICE;
            currentHeros = 0;
        }
    }

    public void SkillAction()
    {
        if (heros[currentHeros].GetComponent<Heros>().CurrentSkill <= 0)
            return;
        heros[currentHeros].GetComponent<Heros>().CurrentSkill -= 10;
        heros[currentHeros].defend = false;

        heros[currentHeros].GetComponent<Animator>().Play("Attack");

        if(heros[currentHeros].name == "Magi")
        {
            for (int i = 0; i < heros.Count; i++)
            {
                heros[i].CurrentLife = heros[i].maxLife;
                heros[i].RefreshUI();
            }
        }
        else
            ennemy.GetComponent<Ennemy>().TakeDamage(heros[currentHeros].attackPower * 1.5f);

        heros[currentHeros].RefreshUI();

        currentHeros++;
        if (currentHeros >= heros.Count)
        {
            currentState = BattleState.ENNEMYCHOICE;
            currentHeros = 0;
        }

        if (ennemy.GetComponent<Ennemy>().CurrentLife <= 0)
        {
            currentState = BattleState.WIN;
        }
    }

    private void EnnemyAttack()
    {
        int lowLife = 0;
        for (int i = 0; i < heros.Count; i++)
        {
            if (heros[lowLife].CurrentLife > heros[i].CurrentLife)
                lowLife = i;
        }
        heros[lowLife].TakeDamage(ennemy.GetComponent<Ennemy>().attackPower);
        if (heros[lowLife].CurrentLife <= 0)
        {
            downHeros.Add(heros[lowLife]);
            heros.RemoveAt(lowLife);
        }

        currentState = BattleState.PLAYERCHOICE;

        if (heros.Count <= 0)
        {
            currentState = BattleState.LOSE;
        }
    }
 
}
