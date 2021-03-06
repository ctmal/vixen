﻿using System.Xml.Linq;

namespace Vixen.IO.Xml.Serializer {
	/// <typeparam name="T">Type of object being serialized.</typeparam>
	interface IXmlSerializer<T> : ISerializer<T, XElement> {
	}
}
