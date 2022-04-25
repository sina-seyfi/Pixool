using System;
using Game;
using System.Collections.Generic;
using UnityEngine;

public class VarianceMissedPixelsCalculator : MissedPixelsCalculator
{

	public static double EMPTY_DIFFERENCE = 0.03;
	private const double LUMINANCE_SHARE = 1.0;
	private const double HUE_SHARE = 1.41;
	private const double SHARE_TOTAL = LUMINANCE_SHARE + HUE_SHARE;
	private const int BOUNDARY_OFFSET = 3;
	private record VarianceModel {
		private double MIN_VARIANCE_THRESHOLD = 0.01;
		private double MAX_VARIANCE_THRESHOLD = 0.1;
		public const double MIN_DIFFERENCE_THRESHOLD = 0.01;
		public const double MAX_DIFFERENCE_THRESHOLD = 0.2;
		public int row { get; private set; }
		public int col { get; private set; }
		public double diff { get; private set; }
		public double variance { get; private set; }
		public void setVarianceRange(double wholeVariance) {
			MIN_VARIANCE_THRESHOLD = wholeVariance / 3;
			MAX_VARIANCE_THRESHOLD = wholeVariance * 3;
        }
		public VarianceModel(int row, int col, double diff, double variance) {
			this.row = row;
			this.col = col;
			this.diff = diff;
			this.variance = variance;
        }
		public bool isCandidate() {
			return variance >= MIN_VARIANCE_THRESHOLD && variance <= MAX_VARIANCE_THRESHOLD &&
				diff >= MIN_DIFFERENCE_THRESHOLD && diff <= MAX_DIFFERENCE_THRESHOLD;
        }
		public double candidateValue() {
			return variance - diff;
        }
    }

    private class VarianceModelComparer : Comparer<VarianceModel> {
        public override int Compare(VarianceModel x, VarianceModel y) {
			return (int)((y.candidateValue() - x.candidateValue()) * 100.0);
        }
    }

 //   private bool isOnCorner(int row, int col, int rows, int cols) {
	//	return (row == 0 && col == 0) || (row == rows - 1 && col == 0)
	//		|| (row == 0 && col == cols - 1) || (row == rows - 1 && col == cols - 1);
 //   }

	//private bool isOnEdge(int row, int col, int rows, int cols) {
	//	return row == 0 || col == 0 || row == rows - 1 || col == cols - 1;
	//}

	private int calculateLowBoundaryIndex(int index, int max) {
		return Math.Clamp(index - BOUNDARY_OFFSET, 0, max - 1);
	}

	private int calculateHighBoundaryIndex(int index, int max) {
		return Math.Clamp(index + BOUNDARY_OFFSET, 0, max - 1);
	}

	private double calculatePixelValue(double luminance, double hue) {
		return (luminance * LUMINANCE_SHARE + hue * HUE_SHARE) / SHARE_TOTAL;
	}

	private T[] gatherAroundArray<T>(T[,] arr, int row, int col, bool includeSelectedIndex) {
		int rows = arr.GetLength(0);
		int cols = arr.GetLength(1);
		var aroundList = new List<T>();
		int rowLowBoundary = calculateLowBoundaryIndex(row, rows);
		int rowHighBoundary = calculateHighBoundaryIndex(row, rows);
		int colLowBoundary = calculateLowBoundaryIndex(col, cols);
		int colHighBoundary = calculateHighBoundaryIndex(col, cols);
		for (int r = rowLowBoundary; r <= rowHighBoundary; r++)
			for (int c = colLowBoundary; c <= colHighBoundary; c++)
				if (!includeSelectedIndex && r == row && c == col) continue;
				else aroundList.Add(arr[r, c]);
		return aroundList.ToArray();
	}

    public Tuple<int, int>[] calculate(Game.Color[,] pixelColors) {
		var rows = pixelColors.GetLength(0);
		var cols = pixelColors.GetLength(1);
		var luminanceArr = new double[rows, cols];
		var hueArr = new double[rows, cols];
		var mixedArr = new double[rows, cols];
		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				luminanceArr[row, col] = Utils.calculateLuminance(pixelColors[row, col]);
				hueArr[row, col] = Utils.calculateHue(pixelColors[row, col]) / 360.0;
				mixedArr[row, col] = calculatePixelValue(luminanceArr[row, col], hueArr[row, col]);
			}
		}
		var totalVariance = Utils.calculateMidAndVariance(mixedArr).Item2;
		var candidates = new List<VarianceModel>();
		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++)
			{
				var luminanceMidAroundArray = gatherAroundArray(luminanceArr, row, col, false);
				var luminanceVarianceAroundArray = gatherAroundArray(luminanceArr, row, col, true);

				var luminanceMid = Utils.average(luminanceMidAroundArray);
				var luminanceVariance = Utils.calculateMidAndVariance(luminanceVarianceAroundArray).Item2;


				var hueMidAroundArray = gatherAroundArray(hueArr, row, col, false);
				var hueVarianceAroundArray = gatherAroundArray(hueArr, row, col, true);

				var hueMid = Utils.average(hueMidAroundArray);
				var hueVariance = Utils.calculateMidAndVariance(hueVarianceAroundArray).Item2;

				var varianceAround = calculatePixelValue(luminanceVariance, hueVariance);
				var midAround = calculatePixelValue(luminanceMid, hueMid);

				var currentPixel = calculatePixelValue(luminanceArr[row, col], hueArr[row, col]);
				var diff = Math.Abs(1 - currentPixel / midAround);
				
                var model = new VarianceModel(
					row,
					col,
					diff,
					varianceAround
				);
				model.setVarianceRange(totalVariance);
				if (model.isCandidate()) { candidates.Add(model); }
			}
		}
		candidates.Sort(
			(a, b) => {
				if (a.variance == b.variance) return 0;
				else if (a.variance < b.variance) return +1;
				else return -1;
            }
		);
		var distinctCandidates = new List<VarianceModel>();
        foreach (var candidate in candidates) {
			var index = 0;
			var shouldReplace = false;
			var shouldSkip = false;
			for (index = 0; index < distinctCandidates.Count; index++) {
				var dc = distinctCandidates[index];
				double candidateValue = calculatePixelValue(luminanceArr[candidate.row, candidate.col], hueArr[candidate.row, candidate.col]);
				double dcValue = calculatePixelValue(luminanceArr[dc.row, dc.col], hueArr[dc.row, dc.col]);
				double diffValue = Math.Abs(candidateValue - dcValue);
				//bool isNearby = Math.Abs(candidate.row - dc.row) <= 1 && Math.Abs(candidate.col - dc.col) <= 1;
				if (diffValue < EMPTY_DIFFERENCE) {
					if (candidate.candidateValue() > dc.candidateValue()) {
						shouldReplace = true;
                    } else {
						shouldSkip = true;
                    }
					break;
				}
			}
			if (shouldSkip) continue;
			if (shouldReplace) { distinctCandidates[index] = candidate; }
			else { distinctCandidates.Add(candidate); }
		}
		if(distinctCandidates.Count < 14) {
			return distinctCandidates.ConvertAll(model => Tuple.Create(model.row, model.col)).ToArray();
		} else {
			return distinctCandidates.GetRange(0, 14).ConvertAll(model => Tuple.Create(model.row, model.col)).ToArray();
		}
	}

}
