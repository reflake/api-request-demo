using Breeds.Details;

namespace Breeds.List
{
	public class ItemPresenter
	{
		private readonly ItemView _view = null;
		private readonly ItemModel _model = null;
		private readonly DetailsPopup.Factory _detailsPopupFactory = null;

		public ItemPresenter(ItemView view, ItemModel model, DetailsPopup.Factory detailsPopupFactory)
		{
			_view = view;
			_model = model;
			_detailsPopupFactory = detailsPopupFactory;
			
			_view.SetIndex(model.Index + 1);
			_view.SetName(model.Name);

			// Subscriptions
			_view.OnClick += ShowPopup;
		}

		private void ShowPopup()
		{
			_detailsPopupFactory.Create(_model.Id);
		}
	}
}