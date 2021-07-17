// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Modular.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;
        [Tooltip("Delay before invoking response. Dafult is 0")]
        public float delayInvoke = 0f;
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        // if the game event also sets a global delay, add it to the individual delay on this listener
        public void OnDelayedEventRaised(float delayFromEvent)
        {
            StartCoroutine(EventResponse(delayFromEvent + delayInvoke));
        }

        public void OnEventRaised()
        {
            //         Debug.Log("\n" + Response.GetPersistentTarget(0) + "." + Response.GetPersistentMethodName(0) + "() called by Event-> " + Event.name + "()");
            if(delayInvoke != 0)
                StartCoroutine(EventResponse(delayInvoke));
            else
                Response.Invoke();
        }

        IEnumerator EventResponse(float delay)
        {
            yield return new WaitForSeconds(delay);
            Response.Invoke();
        }
    }
}