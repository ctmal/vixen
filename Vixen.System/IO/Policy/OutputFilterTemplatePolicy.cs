﻿namespace Vixen.IO.Policy {
	abstract class OutputFilterTemplatePolicy : IFilePolicy {
		public void Write() {
			WriteModuleDataSet();
			WriteOutputFilterCollections();
		}

		abstract protected void WriteModuleDataSet();
		abstract protected void WriteOutputFilterCollections();

		public void Read() {
			ReadModuleDataSet();
			ReadOutputFilterCollections();
		}

		abstract protected void ReadModuleDataSet();
		abstract protected void ReadOutputFilterCollections();

		public int Version {
			get { return 1; }
		}
	}
}
