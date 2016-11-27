using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Auth
{
	public partial class LoginPage : ContentPage
	{		
		Entry name;
		Entry password;
		private const string Url = "http://apiauthmob220161126081011.azurewebsites.net/api/usuarios";
		private ObservableCollection<Users> _users;
		
		public class Users
		{
		    public int Id { get; set; }
		    public string Nome { get; set; }
		    public string NickNome { get; set; }
		    public string Senha { get; set; }
		    public bool Ativo { get; set; }
		}
		
		public LoginPage()
		{			
			//name = this.FindByName <Entry>("txtNome");
			//password = this.FindByName <Entry>("txtSenha");
		
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Login();
		}
		
		public async void Login ()
		{
			using (var client = new HttpClient())
			{
				var content = await client.GetStringAsync(Url);
				var users = JsonConvert.DeserializeObject<List<Users>>(content);
				
				_users = new ObservableCollection<Users>(users);
				
				foreach(Users u in _users)
				{
					if(txtNome.Text == u.Nome)
					{
						if(txtSenha.Text == u.Senha)
						{
							await DisplayAlert("Ok", "Autenticou", "Ok");
						}
					}
				}
			
				//var result = await client.GetAsync("http://apiauthmob220161126081011.azurewebsites.net/api/usuarios");
				//var myJson = result.Content.ReadAsStringAsync().Result;
				//return myJson;
			}	
		} 
	}
}
