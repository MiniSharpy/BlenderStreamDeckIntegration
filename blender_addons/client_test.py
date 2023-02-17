# Demo program to represent what to do when there's input from the Stream Deck.
# https://docs.python.org/3/library/asyncio-stream.html#tcp-echo-client-using-streams
import asyncio

async def tcp_echo_client(message):
    reader, writer = await asyncio.open_connection(
        '127.0.0.1', 8888)

    print(f'Send: {message!r}')
    writer.write(message.encode())
    await writer.drain()

    print('Close the connection')
    writer.close()
    await writer.wait_closed()

asyncio.run(tcp_echo_client('CLAY'))