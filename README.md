# Blender Stream Deck Integration
To communicate with Blender the Stream Deck plugin uses C# to send a message on an action to a non-blocking TCP server, ran using Blender's Python API.

Currently, changing only a subset of sculpt brushes is supported. Further additions should likely be implemented as additional Stream Deck actions, which send an identifier in their message for the server to disambiguate actions from one another.

## Installation
### Installing the Stream Deck Plugin
1. Clone the project.
2. Run ``RegisterPluginAndStartStreamDeck.sh`` or ``RegisterPluginAndStartStreamDeck.ps1``. This will build the project, add it to the Stream Deck, and open the Stream Deck GUI.
3. [Import](https://help.elgato.com/hc/en-us/articles/360048424432-Elgato-Stream-Deck-How-to-Back-Up-and-Restore-Profiles-) one of the Stream Deck profiles containing pre-setup actions and icons.

### Installing the Blender Plugin
To check that the plugin is running view the system console in Blender via Window->Toggle Systems Console.

#### For automatic startup (Not Finished):
See the [Blender documentation.](https://docs.blender.org/manual/en/latest/editors/preferences/addons.html#installing-add-ons)

#### For manual startup:
1. Open a [Text Editor](https://docs.blender.org/manual/en/latest/editors/text_editor.html) in an area of Blender.
2. Open ProjectRepo/blender_addons/server.py as a text block in Blender, or copy the contents of the file into a new text block.
3. Run the script.

## Resources
- https://github.com/FritzAndFriends/StreamDeckToolkit
- https://developer.elgato.com/documentation/stream-deck/sdk/overview/
- https://developer.elgato.com/documentation/stream-deck/sdk/style-guide/
- https://developer.elgato.com/documentation/stream-deck/sdk/manifest/
- https://docs.blender.org/manual/en/latest/index.html
- https://wiki.blender.org/wiki/Source/Interface/Icons
- https://docs.python.org/3/library/asyncio-stream.html
- https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient?view=net-7.0