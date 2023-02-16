namespace BlenderStreamDeckIntegration.Models
{
  public class ServerSettingsModel // Variables that are to be used in the PI need to be defined there too.
  {
        public string Server { get; set; } = "127.0.0.1";

        public int Port { get; set; } = 8888;

        public string Message { get; set; } = "CLAY"; //string.Empty;
  }
}
