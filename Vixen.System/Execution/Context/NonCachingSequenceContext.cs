﻿using Vixen.Execution.DataSource;
using Vixen.Sys.Attribute;

namespace Vixen.Execution.Context {
	[Context(ContextTargetType.Sequence, ContextCaching.NoCaching)]
	class NonCachingSequenceContext : SequenceContext {
		private SequenceDataPump _dataSource;

		public NonCachingSequenceContext() {
			_dataSource = new SequenceDataPump();
		}

		protected override IDataSource _DataSource {
			get { return _dataSource; }
		}

		protected override void OnSequenceStarted(Sys.SequenceStartedEventArgs e) {
			_dataSource.Sequence = Sequence;
			_dataSource.Start();
		}

		protected override void OnSequenceEnded(Sys.SequenceEventArgs e) {
			_dataSource.Stop();
		}
	}
}
