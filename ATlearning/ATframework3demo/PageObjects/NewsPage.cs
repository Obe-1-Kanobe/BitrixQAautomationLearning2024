namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        public NewsPostForm AddPost()
        {
            //Клик в Написать сообщение
            var btnPostCreate = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click();
            return new NewsPostForm();
        }

        public bool LastPostHasDiskAttachment()
        {
            // TODO: как убедиться, что последним сообщением будет тот, что мы создали? 
            // TODO: найти лучший подход для прикрепления 
            // TODO: разбить метод на несколько шагов для создания объекта сообщения 
            // TODO: правильный xpath для поиска элемента
            return atFrameWork2.SeleniumFramework.WebDriverActions.IsValidXPath("//*[@id='log_internal_container']/div[3]/div[1]/div/div[1]/div[contains(@id, 'disk-attach-block')]");
        }
    }
}
