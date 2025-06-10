using TMPro;
using Zenject;

namespace UI
{
	public class TabController : IInitializable
	{
		private readonly TMP_Text _header;
		private readonly TabButton[] _tabButtons;
		private readonly TabPanel[] _tabPanels;

		public TabController(TMP_Text header, TabButton[] tabButtons, TabPanel[] tabPanels)
		{
			_header = header;
			_tabButtons = tabButtons;
			_tabPanels = tabPanels;

			foreach (var tabButton in tabButtons)
			{
				tabButton.OnClick += Focus;
			}
		}

		public void Initialize()
		{
			Focus(_tabButtons[0]);
		}
		
		public void Focus(TabButton tabButton)
		{
			string id = tabButton.Id;
			
			foreach (var button in _tabButtons)
			{
				button.SetFocusedValue(button == tabButton);
			}

			foreach (var panel in _tabPanels)
			{
				bool targetPanel = panel.Id == id;
				panel.SetFocused(targetPanel);

				if (targetPanel)
				{
					_header.text = panel.Name;
				}
			}
		}
	}
}