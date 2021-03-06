﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace Vixen.Sys {
	class UIThread {
		private Thread _thread;
		private Form _form;
		private ApplicationContext _applicationContext;
		private Action _exitAction;
		private Func<Form> _formThreadInit;
		private Func<ApplicationContext> _applicationContextThreadInit;
		private WindowsFormsSynchronizationContext _synchronizationContext;

		public UIThread(Func<ApplicationContext> threadInit) {
			if(threadInit == null) throw new ArgumentNullException();
			_applicationContextThreadInit = threadInit;

			_thread = new Thread(_ApplicationContextThread) { Name = "Application context thread" };
			_thread.SetApartmentState(ApartmentState.STA);
			
			_exitAction = _ApplicationContextExit;
		}

		public UIThread(Func<Form> threadInit) {
			if(threadInit == null) throw new ArgumentNullException();
			_formThreadInit = threadInit;

			_thread = new Thread(_FormThread) { Name = "Form thread" };
			_thread.SetApartmentState(ApartmentState.STA);
			
			_exitAction = _FormExit;
		}

		public void Start() {
			if(_thread.ThreadState != ThreadState.Running) {
				_thread.Start();
			}
		}

		public void Stop() {
			if(_thread != null && _thread.ThreadState == ThreadState.Running) {
				_exitAction();
			}
		}

		public ThreadState ThreadState {
			get { return _thread.ThreadState; }
		}

		public void BeginInvoke(Action methodToInvoke) {
			if(_synchronizationContext == null) return;

			_synchronizationContext.Post(o => methodToInvoke(), null); 
		}

		private void _FormThread() {
			_form = _formThreadInit();
			if(_form == null) throw new InvalidOperationException();

			_synchronizationContext = new WindowsFormsSynchronizationContext();
			_applicationContext = new ApplicationContext(_form);
			Application.Run(_applicationContext);
		}

		private void _ApplicationContextThread() {
			_applicationContext = _applicationContextThreadInit();
			if(_applicationContext == null) throw new InvalidOperationException();

			_synchronizationContext = new WindowsFormsSynchronizationContext();
			Application.Run(_applicationContext);
		}

		private void _FormExit() {
			_ApplicationContextExit();
		}

		private void _ApplicationContextExit() {
			_applicationContext.ExitThread();
		}
	}
}
