﻿namespace Vixen.IO {
	class MigratingObjectLoaderService : IMigratingObjectLoaderService {
		static private MigratingObjectLoaderService _instance;

		private MigratingObjectLoaderService() {
		}

		public static MigratingObjectLoaderService Instance {
			get { return _instance ?? (_instance = new MigratingObjectLoaderService()); }
		}

		public T LoadFromFile<T>(string filePath, IFileReader fileReader, IObjectContentWriter contentWriter, IContentMigrator contentMigrator, int currentObjectVersion)
			where T : class, new() {
			return LoadFromFile(new T(), filePath, fileReader, contentWriter, contentMigrator, currentObjectVersion);
		}

		public T LoadFromFile<T>(T objectToPopulate, string filePath, IFileReader fileReader, IObjectContentWriter contentWriter, IContentMigrator contentMigrator, int currentObjectVersion)
			where T : class {
			object content = fileReader.ReadFile(filePath);
			if(content == null) return null;

			content = ObjectMigratorService.Instance.MigrateObject(content, contentMigrator, contentWriter.GetContentVersion(content), currentObjectVersion, filePath);
			contentWriter.WriteContentToObject(content, objectToPopulate);

			return objectToPopulate;
		}
	}
}