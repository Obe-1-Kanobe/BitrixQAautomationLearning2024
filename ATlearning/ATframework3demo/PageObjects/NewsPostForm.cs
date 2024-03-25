using atFrameWork2.BaseFramework;
using System;
using System.Drawing;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
        // TODO: extract to base framework utils
        private static string generateLocalImageFile()
        {
            // Create a blank image with a specified width and height
            int width = 500;
            int height = 300;
            Bitmap image = new Bitmap(width, height);

            // Create a graphics object from the image
            Graphics graphics = Graphics.FromImage(image);

            // Draw a red rectangle on the image
            Pen pen = new Pen(Color.Red);
            Rectangle rectangle = new Rectangle(50, 50, 200, 100);
            graphics.DrawRectangle(pen, rectangle);

            // Save the image to a file
            string filePath = "image.jpg";
            image.Save(filePath);

            // Dispose of the graphics object and image
            graphics.Dispose();
            image.Dispose();

            return filePath;
        }

        public bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            bool isRecipientPresent = Waiters.WaitForCondition(() => recipientsArea.AssertTextContains(recipientName, default), 2, 6,
                $"Ожидание появления строки '{recipientName}' в '{recipientsArea.Description}'");
            return isRecipientPresent;
        }

        public NewsPostForm AttachLocalImageFile()
        {
            var fileButton = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='mpf-file-blogPostForm']", "Кнопка Файл");
            fileButton.Click();

            var imagePath = generateLocalImageFile();
            var fullPath = Path.GetFullPath(imagePath);

            var bitrixMagicFileInput = new BitrixMagicFileInput();
            bitrixMagicFileInput.UploadFile(fullPath);

            return this;
        }

        public void Send()
        {
            var sendButton = new atFrameWork2.SeleniumFramework.WebItem("//*[@id='blog-submit-button-save']", "Кнопка Отправить");
            sendButton.Click();
        }
    }
}
