/* This code triggers a specific game event when the object is clicked
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Modular.Events {

    public class EventButton : MonoBehaviour {
        public GameEvent trigger;                                           //Game event to be triggered by this button

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        private void OnMouseUpAsButton() {
            trigger.Raise();
        }
    }
}