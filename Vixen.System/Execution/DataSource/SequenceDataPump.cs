﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Vixen.Sys;

namespace Vixen.Execution.DataSource {
	class SequenceDataPump : IDataSource {
		private EffectNodeQueue _effectNodeQueue;
		private Thread _dataPumpThread;

		public SequenceDataPump() {
			_effectNodeQueue = new EffectNodeQueue();
		}

		public ISequence Sequence { get; set; }

		public void Start() {
			if(Sequence == null) throw new InvalidOperationException("Sequence has not been set in the data pump.");

			if(!IsRunning) {
				_StartThread();
			}
		}

		public void Stop() {
			if(IsRunning) {
				_StopThread();
			}
		}

		public bool IsRunning { get; private set; }

		public IEnumerable<IEffectNode> GetDataAt(TimeSpan time) {
			if(IsRunning) {
				return _effectNodeQueue.Get(time).ToArray();
			}
			return Enumerable.Empty<IEffectNode>();
		}

		private void _StartThread() {
			_dataPumpThread = new Thread(_DataPumpThread) { IsBackground = true, Name = Sequence.Name + " data pump" };
			_dataPumpThread.Start();
		}

		private void _StopThread() {
			IsRunning = false;
			_dataPumpThread.Join(1000);
			_dataPumpThread = null;
		}

		private void _DataPumpThread() {
			IsRunning = true;

			IEnumerator<IDataNode> dataEnumerator = Sequence.SequenceData.EffectData.GetEnumerator();
			try {
				while(IsRunning) {
					while(IsRunning && dataEnumerator.MoveNext()) {
						_effectNodeQueue.Add((IEffectNode)dataEnumerator.Current);
					}

					// Wait a bit before checking for more data.
					//*** Look up a better way than an arbitrary sleep.
					Thread.Sleep(5);
				}
			} finally {
				dataEnumerator.Dispose();
			}
		}
	}
}
