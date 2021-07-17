/* This code controlls the reward boxes, flipping them when clicked on
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class RewardBox : MonoBehaviour {
        public ListVariableFloat payouts;                                       //Universal list of the payouts
        public bool isFlipped;                                                  //Is the reward box currently flipped over
        private Text text;                                                      //Text element of the reward box

        // Start is called before the first frame update
        void Start() {
            text = GetComponentInChildren<Text>();
        }

        private void OnMouseUp() {
            if (!isFlipped) {
                //Flip card and reveal reward
                isFlipped = true;
                text.text = payouts.GetValue(0).ToString();
                payouts.RemoveAt(0);
            }
        }
    }
}
