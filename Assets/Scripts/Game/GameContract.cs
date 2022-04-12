using UnityEngine;
using UniRx;
interface GameContract {

	// This is the layer presenter will call
	interface GameView {
		void updateLevelName(string name);
		void updateReferenceTexture(Texture2D texture);
		void updatePixels(PixelData[,] pixels);
		void updateShelf(PixelData[,] pixels);
	}
	// This is the layer view will call on every action from view
	interface GamePresenter {
		void onPixelSelected(PixelData pixel);
	}
	// This is data provider layer
	interface GameModel {
		ReactiveProperty<PixelData[,]> getPixels();
		ReactiveProperty<PixelData[,]> getShelfPixels();
		PixelData[,] getRawPixels();
		void pixelShelfSelected(PixelShelf shelf);
		PixelShelf getSelectedPixelShelf();
		bool pixelInserted(PixelShelf shelf, PixelData pixel);
		bool resetState();
	}

}