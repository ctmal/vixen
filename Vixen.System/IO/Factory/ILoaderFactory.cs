﻿using Vixen.Sys;

namespace Vixen.IO.Factory {
	interface ILoaderFactory {
		IObjectLoader<SystemConfig> CreateSystemConfigLoader();
		IObjectLoader<ModuleStore> CreateModuleStoreLoader();
		IObjectLoader<SystemContext> CreateSystemContextLoader();
		IObjectLoader<Program> CreateProgramLoader();
		IObjectLoader<ElementNodeTemplate> CreateElementNodeTemplateLoader();
		IObjectLoader CreateSequenceLoader();
	}
}
