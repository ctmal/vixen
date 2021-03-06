﻿namespace Vixen.Interpolator {
	[Vixen.Sys.Attribute.Interpolator(typeof(float))]
	class FloatInterpolator : Interpolator<float> {
		protected override float InterpolateValue(double percent, float startValue, float endValue) {
			return (float)(startValue + (endValue - startValue) * percent);
		}
	}
}
