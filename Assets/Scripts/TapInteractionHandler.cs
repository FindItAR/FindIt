//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using HUX.Interaction;
using HUX.Receivers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FindIt
{
    public class TapInteractionHandler : InteractionReceiver
    {
        public Menu menu;
        public Game game;
        private AppBar appBar;

        void start() {
            GameObject obj = GameObject.Find("Menu");
            if (obj != null)
            {
                menu = obj.GetComponent<Menu>();
            }

            GameObject obj_ = GameObject.Find("Game");
            if (obj_ != null)
            {
                game = obj_.GetComponent<Game>();
            }
        }

        protected override void OnTapped(GameObject obj, InteractionManager.InteractionEventArgs eventArgs)
        {
            Debug.Log("Tapped on " + obj.name);
            switch (obj.name)
            {
                case "PlayButton":
                    menu.StartGame();
                    break;

                case "QuizButton":
                    SceneManager.LoadScene("quizScene1");
                    break;

                case "ReturnToMenu":
                    Debug.Log("return to menu tapped");
                    SceneManager.LoadScene("menuScene");
                    break;

                case "ExitButton":
                    Application.Quit();
                    break;

                case "Cube":
                    if (game.CurrentState == Game.State.SearchingCube) {
                        game.ChangeStateTo(Game.State.EndRound);
                    }
                    break;

                default:
                    break;
            }
            base.OnTapped(obj, eventArgs);
        }
    }
}
