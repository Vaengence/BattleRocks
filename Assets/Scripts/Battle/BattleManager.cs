using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {


    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void BeginFight()
    {

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
