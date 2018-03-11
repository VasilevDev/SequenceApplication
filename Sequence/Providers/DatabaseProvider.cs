using System.Data.SqlClient;

namespace Sequence.Providers
{
    /// <summary>
    /// Класс для хранения индекса последовательности в базе данных
    /// </summary>
    public class DatabaseProvider : IProvider
    {
        private string _connectionString;
        private int _sequenceId;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">Строка подключения к бд</param>
        /// <param name="sequenceId">Идентификатор последовательности</param>
        public DatabaseProvider(string connectionString, int sequenceId)
        {
            _connectionString = connectionString;
            _sequenceId = sequenceId;
        }

        /// <summary>
        /// Свойство для работы с индексом значения последовательности
        /// get - запрос индекса из бд
        /// set - сохранение индекса в бд
        /// </summary>
        public int Index
        {
            get
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT \"Current\" FROM \"Table\" WHERE Id=@Id", connection);
                    command.Parameters.AddWithValue("@Id", _sequenceId);

                    connection.Open();
                    var value = (int)command.ExecuteScalar();

                    return value;
                }
            }
            set
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE \"Table\" SET \"Current\"=@Current WHERE Id=@Id", connection);
                    command.Parameters.AddWithValue("@Current", value);
                    command.Parameters.AddWithValue("@Id", _sequenceId);

                    connection.Open();
                    command.ExecuteScalar();
                }
            }
        }
    }
}
