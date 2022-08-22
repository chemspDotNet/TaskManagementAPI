using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web;
using TaskManagementAPI.AuthProvider;
using System.Web.Http;

[assembly: OwinStartup(typeof(TaskManagementAPI.StartUp))]
namespace TaskManagementAPI
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {  
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);  
  
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The Path For generating the Toekn  
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)  
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //AuthorizationServerProvider class will validate the user credentials  
                Provider = new AuthorizationServerProvider()
            };

        //Token Generations  
            app.UseOAuthAuthorizationServer(options);  
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());  
  
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);  
        }
}
}