using System.Linq;
using System.Windows;
using Customer_Case_System.Data;
using Customer_Case_System.Models;

namespace Customer_Case_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var context = new SqlContext())
            {
                context.Database.EnsureCreated();

                var statusUnprocessed = context.StatusOfCases.FirstOrDefault(b => b.Id == StatusOfCase.StatusUnprocessed);
                if (statusUnprocessed == null)
                {
                    context.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusUnprocessed, StatusOfCase1 = nameof(StatusOfCase.StatusUnprocessed) });
                }

                var statusBeingProcessed = context.StatusOfCases.FirstOrDefault(b => b.Id == StatusOfCase.StatusBeingProcessed);
                if (statusBeingProcessed == null)
                {
                    context.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusBeingProcessed, StatusOfCase1 = nameof(StatusOfCase.StatusBeingProcessed) });
                }

                var statusClosed = context.StatusOfCases.FirstOrDefault(b => b.Id == StatusOfCase.StatusClosed);
                if (statusClosed == null)
                {
                    context.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusClosed, StatusOfCase1 = nameof(StatusOfCase.StatusClosed) });
                }


                context.SaveChanges();
            }

            base.OnStartup(e);

        }
    }
}
