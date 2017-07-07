using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FindIt
{
    public class GameOver : MonoBehaviour
    {

        TextMesh playersTxt;

        // Use this for initialization
        void Start()
        {
            float[] times = GlobalControl.Instance.times;
            playersTxt = this.GetComponent<TextMesh>();

            playersTxt.text = "Player 1: " + string.Format("{0:F2}\"", times[0]) + "\n" + "Player 2: " + string.Format("{0:F2}\"", times[1]);

            if (times[0] < times[1])
            {
                playersTxt.text += "\nPlayer 1 wins!";
            } else
            {
                playersTxt.text += "\nPlayer 2 wins!";
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
