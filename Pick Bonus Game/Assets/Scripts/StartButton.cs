/*This code controlls the play bet button
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Modular.Events {

    public class StartButton : MonoBehaviour {
        public GameEvent startRound;                                        //Game event that triggers when the player starts the round
        public BoolVariable roundActive;                                    //Bool which holds if there is currently a round in play

        private void Start() {
            roundActive.Value = false;
        }
        // This method raises the Start Round game event on mouse click
        private void OnMouseUpAsButton() {
            if (!roundActive.Value) {
                startRound.Raise();
            }
        }
    }
}
