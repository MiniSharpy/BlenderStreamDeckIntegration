# A non-blocking server to listen for input messages from within Blender.
import asyncio, threading, bpy

async def handle_input(reader, writer):
    data = await reader.read(100)
    message = data.decode()
    addr = writer.get_extra_info('peername')

    print(f"Received {message!r} from {addr!r}")

    bpy.ops.paint.brush_select(sculpt_tool=message) # Is this safe to run on another thread? It might be better to execute this from the main thread using a queue.

    print("Close the connection")
    writer.close()
    await writer.wait_closed()

async def main():
    server = await asyncio.start_server(
        handle_input, '127.0.0.1', 8888)

    addrs = ', '.join(str(sock.getsockname()) for sock in server.sockets)
    print(f'Serving on {addrs}')

    async with server:
        await server.serve_forever()

def network_thread():
    asyncio.run(main())

thread = threading.Thread(target=network_thread)
thread.start()