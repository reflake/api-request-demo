using System;

namespace Breeds.Data
{
	[Serializable]
	public class ResponseData
	{
		public BreedEntry[] data;
	}

	[Serializable]
	public class ResponseDetailsData
	{
		public BreedEntry data;
	}
	
	[Serializable]
	public class BreedEntry
	{
		public string id;
		public BreedAttributes attributes;
	}

	[Serializable]
	public class BreedAttributes
	{
		public string name;
		public string description;
	}
}