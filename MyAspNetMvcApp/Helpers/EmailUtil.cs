// C# SMTP Configuration for Outlook.Com SMTP Host
// https://www.codeproject.com/Articles/700211/Csharp-SMTP-Configuration-for-Outlook-Com-SMTP-Hos
// Allowing less secure apps to access your account in Gmail
// https://support.google.com/accounts/answer/6010255

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Gabs.Helpers
{
    public class EmailUtil
    {
        private const string ACCOUNT_EMAIL = "hewbertgabon@gmail.com";
        private const string ACCOUNT_PASSWORD = "mypassword";
        private const string SMTP_HOST = "smtp.gmail.com"; // smtp-mail.outlook.com, smtp.mail.yahoo.com
        private const int SMTP_PORT = 587;
        private const bool IS_HTML = true;

        public bool SendEmail(string mailTo, string subject, string body, string attachmentFile = "", EmailAttachment attachment = null, string mailCc = "", string mailBc = "", string mailReplyTo = "")
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = SMTP_HOST;
            smtp.Port = SMTP_PORT;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(ACCOUNT_EMAIL, ACCOUNT_PASSWORD);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ACCOUNT_EMAIL);
            mail.To.Add(mailTo);
            if (!String.IsNullOrEmpty(mailCc)) mail.CC.Add(mailCc);
            if (!String.IsNullOrEmpty(mailBc)) mail.Bcc.Add(mailBc);
            if (!String.IsNullOrEmpty(mailReplyTo)) mail.ReplyToList.Add(mailReplyTo);
            mail.Subject = subject;
            mail.IsBodyHtml = IS_HTML;
            mail.Body = body;

            if (attachment != null && string.IsNullOrEmpty(attachmentFile))
            {
                MemoryStream attachmentStream = new MemoryStream(attachment.Data);
                mail.Attachments.Add(new Attachment(attachmentStream, attachment.FileName, attachment.ContentType));
                attachmentStream.Dispose();
            }
            if (!string.IsNullOrEmpty(attachmentFile) && attachment == null)
            {
                mail.Attachments.Add(new Attachment(attachmentFile));
            }

            smtp.Send(mail);
            return true;
        }

        public class EmailAttachment
        {
            public byte[] Data { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
        }
    }
}