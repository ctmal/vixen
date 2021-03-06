﻿namespace Vixen.IO {
	interface IObjectLoader<out T> : IObjectLoader
		where T : class, new() {
		T LoadFromFile(string filePath);
	}

	internal interface IObjectLoader {
		object LoadFromFile(string filePath);
	}
}
