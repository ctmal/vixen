﻿namespace Vixen.Interpolator {
	class StaticValueInterpolator<T> : Interpolator<T> {
		protected override T InterpolateValue(double percent, T startValue, T endValue) {
			return startValue;
		}
	}
}
