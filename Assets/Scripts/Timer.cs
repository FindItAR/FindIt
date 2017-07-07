using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace FindIt
{
    public class Timer : MonoBehaviour {

        private Text txt;
        private bool isPlaying;

        public float time = 0.0f;

        // Use this for initialization
        void Start() {
            Debug.Log("Start of Timer.cs");
            txt = this.GetComponentInChildren<Text>();
            isPlaying = false;
        }

        public void FixedUpdate()
        {
            if (isPlaying)
            {
                time += Time.deltaTime;
                txt.text = string.Format("{0:F2}\"", time);
            }
        }
        public void startTimer()
        {
            Debug.Log("startTimer");
            isPlaying = true;
        }
    }
}
