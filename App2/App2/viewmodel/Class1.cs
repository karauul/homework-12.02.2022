using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App2.viewmodel
{
    public class Photo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }

    }
    public partial class Class1 : INotifyPropertyChanged

    {
        const string url = "https://jsonplaceholder.typicode.com/albums";
        HttpClient client = new HttpClient();
        private ObservableCollection<Photo> _photo;

        public ObservableCollection<Photo> Photo { get => _photo; set { _photo = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task Output()
        {
            var content = await client.GetStringAsync(url);
            var photos = JsonConvert.DeserializeObject<List<Photo>>(content);
             Photo= new ObservableCollection<Photo>(photos);
        }
        public ICommand LoadData => new Command(async value =>
        {
            await Output();
        });
    }
}
