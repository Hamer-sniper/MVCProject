using System.Xml.Linq;

namespace MVCProject.Models
{
    public class DataBookContextOld
    {
        /// <summary>
        /// Данные.
        /// </summary>
        public static List<DataBook> MyData { get; set; } = new List<DataBook>();

        static DataBookContextOld()
        {
            GenerateDB();
        }

        /// <summary>
        /// Создать тестовую базу данных.
        /// </summary>
        /// <returns>Список с данными</returns>
        public static void GenerateDB()
        {
            for (int i = 1; i <= 100; i++)
                MyData.Add(new DataBook());
        }

        /// <summary>
        /// Получить базу данных.
        /// </summary>
        /// <returns>Список с данными</returns>
        public static List<DataBook> GetMyDB()
        {
            return MyData;
        }

        /// <summary>
        /// Получить запись по Id.
        /// </summary>
        /// <returns>DataBook</returns>
        /*public static DataBook GetByID(int id)
        {
            return MyData.FindAll(d => d.Id == id).FirstOrDefault();
        }*/
    }
}
