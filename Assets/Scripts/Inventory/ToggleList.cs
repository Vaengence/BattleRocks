using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;


public class ToggleList : MonoBehaviour 
{
	
	public List<Toggle> toggleButtons = null;


	private int selectedToggle = 0;

	public int SelectedToggle{ get{return selectedToggle;} }


	[SerializeField]
	private UnityEvent onToggleChange = null;


	void Awake()
	{
		// Add a ToggleGroup Script Component to this gameObject if not already attached
		if (GetComponent<ToggleGroup>() == null)
		{
			gameObject.AddComponent<ToggleGroup> ();
		}

		if (toggleButtons == null)
		{
			toggleButtons = new List<Toggle> ();
		}
		else
		{
			ToggleInit ();
		}
	}


	// Use this for initialization
	void Start ()
	{

	}

	// Initialise the list of toggle buttons
	public void ToggleInit()
	{
		ToggleGroup toggleGroup = GetComponent<ToggleGroup>();

		for (int i = 0; i < toggleButtons.Count; ++i)
		{
			if (i == 0)
			{
				toggleButtons [i].isOn = true;
			}
			else
			{
				toggleButtons [i].isOn = false;
			}

			toggleButtons [i].interactable = true;

			toggleButtons [i].group = toggleGroup;

			toggleButtons [i].onValueChanged.AddListener (delegate {OnToggleSelect ();} );
		}
	}


	private void OnToggleSelect()
	{
		
		if (toggleButtons[selectedToggle].isOn)
		{
			return;
		}

		for (int i = 0; i < toggleButtons.Count; ++i)
		{
			if (toggleButtons [i].isOn == true)
			{
				selectedToggle = i;
				break;
			}
		}

		if (onToggleChange != null)
		{
			onToggleChange.Invoke ();
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
