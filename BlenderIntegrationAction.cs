using StreamDeckLib;
using StreamDeckLib.Messages;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlenderStreamDeckIntegration
{
    [ActionUuid(Uuid = "MiniSharpy.BlenderIntegration.DefaultPluginAction")]
    public class BlenderIntegrationAction : BaseStreamDeckActionWithSettingsModel<Models.ServerSettingsModel>
    {
        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            // Prefer a using declaration to ensure the instance is Disposed later.
            using TcpClient client = new TcpClient(SettingsModel.Server, SettingsModel.Port);

            // Translate the passed message into ASCII and store it as a Byte array.
            byte[] data = System.Text.Encoding.ASCII.GetBytes(SettingsModel.Message);

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            await Manager.SetSettingsAsync(args.context, SettingsModel);
        }

        public override async Task OnDidReceiveSettings(StreamDeckEventPayload args)
        {
            await base.OnDidReceiveSettings(args);
            await Manager.SetTitleAsync(args.context, SettingsModel.Message);
        }

        public override async Task OnWillAppear(StreamDeckEventPayload args)
        {
            await base.OnWillAppear(args);
            await Manager.SetTitleAsync(args.context, SettingsModel.Message);
        }

    }
}
