/* This code triggers a specific game event when the object is clicked
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Modular.Events {

    public class EventButton : MonoBehaviour {
        public GameEvent trigger;                                           //Game event to be triggered by this button

        private void OnMouseUpAsButton() {
            trigger.Raise();
        }
    }
}