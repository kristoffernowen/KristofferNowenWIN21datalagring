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
            using (var sqlContext = new SqlContext())
            {
                sqlContext.Database.EnsureCreated();

                var statusUnprocessed = sqlContext.StatusOfCases.FirstOrDefault(x => x.Id == StatusOfCase.StatusUnprocessed);
                if (statusUnprocessed == null)
                {
                    sqlContext.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusUnprocessed, StatusOfCase1 = nameof(StatusOfCase.StatusUnprocessed) });
                }

                var statusBeingProcessed = sqlContext.StatusOfCases.FirstOrDefault(x => x.Id == StatusOfCase.StatusBeingProcessed);
                if (statusBeingProcessed == null)
                {
                    sqlContext.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusBeingProcessed, StatusOfCase1 = nameof(StatusOfCase.StatusBeingProcessed) });
                }

                var statusClosed = sqlContext.StatusOfCases.FirstOrDefault(x => x.Id == StatusOfCase.StatusClosed);
                if (statusClosed == null)
                {
                    sqlContext.StatusOfCases.Add(new StatusOfCase { Id = StatusOfCase.StatusClosed, StatusOfCase1 = nameof(StatusOfCase.StatusClosed) });
                }

                sqlContext.SaveChanges();
            }

            base.OnStartup(e);

        }
    }
}
