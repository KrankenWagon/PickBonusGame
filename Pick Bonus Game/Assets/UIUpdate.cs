/* This code updates the UI elements throughout the game
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class UIUpdate : MonoBehaviour {
        public FloatVariable value;                                         //The value used to update the text
        private Text text;                                                  //The text element of this object to be updated

        // Start is called before the first frame update
        void Start() {
            text = GetComponent<Text>();
        }

        // This method updates the UI
        public void UpdateUIElement() {
            text.text = "$" + value.Value.ToString("0.00");
        }
    }
}