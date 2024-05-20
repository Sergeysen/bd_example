using bd_lab4.entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_lab4.classes
{
    public static class UseBd
    {
        public static List<Enterprise> GetAllEnterprises()
        {
            List<Enterprise> enterprises = new List<Enterprise>();
            SqlConnection connection = null;
            try
            {
                connection = Bd_Class.ConnectSql();

                string sql = "SELECT * FROM Предприятие";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Enterprise enterprise = new Enterprise();
                            enterprise.RegistrationNumber = Convert.ToInt32(reader["Регистрационный_номер_предприятия"]);
                            enterprise.Name = reader["Наименование"].ToString();
                            enterprise.Address = reader["Адрес"].ToString();
                            enterprise.Phone = reader["Телефон"].ToString();
                            enterprise.Fax = reader["Факс"].ToString();
                            enterprise.Industry = reader["Название_отрасли"].ToString();
                            enterprise.FormOfOwnership = reader["Название_формы_собственности"].ToString();
                            enterprises.Add(enterprise);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return enterprises;
        }


        public static int AddNewEnterprise(string name, string address, string phone, string fax, string industry, string formOfOwnership, int regNumber)
        {
            int rowsAffected = 0;
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            try
            {
                connection = Bd_Class.ConnectSql();
                transaction = connection.BeginTransaction();

                // Проверяем уникальность регистрационного номера
                string checkRegNumberSql = "SELECT COUNT(*) FROM Предприятие WHERE Регистрационный_номер_предприятия = @Регистрационный_номер_предприятия";
                using (SqlCommand checkRegNumberCommand = new SqlCommand(checkRegNumberSql, connection, transaction))
                {
                    checkRegNumberCommand.Parameters.AddWithValue("@Регистрационный_номер_предприятия", regNumber);
                    int existingRegNumberCount = (int)checkRegNumberCommand.ExecuteScalar();

                    if (existingRegNumberCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким регистрационным номером уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было добавлено
                    }
                }

                // Проверяем уникальность комбинации адреса и наименования предприятия
                string checkAddressNameSql = "SELECT COUNT(*) FROM Предприятие WHERE Адрес = @Адрес AND Наименование = @Наименование";
                using (SqlCommand checkAddressNameCommand = new SqlCommand(checkAddressNameSql, connection, transaction))
                {
                    checkAddressNameCommand.Parameters.AddWithValue("@Адрес", address);
                    checkAddressNameCommand.Parameters.AddWithValue("@Наименование", name);
                    int existingAddressNameCount = (int)checkAddressNameCommand.ExecuteScalar();

                    if (existingAddressNameCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким адресом и наименованием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было добавлено
                    }
                }

                // Проверяем уникальность номера телефона
                string checkPhoneSql = "SELECT COUNT(*) FROM Предприятие WHERE Телефон = @Телефон";
                using (SqlCommand checkPhoneCommand = new SqlCommand(checkPhoneSql, connection, transaction))
                {
                    checkPhoneCommand.Parameters.AddWithValue("@Телефон", phone);
                    int existingPhoneCount = (int)checkPhoneCommand.ExecuteScalar();

                    if (existingPhoneCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким номером телефона уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было добавлено
                    }
                }

                // Проверяем уникальность номера факса
                string checkFaxSql = "SELECT COUNT(*) FROM Предприятие WHERE Факс = @Факс";
                using (SqlCommand checkFaxCommand = new SqlCommand(checkFaxSql, connection, transaction))
                {
                    checkFaxCommand.Parameters.AddWithValue("@Факс", fax);
                    int existingFaxCount = (int)checkFaxCommand.ExecuteScalar();

                    if (existingFaxCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким номером факса уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было добавлено
                    }
                }

                // Если все проверки пройдены успешно, выполняем вставку новой записи
                string sql = "INSERT INTO Предприятие (Регистрационный_номер_предприятия, Наименование, Адрес, Телефон, Факс, Название_отрасли, Название_формы_собственности) VALUES (@Регистрационный_номер_предприятия, @Наименование, @Адрес, @Телефон, @Факс, @Название_отрасли, @Название_формы_собственности)";
                using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Регистрационный_номер_предприятия", regNumber);
                    command.Parameters.AddWithValue("@Наименование", name);
                    command.Parameters.AddWithValue("@Адрес", address);
                    command.Parameters.AddWithValue("@Телефон", phone);
                    command.Parameters.AddWithValue("@Факс", fax);
                    command.Parameters.AddWithValue("@Название_отрасли", industry);
                    command.Parameters.AddWithValue("@Название_формы_собственности", formOfOwnership);

                    rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Новое предприятие успешно добавлено!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                transaction.Commit(); // Фиксируем транзакцию, если все операции выполнены успешно
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при добавлении нового предприятия: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transaction?.Rollback(); // Откатываем транзакцию в случае ошибки
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return rowsAffected;
        }


        public static List<string> GetAllIndustryTypes()
        {
            List<string> industryTypes = new List<string>();
            SqlConnection connection = null;
            try
            {
                connection = Bd_Class.ConnectSql();

                string sql = "SELECT Название_отрасли FROM Тип_отрасли";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string industryType = reader["Название_отрасли"].ToString();
                            industryTypes.Add(industryType);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return industryTypes;
        }

        public static List<string> GetAlFormsOfOwnership()
        {
            List<string> formsOfOwnership = new List<string>();
            SqlConnection connection = null;
            try
            {
                connection = Bd_Class.ConnectSql();

                string sql = "SELECT Название_формы_собственности FROM Форма_собственности";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string industryType = reader["Название_формы_собственности"].ToString();
                            formsOfOwnership.Add(industryType);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return formsOfOwnership;
        }
        public static int DeleteEnterprise(int registrationNumber)
        {
            int rowsAffected = 0;
            SqlConnection connection = null;
            try
            {
                connection = Bd_Class.ConnectSql();

                string sql = "DELETE FROM Предприятие WHERE Регистрационный_номер_предприятия = @Регистрационный_номер_предприятия";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Регистрационный_номер_предприятия", registrationNumber);

                    // Выполняем SQL команду для удаления
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Предприятие успешно удалено!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Предприятие с указанным регистрационным номером не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при удалении предприятия!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return rowsAffected;
        }

       

        public static int UpdateEnterprise(int registrationNumber, string name, string address, string phone, string fax, string industry, string formOfOwnership)
        {
            int rowsAffected = 0;
            SqlConnection connection = null;
            try
            {
                connection = Bd_Class.ConnectSql();

                // Проверка уникальности адреса и наименования
                string checkNameAddressSql = "SELECT COUNT(*) FROM Предприятие WHERE Наименование = @Наименование AND Адрес = @Адрес AND Регистрационный_номер_предприятия != @Регистрационный_номер_предприятия";
                using (SqlCommand checkNameAddressCommand = new SqlCommand(checkNameAddressSql, connection))
                {
                    checkNameAddressCommand.Parameters.AddWithValue("@Наименование", name);
                    checkNameAddressCommand.Parameters.AddWithValue("@Адрес", address);
                    checkNameAddressCommand.Parameters.AddWithValue("@Регистрационный_номер_предприятия", registrationNumber);

                    int nameAddressCount = (int)checkNameAddressCommand.ExecuteScalar();
                    if (nameAddressCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким наименованием и адресом уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было обновлено
                    }
                }

                // Проверка уникальности телефона
                string checkPhoneSql = "SELECT COUNT(*) FROM Предприятие WHERE Телефон = @Телефон AND Регистрационный_номер_предприятия != @Регистрационный_номер_предприятия";
                using (SqlCommand checkPhoneCommand = new SqlCommand(checkPhoneSql, connection))
                {
                    checkPhoneCommand.Parameters.AddWithValue("@Телефон", phone);
                    checkPhoneCommand.Parameters.AddWithValue("@Регистрационный_номер_предприятия", registrationNumber);

                    int phoneCount = (int)checkPhoneCommand.ExecuteScalar();
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким телефоном уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было обновлено
                    }
                }

                // Проверка уникальности факса
                string checkFaxSql = "SELECT COUNT(*) FROM Предприятие WHERE Факс = @Факс AND Регистрационный_номер_предприятия != @Регистрационный_номер_предприятия";
                using (SqlCommand checkFaxCommand = new SqlCommand(checkFaxSql, connection))
                {
                    checkFaxCommand.Parameters.AddWithValue("@Факс", fax);
                    checkFaxCommand.Parameters.AddWithValue("@Регистрационный_номер_предприятия", registrationNumber);

                    int faxCount = (int)checkFaxCommand.ExecuteScalar();
                    if (faxCount > 0)
                    {
                        MessageBox.Show("Предприятие с таким факсом уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return rowsAffected; // Возвращаем 0, так как ничего не было обновлено
                    }
                }

                // Если проверка уникальности пройдена, выполняем обновление информации о предприятии
                string sql = "UPDATE Предприятие SET Наименование = @Наименование, Адрес = @Адрес, Телефон = @Телефон, Факс = @Факс, Название_отрасли = @Название_отрасли, Название_формы_собственности = @Название_формы_собственности WHERE Регистрационный_номер_предприятия = @Регистрационный_номер_предприятия";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Регистрационный_номер_предприятия", registrationNumber);
                    command.Parameters.AddWithValue("@Наименование", name);
                    command.Parameters.AddWithValue("@Адрес", address);
                    command.Parameters.AddWithValue("@Телефон", phone);
                    command.Parameters.AddWithValue("@Факс", fax);
                    command.Parameters.AddWithValue("@Название_отрасли", industry);
                    command.Parameters.AddWithValue("@Название_формы_собственности", formOfOwnership);

                    rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Информация о предприятии успешно обновлена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при обновлении информации о предприятии!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Bd_Class.DisconnectSql(connection);
            }

            return rowsAffected;
        }



    }

}
