using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestButtonScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}