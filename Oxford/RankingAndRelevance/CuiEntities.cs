using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RankingAndRelevance
{
    public class CuiEntities
    {
        public Entity[] entities { get; set; }

        /// <summary>
        /// { 'entities': [ {'Vitrectomy': 'C0042903'},{'Scleral Buckling': 'C0036411'}]
        /// </summary>
        // Deserialize a JSON stream to a User object.  
        public static CuiEntities ReadToObject(string json)
        {
            CuiEntities cuiEntities = new CuiEntities();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(cuiEntities.GetType());
            cuiEntities = ser.ReadObject(ms) as CuiEntities;
            ms.Close();
            return cuiEntities;
        }
    }

    public class Entity
    {
        public string surface_form { get; set; }
        public string cui { get; set; }
    }
}