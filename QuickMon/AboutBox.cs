using System;
using System.Reflection;
using System.Windows.Forms;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace QuickMonTray
{
	partial class AboutBox : Form
	{
		public AboutBox()
		{
			InitializeComponent();

			this.Text = String.Format("About {0}", AssemblyTitle);
            //LblUsername.Text = AssemblyProduct;
            //labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            //labelCopyright.Text = AssemblyCopyright;
            //labelCompanyName.Text = AssemblyCompany;
            //	this.textBoxDescription.Text = AssemblyDescription;


            //Dictionary<string, string> Data = new Dictionary<string, string>();
            //Data.Add("COMP_Name", Info.COMP_Name);
            //Data.Add("COMP_Manufacturer", Info.COMP_Manufacturer);
            //Data.Add("COMP_Model", Info.COMP_Model);
            //Data.Add("COMP_NumberOfLogicalProcessors", Info.COMP_NumberOfLogicalProcessors.ToString());
            //Data.Add("COMP_NumberOfProcessors", Info.COMP_NumberOfProcessors.ToString());
            //Data.Add("COMP_PCSystemType", Info.COMP_PCSystemType.ToString());
            //Data.Add("COMP_ThermalState", Info.COMP_ThermalState.ToString());
            //Data.Add("COMP_TotalPhysicalMemory", Info.COMP_TotalPhysicalMemory.ToString());
            //Data.Add("COMP_Workgroup", Info.COMP_Workgroup);
            //Data.Add("COMP_Domain", Info.COMP_Domain);

            //Data.Add("BIOS_Caption", Info.BIOS_Caption);
            //Data.Add("BIOS_Manufacturer", Info.BIOS_Manufacturer);
            //Data.Add("BIOS_BIOSVersion", Info.BIOS_BIOSVersion[0]);
            //Data.Add("BIOS_BuildNumber", Info.BIOS_BuildNumber);
            //Data.Add("BIOS_Status", Info.BIOS_Status);
            //Data.Add("BIOS_SerialNumber", Info.BIOS_SerialNumber);



            // Data.Add("COMP_BootupState", Info.COMP_BootupState.ToString());
          
            SendInfo();

        }

        public async Task SendInfo()
        {
            var Info = new Computer();
            await Info.UpdateAsync();
            await Info.UpdateAccount("dieobox@gmail.com");

            string json = JsonConvert.SerializeObject(Info);
            textBox3.Text = json;
            var bb = Info.BiosSerialNumber;
            var accessToken = await GetAPIToken("dieobox@gmail.com", "5556r72b", "http://localhost:10570/");

            var client = new HttpClient();
            client.SetBearerToken(accessToken.AccessToken);

            var response = await client.GetAsync("http://localhost:10570/api/Enrollment/");
            if (!response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.StatusCode);
                textBox3.Text = response.StatusCode.ToString();
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                textBox3.Text = JArray.Parse(content).ToString();
                //  Console.WriteLine(JArray.Parse(content));
            }

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:10570/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var credentials = Encoding.ASCII.GetBytes("dieobox@gmail.com:5556r72b");
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

            //    StringContent content = new StringContent(json);
            //    HttpResponseMessage response = await client.PostAsJsonAsync("api/ComInfo/", Info);
            //    response.EnsureSuccessStatusCode();
            //}
        }

        private static async Task<TokenResponse> GetAPIToken(string userName, string password, string apiBaseUri)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var disco = await DiscoveryClient.GetAsync(apiBaseUri);                var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
               // var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName,password, "api1");
                //setup login data
                return tokenResponse;
            }
        }

        static async Task<string> GetRequest(string token, string apiBaseUri, string requestPath)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                //make request
                HttpResponseMessage response = await client.GetAsync(requestPath);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion
	}
}