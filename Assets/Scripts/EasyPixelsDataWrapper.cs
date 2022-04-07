using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyPixelsDataWrapper : PixelsDataWrapper
{
	public EasyPixelsDataWrapper(PixelsDataProvider provider) : base(provider) { }

	protected override PixelData[,] CalculateMissedPixels(PixelsDataProvider provider) {
		var data = provider.providePixels();
		var rowSize = data.GetLength(0);
		var colSize = data.GetLength(1);
		var _2dArray = new PixelData[data.GetLength(0), data.GetLength(1)];
		for(int row = 0; row < rowSize; row++) {
			for(int col = 0; col < colSize; col++) {
				if(Utils.onChance(0.5f)) {
					_2dArray[row, col] = new PixelEmpty(data[row, col]);
				} else {
					_2dArray[row, col] = data[row, col];
				}
			}
		}
		return _2dArray;
	}

}
