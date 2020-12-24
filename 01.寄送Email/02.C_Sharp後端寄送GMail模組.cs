using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace piggy.Models
{
    public class CGmail
    {
        public bool SendGmail(string email, string verify)
        {
            bool is成功 = false;
            string mymail = "帳號@gmail.com";
            string mypw = "密碼";
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                // ================== 設定收件人 ==================
                // 收信者信箱(可多人)
                msg.To.Add(email);
                //msg.CC.Add("c@c.com"); 可抄送副本

                // ================== 設定郵件內容 ==================
                // 發信人
                msg.From = new MailAddress(mymail, "最強小豬手", System.Text.Encoding.UTF8);
                // 郵件標題
                msg.Subject = "幫幫小ㄓㄨ手 註冊驗證碼";
                // 郵件標題編碼
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                // 郵件內容
                msg.Body = @"<h1>您好！您的驗證碼為<span style='color:red;'>" + verify + "</span></h1><h3>注意認證碼有效時間為<span style='color:red;'>10分鐘！</span>，逾期請重新點選頁面寄送認證碼</h3>";
                // 郵件內容編碼
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                // 附件
                //msg.Attachments.Add(new Attachment(@"D:\test2.docx"));
                // 是否是HTML郵件
                msg.IsBodyHtml = true;
                // 郵件優先級
                //msg.Priority = MailPriority.High;

                // ================== 身分驗證 ==================
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(mymail, mypw);
                // 設定smtp Server
                client.Host = "smtp.gmail.com";
                // 設定Port
                client.Port = 25;
                // gmail預設開啟驗證
                client.EnableSsl = true;
                // 寄出信件
                client.Send(msg);
                // 釋放資源
                client.Dispose();
                msg.Dispose();

                is成功 = true;
            }
            catch (Exception ex)
            {
            
            }
            return is成功;
        }
    }
}