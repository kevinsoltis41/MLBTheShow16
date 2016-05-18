using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Linq;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(MLBShow16.App_Start.BreezeWebApiConfig), "RegisterBreezePreStart")]
namespace MLBShow16.App_Start {
  ///<summary>
  /// Inserts the Breeze Web API controller route at the front of all Web API routes
  ///</summary>
  ///<remarks>
  /// This class is discovered and run during startup; see
  /// http://blogs.msdn.com/b/davidebb/archive/2010/10/11/light-up-your-nupacks-with-startup-code-and-webactivator.aspx
  ///</remarks>
  public static class BreezeWebApiConfig {

    public static void RegisterBreezePreStart() {
      GlobalConfiguration.Configuration.Routes.MapHttpRoute(
          name: "BreezeApi",
          routeTemplate: "breeze/{controller}/{action}"
      );

      GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

      // Remove default XML handler
      var matches = GlobalConfiguration.Configuration.Formatters
                          .Where(f => f.SupportedMediaTypes
                                       .Where(m => m.MediaType.ToString() == "application/xml" ||
                                                   m.MediaType.ToString() == "text/xml")
                                       .Count() > 0)
                          .ToList();
      foreach (var match in matches)
          GlobalConfiguration.Configuration.Formatters.Remove(match); 
    }
  }
}