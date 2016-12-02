using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Marvel
{
	public partial class PrincipalPage : ContentPage
	{
		public PrincipalPage()
		{
			InitializeComponent();


			var vm = new PrincipalViewModel();

			listCharacters.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
		   {
			   var character = (CharacterItemViewModel)e.SelectedItem;
			   var infoVm = new InformacoesViewModel(character.Id);
				var infoView = new InformacoesPage(infoVm);
			   App.Navigation.PushAsync(infoView);
		   };

			listCharacters.IsPullToRefreshEnabled = true;

			BindingContext = vm;
			vm.LoadData(null,100,0);
		}
	}
}
