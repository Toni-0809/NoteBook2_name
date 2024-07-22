using NoteBook2.App.Core;
using NoteBook2.Core;
using NoteBook2.Core.Service;
using NoteBook2_name.NoteBook2.Core.Core;
using NoteBook2_name.NoteBook2.Core.Entity;
using NoteBook2_name.NoteBook2.Core.Service;
using System.Collections.ObjectModel;

namespace NoteBook2.App
{
    public class MainViewModel : ObservableObject
    {

        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        private ObservableCollection<Note> _NoteList2 = new ObservableCollection<Note>();
        public ObservableCollection<Note> NoteList2 { get => _NoteList2; set { _NoteList2 = value; OnPropertyChanged("NoteList2"); } }

        private NoteService2 NoteService2;

        private Note _selectedNote;
        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public MainViewModel(NoteService2 service)
        {
            NoteService2 = service;
            NoteList2 = new ObservableCollection<Note>(NoteService2.GetAll());
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      NoteService2.Create(
                          new Note(Input)
                          );
                      NoteList2 = new ObservableCollection<Note>(NoteService2.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      NoteService2.Delete(
                          SelectedNote2.ItemId
                          );
                      NoteList2 = new ObservableCollection<Note>(NoteService2.GetAll());
                  }));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      SelectedNote2.Title = Input;
                      NoteService2.Update(
                          SelectedNote2
                          );
                      NoteList2 = new ObservableCollection<Note>(NoteService2.GetAll());
                  }));
            }
        }


    }
}