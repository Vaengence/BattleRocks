using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour 
{
    [SerializeField]
    Sprite[] sprites;

    public void ToggleSoundOnOrOff()
    {
        if(_GameManager.instance.soundOn == true)
        {
            _GameManager.instance.soundOn = false;
            GetComponent<Image>().sprite = sprites[1];
        }
        else
        {
            _GameManager.instance.soundOn = true;
            GetComponent<Image>().sprite = sprites[0];
        }
    }
}
