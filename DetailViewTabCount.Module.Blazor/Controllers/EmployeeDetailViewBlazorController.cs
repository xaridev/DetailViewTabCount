using DetailViewTabCount.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;

namespace DetailViewTabCount.Module.Blazor.Controllers
{
   
        public static class DetailViewControllerHelper
        {
            public static string ClearItemCountInTabCaption(string caption)
            {
                int index = caption.IndexOf('(');
                if (index != -1)
                {
                    return caption.Remove(index - 1);
                }
                return caption;
            }

            public static string AddItemCountToTabCaption(string caption, int count)
            {
                return $"{caption} ({count})";
            }
        }
    

    public class EmployeeDetailViewBlazorController : ObjectViewController<DetailView, Employee>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.DelayedItemsInitialization = false;
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            RefreshTabCaptions();
        }
        private void RefreshTabCaptions()
        {
            foreach (var item in View.GetItems<ListPropertyEditor>())
            {
                item.Caption = DetailViewControllerHelper.ClearItemCountInTabCaption(item.Caption);
                int count = item.ListView.CollectionSource.GetCount();
                if (count > 0)
                {
                    item.Caption = DetailViewControllerHelper.AddItemCountToTabCaption(item.Caption, count);
                }
            }
        }
    }

}
