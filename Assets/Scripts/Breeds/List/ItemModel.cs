using Breeds.List.Data;

namespace Breeds.List
{
	public class ItemModel
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		public ItemModel(Breed breed)
		{
			Id = breed.Id;
			Name = breed.Name;
		}
	}
}