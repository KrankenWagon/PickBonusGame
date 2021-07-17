/*This code controlls the play bet button
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Modular.Events {

    public class StartButton : MonoBehaviour {
        public GameEvent startRound;                                        //Game event that triggers when the player starts the round

        // This method raises the Start Round game event on mouse click
        private void OnMouseUpAsButton() {
            startRound.Raise();
        }
    }
}
