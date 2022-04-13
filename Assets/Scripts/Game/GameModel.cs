using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameModel : IGameContract.IGameModel
{
	ReactiveProperty<PixelData[,]> IGameContract.IGameModel.getPixels() {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameModel.initState() {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameModel.removeMissedPixel(PixelEmpty pixel) {
		throw new System.NotImplementedException();
	}

	void IGameContract.IGameModel.resetState() {
		throw new System.NotImplementedException();
	}

}
