using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel; // CancelEventArgs
using ZOOM_SDK_DOTNET_WRAP;

using ZoomIntegration.Configuration;

namespace zoom_sdk_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        start_join_meeting start_meeting_wnd = new start_join_meeting();
        public MainWindow()
        {
            InitializeComponent(); 
        }

        //callback
        public void onAuthenticationReturn(AuthResult ret)
        {
          

            if (ZOOM_SDK_DOTNET_WRAP.AuthResult.AUTHRET_SUCCESS == ret)
            {
                start_meeting_wnd.Show();
            }
            else//error handle.todo
            {
                Show();
            }
          
        }
        public void onLoginRet(LOGINSTATUS ret, IAccountInfo pAccountInfo)
        {
            //todo
        }
        public void onLogout()
        {
            //todo
        }
        private void button_auth_Click(object sender, RoutedEventArgs e)
        {
            //register callback
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onAuthenticationReturn(onAuthenticationReturn);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onLoginRet(onLoginRet);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onLogout(onLogout);
            //
            ZOOM_SDK_DOTNET_WRAP.AuthContext param = new ZOOM_SDK_DOTNET_WRAP.AuthContext();

            string apiKey = "STxJ01JLrdJfX2FEag7jYfyt3iGtJWELKyB7";
            string apiSecret = "WeAnA3XqRTC56p7Jhrby8PQF9sMCqokCl0cd";
            ZoomToken myToken = new ZoomToken(apiKey, apiSecret);
            param.jwt_token = myToken.Token;

            // param.jwt_token = textBox_apptoken.Text;
            // param.jwt_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhcHBLZXkiOiJTVHhKMDFKTHJkSmZYMkZFYWc3allmeXQzaUd0SldFTEt5QjciLCJpYXQiOjE2MjcwMjcwMzIsImV4cCI6MTYyNzExMzQzMiwidG9rZW5FeHAiOjE2MjcxMTM0MzJ9.svtjOUAdgSDIQnC8cje3Tn1cKS0morxU003BpNK-Jqo";
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().SDKAuth(param);
            Hide();
        }

        void Wnd_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
