using UniRx;

public class GamePresenter : IGameContract.IGamePresenter {

	private IGameContract.IGameView view;
	private IGameContract.IGameModel model;

	public GamePresenter(IGameContract.IGameView view) {
		this.view = view;
		this.model = GameModelBuilder.build();
		this.model.initState();
		init();
	}

	private void init() {
		model.getPixels().Subscribe(xs => view.updatePixels(xs));
	}

    void IGameContract.IGamePresenter.onPixelSelected(PixelData pixel) {
		// TODO Implement this later...
	}
}
