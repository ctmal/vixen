﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Instrumentation;

namespace Vixen.Sys.Instrumentation {
	class CommandsQualifiedCountValue : CountValue {
		public CommandsQualifiedCountValue()
			: base("Commands - Qualified (count)") {
		}
	}
}
