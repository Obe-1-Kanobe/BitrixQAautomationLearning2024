using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Attach_File : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("Создание поста с прикреплённым файлом", homePage => CreatePostAndAttachFile(homePage)));
            return caseCollection;
        }

        void CreatePostAndAttachFile(PortalHomePage homePage)
        {
            // Шаги:

            // Добавить пост
            // Загрузить фаил
            // Опубликовать пост (нажать на "Отправить")
            // Пост опубликован с прикрепленным фаилом

            // ID фаил для дальнеишего сравнения
            const int fileId = 42;

            // Открыть новостуную страницу
            var newsPage = homePage.LeftMenu
                .OpenNews();

            // Открыть "Создать пост" и прикрепить фаил с изображением
            var postWithImage = newsPage
                    .AddPost()
                    .AttachLocalImageFile();

            //Опубликовать пост
            postWithImage.Send();

            // TODO: добавить правильный waiter по событию, а не по времени
            Waiters.StaticWait_s(2);

            // Проверить последний созданный пост и згрузился ли в него фаил
            if (!newsPage.LastPostHasDiskAttachment())
            {
                Log.Error("Вновь созданный пост не содержит прикреплённый файл");
            }
        }
    }
}
