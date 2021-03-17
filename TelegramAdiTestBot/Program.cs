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
                              $"1. Página Web ADI Solutions" + Environment.NewLine +
                              $"2. Desarrollo de aplicaciones Web" + Environment.NewLine +
                              $"3. Desarrollo de ChatBot" + Environment.NewLine +
                              $"4. Solicitud de cotización" + Environment.NewLine +
                              $"5. Salir"
                        );
                }
                else if (!e.Message.Text.ToLower().Contains($"hola") && !e.Message.Text.ToLower().Contains("1") &&
                    !e.Message.Text.ToLower().Contains("2") && !e.Message.Text.ToLower().Contains("3") &&
                    !e.Message.Text.ToLower().Contains("4") && !e.Message.Text.ToLower().Contains("5"))
                {
                    await _botClient.SendTextMessageAsync(
                   chatId: e.Message.Chat.Id,
                   text: $"Disculpa no reconozco la opción ingresada: {e.Message.Text}, Si me saludas con un Hola aprendere");
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
                        text: $"Dejanos tus datos de contacto en contados minutos nos comunicaremos contigo!!!" + Environment.NewLine +
                              $" Nombre Completa:" + Environment.NewLine +
                              $" Número de Contacto:  "
                        );
                }

                if (e.Message.Text.ToLower().Contains("3"))
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $"Creamos diferentes flujos que responderan a tus clientes"
                        );
                }

                if (e.Message.Text.ToLower().Contains("4"))
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $" Números de Contacto"
                        );
                }

                if (e.Message.Text.ToLower().Contains("5"))
                {
                    await _botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "https://tlgrm.eu/_/stickers/8a1/9aa/8a19aab4-98c0-37cb-a3d4-491cb94d7e12/2.webp"
                        );
                }
            }
        }
    }
}
