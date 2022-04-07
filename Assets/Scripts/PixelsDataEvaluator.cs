public class PixelsDataEvaluator
{
	private PixelsDataWrapper wrapper;
	public PixelsDataEvaluator(PixelsDataWrapper wrapper) {
		this.wrapper = wrapper;
	}

	public bool Evaluate(int x, int y, PixelColor Color) {
		if(wrapper.PixelsData[x, y] is PixelEmpty) {
			return ((PixelEmpty) wrapper.PixelsData[x, y]).PixelColor.Color.Equals(Color.Color);
		} else {
			return false;
		}
	}

}
