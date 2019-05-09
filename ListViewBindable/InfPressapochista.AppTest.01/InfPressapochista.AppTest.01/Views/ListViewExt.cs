using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace InfPressapochista.AppTest01.Views
{
public class ListViewExt:ListView
{
	public ListViewExt()
	{
		ItemSelected += OnItemSelected;
	}

	public static BindableProperty ItemSelezionatoCommandProperty =
		BindableProperty.Create(nameof(ItemSelezionatoCommand),
		                        typeof(ICommand),
		                        typeof(ListViewExt),
		                        null);
	
	public ICommand ItemSelezionatoCommand
	{
		get { return (ICommand)GetValue(ItemSelezionatoCommandProperty); }
		set { SetValue(ItemSelezionatoCommandProperty, value); }
	}

	private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var item = e.SelectedItem;
		if (item != null && ItemSelezionatoCommand != null
			&& ItemSelezionatoCommand.CanExecute(item))
		{
			ItemSelezionatoCommand.Execute(e.SelectedItem);
		}
		SelectedItem = null;
	}
}
}

