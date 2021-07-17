/* This code controlls the reward boxes, flipping them when clicked on
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Modular.Events {

    public class RewardBox : MonoBehaviour {
        public GameEvent roundOver;                                         //Game event that triggers the end of the current round
        public BoolVariable roundActive;                                    //Is there a current active round
        public ListVariableFloat payouts;                                   //Universal list of the payouts
        private bool isFlipped = false;                                     //Is the reward box currently flipped over
        private ParticleSystem particles;                                   //Particle system which triggers upon flipping
        private Text text;                                                  //Text element of the reward box

        // Start is called before the first frame update
        void Start() {
            text = GetComponentInChildren<Text>();
            particles = GetComponentInChildren<ParticleSystem>();
        }

        //This method flips the card and reveals the reward
        private void OnMouseUpAsButton() {
            if (!isFlipped && roundActive.Value) {
                isFlipped = true;

                text.text = payouts.GetValue(0).ToString();
                if (payouts.GetValue(0) == 0)
                    roundOver.Raise();

                payouts.RemoveAt(0);
                particles.Play();
            }
        }
    }
}
