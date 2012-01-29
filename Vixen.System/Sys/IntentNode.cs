﻿using System;
using System.Collections.Generic;
using Vixen.Module.Intent;

namespace Vixen.Sys {
	public class IntentNode : IDataNode, IComparable<IntentNode> {
		public IntentNode(IIntentModuleInstance intent, TimeSpan startTime) {
			Intent = intent;
			StartTime = startTime;
		}

		public IIntentModuleInstance Intent { get; private set; }

		public TimeSpan StartTime { get; set; }

		public TimeSpan TimeSpan {
			get { return (Intent != null) ? Intent.TimeSpan : TimeSpan.Zero; }
		}

		public TimeSpan EndTime { 
			get { return (Intent != null) ? StartTime + TimeSpan : StartTime; }
		}
		
		#region IComparer<IntentNode>
		public class Comparer : IComparer<IntentNode> {
			public int Compare(IntentNode x, IntentNode y) {
				return x.StartTime.CompareTo(y.StartTime);
			}
		}
		#endregion

		#region IComparable<IntentNode>
		public int CompareTo(IntentNode other) {
			return StartTime.CompareTo(other.StartTime);
		}
		#endregion
	}
}
