#region Namespaces

using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HideInternalOriginEverywhere.UI;

#endregion

namespace HideInternalOriginEverywhere
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //This is the new internal origin category
            //var bic = BuiltInCategory.OST_IOS_GeoSite;
            ElementId internalOriginCategoryId = new ElementId(-2000111);
            Category category = Category.GetCategory(doc, internalOriginCategoryId);

            //Collect all views. View templates are views, so yeah.
            List<View> viewsWithInternalOrigin = new FilteredElementCollector(doc).OfClass(typeof(View)).Cast<View>().Where(v => v.CanCategoryBeHidden(internalOriginCategoryId)).ToList();
            int viewCount = viewsWithInternalOrigin.Count;

            //build a progress form for funsies
            //build and activate our progress window to tell the end user what is happening
            DefaultProgressForm progressForm = new DefaultProgressForm("Updating....", "Hiding internal origin in view {0} of " + viewCount, "Soopa Doopa Internal Origin Hide-ifier", viewCount);
            progressForm.Activate();

            Transaction hideInternalOrigin = new Transaction(doc,"Hiding internal origin everywhere.");
            hideInternalOrigin.Start();
            foreach (View view in viewsWithInternalOrigin)
            {
                if (view.ViewTemplateId.IntegerValue == -1)
                {
                    category.set_Visible(view,false);
                }
                progressForm.Increment();
            }
            //convert the progress form to a results form
            progressForm.ShowResults();
            hideInternalOrigin.Commit();

            return Result.Succeeded;
        }
    }
}
