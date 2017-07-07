using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FindIt
{
    public class Game : MonoBehaviour {

        public Timer timer;
        public Image image;
        public TextMesh txt;
        public GameObject cube;
        public KeywordManager keywordManager;

        public enum State {
            GameMenu,
            HidingCube,
            SearchingCube,
            EndRound,
        }

        public State CurrentState { get; private set; }

        // Use this for initialization
        void Start() {
            GameObject timerHUD = GameObject.Find("TimerHUD");
            if (timerHUD != null)
            {
                timer = timerHUD.GetComponent<Timer>();
            }
            ChangeStateTo(Game.State.HidingCube);
        }

        public void ChangeStateTo(State state) {
            CurrentState = state;
            switch(state) {
                case State.GameMenu:
                    Debug.Log("GameMenu");
                    SceneManager.LoadScene("menuScene");
                    break;

                case State.HidingCube:
                    Debug.Log("HindingCube");
                    image.enabled = false;
                    cube.GetComponent<AudioSource>().Stop();
                    txt.text = "Player " + (GlobalControl.Instance.currentPlayer == 0 ? "1" : "2") + "\nHide the cube";
                    break;

                case State.SearchingCube:
                    Debug.Log("SearchingCube");
                    image.enabled = true;
                    keywordManager.StartKeywordRecognizer();
                    cube.GetComponent<AudioSource>().Play();
                    GlobalControl.Instance.ToggleCurrentPlayer();
                    txt.text = "Player " + (GlobalControl.Instance.currentPlayer == 0 ? "1" : "2") + "\nSay \"Go\" and find the cube";
                    break;

                case State.EndRound:
                    Debug.Log("EndRound");
                    keywordManager.StopKeywordRecognizer();
                    GlobalControl.Instance.SaveTime(timer.time);
                    Debug.Log(GlobalControl.Instance.currentRound);
                    if (GlobalControl.Instance.currentRound == 2) {
                        SceneManager.LoadScene("resultScene");
                    } else {
                        ChangeStateTo(State.HidingCube);
                        SceneManager.LoadScene("mainScene");
                    }
                    GlobalControl.Instance.currentRound++;
                    break;

                default:
                    break;
            }
        }
    }
}
