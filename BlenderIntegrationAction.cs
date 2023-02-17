using BlenderStreamDeckIntegration.Models;
using StreamDeckLib;
using StreamDeckLib.Messages;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlenderStreamDeckIntegration
{
    [ActionUuid(Uuid = "MiniSharpy.BlenderIntegration.ChangeSculptBrush")]
    public class SculptBrushAction : BaseStreamDeckActionWithSettingsModel<Models.ServerSettingsModel>
    {
        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient?view=net-7.0#examples
            // Prefer a using declaration to ensure the instance is Disposed later.
            using TcpClient client = new(SettingsModel.Server, SettingsModel.Port);

            // Translate the passed message into ASCII and store it as a Byte array.
            byte[] data = Encoding.ASCII.GetBytes(SettingsModel.Message.ToUpper());
            // Ideally would want to use the title as the message to send, after some formatting, to simplify the 
            // the input needed from the Stream Deck GUI. 


            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            await Manager.SetSettingsAsync(args.context, SettingsModel);
        }
    }
}
