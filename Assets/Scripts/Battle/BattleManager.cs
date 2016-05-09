using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleManager : MonoBehaviour {

    [SerializeField]
    GameObject playerRock;
    [SerializeField]
    GameObject enemyRock;

    //Variables to determine Win/Lose/Tie 
    private bool hasWon;
    private bool hasLost;
    private bool isTie;

    // Use this for initialization
    void Start ()
    {
        //Battle Scene Starts and all are initialised to False
        hasWon = false;
        hasLost = false;
        isTie = false;

        playerRock.GetComponent<Battle_Rock_Player>().Start();
        enemyRock.GetComponent<Battle_Rock_Enemy>().Start();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    //When the Battle button is clicked, this Function is called
    public void BeginFight()
    {


        //Checks for Win/Lose/Tie, if none, Initiate Combat
        playerRock.GetComponent<Battle_Rock_Player>().Combat();
        enemyRock.GetComponent<Battle_Rock_Enemy>().Combat();

        playerRock.GetComponent<Battle_Rock_Player>().ResolveCombat();
        enemyRock.GetComponent<Battle_Rock_Enemy>().ResolveCombat();
        

        if (playerRock.GetComponent<Battle_Rock_Player>().CurrentHealth <= 0 && enemyRock.GetComponent<Battle_Rock_Enemy>().CurrentHealth > 0)
        {
            hasLost = true;
        }
        else if (enemyRock.GetComponent<Battle_Rock_Enemy>().CurrentHealth <= 0 && playerRock.GetComponent<Battle_Rock_Player>().CurrentHealth > 0)
        {
            hasWon = true;
        }
        else
        {
            isTie = true;
        }




    }

    public void ChooseSpecial()
    {

    }

    public void ChooseDefense()
    {

    }

    public void ChooseForfeit()
    {
        if (_GameManager.instance.LoseLife())
        {
            GameObject.Find("FadeScreen").GetComponent<SceneFadeInAndOut>().LoadNewScene("MainMenu");
        }
    }
}
