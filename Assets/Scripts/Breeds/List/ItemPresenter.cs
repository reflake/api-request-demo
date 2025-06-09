namespace Breeds.List
{
	public class ItemPresenter
	{
		private readonly ItemView _view = null;
		private readonly ItemModel _model = null;
		
		public ItemPresenter(ItemView view, ItemModel model)
		{
			_view = view;
			_model = model;
			
			_view.SetName(model.Name);
		}
	}
}