/* This code calculates and divides the payouts
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Modular.Events {

    public class PayoutDivider : MonoBehaviour {
        public GameEvent startRound;
        public ListVariableFloat payouts;                               //Universal List with the outputted payout array
        public float denomination;                                      //Total amount the player is betting
        private float[] payoutArray = new float[9];                     //Array containing all the payout values
        private int multiplier;                                         //The amount the bet is being multiplied by

        private void Start() {
            startRound.Raise();
        }

        // This method generates a new random payout array
        public void GeneratePayoutArray() {
            float temp = Random.value;                                  //Temp float used to randomize the multiplier

            //Reset all the payouts
            for (int i = 0; i < payoutArray.Length; i++) {
                payoutArray[i] = 0f;
            }
            for (int i = 0; i < payouts.Count(); i++) {
                payouts.Resize(0);
            }

            //Randomly generate the multiplier
            if (temp <= .5f) {
                multiplier = 0;
            } else if (temp <= .8f) {
                multiplier = Random.Range(1, 11);
                FillArray();
            } else if (temp <= .95f) {
                int[] validMultipliers = { 12, 16, 24, 32, 48, 64 };
                multiplier = validMultipliers[Random.Range(0, validMultipliers.Length)];
                FillArray();
            } else {
                multiplier = Random.Range(1, 6) * 100;
                FillArray();
            }

            RandomizeArray();

            for (int i = 0; i < payoutArray.Length; i++) {
                payouts.Add(payoutArray[i]);
            }
        }

        // This method fills the payout array
        void FillArray() {
            float payoutValue;                                          //Amount placed in current payout
            float totalLeft;                                            //The total amount left to divide

            totalLeft = denomination * multiplier;

            //Fill the entire array except the last two values
            for (int i = 0; i < payoutArray.Length - 2; i++) {
                payoutValue = totalLeft / .05f;
                payoutValue = Mathf.RoundToInt(Random.Range(0, payoutValue)) * .05f;
                payoutArray[i] = payoutValue;
                totalLeft -= payoutValue;
                Debug.Log(totalLeft);
            }

            //Add whatevers left to the second to last array index, leaving one space for the guarenteed pooper
            payoutValue = Mathf.RoundToInt(totalLeft / .05f) * .05f;
            payoutArray[payoutArray.Length - 2] = payoutValue;
        }

        // This method randomizes the payout array
        void RandomizeArray() {
            float temp;                                                 //Temporary variable to hold the value of the current index being swapped
            int rand;                                                   //Array index to swap current index with

            for (int i = 0; i < payoutArray.Length; i++) {
                temp = payoutArray[i];
                rand = Random.Range(0, payoutArray.Length);
                payoutArray[i] = payoutArray[rand];
                payoutArray[rand] = temp;
            }
        }
    }
}