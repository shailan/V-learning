using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAgain(string MiniGame)
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void Exit(string exit)
    {
        Application.Quit();
    }

}
//audio.clip = Resources.Load<AudioClip>("audio/firstmenu");
//audio.Play();