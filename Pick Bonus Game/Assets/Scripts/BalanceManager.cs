/* This code manages the player's balance
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class BalanceManager : MonoBehaviour {
        public FloatVariable currentBalance;                                //The player's current balance
        public FloatVariable currentDenomination;                           //The player's current bet
        public BoolVariable roundActive;                                    //Bool variable that determines if there is an active round
        private Text text;                                                  //Text element that displays the current balance

        // Start is called before the first frame update
        void Start() {
            text = GetComponent<Text>();
        }

        // This method updates the balance at the start of the game
        public void UpdateBalance() {
            if (currentBalance.Value >= currentDenomination.Value) {
                currentBalance.Value -= currentDenomination.Value;
                roundActive.Value = true;
                text.text = "$" + currentBalance.Value.ToString("0.00");
            }
        }
    }
}