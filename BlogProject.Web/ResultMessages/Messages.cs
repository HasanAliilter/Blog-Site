using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlogProject.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir";
            }

        }
        public static class Category{
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir.";
            }
        }
    }
}
