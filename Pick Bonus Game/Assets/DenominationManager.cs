/* This code manages the denomination of the game
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class DenominationManager : MonoBehaviour {
        public FloatVariable currentDenomination;                           //Value of the current denomination
        private Text text;                                                  //Text element of the denomination
        private float[] validDenominations = { .25f, .5f, 1f, 5f };         //Array of the valid denominations
        private int index = 0;                                              //Index of current denomination

        private void Start() {
            text = GetComponent<Text>();
        }

        // This method increases the denomination
        public void DenominationUp() {
            index++;
            if (index < validDenominations.Length)
                currentDenomination.Value = validDenominations[index];
            else
                index--;

            text.text = "$" + currentDenomination.Value.ToString("0.00");
        }

        // This method decreases the denomination
        public void DenominationDown() {
            index--;
            if (index >= 0)
                currentDenomination.Value = validDenominations[index];
            else
                index++;

            text.text = "$" + currentDenomination.Value.ToString("0.00");
        }
    }
}