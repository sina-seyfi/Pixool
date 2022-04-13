using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour, IGameContract.IGameView
{

	private IGameContract.IGamePresenter presenter;

    // Start is called before the first frame update
    void Start()
    {
		presenter = new GamePresenter(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void IGameContract.IGameView.updateLevelName(string name) {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameView.updatePixels(PixelData[,] pixels) {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameView.updateReferenceTexture(Texture2D texture) {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameView.updateShelf(PixelData[,] pixels) {
		throw new System.NotImplementedException();
	}
}
