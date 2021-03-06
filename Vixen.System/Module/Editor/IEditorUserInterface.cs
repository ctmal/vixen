﻿using System;
using System.ComponentModel;
using Vixen.Sys;

namespace Vixen.Module.Editor {
	public interface IEditorUserInterface : IDisposable {
		event CancelEventHandler Closing;
		event EventHandler Activated;

		IEditorModuleInstance OwnerModule { get; set; }
		/// <summary>
		/// The editor's signal to show or otherwise start as the user interface.
		/// </summary>
		void Start();

		ISequence Sequence { get; set; }
		ISelection Selection { get; }
		void Save(string filePath = null);
		void Refresh();
		//EditorValues EditorValues { get; }
		bool IsModified { get; }
		bool IsDisposed { get; }
	}
}
