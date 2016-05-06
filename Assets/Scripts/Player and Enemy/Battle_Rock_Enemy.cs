using UnityEngine;
using System.Collections;

public class Battle_Rock_Enemy : Base_Rock {

	// Use this for initialization
	void Start ()
    {
        cachedY = healthTranform.position.y;
        maxXValue = healthTranform.position.x;
        minXValue = healthTranform.position.x - healthTranform.rect.width;
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleHealth();
    }

    public void Combat()
    {
        GameObject player = GameObject.Find("Battle_Rock_Player");
        Battle_Rock_Enemy thePlayer = player.GetComponent<Battle_Rock_Enemy>();

        finalDamageOutput = (attack - thePlayer.Defense) * (speed / thePlayer.Speed) + luck;

    }

    public void ResolveCombat()
    {
        GameObject player = GameObject.Find("Battle_Rock_Player");
        Battle_Rock_Enemy thePlayer = player.GetComponent<Battle_Rock_Enemy>();

        this.CurrentHealth -= thePlayer.Damage;
    }
}
