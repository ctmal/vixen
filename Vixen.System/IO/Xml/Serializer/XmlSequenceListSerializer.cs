﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Vixen.Services;
using Vixen.Sys;

namespace Vixen.IO.Xml.Serializer {
	class XmlSequenceListSerializer : IXmlSerializer<IEnumerable<ISequence>> {
		private const string ELEMENT_SEQUENCES = "Sequences";
		private const string ELEMENT_SEQUENCE = "Sequence";
		private const string ATTR_FILE_NAME = "fileName";

		public XElement WriteObject(IEnumerable<ISequence> value) {
			return new XElement(ELEMENT_SEQUENCES,
				value.Select(x =>
					new XElement(ELEMENT_SEQUENCE,
						new XAttribute(ATTR_FILE_NAME, Path.GetFileName(x.FilePath)))));
		}

		public IEnumerable<ISequence> ReadObject(XElement element) {
			List<ISequence> sequences = new List<ISequence>();

			XElement sequencesElement = element.Element(ELEMENT_SEQUENCES);
			if(sequencesElement != null) {
				foreach(XElement sequenceElement in sequencesElement.Elements(ELEMENT_SEQUENCE)) {
					string fileName = XmlHelper.GetAttribute(sequenceElement, ATTR_FILE_NAME);
					if(fileName == null) continue;

					ISequence sequence = FileService.Instance.LoadSequenceFile(fileName);

					sequences.Add(sequence);
				}
			}

			return sequences;
		}
	}
}
