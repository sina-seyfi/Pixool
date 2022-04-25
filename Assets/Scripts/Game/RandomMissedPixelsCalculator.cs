using System;
using System.Collections.Generic;
using Game;

public class RandomMissedPixelsCalculator : MissedPixelsCalculator
{

	public static float EMPTY_LUMINANCE_DIFFERENCE = 0.06f;

	public Tuple<int, int>[] calculate(Color[,] pixelColors)
    {
		var rows = pixelColors.GetLength(0);
		var cols = pixelColors.GetLength(1);
		var maxEdgeSize = Math.Max(rows, cols);
		var emptyListIndexes = new List<Tuple<int, int>>();
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				if (Utils.onChance(EMPTY_LUMINANCE_DIFFERENCE * maxEdgeSize * 4))
				{
					var emptyIndex = Tuple.Create(row, col);
					var emptyColor = pixelColors[row, col];
					var isThisColorFound = false;
					foreach (var itemIndex in emptyListIndexes)
					{
						var itemColor = pixelColors[itemIndex.Item1, itemIndex.Item2];
						var luminance1 = (float)Utils.calculateLuminance(itemColor);
						var luminance2 = (float)Utils.calculateLuminance(emptyColor);
						if (Math.Abs(luminance1 - luminance2) <= EMPTY_LUMINANCE_DIFFERENCE)
						{
							isThisColorFound = true;
							break;
						}
					}
					if (!isThisColorFound)
					{
						emptyListIndexes.Add(emptyIndex);
					}
				}
			}
		}
		return emptyListIndexes.ToArray();
	}
}
