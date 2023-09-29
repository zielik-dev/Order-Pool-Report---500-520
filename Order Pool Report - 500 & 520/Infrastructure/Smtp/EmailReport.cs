using Order_Pool_Report___500___520.Interfaces;
using Order_Pool_Report___500___520.Logs;
using Order_Pool_Report___500___520.RemoteConfigurations.SmtpConfig;
using System.Net.Mail;

namespace Order_Pool_Report___500___520.Infrastructure.Smtp
{
    public class EmailReport : ConnectionStrings, IEmailReport
    {
        private static EmailReport emailReport;
        private static string _smptHostName, _senderAddress, _emailRecipients, _regards, _sign, _line, _footer;

        public EmailReport()
        {
            _smptHostName = SmtpHostName.Read();
            _senderAddress = SmtpSenderAddress.Read();
            _emailRecipients = SmtpEmailRecipients.Read();
            _regards = SmtpEmailSignature.ReadRegards();
            _sign = SmtpEmailSignature.ReadSign();
            _line = SmtpEmailSignature.ReadLine();
            _footer = SmtpEmailSignature.ReadFooter();
        }

        public static EmailReport Instance
        {
            get
            {
                if (emailReport == null)
                    emailReport = new EmailReport();
                return emailReport;
            }
        }

        public void Send(string environment, DateTime dt, string templateFP)
        {
            try
            {
                string dateStamp = dt.ToString("dd/MM/yyyy");

                MailAddress from = new(_senderAddress);

                MailMessage message = new()
                {
                    From = from
                };

                message.To.Add(_emailRecipients);

                message.Subject = $"{logTitle} - {dateStamp}";

                Attachment outboundFile = new(templateFP);
                message.Attachments.Add(outboundFile);
                message.IsBodyHtml = false;
                message.Body = @"Hello All," + Environment.NewLine + Environment.NewLine +
                                 $"Please find attached {logTitle} file." + Environment.NewLine + Environment.NewLine +
                                 "Please do not reply directly to this email and if escalating an issue please change subject of the email to avoid the risk of Outlook rule moving the email to specific folder that is less visited." + Environment.NewLine + Environment.NewLine +
                                 _regards + Environment.NewLine +
                                 _sign + Environment.NewLine +
                                 _line + Environment.NewLine +
                                 _footer;

                SmtpClient client = new()
                {
                    Host = _smptHostName
                };

                client.Send(message);
            }
            catch (Exception e)
            {
                string exception = e.ToString();
                string dbExceptionPrName = "Email";
                InsertLogToDb.Exception(dbExceptionPrName, environment);
                ExceptionLogToFile.Instance.WriteExceptionLog(exception);
            }
        }
    }
}