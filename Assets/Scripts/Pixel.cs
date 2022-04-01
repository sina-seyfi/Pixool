using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
	private PixelData data;
	private SpriteRenderer sr;
	private SpriteRenderer getSpriteRenderer() {
		if(sr == null) {
			sr = GetComponent<SpriteRenderer>();
		}
		return sr;
	}
	private void Start() {
		sr = GetComponent<SpriteRenderer>();
	}
	public PixelData Data {
		get { return data; }
		set {
			if(value != null) {
				data = value;
				updateInternalState();
			}
		}
	}

	private void updateInternalState() {
		switch(data) {
			case PixelColor pc: {
				getSpriteRenderer().color = pc.Color;
				break;
			}
		}
	}
}
