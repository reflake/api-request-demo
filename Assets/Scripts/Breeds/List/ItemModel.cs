namespace Breeds.List
{
	public class ItemModel
	{
		public int Index { get; private set; }
		public string Id { get; private set; }
		public string Name { get; private set; }

		public ItemModel(Breed breed)
		{
			Index = breed.Index;
			Id = breed.Id;
			Name = breed.Name;
		}
	}
}