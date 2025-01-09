using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace Backend_CruzRoja.Utilidades
{
    public class TelegramNotificationService
    {
        private readonly TelegramBotClient _botClient;
        private readonly long _chatId;

        public TelegramNotificationService(string botToken, long chatId)
        {
            _botClient = new TelegramBotClient(botToken);
            _chatId = chatId;
        }

        public async Task EnviarMensaje(string mensaje)
        {
            try
            {
                await _botClient.SendTextMessageAsync(_chatId, mensaje);
                Console.WriteLine($"Mensaje enviado correctamente a Telegram al chat {_chatId}");
            }
            catch (ApiRequestException ex)
            {
                Console.WriteLine($"Error de API al enviar mensaje a Telegram: {ex.Message}");
                throw; // Re-lanza la excepción para que la aplicación principal pueda manejarla
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al enviar mensaje a Telegram: {ex.Message}");
                throw; // Re-lanza la excepción para que la aplicación principal pueda manejarla
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Reemplaza con tu token de bot y chat ID
            string botToken = "7470712382:AAHT6LGTl53rdE256kehg_IXGfEDiE4Tj2A";
            long chatId = 5997661225;

            var telegramService = new TelegramNotificationService(botToken, chatId);

            // Mensaje de inicio de sesión
            string mensaje = "¡Hola! Mi aplicación se ha iniciado sesión.";

            try
            {
                // Envío del mensaje
                await telegramService.EnviarMensaje(mensaje);
                Console.WriteLine("Mensaje enviado a Telegram correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar mensaje a Telegram: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para salir.");
                Console.ReadKey();
            }
        }
    }
}
