using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramAdiTestBot
{
    class Program
    {
        public static ITelegramBotClient _botClient;
        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("1621659494:AAGW2kEdFzs1Z8ULCueEf5NteNnv4ivY8EM");
            var me = _botClient.GetMeAsync().Result;

            Console.WriteLine($"Hola, Tengo un id: {me.Id} y de nombre: {me.FirstName}");

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Por favor ingrese cualquier tecla para salir");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        private async static void _botClient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                if (e.Message.Text.ToLower().Contains($"hola"))
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $"Hola Bienvenido a ADI Solutions " + Environment.NewLine +
                              $"" + Environment.NewLine +
                              $"¿Que deseas realizar? " + Environment.NewLine +
                              $"" + Environment.NewLine +
                              $"1. Página Web ADI Solutions" +
                              $"" + Environment.NewLine +
                              $"2. Conocer el equipo de ADI Solutions"
                        );
                }

                if (e.Message.Text.ToLower().Contains("1"))
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $"https://adisolutions.com.co/"
                        );
                }

                if (e.Message.Text.ToLower().Contains("2"))
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $"Andres Bulla"
                        );

                    await _botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "https://www.pngitem.com/pimgs/m/128-1280086_transparent-krillin-png-dibujos-de-dragon-ball-z.png"
                        );

                    await _botClient.SendTextMessageAsync(
                       chatId: e.Message.Chat.Id,
                       text: $"Andres Guerrero"
                       );

                    await _botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "http://pm1.narvii.com/7085/97bb26ea1678fd27379ba29453ee1c1e1118e254r1-564-630v2_uhq.jpg"
                        );

                    await _botClient.SendTextMessageAsync(
                     chatId: e.Message.Chat.Id,
                     text: $"Alejandro Gil"
                     );

                    await _botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "https://static.wikia.nocookie.net/powerrangersfanon/images/c/ce/Phineas.jpg/revision/latest?cb=20140205212422"
                        );

                }
            }
        }
    }
}
