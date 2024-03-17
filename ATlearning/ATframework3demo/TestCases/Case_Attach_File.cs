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
            // Добавить текст поста("Test")
            // Загрузить фаил
            // Фаил загружен
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
                    .AddText("Test")
                    .AddLocalImageFile(fileId);

            // Проверить что загружаемый фаил прикрепился
            if (!postWithImage.IsFileAttached(fileId))
            {
                Log.Error("Attached file is not displayed in the post creation form");
            }

            // Опубликовать пост
            postWithImage.Send();

            // Проверить последний созданный пост и згрузился ли в него фаил
            bool isPostWithAttachedFile = newsPage
                .GetLastPost()
                .HasImage(fileId);

            if (!isPostWithAttachedFile)
            {
                Log.Error("Newly created post does not have attached image");
            }
        }
    }
}
