using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIApp.Model;
using UIApp.Services;
using Xamarin.Forms;

namespace UIApp.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
    	//This a properties that we are going to bind to the Searchview Page. 
    	// Search property for the inserted text, the Isrunning property for loading, and the Search Results for the observable
    	//to be bound to the itemsource of the collection vie
        private string search;
        public string Search
        {
            get { return search; }
            set { search = value; OnPropertyChanged(); }
        }
        private bool _IsRunning;
        public bool IsRunning
        {
            get { return _IsRunning; }
            set { _IsRunning = value; OnPropertyChanged(); }
        }

        private List<Search> _searchResults;
        public List<Search> SearchResults
        {
            get { return _searchResults; }
            set { _searchResults = value; OnPropertyChanged(); }
        }


        public Command SearchCommand { get; set; }
        public SearchViewModel()
        {
            SearchCommand = new Command(async () => await SearchAsync());
            IsRunning = false;
        }

        private async Task SearchAsync()
        {
            IsRunning = true;
            MovieService ms = new MovieService();
            var res = await ms.SearchMovieAsync(Search);
            if (res != null)
            {
                IsRunning = false;
                SearchResults = res;
            }
            else
            {
                IsRunning = false;
             await Application.Current.MainPage.DisplayAlert("No Results", $"Sorry, We are unable to find the movie ' {Search}'", "Try Again");
            }

        }
    }
}
