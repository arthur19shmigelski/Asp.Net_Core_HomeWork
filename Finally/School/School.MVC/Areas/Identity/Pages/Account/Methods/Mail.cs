using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace School.MVC.Areas.Identity.Pages.Account.Methods
{
    public static class Mail
    {
        public static void SendLetterIfForgotPassword(string toEmail,string callbackUrl)
        {
            var message = PackMessage(toEmail, "Восстановление пароля", $"Восстановить пароль вы можете по нажатию <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>на меня</a>.");
            SendLetter(message);
        }
        public static void SendLetterRegisterConfirmation(string toEmail, string EmailConfirmationUrl)
        {
            var message = PackMessage(toEmail, "Подтверждение регистрации ", $"Привет. Ты зарегестриторвался у нас на сайте. " +
                $"Для подтверждения своей почты кликни <a href='{HtmlEncoder.Default.Encode(EmailConfirmationUrl)}'>на меня</a>.");
            SendLetter(message);
        }
        public static void SendLetterChangeEmail(string toEmail, string callbackUrl)
        {
            var message = PackMessage(toEmail, "Изменение почты", $"Привет. Ты изменил почту у нас на сайте. " +
                $"Для подтверждения своей новой почты кликни <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>на меня</a>.");
            SendLetter(message);
        }
        private static MimeMessage PackMessage(string toEmail, string subjectLetter, string bodyText)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Администратор", "testingciscoyandex@gmail.com"));
            message.To.Add(new MailboxAddress("Пользователь", toEmail));
            message.Subject = subjectLetter;
            message.Body = new TextPart("plain")
            {
                Text = bodyText
            };

            return message;
        }
        private static void SendLetter(MimeMessage message)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("testingciscoyandex@gmail.com", "!@3QWeASd");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
