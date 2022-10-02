using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class NumberSequenceGateway : Gateway
    {
       
        public string GetNumberSequence(string module)
        {
            NumberSequence numberSequence = new NumberSequence();
            string result = string.Empty;
            try
            {
                
                int counter = 0;
                
                Query = string.Format("SELECT * FROM NumberSequence where Module = '{0}' ", module);
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    numberSequence = new NumberSequence()
                    {
                        NumberSequenceId = Convert.ToInt32(Reader["NumberSequenceId"]),
                        LastNumber = Convert.ToInt32(Reader["LastNumber"]),
                        Module = Convert.ToString(Reader["Module"]),
                        NumberSequenceName = Convert.ToString(Reader["NumberSequenceName"]),
                        Prefix = Convert.ToString(Reader["Prefix"])
                    };
                 }

                Connection.Close();
                Reader.Close();


                if (numberSequence.Module == null)
                {
                    counter += 1;
                    numberSequence = new Models.NumberSequence();
                    numberSequence.Module = module;
                    numberSequence.LastNumber = counter;
                    numberSequence.NumberSequenceName = module;
                    numberSequence.Prefix = module;


                    Query = string.Format("INSERT INTO NumberSequence(LastNumber, Module, NumberSequenceName, Prefix) VALUES({0}, '{1}', '{2}', '{3}') ", counter, module, module, module);
                    Command = new MySqlCommand(Query, Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
                else
                {
                    counter = numberSequence.LastNumber + 1;

                    //Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;

                    Query = string.Format("UPDATE NumberSequence SET LastNumber = {0} WHERE Module = '{1}'  ", counter, module);
                    Command = new MySqlCommand(Query, Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }

                // result = counter.ToString().PadLeft(5, '0') + "#" + numberSequence.Prefix;
                result = numberSequence.Prefix + DateTime.Now.ToString("MMyy") + counter.ToString().PadLeft(4, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
            return result;
        }
    }
}