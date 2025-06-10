using Cysharp.Threading.Tasks;

namespace Breeds.Details
{
	public class Presenter
	{
		private readonly View _view = null;
		private readonly Model _model = null;

		public Presenter(View view, Model model)
		{
			_view = view;
			_model = model;

			ShowDetails().Forget();
		}

		private async UniTaskVoid ShowDetails()
		{
			_view.ShowLoading();
			
			var data = await _model.GetDetailsAsync();
			
			_view.SetName(data.Name);
			_view.SetDescription(data.Description);

			_view.HideLoading();
		}
	}
}