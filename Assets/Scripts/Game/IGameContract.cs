using UnityEngine;
using UniRx;
public interface IGameContract {

	// This is the layer presenter will call
	public interface IGameView {
		void updateLevelName(string name);
		void updateReferenceTexture(Texture2D texture);
		void updatePixels(PixelData[,] pixels);
		void updateShelf(PixelData[,] pixels);
	}
	// This is the layer view will call on every action from view
	public interface IGamePresenter {
		void onPixelSelected(PixelData pixel);
	}
	// This is data provider layer
	public interface IGameModel {
		void initState();
		ReactiveProperty<PixelData[,]> getPixels();
		void removeMissedPixel(PixelEmpty pixel);
		void resetState();
	}

}