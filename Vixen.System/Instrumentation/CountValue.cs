﻿namespace Vixen.Instrumentation {
	abstract public class CountValue : InstrumentationValue {
		private double _value;

		protected CountValue(string name)
			: base(name) {
		}

		// Simple count.
		override protected double _GetValue() {
			return _value;
		}
		
		public void Add(double value) {
			_value += value;
		}
	}
}
