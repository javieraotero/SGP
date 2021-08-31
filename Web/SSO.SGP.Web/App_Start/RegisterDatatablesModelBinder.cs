using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

[assembly: PreApplicationStartMethod(typeof(Syncrosoft.Test.RegisterDatatablesModelBinder), "Start")]

namespace Syncrosoft.Test
{
    public static class RegisterDatatablesModelBinder
    {
        public static void Start()
        {
            ModelBinders.Binders.Add(typeof(Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables.DataTablesParam), new Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables.DataTablesModelBinder());
        }
    }
}
