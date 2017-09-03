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
        private const string ACCOUNT_EMAIL = "yuberto.gabon@gmail.com";
        private const string ACCOUNT_PASSWORD = "my_password";
        private const string SMTP_HOST = "smtp.gmail.com"; // smtp-mail.outlook.com, smtp.mail.yahoo.com
        private const int SMTP_PORT = 587;
        private const bool REQUIRE_SSL = true;
        private const bool IS_HTML = true;

        public static bool SendEmail(IEnumerable<string> mailTos, string subject, string body, EmailAttachment attachment = null, string attachmentFile = "", string mailCc = "", string mailBc = "", string mailReplyTo = "")
        {
            SmtpClient smtp = new SmtpClient()
            {
                Host = SMTP_HOST,
                Port = SMTP_PORT,
                EnableSsl = REQUIRE_SSL,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(ACCOUNT_EMAIL, ACCOUNT_PASSWORD)
            };

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ACCOUNT_EMAIL);
            foreach(var mailTo in mailTos)
            {
                mail.To.Add(mailTo);
            }
            if (!String.IsNullOrEmpty(mailCc)) mail.CC.Add(mailCc);
            if (!String.IsNullOrEmpty(mailBc)) mail.Bcc.Add(mailBc);
            if (!String.IsNullOrEmpty(mailReplyTo)) mail.ReplyToList.Add(mailReplyTo);
            mail.Subject = subject;
            mail.IsBodyHtml = IS_HTML;
            mail.Body = body;

            try
            {
                if (attachment != null && string.IsNullOrEmpty(attachmentFile))
                {
                    using (var attachmentStream = new MemoryStream(attachment.Data))
                    {
                        mail.Attachments.Add(new Attachment(attachmentStream, attachment.FileName, attachment.ContentType));
                        smtp.Send(mail);
                    }
                    return true;
                }
                else if (!string.IsNullOrEmpty(attachmentFile) && attachment == null)
                {
                    mail.Attachments.Add(new Attachment(attachmentFile));
                }

                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendEmail(string mailTo, string subject, string body, EmailAttachment attachment = null, string attachmentFile = "", string mailCc = "", string mailBc = "", string mailReplyTo = "")
        {
            return SendEmail(new List<string> { mailTo }, subject, body, attachment, attachmentFile, mailCc, mailBc, mailReplyTo);
        }

        public static EmailAttachment FileToAttachment(System.Web.HttpPostedFileBase File)
        {
            if (File != null)
            {
                var attachment = new EmailAttachment
                {
                    Data = new byte[File.ContentLength],
                    FileName = File.FileName,
                    ContentType = File.ContentType
                };
                File.InputStream.Read(attachment.Data, 0, File.ContentLength);

                return attachment;
            }

            return null;
        }

        public class EmailAttachment
        {
            public byte[] Data { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
        }
    }
}