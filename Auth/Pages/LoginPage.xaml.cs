using System;
using System.Collections.Generic;
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
		
		public LoginPage()
		{			
			//name = this.FindByName <Entry>("txtNome");
			//password = this.FindByName <Entry>("txtSenha");
		
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var name = GetData();

			
		}
		
		public async Task<string> GetData ()
		{
			using (var client = new HttpClient())
			{
				var result = await client.GetAsync("http://apiauthmob220161126081011.azurewebsites.net/api/usuarios");
				var myJson = result.Content.ReadAsStringAsync().Result;
				return myJson;
			}	
		} 
	}
}
