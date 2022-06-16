using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Animaux
{
    public class Animal : Crud<Animal>
    {
        private int idAnimal;
        public int IdAnimal
        {
            get
            {
                return idAnimal;
            }
            set
            {
                idAnimal = value;
            }
        }
        private string nomAnimal;
        public string NomAnimal
        {
            get
            {
                return nomAnimal;
            }
            set
            {
                nomAnimal = value;
            }
        }
        private double poidsAnimal;
        public double PoidsAnimal
        {
            get
            {
                return poidsAnimal;
            }
            set
            {
                poidsAnimal = value;
            }
        }
        private int tailleAnimal;
        public int TailleAnimal
        {
            get
            {
                return tailleAnimal;
            }
            set
            {
                tailleAnimal = value;
            }
        }
        private int typeAnimal;
        public int TypeAnimal
        {
            get
            {
                return typeAnimal;
            }
            set
            {
                typeAnimal = value;
            }
        }

        public List<Animal> FindAll()
        {
            List<Animal> listeAnimaux = new List<Animal>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from [iut-acy\\reydetb].Animal;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Animal unAnimal = new Animal();
                            unAnimal.IdAnimal = (int)reader.GetDecimal(0);
                            unAnimal.TypeAnimal = (int)reader.GetDecimal(1);
                            unAnimal.NomAnimal = reader.GetString(2);
                            unAnimal.TailleAnimal = reader.GetInt32(3);
                            unAnimal.PoidsAnimal = (double)reader.GetDecimal(4);
                            
                            listeAnimaux.Add(unAnimal);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message Animal");
            }
            return listeAnimaux;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            int id = this.IdAnimal;
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    bool writer = access.setData($"UPDATE [iut-acy\\reydetb].Animal SET IDTYPE = {this.TypeAnimal}, NOMANIMAL  = {this.NomAnimal}, TAILLEANIMAL = {this.TailleAnimal}, POIDSANIMAL = {this.PoidsAnimal}  WHERE idAnimal = {id}");
                    if (! writer)
                    {
                        string message = "Impossible d'ajouter des donn�es";
                        string title = "Erreur d'ajout";
                        var result = System.Windows.MessageBox.Show(message, title, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        string message = "Donn�es modifi�e !";
                        string title = "Erreur d'ajout";
                        var result = System.Windows.MessageBox.Show(message, title, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Exclamation);
                    }
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message Animal");
            }

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Animal> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
        
        public static int CompareById(Animal value1, Animal value2)
        {
            return value1.IdAnimal.CompareTo(value2.IdAnimal);
        }
    }
}