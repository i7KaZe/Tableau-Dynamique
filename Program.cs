namespace TableauDynamique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double note = 0.0;
            TableauDynamique tabNotes = new TableauDynamique();

            int option = 1;

            while (note >= 0.0)
            {
                Console.Clear();
                Console.WriteLine("Entrer les notes de votre groupe, note négative pour arrêter");

                double.TryParse(Console.ReadLine(), out note);

                if (note >= 0.0)
                {
                    tabNotes.ajouterNombre(note);
                }
            }


            while (option > 0 && option < 5)
            {
                Console.Clear();
                Console.Write("Choisir une option 1-4\n 1. Moyenne\n 2. Mediane\n 3. Ecart type\n 4. Quitter");
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Moyenne : {0}", tabNotes.calculerMoyenne());
                        break;
                    case 2:
                        Console.WriteLine("Mediane : {0}", tabNotes.calculerMediane());
                        break;
                    case 3:
                        Console.WriteLine("Ecart type {0}", tabNotes.calculerEcartType());
                        break;
                    case 4:
                        Console.WriteLine("Fin");
                        break;
                    default:
                        Console.WriteLine("Option invalide");
                        option = 1;
                        break;
                }
                Console.WriteLine("Appuyer sur une touche pour continuer");
                Console.ReadKey();
            }
        }
    }
}