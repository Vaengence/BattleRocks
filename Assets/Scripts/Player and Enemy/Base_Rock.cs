using UnityEngine;
using System.Collections;

public abstract class Base_Rock : Object {

    protected float attack, defense, speed, luck, health;
    protected float finalDamageOutput;

    protected string rockName;
    protected string rockDescription;

    protected string SpriteID;


    public float Defense{get { return defense; }}
    public float Speed { get { return speed; } }
    public float Damage { get { return finalDamageOutput; } }

    public abstract void Combat();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
