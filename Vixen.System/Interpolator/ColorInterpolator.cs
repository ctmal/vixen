﻿using System.Drawing;

namespace Vixen.Interpolator {
	[Vixen.Sys.Attribute.Interpolator(typeof(Color))]
	class ColorInterpolator : Interpolator<Color> {
		protected override Color InterpolateValue(double percent, Color startValue, Color endValue) {
			int r = (int)(startValue.R + (endValue.R - startValue.R) * percent);
			int g = (int)(startValue.G + (endValue.G - startValue.G) * percent);
			int b = (int)(startValue.B + (endValue.B - startValue.B) * percent);
			return Color.FromArgb(r, g, b);
		}
	}
}
