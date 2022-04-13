using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : IGameContract.IGamePresenter {

	private IGameContract.IGameView view;
	private IGameContract.IGameModel model;

	public GamePresenter(IGameContract.IGameView view) {
		this.view = view;
		this.model = GameModelBuilder.build();
	}

	void IGameContract.IGamePresenter.onPixelSelected(PixelData pixel) {
		throw new System.NotImplementedException();
	}
}
