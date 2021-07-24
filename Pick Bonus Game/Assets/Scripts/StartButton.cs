/*This code controlls the play bet button
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class StartButton : MonoBehaviour {
        public GameEvent startRound;                                        //Game event that triggers when the player starts the round
        public BoolVariable roundActive;                                    //Bool which holds if there is currently a round in play
        private Text text;                                                  //Text element of the button

        // Start is called before the first frame update
        void Start() {
            roundActive.Value = false;
            text = GetComponentInChildren<Text>();
        }

        // This method raises the Start Round game event on mouse click
        private void OnMouseUpAsButton() {
            if (!roundActive.Value) {
                startRound.Raise();
                if (roundActive.Value)
                    text.text = "Round in progress";
            }
        }

        //This method resets the text of the button
        public void ResetText() {
            text.text = "Start Round";
        }
    }
}
