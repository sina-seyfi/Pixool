public class PixelsClickManager
{

	private PixelShelf selectedPixelShelf;

	public event PixelShelfSelected selected;
	public event PixelShelfDeselected deselected;
	public event PixelShelfIsPlaced placed;

	public void Clicked(PixelData pixelData) {
		switch(pixelData) {
			case PixelShelf ps: {
					if(selectedPixelShelf == null) {
						selectedPixelShelf = ps;
						selected.Invoke(ps);
					} else {
						if(selectedPixelShelf.X == ps.X && selectedPixelShelf.Y == ps.Y && selectedPixelShelf.Color.Equals(ps.Color)) {
							selectedPixelShelf = null;
							deselected.Invoke(ps);
						} else {
							selectedPixelShelf = ps;
							selected.Invoke(ps);
						}
					}
					break;
				}
			case PixelWaiting pc: {
					if(selectedPixelShelf != null) {
						placed.Invoke(selectedPixelShelf, pc);
					}
					break;
				}
		}
	}

	public void resetState() {
		selectedPixelShelf = null;
	}

}

public delegate void PixelShelfSelected(PixelShelf shelf);
public delegate void PixelShelfDeselected(PixelShelf shelf);
public delegate void PixelShelfIsPlaced(PixelShelf shelf, PixelWaiting color);