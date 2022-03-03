using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClicked()
	{
        GameObject[] bluePixels = GameObject.FindGameObjectsWithTag("Blue Pixel"); // TODO Hardcoded tag is not optimal.
		foreach(GameObject bluePixel in bluePixels) {
            Rigidbody2D rb2d = bluePixel.GetComponent<Rigidbody2D>();
            if(rb2d != null) {
                rb2d.simulated = true;
			}
		}
	}

}
