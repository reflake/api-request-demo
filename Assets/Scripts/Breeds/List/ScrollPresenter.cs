using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Breeds.List
{
	public class ScrollPresenter
	{
		private readonly Item.Factory _itemFactory;
		private readonly ScrollView _view;
		private readonly ScrollModel _model;
		
		private List<Item> _items = new();

		public ScrollPresenter(ScrollView view, ScrollModel model, Item.Factory itemFactory)
		{
			_view = view;
			_model = model;
			_itemFactory = itemFactory;
			
			// Subscriptions
			_view.OnClickRefresh += Refresh;
			_view.OnLostFocus += CancelRequests;

			RefreshList().Forget();
		}

		private void CancelRequests()
		{
			_model.TryCancelRequest();
		}

		private void Refresh()
		{
			RefreshList().Forget();
		}

		private async UniTaskVoid RefreshList()
		{
			ClearItems();
			
			_view.ShowLoading();
			
			var itemsData = await _model.LoadEntries();
			
			// Create items from their data
			_items = itemsData
				.Select(_itemFactory.Create)
				.ToList();

			_view.HideLoading();
		}

		private void ClearItems()
		{
			foreach (var item in _items)
			{
				item.Remove();
			}
			
			_items.Clear();
		}
	}
}