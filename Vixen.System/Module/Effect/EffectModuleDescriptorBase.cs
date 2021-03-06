﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Vixen.Sys;

namespace Vixen.Module.Effect {
	[Serializable]
	abstract public class EffectModuleDescriptorBase : ModuleDescriptorBase, IEffectModuleDescriptor, IEqualityComparer<IEffectModuleDescriptor>, IEquatable<IEffectModuleDescriptor>, IEqualityComparer<EffectModuleDescriptorBase>, IEquatable<EffectModuleDescriptorBase> {
		protected EffectModuleDescriptorBase() {
			PropertyDependencies = new Guid[0];
		}

		abstract public override string TypeName { get; }

		abstract public override Guid TypeId { get; }

		abstract public override Type ModuleClass { get; }

		abstract public override string Author { get; }

		abstract public override string Description { get; }

		abstract public override string Version { get; }

		abstract public string EffectName { get; }

		abstract public ParameterSignature Parameters { get; }

		virtual public Guid[] PropertyDependencies { get; private set; }

		virtual public Image GetRepresentativeImage(int desiredWidth, int desiredHeight) {
			int maxDimension = Math.Max(desiredWidth, desiredHeight);
			if(maxDimension <= 16) {
				return ImageResource.Effect16;
			} else if(maxDimension <= 48) {
				return ImageResource.Effect48;
			} else {
				return ImageResource.Effect64;
			}
		}

		public bool Equals(IEffectModuleDescriptor x, IEffectModuleDescriptor y) {
			return base.Equals(x, y);
		}

		public int GetHashCode(IEffectModuleDescriptor obj) {
			return base.GetHashCode();
		}

		public bool Equals(IEffectModuleDescriptor other) {
			return base.Equals(other);
		}

		public bool Equals(EffectModuleDescriptorBase x, EffectModuleDescriptorBase y) {
			return Equals(x as IEffectModuleDescriptor, y as IEffectModuleDescriptor);
		}

		public int GetHashCode(EffectModuleDescriptorBase obj) {
			return GetHashCode(obj as IEffectModuleDescriptor);
		}

		public bool Equals(EffectModuleDescriptorBase other) {
			return Equals(other as IEffectModuleDescriptor);
		}
	}
}
