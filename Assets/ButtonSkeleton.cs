using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkeleton : MonoBehaviour {

    public Color MouseDownColour = Color.green;
    public Color MouseUpColour = Color.white;
    public bool ButtonPressed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            this.ButtonPressed = true;
        }
        else
        {
            this.ButtonPressed = false;
        }

    }

    public void SayHi()
    {
        Button btn = gameObject.GetComponent<Button>();
        ColorBlock c = btn.colors;
        c.pressedColor = MouseDownColour;
        btn.colors = c;
    }

    public void ReleaseButton()
    {
        

    }


}
