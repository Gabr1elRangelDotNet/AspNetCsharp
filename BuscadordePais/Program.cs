using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()

    {
        //Fazendo conexão BD//
        var strConexao = "Server=localhost; Port=3306; Database=world; Uid=root; Pwd=@Gsr33412142;";
        var conexao = new MySqlConnection(strConexao);
        //abrindo BD//
        conexao.Open();
        //Comando BD//
        string sqlQuery = "SELECT * FROM city";
        //Fazendo a chamada para o BD//
        MySqlCommand command = new MySqlCommand(sqlQuery, conexao);
        Console.WriteLine("BEM VINDO\nDigite o Pais desejado:    Ex: 'BRA', 'DEU', 'USA'");
        //Entrada de dados//
        string ?Ccode = Console.ReadLine();
        //Executando BD//
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            //fazendo leitura do BD//
            while (reader.Read())
            {
                //Passando dados//
                string country = reader.GetString("CountryCode");
                string district = reader.GetString("District");

                //filtrando o processamento dos dados aqui//

                if(country == Ccode){
                    //Saida de dados//
                    Console.WriteLine($"PAÍS: {country} ESTADO: {district}");
                    Console.WriteLine("=================================================================");
                }
            }
        }
        
        conexao.Close();
        
    }
}

