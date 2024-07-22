using NoteBook2_name.NoteBook2.Core.Entity;
using NoteBook2_name.NoteBook2.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook2_name.NoteBook2.Core.Data
{ 

    /// <summary>
    /// Класс для доступа к данным о фильмах
    /// </summary>
    public class NoteDataSource2
    {
        /// <summary>
        /// Относительный путь к файлу, где хранятся данные
        /// </summary>
        private readonly string path = ".\\Note_data.json";

        /// <summary>
        /// Метод чтения данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public List<Note> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Note>>(data) ?? [];
                    Note._id_counter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public void Write(List<Note> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }
    }
}