using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Forms.Navigation.MasterDetail
{
    //Diesen Model-Klasse wird vom MasterDetailPage-Template automatisch generiert
    public class MDPMasterMenuItem
    {
        public MDPMasterMenuItem()
        {
            TargetType = typeof(MDPMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}