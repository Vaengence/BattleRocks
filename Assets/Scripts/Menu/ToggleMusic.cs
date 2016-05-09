using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour 
{
    [SerializeField]
    Sprite[] sprites;

    public void ToggleMusicOnOrOff()
    {
        if(_GameManager.instance.musicOn == true)
        {
            _GameManager.instance.musicOn = false;
            GetComponent<Image>().sprite = sprites[1];
        }
        else
        {
            _GameManager.instance.musicOn = true;
            GetComponent<Image>().sprite = sprites[0];
        }
    }
}