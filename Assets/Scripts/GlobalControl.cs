using UnityEngine;

namespace FindIt {
    public class GlobalControl : MonoBehaviour
    {
        public static GlobalControl Instance;
        public float[] times = new float[10];

        public int currentRound = 1;

        public int currentPlayer = 0;
        void Awake ()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy (gameObject);
            }
        }

        public void SaveTime(float time) {
            times[currentPlayer] = time;
        }

        public void ToggleCurrentPlayer() {
            if (currentPlayer == 0) {
                currentPlayer = 1;
            } else {
                currentPlayer = 0;
            }
        }
    }
}
