using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBox : MonoBehaviour
{
    public bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        if (!isFlipped)
        {
            //Flip card and reveal reward
            isFlipped = true;
        }
    }
}
