using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void goToResponseScene()
    {
        Debug.Log("Get voice answer");
        SceneManager.LoadScene("endQuizScene");
    }
}
