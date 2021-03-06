﻿using Vixen.Instrumentation;

namespace Vixen.Sys.Instrumentation {
	class ElementUpdateTimeValue : DoubleValue {
		public ElementUpdateTimeValue()
			: base("Update time for all elements") {
		}

		protected override string _GetFormattedValue() {
			return ((int)_GetValue()) + " ms";
		}
	}
}
