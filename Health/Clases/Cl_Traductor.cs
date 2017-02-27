using System.Resources;

namespace Health.Clases
{
    public class Cl_Traductor
    {
        public string BuscaString(string pIdioma, string Codigo)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.Load("QHealth.resources");
            ResourceManager rm;
            rm = new ResourceManager("QHealth.es-GT", a);
            switch (pIdioma.Trim())
            {
                case "es-GT":
                    rm = new ResourceManager("QHealth.es-GT", a);
                    break;
                case "en-US":
                    rm = new ResourceManager("QHealth.en-US", a);
                    break;
            }
            return rm.GetString(Codigo);
        }
    }
}
