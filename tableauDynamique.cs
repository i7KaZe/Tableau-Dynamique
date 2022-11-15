namespace TableauDynamique
{
    public class TableauDynamique
    {
        double[] tab;
        int cnt;
        public TableauDynamique()
        {
            this.tab = new double[10];
            this.cnt = 0;
        }

        public void ajouterNombre(double nombre)
        {
            if (this.cnt < this.tab.Length)
            {
                this.tab[this.cnt] = nombre;
                this.cnt++;
            }
            else
            {
                // Nouveau tableau de 1.5 fois la longueur
                double[] nouvTab = new double[this.tab.Length + this.tab.Length / 2];
                // Copier les données du tableau actuel dans le nouveau tableau
                for (int i = 0; i < this.tab.Length; i++)
                {
                    nouvTab[i] = this.tab[i];
                }
                // Remplacer le tableau actuel par le nouveau tableau
                this.tab = nouvTab;

                this.tab[this.cnt] = nombre;
                this.cnt++;
            }
        }

        public double calculerTotal()
        {
            double total = 0.0;

            for (int i = 0; i < this.cnt; i++)
            {
                total += this.tab[i];
            }

            return total;
        }

        public double calculerMoyenne()
        {
            return this.calculerTotal() / this.cnt;
        }

        public double calculerMediane()
        {
            double mediane = 0;

            this.trierAsc();

            int position = this.cnt / 2;

            if (this.cnt % 2 == 0)
            {


                mediane = (this.tab[position] + this.tab[position - 1]) / 2;
            }
            else
            {
                mediane = this.tab[position];
            }

            return mediane;
        }

        public double calculerEcartType()
        {
            double moyenne = this.calculerMoyenne();
            double sommeCarreEcart = 0.0;
            double ecartType = 0.0;

            for (int i = 0; i < this.cnt; i++)
            {
                sommeCarreEcart += Math.Pow(this.tab[i] - moyenne, 2);
            }
            sommeCarreEcart /= this.cnt - 1;

            ecartType = Math.Sqrt(sommeCarreEcart);

            return ecartType;
        }

        public void trierAsc()
        {
            // Classer mon tableau du plus petit au plus grand
            // pour chaque case du tableau
            for (int i = 0; i < this.cnt; i++)
            {
                // trouver l'index(la position) de la note minimum du tableau restant
                int positionMin = trouverMin(i);
                // échange la note à la position minimum avec la note à la position actuelle
                double temp = this.tab[positionMin];
                this.tab[positionMin] = this.tab[i];
                this.tab[i] = temp;
            }
        }

        public int trouverMin(int depart)
        {
            int positionMin = depart;

            for (int i = depart; i < this.cnt; i++)
            {
                if (this.tab[i] < this.tab[positionMin])
                {
                    positionMin = i;
                }
            }

            return positionMin;
        }
    }
}
