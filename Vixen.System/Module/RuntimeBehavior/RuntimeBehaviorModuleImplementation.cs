﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Common;

namespace Vixen.Module.RuntimeBehavior {
	[TypeOfModule("RuntimeBehavior")]
	class RuntimeBehaviorModuleImplementation : ModuleImplementation<IRuntimeBehaviorModuleInstance> {
		public RuntimeBehaviorModuleImplementation()
			: base(new RuntimeBehaviorModuleManagement(), new RuntimeBehaviorModuleRepository()) {
		}
	}
}
