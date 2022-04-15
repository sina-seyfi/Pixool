using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour, IGameContract.IGameView
{

	private IGameContract.IGamePresenter presenter;
	[SerializeField]
	private PixelsSpawner mainPixelsSpawner;
	[SerializeField]
	private PixelsSpawner shelfPixelsSpawner;

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
		// TODO Implement this later
	}

	void IGameContract.IGameView.updatePixels(PixelData[,] pixels) {
		mainPixelsSpawner.Spawn(pixels);
	}

	void IGameContract.IGameView.updateReferenceTexture(Texture2D texture) {
		// TODO Implement this later
	}

	void IGameContract.IGameView.updateShelf(PixelShelf[,] pixels) {
		shelfPixelsSpawner.Spawn(pixels);
	}
}
